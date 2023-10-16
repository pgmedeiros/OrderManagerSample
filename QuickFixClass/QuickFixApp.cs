using OrderApi.Models;
using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX44;

namespace OrderApi.QuickFixClass
{
    internal class QuickFixApp : IApplication
    {

        private SessionID MySessionID = null;
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
    }


}
