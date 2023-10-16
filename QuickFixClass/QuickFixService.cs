using QuickFix;
using QuickFix.Transport;
using QuickFix.FIX44;
using OrderApi.Models;
using QuickFix.Fields;

namespace OrderApi.QuickFixClass
{
    public class QuickFixService
    {
        private readonly string ERROR_MESSAGE = "A quantidade deve ser maior que zero.";
        private readonly int ZERO = 0;
        QuickFixApp app;
        SocketInitiator initiator;
        public string InitiateProcessToSendOrder(Order order)
        {

            app = AppFactory.GetInstance();
            initiator = InitiatorFactory.GetInstance(app);
            


            return LoginAndSendOrder(initiator, app, order);
        }
     
        private string LoginAndSendOrder(AbstractInitiator initiator, QuickFixApp app, Order order)
        {

            if (isInvalid(order))
            {
                return ERROR_MESSAGE;
            }

            if (!initiator.IsLoggedOn)
            {
                initiator.Start();

                Thread.Sleep(2 * 1000);
            } 

            if (initiator.IsLoggedOn)

            {
                return SendOrder(order, app);
            }
            else

            {
                return "Não foi possível realizar o login.";
            }
        }


        private static string SendOrder(Order order, QuickFixApp app)
        {

            bool f = Session.SendToTarget(OrderToNewOrderSingle(order), app.getSessionId());


            if (!f)
            {
                return "Erro ao enviar ordem.";
            }
            else
            {
                return "Ordem enviada com sucesso.";
            }

        }
        public static NewOrderSingle OrderToNewOrderSingle(Order order)
        {
            
            var newOrderSingle = new NewOrderSingle(
                new ClOrdID("1234"),
                new Symbol(order.symbol),
                new Side(defineSide(order)),
                new TransactTime(DateTime.Now),
                new OrdType(OrdType.MARKET));


            newOrderSingle.Set(new OrderQty(order.qty));
            newOrderSingle.Set(new Price(order.price));

            return newOrderSingle;
        }

        private static char defineSide(Order order)
        {
            if (order.side == null || order.side == "COMPRA")
            {
                return Side.BUY;
            }

            return Side.SELL;
        }

        private  bool isInvalid(Order order)
        {
            return (order.qty <= ZERO);
        }

    }   
}