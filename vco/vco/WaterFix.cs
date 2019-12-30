using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Native;

namespace vco
{
    class WaterFix : Script
    {
        float waveScale = 0.0f; // What should we set the wave scale to when VCO is loaded? 0.0 = an attempt for it to be flat pretty much. 

        public WaterFix()
        {
            Tick += OnTick;
        }

        void OnTick(object sender, EventArgs e)
        {
            if (UsefulFunctions.IsVCOLoaded())
            {
                Function.Call(Hash.SET_DEEP_OCEAN_SCALER, waveScale); // Sets the wave scale to whatever the waveScale value is, only if VCO is loaded.
            }
            else
            {
                Function.Call(Hash.RESET_DEEP_OCEAN_SCALER); // If VCO is not loaded then we will make sure the wave scale is reset/default values. This is usually 1.0f
            }
        }
    }
}
