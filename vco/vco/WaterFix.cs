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
    class WaterFix : Script
    {
        float modifiedWaterHeight = 0.0f; // What should we set the wave scale to when VCO is loaded? 0.0 = an attempt for it to be flat pretty much. 
        float modifiedWaterRadius = 200.0f;
        //Vector3 vcoArea1 = new Vector3(-2461f, -4912f, 1.0f); // These vectors is a squared area/box of the VCO map
        //Vector3 vcoArea2 = new Vector3(-5651f, -141, 1.0f); // These vectors is a squared area/box of the VCO map

        public WaterFix()
        {
            Tick += OnTick;
        }

        void OnTick(object sender, EventArgs e)
        {
            if (UsefulFunctions.IsVCOLoaded())
            {
                Function.Call(Hash.SET_DEEP_OCEAN_SCALER, modifiedWaterHeight); // Sets the wave scale to whatever the waveScale value is, only if VCO is loaded.
                Function.Call(Hash.MODIFY_WATER, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, modifiedWaterRadius, modifiedWaterHeight);
                Function.Call((Hash)0x547237AA71AB44DE, 0f); // This hash has not been named and I am not entirely sure on what it does. I believe it calms the waves a little (idk :P)
            }
            else
            {
                Function.Call(Hash.RESET_DEEP_OCEAN_SCALER); // If VCO is not loaded then we will make sure the wave scale is reset/default values. This is usually 1.0f
            }
        }
    }
}
