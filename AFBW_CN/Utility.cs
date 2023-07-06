using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace AFBW_CN
{
    public static class Utility
    {
        public static IEnumerable<CodeInstruction> TranslateIL(IEnumerable<CodeInstruction> instructions, string source, string target)
        {
            var codeList = instructions.ToList();
            foreach (var code in codeList)
            {
                if (code.opcode == OpCodes.Ldstr && ((string)code.operand).Equals(source))
                {
                    code.operand = target;
#if DEBUG
                    Debug.Log($"原文[{source}]已成功翻译为[{target}]");
#endif
                    //return instructions;
                }
            }
            return codeList.AsEnumerable();
        }
    }
}
