namespace OrderApi.Models
{
    public class Waiting
    {
        public char Result { get; set; } = '@';

        public static char getConstantWithoutChange()
        {
            return '@';
        }

        public static char getValueNew()
        {
            return '0';
        }
    }
}
