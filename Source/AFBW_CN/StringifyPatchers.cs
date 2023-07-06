using System.Collections.Generic;
using HarmonyLib;
using KSPAdvancedFlyByWire;

namespace AFBW_CN;

[HarmonyPatch]
public class StringifyPatchers
{
    [HarmonyTranspiler, HarmonyPatch(typeof(Stringify), nameof(Stringify.ContinuousActionToString), typeof(ContinuousAction))]
    static IEnumerable<CodeInstruction> ILPatcher1(IEnumerable<CodeInstruction> codeInstructions)
    {
        codeInstructions = Utility.TranslateIL(codeInstructions,"None", "无");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Yaw", "偏航");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Yaw (Negative)", "偏航(负向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Yaw (Trim)", "偏航(配平)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Pitch", "俯仰");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Pitch (Negative)", "俯仰(负向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Pitch (Trim)", "俯仰(配平)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Roll", "滚转");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Roll (Negative)", "滚转(负向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Roll (Trim)", "滚转(配平)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Transl. X", "X轴向平移");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Transl. X (Negative)", "X轴向平移(负向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Transl. Y", "Y轴向平移");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Transl. Y (Negative)", "Y轴向平移(负向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Transl. Z", "Z轴向平移");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Transl. Z (Negative)", "Z轴向平移(负向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Throttle", "节流阀");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Throttle (Increment)", "节流阀(增大)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Throttle (Decrement)", "节流阀(减小)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Wheel Steer", "车轮转向");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Wheel Steer (Trim)", "车轮转向(配平)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Wheel Throttle", "车轮动力");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Wheel Throttle (Trim)", "车轮动力(配平)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Camera X", "镜头X轴");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Camera Y", "镜头Y轴");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Camera Zoom", "镜头缩放");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom Axis 1", "自定义轴1");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom Axis 2", "自定义轴2");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom Axis 3", "自定义轴3");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom Axis 4", "自定义轴4");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Unknown Action", "未知动作");
        return codeInstructions;
    } 

    [HarmonyTranspiler, HarmonyPatch(typeof(Stringify), nameof(Stringify.DiscreteActionToString), typeof(DiscreteAction))]
    static IEnumerable<CodeInstruction> ILPatcher2(IEnumerable<CodeInstruction> codeInstructions)
    {
        codeInstructions = Utility.TranslateIL(codeInstructions,"None", "无");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Next Preset", "下个预设配置");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Previous Preset", "上个预设配置");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Cycle Presets", "切换预设配置");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Yaw+", "偏航+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Yaw-", "偏航-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Pitch+", "俯仰+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Pitch-", "俯仰-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Pitch Trim+", "俯仰配平+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Pitch Trim-", "俯仰配平-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Roll+", "滚转+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Roll-", "滚转-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Translate X+", "X轴向平移+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Translate X-", "X轴向平移-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Translate Y+", "Y轴向平移+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Translate Y-", "Y轴向平移-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Translate Z+", "Z轴向平移+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Translate Z-", "Z轴向平移-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Throttle+", "节流阀+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Throttle-", "节流阀-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Stage", "分级");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Gear", "起落装置");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Light", "灯光");
        // codeInstructions = Utility.TranslateIL(codeInstructions,"RCS", "RCS");
        // codeInstructions = Utility.TranslateIL(codeInstructions,"SAS", "SAS");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Brakes (Toggle)", "制动(切换)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Brakes (Hold)", "制动(长按)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Abort", "紧急终止");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom 1", "自定义动作1");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom 2", "自定义动作2");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom 3", "自定义动作3");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom 4", "自定义动作4");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom 5", "自定义动作5");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom 6", "自定义动作6");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom 7", "自定义动作7");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom 8", "自定义动作8");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom 9", "自定义动作9");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Custom 10", "自定义动作10");
        codeInstructions = Utility.TranslateIL(codeInstructions,"EVA Jetpack [Toggle]", "舱外活动喷气背包[切换]");
        codeInstructions = Utility.TranslateIL(codeInstructions,"EVA Interact", "舱外互动");
        codeInstructions = Utility.TranslateIL(codeInstructions,"EVA Jump", "舱外跳跃");
        codeInstructions = Utility.TranslateIL(codeInstructions,"EVA Plant Flag", "舱外插旗");
        codeInstructions = Utility.TranslateIL(codeInstructions,"EVA AutoRun [Toggle]", "舱外自动奔跑[切换]");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Cut Throttle", "关闭节流阀");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Full Throttle", "节流阀全开");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Camera Zoom+", "镜头缩放+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Camera Zoom-", "镜头缩放-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Camera X+", "镜头X轴+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Camera X-", "镜头X轴-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Camera Y+", "镜头Y轴+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Camera Y-", "镜头Y轴-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Orbit Map [Toggle]", "星图界面[切换]");
        codeInstructions = Utility.TranslateIL(codeInstructions,"TimeWarp+", "时间加速+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"TimeWarp-", "时间加速-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Physics TimeWarp+", "物理时间加速+");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Physics TimeWarp-", "物理时间加速-");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Stop Warp", "停止时间加速");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Navball [Toggle]", "导航球[切换]");
        codeInstructions = Utility.TranslateIL(codeInstructions,"IVA View [Toggle]", "舱内视角[切换]");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Camera View [Toggle]", "镜头模式[切换]");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Hold)", "SAS(长按)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Invert)", "SAS(反转)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Stability assist)", "SAS(稳定辅助)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Prograde)", "SAS(顺向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Retrograde)", "SAS(逆向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Normal)", "SAS(法向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Antinormal)", "SAS(反法向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Radial in)", "SAS(径向向内)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Radial out)", "SAS(径向向外)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Maneuver)", "SAS(机动节点)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Target)", "SAS(目标正向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Anti target)", "SAS(目标反向)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"SAS (Maneuver or target)", "SAS(机动节点或目标)");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Lock Staging", "锁定分级");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Precision Controls [Toggle]", "精细控制[切换]");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Reset Trim", "重置配平");
        codeInstructions = Utility.TranslateIL(codeInstructions,"IVA Next Kerbal", "舱内视角切换坎巴拉人");
        codeInstructions = Utility.TranslateIL(codeInstructions,"IVA Focus Window", "舱内视角聚焦窗口");
        codeInstructions = Utility.TranslateIL(codeInstructions,"Unknown Action", "未知动作");
        return codeInstructions;
    }
}