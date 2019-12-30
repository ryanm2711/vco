using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Native;
using System.IO;

namespace vco
{
    public class UsefulFunctions
    {
        public UsefulFunctions()
        {
            return;
        }

        public static bool IsVCOLoaded()
        {
            if (Function.Call<bool>(Hash.IS_IPL_ACTIVE, "oceandrv_stream0"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
