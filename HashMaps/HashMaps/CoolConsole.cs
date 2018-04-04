using System;
namespace HashMaps
{
    public static class CoolConsole
    {
        public static void Write(string text){
			Array values = Enum.GetValues(typeof(ConsoleColor));
			Random random = new Random();
			foreach (char c in text)
			{
				Console.BackgroundColor = (ConsoleColor)values.GetValue(random.Next(values.Length));
				Console.ForegroundColor = (ConsoleColor)values.GetValue(random.Next(values.Length));
				Console.Write(c);
			}
        }

        public static void WriteLine(string text){
            Write(text + "\n"); 
        }

    }
}
