using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace XScienceTrans
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class PatcherInit: MonoBehaviour
    {
        public void Awake()
        {
            var harmony = new Harmony("tinygrox.XScience.CHS");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}