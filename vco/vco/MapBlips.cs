using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Xml.Linq;

namespace vco
{
    class MapBlips : Script
    {
        List<Blip> vcoMapBlips = new List<Blip>(); // We are creating a list so we can keep track of the blips on the player's map

        XDocument doc = XDocument.Load("./scripts/vco/mapBlips.xml");

        bool hasCreatedBlips;
        bool hasRemovedBlips;

        public MapBlips()
        {
            Tick += OnTick;

            // Checking to see if blip has already been created when script starts 
            /*var getAllBlips = World.GetAllBlips();

            foreach (Tuple<Vector3, string, int, bool, int> tuple in BlipsDefs)
            {
                foreach (Blip vcoBlip in World.GetAllBlips())
                {
                    
                }
            }*/
        }

        static readonly Tuple<Vector3, string, int, bool, int>[] BlipsDefs = new Tuple<Vector3, string, int, bool, int>[]
        {
            Tuple.Create<Vector3, string, int, bool, int>(new Vector3(-3021.0f, -2565.0f, 0.0f), "Malibu Club", 614, true, 0), // Malibu Club
        };

        void OnTick(object sender, EventArgs e)
        {
            if (UsefulFunctions.IsVCOLoaded())
            {
                if (!hasCreatedBlips)
                {
                    foreach (Tuple<Vector3, string, int, bool, int> tuple in BlipsDefs) // Loops through our tuple and gets information to use in our custom create blip function
                    {
                        UsefulFunctions.CreateBlip(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, vcoMapBlips); // This is our custom function for creating blips, I recommend you use this for cleaner code :)
                    }
                    
                    hasCreatedBlips = !hasCreatedBlips; // Reverses a boolean so it's = opposite
                    hasRemovedBlips = !hasRemovedBlips;
                }
            }
            else
            {
                if (!hasRemovedBlips)
                {
                    foreach (Blip b in vcoMapBlips) // Loops through the list of blips, b is the result of each blip
                    {
                        Function.Call(Hash.REMOVE_BLIP, b); // This removes every blip in list
                    }
                    vcoMapBlips.Clear(); // Clears our list so it's empty again

                    hasRemovedBlips = !hasRemovedBlips; // Reverses a boolean so it's = opposite
                    hasCreatedBlips = !hasCreatedBlips;
                }
            }
        }
    }
}
