using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Native;
using GTA.Math;

namespace vco
{
    class Gangs : Script
    {
        List<Blip> gangHideoutBlips = new List<Blip>();

        bool blipsCreated;

        public Gangs()
        {
            Tick += OnTick;
        }

        static readonly Tuple<Vector3, string, int, bool, int>[] GangHideoutDefs = new Tuple<Vector3, string, int, bool, int>[]
        {
            Tuple.Create<Vector3, string, int, bool, int>(new Vector3(-5000f, -2565.0f, 125.0f), "Gang Hideout", 438, true, 0), // Gang hideout #1
            Tuple.Create<Vector3, string, int, bool, int>(new Vector3(-5000f, -5500, 1.0f), "Gang Hideout", 438, true, 0), // Gang hideout #2
            Tuple.Create<Vector3, string, int, bool, int>(new Vector3(-5000f, -4500, 5.0f), "Gang Hideout", 438, true, 0), // Gang hideout #3
        };


        void OnTick(object sender, EventArgs e)
        {
            if (VCOFunctions.IsVCOLoaded())
            {
                if (!blipsCreated)
                {
                    foreach (Tuple<Vector3, string, int, bool, int> tuple in GangHideoutDefs)
                    {
                        VCOFunctions.UI.CreateBlip(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, gangHideoutBlips);
                    }

                    blipsCreated = !blipsCreated;
                }
            }

        }
    }
}
