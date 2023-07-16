using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace XScienceTrans
{
    [HarmonyPatch]
    public class PatcherScienceWindow
    {
        [HarmonyTargetMethods]
        static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.TypeByName("ScienceWindow").GetMethod("DrawControls", AccessTools.all, null,new Type []{typeof(int)},null);
            yield return AccessTools.TypeByName("ScienceWindow").GetMethod("DrawTitleBarButtons", AccessTools.all, null,new Type []{typeof(Rect), typeof(bool)},null);
        }
        
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> ILTrans(IEnumerable<CodeInstruction> instructions)
        {
            var codeList = instructions.ToList();
            foreach (var code in codeList.Where(code => code.opcode == OpCodes.Ldstr))
            {
                switch (code.operand)
                {
                    case "{0}/{1} complete.":
                        code.operand = "{0}/{1} 已完成.";
                        continue;
                    case "{0} remaining\n{1:0.#} mits":
                        code.operand = "{0}剩余\n{1:0.#} Mits";
                        continue;
                    case "Clear search":
                        code.operand = "清除搜索";
                        continue;
                    case "Show experiments available right now":
                        code.operand = "显示当前可用实验";
                        continue;
                    case "Show experiments available on this vessel":
                        code.operand = "显示当前载具可用实验";
                        continue;
                    case "Show unlocked experiments unavailable on this vessel":
                        code.operand = "显示当前载具不可用的已解锁实验";
                        continue;
                    case "Show all unlocked experiments":
                        code.operand = "显示所有已解锁的实验";
                        continue;
                    case "Show all experiments":
                        code.operand = "显示全部实验";
                        continue;
                    case "Close window":
                        code.operand = "关闭窗口";
                        continue;
                    case "Open help window":
                        code.operand = "打开帮助页面窗口";
                        continue;
                    case "Open settings window":
                        code.operand = "打开设置窗口";
                        continue;
                    case "Maximise window":
                        code.operand = "最大化窗口";
                        continue;
                    case "Compact window":
                        code.operand = "迷你窗口";
                        continue;
                }
            }
            return codeList.AsEnumerable();
        }
    }
}