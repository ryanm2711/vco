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
    class Gangs : Script
    {
        List<Blip> gangHideoutBlips = new List<Blip>();

        bool blipsCreated;

        XmlReader xmlReader = XmlReader.Create("./scripts/vco/gangBlips.xml");

        public Gangs()
        {
            Tick += OnTick;
            Aborted += OnAbort;
        }

        void OnAbort(object sender, EventArgs e)
        {
            foreach (Blip b in gangHideoutBlips)
            {
                b.Delete();
            }
        }


        void OnTick(object sender, EventArgs e)
        {
            if (VCOFunctions.IsVCOLoaded())
            {
                if (!blipsCreated)
                {
                    while (xmlReader.Read())
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

                            VCOFunctions.UI.CreateBlip(new Vector3(x, y, z), name, spriteID, shortRange, colourID, gangHideoutBlips); // This is our custom function for creating blips, I recommend you use this for cleaner code :
                        }
                    }

                    blipsCreated = !blipsCreated;
                }
            }

        }
    }
}
