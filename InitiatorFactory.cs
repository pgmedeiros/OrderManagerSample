using QuickFix;
using QuickFix.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste;

namespace Teste
{
    internal class InitiatorFactory
    {

        public static SocketInitiator Build(QuickFixApp app)
        {
            SessionSettings settings = new SessionSettings("C:/estudo/OrderManagerSample/config.txt");

            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
            QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(app, storeFactory, settings, logFactory);

            return initiator;
        }

    }
}
