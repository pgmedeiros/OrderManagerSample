namespace OrderApi.QuickFixClass
{
    internal class AppFactory
    {

        private AppFactory() { }
        
        private static QuickFixApp instance;

        public static QuickFixApp GetInstance()
        {
            if (instance == null)
            {
                instance = new QuickFixApp();
            }

            return instance;
        }

    }
}
