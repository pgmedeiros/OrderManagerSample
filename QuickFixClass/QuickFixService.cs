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
        private readonly string BUY_CODE = "COMPRA";
        private readonly string INTITUTE_EXAMPLE_COD = "ABCD";
        
        QuickFixApp app;
        SocketInitiator initiator;
        public string InitiateProcessToSendOrder(Order order)
        {
            var waiting = new Waiting();
            app = AppFactory.GetInstance();
            initiator = InitiatorFactory.GetInstance(app);

            app.setWaiting(waiting);


            return LoginAndSendOrder(initiator, app, order, waiting);
        }
     
        private string LoginAndSendOrder(AbstractInitiator initiator, QuickFixApp app, Order order, Waiting waiting)
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
                return SendOrder(order, app, waiting);

            }

            return "Não foi possível fazer login";

        }


        private string SendOrder(Order order, QuickFixApp app, Waiting waiting)
        {

            bool orderAchieveTarget = Session.SendToTarget(OrderToNewOrderSingle(order), app.getSessionId());


            if (!orderAchieveTarget)
            {
               Console.WriteLine("Erro ao enviar ordem.");
                return "Erro";
            }
            else
            {
                Console.WriteLine("Ordem enviada com sucesso.");
                
                while (waiting.Result == '@') ;

                if (waiting.Result == '0')
                {
                    return "Ok";
                } else
                {
                    return "Erro";
                }
            }

        }
        public NewOrderSingle OrderToNewOrderSingle(Order order)
        {
            
            var newOrderSingle = new NewOrderSingle(
                new ClOrdID(INTITUTE_EXAMPLE_COD),
                new Symbol(order.symbol),
                new Side(defineSide(order)),
                new TransactTime(DateTime.Now),
                new OrdType(OrdType.MARKET));


            newOrderSingle.Set(new OrderQty(order.qty));
            newOrderSingle.Set(new Price(order.price));

            return newOrderSingle;
        }

        private char defineSide(Order order)
        {
            if (order.side == null || order.side == BUY_CODE)
            {
                return Side.BUY;
            }

            return Side.SELL;
        }

        private bool isInvalid(Order order)
        {
            return (order.qty <= ZERO);
        }

    }   
}