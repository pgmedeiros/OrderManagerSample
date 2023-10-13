using QuickFix;
using teste;
public class Program
{

    static void Main()
    {

        QuickFixApp quickFixApp = new QuickFixApp();
        SessionSettings settings = new SessionSettings("C:/estudo/OrderManagerSample/config.txt");

        IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
        ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
        QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(quickFixApp, storeFactory, settings, logFactory);
        
        Run(initiator, quickFixApp);

        initiator.Stop();
    }

    static void Run(AbstractInitiator initiator, QuickFixApp app)
    {
       initiator.Start();
       Thread.Sleep(2 * 1000);
       app.Run();
    }
}