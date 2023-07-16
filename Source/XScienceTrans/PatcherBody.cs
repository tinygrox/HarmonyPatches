using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace XScienceTrans
{
    [HarmonyPatch]
    public class PatcherBody
    {
        [HarmonyTargetMethod]
        public static MethodBase TargetMethod()
        {
            return AccessTools.TypeByName("Body").GetMethod("FigureOutType", AccessTools.all);
        }

        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> ILTrans(IEnumerable<CodeInstruction> instructions)
        {
            var codeList = instructions.ToList();
            foreach (var code in codeList.Where(code => code.opcode == OpCodes.Ldstr))
            {
                switch (code.operand)
                {
                    case "Gas Giant":
                        code.operand = "气态行星";
                        continue;
                    case "Star":
                        code.operand = "恒星";
                        continue;
                    case "Planet":
                        code.operand = "行星";
                        continue;
                    case "Moon":
                        code.operand = "卫星";
                        continue;
                    case "Unknown":
                        code.operand = "未知天体类型";
                        continue;
                }
            }
            Debug.Log("美好的汉化工作已经完成");
            return codeList.AsEnumerable();
        }
    }
}