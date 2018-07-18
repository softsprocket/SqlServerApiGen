using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompilerTests
{
    class Program
    {
        static void Main(string[] args)
        {
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.OutputAssembly = "AutoGen.dll";
            parameters.ReferencedAssemblies.Add("System.Data.Linq");

            CompilerResults r = CodeDomProvider.CreateProvider("CSharp").CompileAssemblyFromSource(parameters, "public class B {public static int k=7;}");

            //verify generation
            Console.WriteLine(Assembly.LoadFrom("AutoGen.dll").GetType("B").GetField("k").GetValue(null));

            if (Debugger.IsAttached)
            {
                Console.ReadKey();
            }
        }
    }
}
