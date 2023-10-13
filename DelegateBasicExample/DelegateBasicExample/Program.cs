




namespace DelegateBasicExample
{
    class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            var log = new Log();
            LogDel logTextToFile, logTextToScreen;
            
            logTextToFile = new LogDel(log.LogTextToFile);
            logTextToScreen = new LogDel(log.LogTextToScreen);

            LogDel multiLogDel = logTextToScreen + logTextToFile;
            Console.Write("Please enter your name");

            var name = Console.ReadLine();

            LogText(multiLogDel, name);

            Console.ReadKey();
        }
        
        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
    }

    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now} {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt")))
            {
                streamWriter.WriteLine($"{DateTime.Now}: {text}");
            }
        }


    }
}
