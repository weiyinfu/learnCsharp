using System;
using System.Diagnostics;

class TestStackTrace
{
    public static void TestStackTrace2()
    {
        StackTrace st = new StackTrace(new StackFrame());
        Console.WriteLine(" Stack trace for current level: {0}", st.ToString());
        for (int i = 0; i < st.FrameCount; i++)
        {
            Console.WriteLine($"frame {i}");
            StackFrame sf = st.GetFrame(i);
            Console.WriteLine("File: {0}", sf.GetFileName());
            Console.WriteLine("Method: {0}", sf.GetMethod().Name);
            Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
            Console.WriteLine("Column Number: {0}", sf.GetFileColumnNumber());
        }
    }
}