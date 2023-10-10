using QuickFix;
using QuickFix.Fields;
using teste;
public class Program
{

    static void Main()
    {

        QuickFixApp quickFixApp = new QuickFixApp();
        SessionSettings settings = new SessionSettings("C:/estudo/teste/config.txt");

        IMessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
        ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
        QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(quickFixApp, storeFactory, settings, logFactory);

        // this is a developer-test kludge.  do not emulate.

        initiator.Start();

        quickFixApp.createOrder();

        initiator.Stop();
          
    }
}