using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using KSPAdvancedFlyByWire;

namespace AFBW_CN;

[HarmonyPatch]
public class DoWindowPatchers
{
    [HarmonyTranspiler, HarmonyPatch(typeof(PresetEditorWindow), nameof(PresetEditorWindow.DoWindow), typeof(int))]
    static IEnumerable<CodeInstruction> ILPatcher1(IEnumerable<CodeInstruction> codeInstructions)
    {
        codeInstructions = Utility.TranslateIL(codeInstructions,"Preset: ", "预设：");
        codeInstructions = Utility.TranslateIL(codeInstructions,"New", "新增");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Delete", "删除");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Sure?", "确定？");
        // codeInstructions = Utility.TranslateIL(codeInstructions,"Continuous actions", "连续动作");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Press desired combination", "按下想使用的组合键");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Click to assign", "单击指定");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Invert", "反向");
        // codeInstructions = Utility.TranslateIL(codeInstructions,"Discrete actions", "离散动作");
        return codeInstructions;
    }
    
    [HarmonyTranspiler, HarmonyPatch(typeof(PresetEditorWindow), nameof(PresetEditorWindow.OnGUI))]
    static IEnumerable<CodeInstruction> ILPatcher2(IEnumerable<CodeInstruction> codeInstructions)
    {
        codeInstructions = Utility.TranslateIL(codeInstructions,"Fly-By-Wire Preset Editor", "Fly-By-Wire(电传控制)预设编辑器：");
        return codeInstructions;
    }
}

[HarmonyPatch]
public class NgDoWindowPatchers
{
    [HarmonyTargetMethods]
    static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.TypeByName("PresetEditorWindowNG").GetMethod("DoChooseContinuousActionWindow", new Type[] {typeof(int)});
        yield return AccessTools.TypeByName("PresetEditorWindowNG").GetMethod("DoChooseDiscreteActionWindow", new Type[]{ typeof(int)});
        yield return AccessTools.TypeByName("PresetEditorWindowNG").GetMethod("DoPressDesiredCombinationWindow", new Type[] {typeof(int)});
        yield return AccessTools.TypeByName("PresetEditorWindowNG").GetMethod("DoWindow", new Type[] {typeof(int)});
        yield return AccessTools.TypeByName("PresetEditorWindowNG").GetMethod("OnGUI", new Type[]{ });
    }
    
    [HarmonyTranspiler]
    static IEnumerable<CodeInstruction> ILPatcher1(IEnumerable<CodeInstruction> codeInstructions)
    {
        codeInstructions = Utility.TranslateIL(codeInstructions,"Cancel", "取消");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Press desired combination", "按下想使用的组合键");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Preset: ", "预设：");
        codeInstructions = Utility.TranslateIL(codeInstructions,"New", "新建");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Clone", "克隆");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Delete", "删除");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Sure?", "确定？");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Add button", "添加按键控制");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Add axis", "添加轴控制");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Click to assign", "单击指定");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Invert", "反向");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Choose action", "选择动作");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Fly-By-Wire Preset Editor", "Fly-By-Wire(电传控制)预设编辑器：");
        return codeInstructions;
    }
}

[HarmonyPatch]
public class ControllerWindow
{
    [HarmonyTargetMethods]
    static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.TypeByName("ControllerConfigurationWindow").GetConstructor(new Type[]{typeof(ControllerConfiguration), typeof(int)});
        yield return AccessTools.TypeByName("ControllerConfigurationWindow").GetMethod("DoWindow", new Type[] {typeof(int)});
    }

    [HarmonyTranspiler]
    static IEnumerable<CodeInstruction> ILPatcher(IEnumerable<CodeInstruction> instructions)
    {
        instructions = Utility.TranslateIL(instructions, "Controller Configuration (", "控制器配置 (");
        instructions = Utility.TranslateIL(instructions, "Show additional options", "显示额外设置");
        instructions = Utility.TranslateIL(instructions, "Discrete action step", "离散动作步长");
        instructions = Utility.TranslateIL(instructions, "Incremental action sensitivity", "增量灵敏度");
        instructions = Utility.TranslateIL(instructions, "Camera sensitivity", "镜头灵敏度");
        instructions = Utility.TranslateIL(instructions, "Analog input curve", "输入模拟曲线");
        instructions = Utility.TranslateIL(instructions, "Quadratic", "平方");
        instructions = Utility.TranslateIL(instructions, "Linear", "线性");
        instructions = Utility.TranslateIL(instructions, "Quadratic (Inverted)", "平方(反向)");
        instructions = Utility.TranslateIL(instructions, "Treat hats as buttons (requires restart)", "将hat控制视为按钮(需重启游戏)");
        instructions = Utility.TranslateIL(instructions, "Manual dead-zones", "手动输入盲区");
        instructions = Utility.TranslateIL(instructions, "If some axes below are not displaying 0.0 when the controller is left untouched then it needs calibration.", "当控制器处于未按下且下列轴控制未回正为0.0，则需要校准。");
        instructions = Utility.TranslateIL(instructions, "Leave the controller and press calibrate, then move around all the axes", "取消控制器操作然后按下校准按钮，然后再对轴进行控制");
        instructions = Utility.TranslateIL(instructions, "Calibrate", "校准");
        instructions = Utility.TranslateIL(instructions, "Axes", "轴");
        instructions = Utility.TranslateIL(instructions, "Negative dead-zone", "负向盲区");
        instructions = Utility.TranslateIL(instructions, "Positive dead-zone", "正向盲区");
        instructions = Utility.TranslateIL(instructions, "Buttons", "按钮");
        return instructions;
    }

}