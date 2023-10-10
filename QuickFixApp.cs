using QuickFix;
using QuickFix.Fields;

namespace teste
{
    internal class QuickFixApp : IApplication
    {

        private SessionID MySessionID = null;
        public void ToAdmin(Message message, SessionID sessionID)
        {
            
        }

        public void FromAdmin(Message message, SessionID sessionID)
        {
        }

        public void ToApp(Message message, SessionID sessionID)
        {
            
        }

        public void FromApp(Message message, SessionID sessionID)
        {
        }

        public void OnCreate(SessionID sessionID)
        {
            MySessionID = sessionID;
        }

        public SessionID getSessionId()
        {
            return this.MySessionID;
        }

        public void OnLogout(SessionID sessionID)
        {
        }

        public void OnLogon(SessionID sessionID)
        {
            Console.WriteLine("session id" + sessionID.ToString);
        }

        public void createOrder()
        {
            var order = new QuickFix.FIX44.NewOrderSingle(
            new ClOrdID("1234"),
            new Symbol("AAPL"),
            new Side(Side.BUY),
            new TransactTime(DateTime.Now),
            new OrdType(OrdType.MARKET));

            Session.SendToTarget(order, MySessionID);
        }

    }
}
