using QuickFix;
using QuickFix.Fields;

namespace teste
{
    internal class QuickFixApp : IApplication
    {

        private SessionID MySessionID = null;
        public bool isLogged { get; private set; } = false;
        public void ToAdmin(Message message, SessionID sessionID)
        {
        }

        public void FromAdmin(Message message, SessionID sessionID)
        {
            Console.WriteLine("From Admin");
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
            isLogged = true;
            Console.WriteLine("Login realizado");
        }

        public void createOrder()
        {
            var order = new QuickFix.FIX44.NewOrderSingle(
            new ClOrdID("1234"),
            new Symbol("AAPL"),
            new Side(Side.BUY),
            new TransactTime(DateTime.Now),
            new OrdType(OrdType.MARKET));

            order.Set(new HandlInst('1'));
            order.Set(new OrderQty(10));
            order.Set(new TimeInForce('1'));
            order.Set(new Price(20));
            order.Set(new StopPx(12));
            order.Set(new TimeInForce('1'));

            bool f = Session.SendToTarget(order, MySessionID);


            if (!(f))
            {
                Console.WriteLine("Erro ao enviar ordem");
            } else
            {
                Console.WriteLine("TUDO CERTO ao enviar ordem");
            }

        }


        public void Run()
        {
            bool shouldRun = true;

            while (shouldRun)
            {
                Console.WriteLine("----------------- TRADER CLIENT --------------------");
                Console.WriteLine("1. Realizar ordem\n 2.Sair");

                string? entrada = Console.ReadLine();

                if (entrada == "1") 
                {
                    createOrder();
                } else if(entrada == "2")
                {
                    break;
                } else
                {
                    Console.WriteLine("Escolha uma opção válida");
                }

            }
        }
    }

       
}
