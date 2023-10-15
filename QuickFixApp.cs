using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX44;

namespace teste
{
    internal class QuickFixApp : IApplication
    {

        private SessionID MySessionID = null;
        public bool isLogged { get; private set; } = false;
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
            return this.MySessionID;
        }

        public void OnLogout(SessionID sessionID)
        {
            isLogged = false;
            Console.WriteLine("Logout realizado.");
        }

        public void OnLogon(SessionID sessionID)
        {
            isLogged = true;
            Console.WriteLine("Login realizado.");
        }

        public NewOrderSingle orderExample()
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

            return order;
        }

        public void createOrder(NewOrderSingle order)
        {
            bool f = Session.SendToTarget(order, MySessionID);


            if (!(f))
            {
                Console.WriteLine("Erro ao enviar ordem.");
            } else
            {
                Console.WriteLine("Ordem enviada com sucesso.");
            }

        }


        public void Run()
        {
            bool shouldRun = true;

            while (shouldRun)
            {
                Console.WriteLine("----------------- TRADER CLIENT --------------------");
                Console.WriteLine("1.Realizar ordem\n2.Sair");

                string? input = Console.ReadLine();

                if (input == "1") 
                {
                    createOrder(orderExample());
                
                } else if(input == "2")
                {
                    shouldRun = false;
                } else
                {
                    Console.WriteLine("Escolha uma opção válida");
                }

            }
        }
    }

       
}
