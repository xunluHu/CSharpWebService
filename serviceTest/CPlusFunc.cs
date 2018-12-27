using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

using System.Text;

using System.Threading.Tasks;

namespace serviceTest
{
    public class CPlusFunc
    {
        [DllImport("testx64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int add(int a, int b);
    }
}