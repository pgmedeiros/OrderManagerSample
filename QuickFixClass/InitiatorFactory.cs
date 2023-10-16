using QuickFix;
using QuickFix.Transport;

namespace OrderApi.QuickFixClass
{
    internal class InitiatorFactory
    {
        private InitiatorFactory() { }

        private static SocketInitiator instance;
        public static SocketInitiator GetInstance(QuickFixApp app)
        {

            if (instance == null)
            {
                SessionSettings settings = new SessionSettings("C:/estudo/OrderManagerSample/Configs/quickFixConfig.txt");

                IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
                ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
                instance = new QuickFix.Transport.SocketInitiator(app, storeFactory, settings, logFactory);
            }

            return instance;
            
        }

    }
}
