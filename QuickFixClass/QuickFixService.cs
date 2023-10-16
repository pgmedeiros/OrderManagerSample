using QuickFix;
using QuickFix.Transport;
using QuickFix.FIX44;
using OrderApi.Models;
using QuickFix.Fields;

namespace OrderApi.QuickFixClass
{
    public class QuickFixService
    {

        SocketInitiator initiator = null;
        private static string TryToSend(Order order, QuickFixApp app)
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

        public string SendOrder(Order order)
        {

            QuickFixApp quickFixApp = new QuickFixApp();

            initiator = InitiatorFactory.Build(quickFixApp);

            return LoginAndSendOrder(initiator, quickFixApp, order);
        }

        public void Logout()
        {
            initiator.Stop();
        }

        static string LoginAndSendOrder(AbstractInitiator initiator, QuickFixApp app, Order order)
        {

            if (!initiator.IsLoggedOn)
            {
                initiator.Start();

                Thread.Sleep(2 * 1000);
            } 

            if (app.isLogged)

            {
                return TryToSend(order, app);
            }
            else

            {
                return "Não foi possível realizar o login.";
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
            if (order.side == null || order.side == "1")
            {
                return Side.BUY;
            }

            return Side.SELL;
        }

    }   
}