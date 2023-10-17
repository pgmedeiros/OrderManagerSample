using OrderApi.Models;
using QuickFix;
using QuickFix.FIX44;

namespace OrderApi.QuickFixClass
{
    internal class QuickFixApp : MessageCracker, IApplication
    {

        private SessionID MySessionID = null;
        private Waiting waiting = null;

        public void ToAdmin(QuickFix.Message message, SessionID sessionID)
        {
        }

        public void FromAdmin(QuickFix.Message message, SessionID sessionID)
        {
            Console.WriteLine("From Admin");
        }

        public void ToApp(QuickFix.Message message, SessionID sessionID)
        {
        }

        public void FromApp(QuickFix.Message message, SessionID sessionID)
        {
            Console.WriteLine("IN:  " + message.ToString());
            try
            {
                Crack(message, sessionID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("==Cracker exception==");
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void OnCreate(SessionID sessionID)
        {
            MySessionID = sessionID;
        }

        public SessionID getSessionId()
        {
            return MySessionID;
        }

        public void OnLogout(SessionID sessionID)
        {
            Console.WriteLine("Logout realizado.");
        }

        public void OnLogon(SessionID sessionID)
        {
            Console.WriteLine("Login realizado.");
        }

        public void setWaiting(Waiting waiting)
        {
            this.waiting = waiting;
        }

        public void OnMessage(ExecutionReport m, SessionID s)
        {
            Console.WriteLine("Received execution report");

            waiting.Result = m.OrdStatus.getValue();
        }
    }
    
}
