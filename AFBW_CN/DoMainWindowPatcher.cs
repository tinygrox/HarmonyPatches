using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using KSPAdvancedFlyByWire;

namespace AFBW_CN
{
    [HarmonyPatch]
    public class DoMainWindowPatcher
    {
        [HarmonyTargetMethod]
        static MethodBase TargetMethod()
        {
            return AccessTools.TypeByName(nameof(AdvancedFlyByWire)).GetMethod("DoMainWindow", AccessTools.all, Type.DefaultBinder, new Type[]{typeof(int)}, null);
        }

        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> ILPatcher(IEnumerable<CodeInstruction> codeInstructions)
        {
            codeInstructions = Utility.TranslateIL(codeInstructions, "Mod settings", "Mod设置");
            codeInstructions = Utility.TranslateIL(codeInstructions, "Controllers", "控制器");
            codeInstructions = Utility.TranslateIL(codeInstructions, "Presets", "预设管理");
            codeInstructions = Utility.TranslateIL(codeInstructions, "Configuration", "配置");
            codeInstructions = Utility.TranslateIL(codeInstructions, "Preset: ", "预设：");
            return codeInstructions;
        }
    }
}