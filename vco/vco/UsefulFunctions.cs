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
        static string[] vcoIPLS = File.ReadAllLines("scripts\\vco/vco_ipls.txt");
        public UsefulFunctions()
        {

        }

        public static bool IsVCOLoaded()
        {
            foreach (string ipl in vcoIPLS)
            {
                if (Function.Call<bool>(Hash.IS_IPL_ACTIVE, ipl))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
