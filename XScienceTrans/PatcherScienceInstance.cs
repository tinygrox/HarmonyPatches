using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using ScienceChecklist;
using UniLinq;

namespace XScienceTrans
{
    [HarmonyPatch]
    public class PatcherScienceInstance
    {
        [HarmonyTargetMethod]
        static MethodBase TargetMethod()
        {
            return AccessTools.TypeByName("ScienceInstance").GetProperty("Description")?.GetMethod;
        }
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> ILTrans(IEnumerable<CodeInstruction> instructions)
        {
            var codeList = instructions.ToList();
            foreach (var code in codeList.Where(code => code.opcode == OpCodes.Ldstr))
            {
                if (code.operand.Equals("{0} while {1}"))
                    code.operand = "{0} {1}"; // 此处在中文语境下无需翻译这个 while
            } 
            return codeList.AsEnumerable();
        }
    }
}