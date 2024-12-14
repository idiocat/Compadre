using System.Diagnostics;

namespace Compadre;
class Program
{
    static void Main()
    {
        string text = File.ReadAllText(@"E:\test\Text1.txt");
        char[] separators = {' ', '\r', '\n'};
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        
        List<string> list = new List<string>();
        ShowTime(FillList(ref list, words), typeof(List<string>));

        LinkedList<string> linkedList = new LinkedList<string>();
        ShowTime(FillList(ref linkedList, words), typeof(LinkedList<string>));
    }

    static double FillList(ref List<string> list, string[] words)
    {
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < words.Length; ++i) { list.Insert(0, words[i]); }
        return sw.Elapsed.TotalMilliseconds;
    }
    static double FillList(ref LinkedList<string> list, string[] words)
    {
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < words.Length; ++i) { list.AddFirst(words[i]); }
        return sw.Elapsed.TotalMilliseconds;
    }
    static void ShowTime(double time, Type type)
    {
        Console.WriteLine($"Time for {type}: {time}");
        Console.WriteLine();
        Console.ReadKey();
    }
}