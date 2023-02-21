using System;
using System.Diagnostics;
using System.IO;

class UseFile
{
    public static void TestUseFile()
    {
        string[] sons = Directory.GetFileSystemEntries(".");
        foreach (var i in sons)
        {
            Console.WriteLine($"{i}");
        }

        Console.WriteLine(
            $"current directory:{Directory.GetCurrentDirectory()} absolute path:{Path.GetFullPath(Directory.GetCurrentDirectory())}");
        StackTrace st = new StackTrace(new StackFrame(true));
        var s = File.OpenText("../../../README.md");
        var content = s.ReadToEnd();
        Console.WriteLine(content);
    }

    public static void CurrentDirectory()
    {
        Console.WriteLine($@"
{Environment.CurrentDirectory}
{Directory.GetCurrentDirectory()}
");
    }
}