using System;
using HarmonyLib;
using UnityEngine;
namespace AFBW_CN
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class PatcherInit: MonoBehaviour
    {
        private void Start()
        {
            var har = new Harmony("tinygrox.AFBW.CHS");
            har.PatchAll();
        }
    }
}