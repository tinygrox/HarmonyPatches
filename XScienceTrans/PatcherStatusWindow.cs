using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using ScienceChecklist;
using UnityEngine;

namespace XScienceTrans
{
    [HarmonyPatch]
    public class PatcherStatusWindow
    {
        [HarmonyTargetMethods]
        static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.TypeByName("StatusWindow").GetConstructor(new[] { typeof(ScienceChecklistAddon) });
            yield return AccessTools.TypeByName("StatusWindow").GetMethod("DrawWindowContents", AccessTools.all);
            yield return AccessTools.TypeByName("StatusWindow").GetMethod("MakeSituationToolTip", AccessTools.all);
            yield return AccessTools.TypeByName("StatusWindow").GetMethod("DrawExperiment", AccessTools.all);
            yield return AccessTools.TypeByName("StatusWindow").GetMethod("UpdateSituation", AccessTools.all);
        }
        
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> ILTrans(IEnumerable<CodeInstruction> instructions)
        {
            var codeList = instructions.ToList();
            foreach (var code in codeList.Where(code => code.opcode == OpCodes.Ldstr))
            {
                // Debug.Log($"看看字符串：{code.operand}");
                switch (code.operand)
                {
                    case "[x] Science! Here and Now":
                        code.operand = "[x] Science! 此时此地";
                        continue;
                    case "Min Science":
                        code.operand = "最小科学点数";
                        continue;
                    case "Time warp will be stopped":
                        code.operand = "时间加速会被打断";
                        continue;
                    case "Time warp will not be stopped":
                        code.operand = "时间加速不会被打断";
                        continue;
                    case "Audio alert will sound":
                        code.operand = "有声音提示";
                        continue;
                    case "No audio alert":
                        code.operand = "无声音提示";
                        continue;
                    case "Show results window":
                        code.operand = "显示结果窗口";
                        continue;
                    case "Suppress results window":
                        code.operand = "关掉结果窗口";
                        continue;
                    case "Space high: ":
                        code.operand = "远地太空：";
                        continue;
                    case "Atmos depth: ":
                        code.operand = "大气高度：";
                        continue;
                    case "Flying high: ":
                        code.operand = "高空飞行：";
                        continue;
                    case "Has oxygen - jets work\n":
                        code.operand = "存在氧气 - 喷气引擎可用\n";
                        continue;
                    case "No kind of atmosphere\n":
                        code.operand = "无大气\n";
                        continue;
                    case "Has oceans\n":
                        code.operand = "存在海洋\n";
                        continue;
                    case "No surface\n":
                        code.operand = "无地表\n";
                        continue;
                    case "Current vessel: ":
                        code.operand = "当前载具：";
                        continue;
                    case " stored experiments":
                        code.operand = "已存储实验";
                        continue;
                    case "Experiment description (next run value)\n\nRecovered+OnBoard value":
                        code.operand = "实验描述(下次运行值)\n\n回收+收集的值";
                        continue;
                    case "New Situation: ":
                        code.operand = "新的情境：";
                        continue;
                }
            } 
            return codeList.AsEnumerable();
        }

    }
}