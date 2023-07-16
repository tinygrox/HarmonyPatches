using System;
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
    public class PatcherSituation
    {
        [HarmonyTargetMethods]
        static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Constructor(typeof(Situation),
                new Type[] { typeof(Body), typeof(ExperimentSituations), typeof(string), typeof(string) });
            yield return AccessTools.Method(typeof(Situation), "ToString", new Type[] {typeof(ExperimentSituations)});
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
                    case "{0} {1}{2}":
                        code.operand = "{0} {1}{2}";
                        continue;
                    case "'s {0}":
                        code.operand = "的{0}";
                        continue;
                    case "'s {0} ({1})":
                        code.operand = "的{0}({1})";
                        continue;
                    case "flying high over":
                        code.operand = "高空飞行";
                        continue;
                    case "flying low over":
                        code.operand = "低空飞行";
                        continue;
                    case "in space high over":
                        code.operand = "远地太空";
                        continue;
                    case "in space near":
                        code.operand = "近地太空";
                        continue;
                    case "landed at":
                        code.operand = "着陆在";
                        continue;
                    case "splashed down at":
                        code.operand = "溅落在";
                        continue;
                }
            } 
            return codeList.AsEnumerable();
        }
    }
}