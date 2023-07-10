using FontStashSharp;
using Scrappers.Resources;

namespace Scrappers.Managers
{
    public static class FontManager
    {
        private static FontSystem _whiteRabbit;

        public static float Large
        {
            get
            {
                return 40;
            }
        }

        public static float Massive
        {
            get
            {
                return 50;
            }
        }

        public static float Medium
        {
            get
            {
                return 35;
            }
        }

        public static float Micro
        {
            get
            {
                return 25;
            }
        }

        public static float Small
        {
            get
            {
                return 30;
            }
        }

        public static FontSystem WhiteRabbit
        {
            get
            {
                if (_whiteRabbit == null)
                {
                    _whiteRabbit = new FontSystem();
                    _whiteRabbit.AddFont(ResourceGrabber.GetResource("WhiteRabbit.ttf"));
                }
                return _whiteRabbit;
            }
        }
    }
}