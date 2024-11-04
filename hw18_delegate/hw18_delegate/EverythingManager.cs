namespace Delegate
{
    internal class EverythingManager
    {
        public delegate void DisplayDelegate();
        public delegate double AreaDelegate(double dimension1, double dimension2);
        public static void DisplayCurrentTime()
        {
            Console.WriteLine("Current time: " + DateTime.Now.ToString("HH:mm:ss"));
        }

        public static void DisplayCurrentDate()
        {
            Console.WriteLine("Current date: " + DateTime.Now.ToString("yyyy-MM-dd"));
        }
        public static void DisplayCurrentDayOfWeek()
        {
            Console.WriteLine("Current day of the week: " + DateTime.Now.DayOfWeek);
        }
        public static double CalculateTriangleArea(double u_base, double height)
        {
            return 0.5 * u_base * height;
        }

        public static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}
