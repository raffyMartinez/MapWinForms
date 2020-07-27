using System;
using System.IO;
using System.Threading.Tasks;
namespace MapWinForms.classes
{

    public static class Logger
    {

        private static string _filepath = $"{AppDomain.CurrentDomain.BaseDirectory}/log.txt";


        public static void Log(string s, bool simpleLog = false)
        {
            using (StreamWriter writer = new StreamWriter(_filepath, true))
            {
                if (!simpleLog)
                {
                    writer.WriteLine($"Message: {s} Date :{DateTime.Now.ToString()}");
                }
                else
                {
                    writer.WriteLine(s);
                }
            }
        }

        public static void Log(string s, Exception ex)
        {
            using (StreamWriter writer = new StreamWriter(_filepath, true))
            {
                writer.WriteLine($"Log message:{s}\r\nError: {ex.Message}\r\n{ex.StackTrace}\r\n Date :{DateTime.Now.ToString()}");
            }
        }

        public static void Log(Exception ex)
        {
            using (StreamWriter writer = new StreamWriter(_filepath, true))
            {
                writer.WriteLine($"Error: {ex.Message}\r\n{ex.StackTrace}\r\n Date :{DateTime.Now.ToString()}");
            }
        }
    }
}
