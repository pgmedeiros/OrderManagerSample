using OrderApi.Models;
using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX44;

namespace OrderApi.QuickFixClass
{
    internal class QuickFixApp : IApplication
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

            waiting.Result = 1;
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
    }


}
