using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using ScienceChecklist;

namespace XScienceTrans
{
    [HarmonyPatch]
    public class PatcherSettingsWindow
    {
        [HarmonyTargetMethods]
        static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.TypeByName("ScienceChecklist.SettingsWindow").GetConstructor(new Type[] {typeof(ScienceChecklistAddon)});
            yield return AccessTools.TypeByName("ScienceChecklist.SettingsWindow").GetMethod("DrawWindowContents", AccessTools.all);
        }
        
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> ILTrans(IEnumerable<CodeInstruction> instructions)
        {
            var codeList = instructions.ToList();
            foreach (var code in codeList.Where(code => code.opcode == OpCodes.Ldstr))
            {
                switch (code.operand)
                {
                    case "[x] Science! Settings":
                        code.operand = "[x] Science! 设置";
                        continue;
                    case "Hide complete experiments":
                        code.operand = "隐藏已完成实验";
                        continue;
                    case "Experiments considered complete will not be shown.":
                        code.operand = "被视为已完成的实验将不会显示在列表中。";
                        continue;
                    case "Complete without recovery":
                        code.operand = "未回收视为完成";
                        continue;
                    case "Show experiments as completed even if they have not been recovered yet.\nYou still need to recover the science to get the points!\nJust easier to see what is left.":
                        code.operand = "将尚未回收的实验数据视为已完成的实验。\n你仍然需要回收科学数据才能获得点数！\n仅为更方便查看剩下的实验。";
                        continue;
                    case "Check unloaded vessels":
                        code.operand = "检查未载入的航天器";
                        continue;
                    case "Unloaded vessels will be checked for recoverable science.":
                        code.operand = "未载入的航天器也同样会检查是否有可回收的科学点数";
                        continue;
                    case "Check debris":
                        code.operand = "检查残骸";
                        continue;
                    case "Vessels marked as debris will be checked for recoverable science.":
                        code.operand = "被标记为残骸的航天器也会被检查是否有可回收的科学点数";
                        continue;
                    case "Hide Min Science Slider":
                        code.operand = "隐藏最小科学点数滑动条";
                        continue;
                    case "Hide the minimum science slider in the Here & Now window":
                        code.operand = "隐藏在此时此地窗口的最小科学点数滑动条";
                        continue;
                    case "Low Min Science":
                        code.operand = "最低科学点数";
                        continue;
                    case "Minimum science slider in the Here & Now window will go fom 0.0001 to 0.1":
                        code.operand = "在此时此地窗口最小科学点数滑动条范围从0.0001至0.1";
                        continue;
                    case "Allow all filter":
                        code.operand = "允许显示所有实验";
                        continue;
                    case "Adds a filter button showing all experiments, even on unexplored bodies using unavailable instruments.\nMight be considered cheating.":
                        code.operand = "添加一个可以显示所有实验的按钮，即使未访问过天体且未解锁相应的科学仪器的实验也能够查看。\n某些玩家可能视其为作弊。";
                        continue;
                    case "Filter difficult science":
                        code.operand = "过滤困难科学实验";
                        continue;
                    case "Hide a few experiments such as flying at stars and gas giants that are almost impossible.\n Also most EVA reports before upgrading Astronaut Complex.":
                        code.operand = "隐藏一些几乎不可能进行的实验，比如在恒星和气态行星进行低空飞行。\n还有在升级宇航员之家之前的那堆EVA报告。";
                        continue;
                    case "Selected Object Window":
                        code.operand = "选定物体窗口";
                        continue;
                    case "Show the Selected Object Window in the Tracking Station.":
                        code.operand = "在追踪站中显示“选定物体”窗口。";
                        continue;
                    case "Right click [x] icon":
                        code.operand = "右击[x]图标";
                        continue;
                    case "Mute music":
                        code.operand = "音乐静音";
                        continue;
                    case "Here & Now window gets its own icon":
                        code.operand = "此时此地窗口会有单独的图标按钮";
                        continue;
                    case "Opens Here & Now window":
                        code.operand = "打开此时此地窗口";
                        continue;
                    case "Here & Now icon is hidden":
                        code.operand = "此时此地的图标按钮隐藏";
                        continue;
                    case "Music starts muted":
                        code.operand = "初始音乐静音";
                        continue;
                    case "Title music is silenced upon load.  No need to right click":
                        code.operand = "音乐在加载时静音。无需右键单击";
                        continue;
                    case "Adjust UI size":
                        code.operand = "调整界面大小";
                        continue;
                    case "Adjusts the the UI scaling.":
                        code.operand = "调整界面的缩放比例";
                        continue;
                }
            }
            return codeList.AsEnumerable();
        }
    }
}