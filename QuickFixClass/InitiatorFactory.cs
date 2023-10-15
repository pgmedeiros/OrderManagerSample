using QuickFix;
using QuickFix.Transport;

namespace OrderApi.QuickFixClass
{
    internal class InitiatorFactory
    {

        public static SocketInitiator Build(QuickFixApp app)
        {
            SessionSettings settings = new SessionSettings("C:/estudo/OrderManagerSample/Configs/quickFixConfig.txt");

            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
            QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(app, storeFactory, settings, logFactory);

            return initiator;
        }

    }
}
