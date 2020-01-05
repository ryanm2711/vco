using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Native;
using GTA.Math;
using GTA.UI;

namespace vco
{
    class WaterFix : Script
    {
        float modifiedWaterHeight = 200f; // What should we set the wave scale to when VCO is loaded? 0.0 = an attempt for it to be flat pretty much. 
        Vector3 vcoArea1 = new Vector3(-2461f, -4912f, 1.0f); // These vectors is a squared area/box of the VCO map
        Vector3 vcoArea2 = new Vector3(-5651f, -141, 1.0f); // These vectors is a squared area/box of the VCO map

        public WaterFix()
        {
            Tick += OnTick;
        }

        void OnTick(object sender, EventArgs e)
        {
            if (VCOFunctions.IsVCOLoaded())
            {
                if (Function.Call<bool>(Hash.IS_ENTITY_IN_AREA, Game.Player, vcoArea1.X, vcoArea1.Y, vcoArea1.Z, vcoArea2.X, vcoArea2.Y, vcoArea2.Z))
                {
                    Function.Call(Hash.SET_DEEP_OCEAN_SCALER, modifiedWaterHeight);
                }
                else
                {
                    Function.Call(Hash.RESET_DEEP_OCEAN_SCALER);
                }
            }
        }
    }
}