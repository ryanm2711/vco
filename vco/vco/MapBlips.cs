using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Xml;

namespace vco
{
    class MapBlips : Script
    {
        List<Blip> vcoMapBlips = new List<Blip>(); // We are creating a list so we can keep track of the blips on the player's map

        XmlReader xmlReader = XmlReader.Create("./scripts/vco/mapBlips.xml");

        bool hasCreatedBlips;
        bool hasRemovedBlips;

        public MapBlips()
        {
            Tick += OnTick;
            Aborted += OnAbort;
        }

        void OnAbort(object sender, EventArgs e)
        {
            foreach (Blip b in vcoMapBlips)
            {
                Function.Call(Hash.REMOVE_BLIP, b);
            }
        }

        void OnTick(object sender, EventArgs e)
        {
            if (VCOFunctions.IsVCOLoaded())
            {
                if (!hasCreatedBlips)
                {
                    while (xmlReader.Read()) // Reading loop (I honestly don't really know what this does, pretty sure it loops through the elements)
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Blip")
                        {
                            string name;
                            float x, y, z;
                            int spriteID;
                            int colourID;
                            bool shortRange;

                            // Read the name from the XML file
                            xmlReader.ReadToDescendant("Name");
                            xmlReader.Read();
                            name = xmlReader.Value;

                            // Read the position from the XML file
                            xmlReader.ReadToFollowing("X");
                            xmlReader.Read();
                            float.TryParse(xmlReader.Value, out x);

                            xmlReader.ReadToFollowing("Y");
                            xmlReader.Read();
                            float.TryParse(xmlReader.Value, out y);

                            xmlReader.ReadToFollowing("Z");
                            xmlReader.Read();
                            float.TryParse(xmlReader.Value, out z);

                            // Read the sprite id from the XML file
                            xmlReader.ReadToFollowing("SpriteID");
                            xmlReader.Read();
                            Int32.TryParse(xmlReader.Value, out spriteID);

                            // Read the colour id from the XML file
                            xmlReader.ReadToFollowing("ColourID");
                            xmlReader.Read();
                            Int32.TryParse(xmlReader.Value, out colourID);

                            // Read the short range value from the XML file
                            xmlReader.ReadToFollowing("ShortRange");
                            xmlReader.Read();
                            bool.TryParse(xmlReader.Value, out shortRange);

                            VCOFunctions.UI.CreateBlip(new Vector3(x, y, z), name, spriteID, shortRange, colourID, vcoMapBlips); // This is our custom function for creating blips, I recommend you use this for cleaner code :
                        }
                    }

                    xmlReader.Close();
                    
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
                        b.Delete(); // This removes every blip in list
                    }
                    vcoMapBlips.Clear(); // Clears our list so it's empty again

                    hasRemovedBlips = !hasRemovedBlips; // Reverses a boolean so it's = opposite
                    hasCreatedBlips = !hasCreatedBlips;
                }
            }
        }
    }
}
