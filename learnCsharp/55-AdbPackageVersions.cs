using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class AdbPackageVersions
{
    private string[] keywordList = {"bytedance", "pico", "pvr", "picovr"};

    string runShell(string file, string arguments)
    {
        var p = Process.Start(file, arguments);
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
        p.StartInfo.RedirectStandardOutput = true;
        var res = p.Start();
        p.WaitForExit();
        var content = p.StandardOutput.ReadToEnd();
        return content;
    }

    string runShell(string command)
    {
        return runShell("sh", $"-c \"{command}\"");
    }

    List<string> getPackages()
    {
        var content = runShell("adb shell pm list packages ");
        var lines = Regex.Split(content, "\n");
        List<string> packages = new List<string>();
        foreach (var line in lines)
        {
            var packgeName = line.Trim();
            if (packgeName.StartsWith("package:"))
            {
                packages.Add(packgeName.Substring("package:".Length));
            }
        }

        return packages;
    }

    bool isBytedancePackage(string packageName)
    {
        foreach (var keywords in keywordList)
        {
            if (packageName.ToLower().Contains(keywords))
            {
                return true;
            }
        }

        return false;
    }

    struct Version
    {
        public string pacakge;
        public string name;
        public string code;
    }

    Version getVersion(string package)
    {
        Version v = default;
        var result = runShell($"adb shell dumpsys package {package} |grep version");
        v.code = Regex.Match(result, "versionCode=(\\d+)").Groups[1].Value;
        v.name = Regex.Match(result, "versionName=([0-9.]+)").Groups[1].Value;
        v.pacakge = package;
        return v;
    }

    void run()
    {
        var packages = getPackages();
        packages = packages.Where(isBytedancePackage).ToList();
        List<Version> versions = new List<Version>();
        foreach (var i in packages)
        {
            var v = getVersion(i);
            versions.Add(v);
        }

        versions.Sort((x, y) => { return x.pacakge.CompareTo(y.pacakge); });
        foreach (var i in versions)
        {
            Console.WriteLine($"{i.pacakge} {i.name}");
        }
    }

    public static void testGetVersion()
    {
        var x = new AdbPackageVersions();
        var res = x.getVersion("com.pvr.picocast");
        Console.WriteLine($"版本为:");
        Console.WriteLine(res.code + " " + res.name);
    }

    public static void Run()
    {
        new AdbPackageVersions().run();
    }
}