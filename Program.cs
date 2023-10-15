using QuickFix;
using QuickFix.Transport;
using teste;
using Teste;

public class Program
{

    static void Main()
    {

        QuickFixApp quickFixApp = new QuickFixApp();

        SocketInitiator initiator = InitiatorFactory.Build(quickFixApp);
        
        StartConsoleApplication(initiator, quickFixApp);

        initiator.Stop();
    }

    static void StartConsoleApplication(AbstractInitiator initiator, QuickFixApp app)
    {
       
        initiator.Start();
       
        Thread.Sleep(2 * 1000);
      
        if (app.isLogged)
       
        {
            app.Run();
       
        } else
      
        {
            Console.WriteLine("Não foi possível realizar o login.");
            Environment.Exit(1);
        }
    }
}