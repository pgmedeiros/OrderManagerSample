using QuickFix;
using QuickFix.Transport;



namespace OrderApi.QuickFixClass
{
    public class QuickFixService
    {

        SocketInitiator initiator = null;

        public void Do()
        {

            QuickFixApp quickFixApp = new QuickFixApp();

            initiator = InitiatorFactory.Build(quickFixApp);

            StartConsoleApplication(initiator, quickFixApp);
        }

        public void Logout()
        {
            initiator.Stop();
        }

        static void StartConsoleApplication(AbstractInitiator initiator, QuickFixApp app)
        {

            if (!initiator.IsLoggedOn)
            {
                initiator.Start();

                Thread.Sleep(2 * 1000);
            } 

            if (app.isLogged)

            {
                app.Run();

            }
            else

            {
                Console.WriteLine("Não foi possível realizar o login.");
                Environment.Exit(1);
            }
        }
    }
}