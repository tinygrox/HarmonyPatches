using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using ScienceChecklist;

namespace XScienceTrans
{
    [HarmonyPatch]
    public class PatcherShipState
    {
        [HarmonyTargetMethods]
        static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.TypeByName("ShipStateWindow").GetConstructor(new[] { typeof(ScienceChecklistAddon) });
            yield return AccessTools.TypeByName("ShipStateWindow").GetMethod("DrawBody", AccessTools.all);
            yield return AccessTools.TypeByName("ShipStateWindow").GetMethod("DrawVessel", AccessTools.all);
        }

        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> ILPatcher(IEnumerable<CodeInstruction> codeInstructions)
        {
            var codeList = codeInstructions.ToList();
            foreach (var code in codeList.Where(code => code.opcode == OpCodes.Ldstr))
            {
                switch (code.operand)
                {
                    case "[x] Science! Selected Object":
                        code.operand = "[x] Science! 选定物体";
                        continue;
                    case "Body: ":
                        code.operand = "天体：";
                        continue;
                    case " - Home!":
                        code.operand = " - 家！";
                        continue;
                    case "Space high: ":
                        code.operand = "远地太空：";
                        continue;
                    case "\nAtmos depth: ":
                        code.operand = "\n大气高度：";
                        continue;
                    case "\nFlying high: ":
                        code.operand = "\n高空飞行：";
                        continue;
                    case "\nHas oxygen - jets work":
                        code.operand = "\n存在氧气 - 喷气引擎可用";
                        continue;
                    case "\nNo kind of atmosphere":
                        code.operand = "\n无大气";
                        continue;
                    case "\nHas oceans":
                        code.operand = "\n存在海洋";
                        continue;
                    case "\nNo surface":
                        code.operand = "\n无地表";
                        continue;
                    case "Unowned object":
                        code.operand = "未知物体";
                        continue;
                    case "Crew: {0}, Parts: {1}, Mass: {2:f2}t":
                        code.operand = "乘员：{0}, 部件: {1}, 质量：{2:f2}t";
                        continue;
                    case "No command pod":
                        code.operand = "无指令舱";
                        continue;
                    case "Has command seat":
                        code.operand = "存在指挥座椅";
                        continue;
                }
            } 
            return codeList.AsEnumerable();
        }
    }
}