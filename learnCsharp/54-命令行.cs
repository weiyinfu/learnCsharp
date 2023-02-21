using System;
using System.Diagnostics;

class CmdLine
{
    public static void AdbList()
    {
        Process p = new Process();
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.FileName = "adb";
        p.StartInfo.Arguments = "devices -l";
        p.StartInfo.RedirectStandardOutput = true;
        var res = p.Start();
        p.WaitForExit();
        Console.WriteLine($"startResult={res}");
        var s = p.StandardOutput.ReadToEnd();
        Console.WriteLine($"{s}");
    }

    public static void Python()
    {
        Process p = new Process();
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.FileName = "python3";
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.Arguments = "-c \"import os;print(os.listdir()) \"";
        var res = p.Start();
        p.WaitForExit();
        Console.WriteLine($"Python={res}");
        var s = p.StandardOutput.ReadLine();
        Console.WriteLine($"{s} exitCode={p.ExitCode}");
    }

    public static void ProcessStart()
    {
        var p = Process.Start("adb", "devices -l");
        var res = p.Start();
        p.WaitForExit();
        Console.WriteLine($"{res}");
    }

    public static void ProcessShell()
    {
        var p = Process.Start("adb", "shell pm list packages ");
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        var res = p.Start();
        p.WaitForExit();
        Console.WriteLine(res);
    }
}