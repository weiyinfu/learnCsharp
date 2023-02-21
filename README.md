学习csharp，创建一个测试项目，每个文件都是一个单独的可执行程序

# 封装
Java是四级封装：public、protected、private、default。  
C#是五级封装。  
* public：所有对象都可以访问；
* private：对象本身在对象内部可以访问；
* protected：只有该类对象及其子类对象可以访问
* internal：同一个程序集的对象可以访问；
* protected internal：访问限于当前程序集或派生自包含类的类型。

# C#的项目布局
解决方案是最顶级的东西，一个解决方案就是要解决特定的问题。一个解决方案包含多个Project（项目）。一个解决方案下可以有ConsoleApplication，UnitTest Application等。

不同项目之间是隔离的，每个项目可以有自己的main函数，一个项目只能有一个main函数。  
如何创建有多个main函数的工程？
1. 使用单元测试即可。在解决方案下面创建一个单元测试类型的解决方案。
2. 现在C#是支持多个入口的，只需要定义多个public static void XXX()类型的函数即可。  

执行的时候的命令如下：
```plain
$HOME/.dotnet/dotnet --fx-version 6.0.1 "$HOME/Library/Application Support/JetBrains/Toolbox/apps/Rider/ch-0/221.5787.36/Rider.app/Contents/lib/ReSharperHost/JetLauncherILc.exe" /Launcher::NoSplash /Launcher::Mode:InvokeMethod /Launcher::Target:Assembly /Launcher::AssemblyFile:$HOME/Desktop/Github/learnCsharpCppJava/learnCppSharp/OculusPlatformSdk/bin/Debug/net6.0/OculusPlatformSdk.dll /Launcher::ClassName:Program /Launcher::MethodName:Haha3
```
# 如何修改解决方案下项目的名称
首先修改项目文件夹的名称，然后修改解决方案下的`<解决方案>.sln`，把里面的相关字段修改一下。

sln文件是微软推出的一种Solution文件格式。
```plain

Microsoft Visual Studio Solution File, Format Version 12.00
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "PicoPlatformSdk", "PicoPlatformSdk\PicoPlatformSdk.csproj", "{5C70678C-5529-4654-AEAA-80A9DC75FBCC}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "RtcWrapper", "RtcWrapper\RtcWrapper.csproj", "{0DC54334-654C-4A6D-80B3-279A3D53946D}"
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "SolutionFolder1", "SolutionFolder1", "{EFEDAF87-4761-4E51-94BE-83D1326B6CE0}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "MyTest", "MyTest\MyTest.csproj", "{2DDC36FD-621A-476E-9867-25545F185023}"
EndProject
```

# C# 语言相关
获取Assembly路径
```csharp
var x = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
Console.WriteLine(x);
```
# C#获取当前路径的两种方法
1. System.Environment.CurrentDirectory
   －获取和设置当前目录(该进程从中启动的目录)的完全限定目录。
2. System.IO.Directory.GetCurrentDirectory()


# Csharp中的时间转换
时间又时区的概念。C/C++中的时间表示是秒，Java、C#中的时间表示是毫秒。  
不管是秒还是毫秒，我们都在使用一个数字表示时间。当我们使用数字表示时间的时候一定默认这个数字是0时区。

```plain
最小时间：{DateTime.MinValue}
最大时间：{DateTime.MaxValue}
今天时间Now：{DateTime.Now}
今天0点时间Today：{DateTime.Today}
UnixEpoch:{DateTime.UnixEpoch}
UTCNow:{DateTime.UtcNow}
```
C#中获取当前秒数
```csharp
int getCurrentSecond()
{
    var x = (DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;
    return (int) x;
}

int getCurrentSecond2()
{
    var x = (DateTime.Now - DateTime.UnixEpoch.ToLocalTime()).TotalSeconds;
    return (int) x;
}
```
对于直接new出来的DateTime默认没有时区信息，当调用它的ToUniversalTime的时候，则它的默认时区是当前时间；当调用它的ToLocalTime的时候，它的默认时区是0时区。

当两个时间做运算的时候，它们的时区信息是不被考虑在内的。因此，必须保证做运算的两个DateTime处于同一个时区。  
关于时间的总结：
* 当使用数字表示时间的时候，可以理解为默认都是0时区的时间。
* 当对时间进行运算的时候，应该保证正在运算的数据处于同一个时区。

关于new DateTime的坑（如下代码所示）：
1. UnixEpoch一开始就是等于x的
2. 但是UnixEpoch.ToUniversalTime()结果不变，而x.ToUniversalTime()则会减去8小时。
3. x.ToLocalTime()则为结果第一次添加了时区，x.ToLocalTime().ToUniversalTime()则得到了一个0时区的UnixEpoch。

`DateTime.UnixEpoch==new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc)`

这其中一个关键的类型就是DateTimeKind，它有三个枚举值：
* 本地时间
* 未指定
* UTC时间

如果直接new DateTime，默认的kind就是未指定。
* 未指定kind toUniversalTime()调用时将当前kind视为本地时间
* 未指定kind toLocalTime()调用时将当前kind视为UTC时间

```plain
var x = new DateTime(1970, 1, 1);
Console.WriteLine(@$"
    {DateTime.UnixEpoch == x}
    {DateTime.UnixEpoch.ToLocalTime() == x.ToLocalTime()}
    {DateTime.UnixEpoch.ToUniversalTime() == x.ToUniversalTime()}
");
```

# dotnet各个版本的特点
* UnmanagedType.LPUTF8Str，Marshal.PtrToUTF8Str：4.0才有
* `$@`字符串顺序无关，6.0才有
* DateTime.UnixEpoch，6.0才有

# C#教程
微软官方教程：https://docs.microsoft.com/zh-cn/dotnet/csharp/  
菜鸟网：https://www.runoob.com/csharp/csharp-tutorial.html