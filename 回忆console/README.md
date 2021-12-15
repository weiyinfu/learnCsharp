# 在Mac环境下学习csharp
需要依赖mono环境，每个文件都是独立的。运行时只需要`run.sh x.cs`

# 模仿visual studio的编译命令行制作一个命令行工具
```sh
/Applications/Visual Studio.app/Contents/Resources/lib/monodevelop/bin/MSBuild/Current/bin/Roslyn/csc.exe /noconfig /nowarn:1701,1702,2008 /fullpaths /nostdlib+ /platform:anycpu32bitpreferred /errorreport:prompt /warn:4 /define:DEBUG /errorendlocation /preferreduilang:zh-CN /highentropyva+ /reference:/Library/Frameworks/Mono.framework/Versions/6.12.0/lib/mono/4.7.2-api/mscorlib.dll /reference:/Library/Frameworks/Mono.framework/Versions/6.12.0/lib/mono/4.7.2-api/System.Core.dll /reference:/Library/Frameworks/Mono.framework/Versions/6.12.0/lib/mono/4.7.2-api/System.dll /debug+ /debug:full /optimize- /out:"obj/Debug/回忆console.exe" /subsystemversion:6.00 /target:exe /utf8output /langversion:7.3 "快排.cs"
```
