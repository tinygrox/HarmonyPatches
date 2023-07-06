using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace AFBW_CN;

[HarmonyPatch]
public class ModSettingsWindowPatcher
{
    [HarmonyTargetMethod]
    static MethodBase TargetMethod()
    {
        return AccessTools.TypeByName("ModSettingsWindow").GetMethod("DoWindow", AccessTools.all, Type.DefaultBinder, new Type[]{ typeof(int)}, null);
    }
    
    [HarmonyTranspiler]
    static IEnumerable<CodeInstruction> ILPatcher1(IEnumerable<CodeInstruction> codeInstructions)
    {
        codeInstructions = Utility.TranslateIL(codeInstructions,"Use stock skin", "原版样式");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Use old presets editor", "旧版预设编辑器");
        codeInstructions = Utility.TranslateIL(codeInstructions,"PrecisionMode Factor", "精细模式控制幅度");
        codeInstructions = Utility.TranslateIL(codeInstructions,"AFBW input overrides SAS and other control inputs", "AFBW输入覆盖SAS和其他控制输入");
        codeInstructions = Utility.TranslateIL(codeInstructions,"AFBW input overrides throttle", "AFBW输入覆盖节流阀");
        codeInstructions = Utility.TranslateIL(codeInstructions,"AtmosphereAutopilot compatibility", "兼容AtmosphereAutopilot");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Run at max speed always (even when not going forward)", "始终以全速运行(即使无法移动)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Save configuration", "保存配置");
        return codeInstructions;
    }
}
