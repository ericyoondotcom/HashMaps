using System;

namespace HashMaps
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CoolConsole.Write("Hello World!\n");
            var hashy = new HashMap<string, string>(3);
            hashy["humpty dumpty"] = "broken";
            hashy["Sadface"] = "sad";
            hashy["Waldo"] = "hidden";
            hashy["happyface"] = "happy";

            hashy["Waldo"] = "found";

            CoolConsole.WriteLine(hashy["Sadface"]);
            CoolConsole.WriteLine(hashy["Waldo"]);
            CoolConsole.WriteLine(hashy["humpty dumpty"]);
            CoolConsole.WriteLine(hashy["happyface"]);

        }
    }
}
