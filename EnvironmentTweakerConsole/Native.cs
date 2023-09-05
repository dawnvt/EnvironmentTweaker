using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentTweakerConsole;

internal class Native
{
    [DllImport("entry", EntryPoint = "hello_func")]
    internal static extern void HelloFunc();
}