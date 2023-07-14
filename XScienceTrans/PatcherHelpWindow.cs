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
    public class PatcherHelpWindow
    {
        [HarmonyTargetMethods]
        static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.TypeByName("HelpWindow").GetConstructor(new Type[] { typeof(ScienceChecklistAddon) });
            yield return AccessTools.TypeByName("HelpWindow").GetMethod("DrawWindowContents", AccessTools.all);
        }

        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> ILTrans(IEnumerable<CodeInstruction> codeInstructions)
        {
            var codeList = codeInstructions.ToList();
            foreach (var code in codeList.Where(code => code.opcode == OpCodes.Ldstr))
            {
                switch (code.operand)
                {
                    case "[x] Science! Help":
                        code.operand = "[x] Science! 帮助页面";
                        continue;
                    case "[x] Science! by Z-Key Aerospace and Bodrick.":
                        code.operand = "[x] Science! 由 Z-Key Aerospace 和 Bodrick 开发";
                        continue;
                    case "About":
                        code.operand = "关于";
                        continue;
                    case "[x] Science! creates a list of all possible science.  Use the list to find what is possible, to see what is left to accomplish, to decide where your Kerbals are going next.":
                        code.operand = "[x] Science! 会创建一个列出了所有潜在的科学实验列表。利用这个列表可以查询有什么实验是能够完成的，还有什么实验是未完成的，决定你下次派遣的坎巴拉人的目的地。";
                        continue;
                    case "The four filter buttons at the bottom of the window are":
                        code.operand = "窗口底部的四个筛选按钮是";
                        continue;
                    case "* Show experiments available right now – based on you current ship and its situation":
                        code.operand = "* 显示当前可用的实验 - 基于你当前的载具和所处的情景";
                        continue;
                    case "* Show experiments available on this vessel – based on your ship but including all known biomes":
                        code.operand = "* 显示载具上可用的实验 - 基于你的载具，显示包括所有已知的生态群落";
                        continue;
                    case "* Show all unlocked experiments – based on instruments you have unlocked and celestial bodies you have visited.":
                        code.operand = "* 显示所有已解锁的实验 - 基于已解锁仪器和你访问过的天体";
                        continue;
                    case "* Show all experiments – shows everything.  You can hide this button":
                        code.operand = "* 显示所有实验 - 显示全部实验。你可以隐藏此按钮";
                        continue;
                    case "The text filter":
                        code.operand = "按文字筛选";
                        continue;
                    case "To narrow your search, you may enter text into the filter eg \"kerbin’s shores\"":
                        code.operand = "要缩小搜索范围，你可以在输入框中输入关键词，例如“Kerbin 水边”";
                        continue;
                    case "Use – to mean NOT eg \"mun space -near\"":
                        code.operand = "使用符号 - 意为【排除】，比如“Mun 太空 -近地”";
                        continue;
                    case "Use | to mean OR eg \"mun|minmus space\"":
                        code.operand = "使用符号 | 意为【或】，比如“Mun|Minums 太空”";
                        continue;
                    case "Hover the mouse over the \"123/456 completed\" text.  A pop-up will show more infromation.":
                        code.operand = "鼠标移到左上的 \"123/456 已完成\" 上面. 能显示更多信息";
                        continue;
                    case "Press the X button to clear your text filter.":
                        code.operand = "按下 X 清空所有文本。";
                        continue;
                    case "The settings are":
                        code.operand = "设置界面相关";
                        continue;
                    case "* Hide complete experiments – Any science with a full green bar is hidden.  It just makes it easier to see what is left to do.":
                        code.operand = "* 隐藏已完成实验 - 任何绿色条满的科学实验都会被隐藏。仅仅是为了能够更加容易知道还有哪些剩下的实验。";
                        continue;
                    case "* Complete without recovery – Consider science in your spaceships as if it has been recovered.  You still need to recover to get the points.  It just makes it easier to see what is left to do.":
                        code.operand = "* 已完成待回收 - 将当前载具中存储的科学视认为已经回收。但你仍然需要回收载具才能拿到科学点数。仅仅是为了能够更加容易知道还有哪些剩下的实验。";
                        continue;
                    case "* Check debris – Science that survived a crash will be visible.  You may still be able to recover it.":
                        code.operand = "* 检查残骸 - 坠毁后残骸中保存的科学将可见。你没准还能够有机会回收它。";
                        continue;
                    case "* Allow all filter – The \"All\" filter button shows science on planets you have never visited using instruments you have not invented yet.  Some people may consider it overpowered.  If you feel like a cheat, turn it off.":
                        code.operand = "* 显示所有内容 - “所有”筛选按钮显示会显示所有的科学，包括那些你没有访问过的星球和未解锁仪器的科学。有些人会觉得这功能有点过了。但如果你觉得这有开挂的嫌疑，那就关掉它。";
                        continue;
                    case "* Filter difficult science – Hide science that is practically impossible.  Flying at stars, that kinda thing.":
                        code.operand = "* 过滤掉困难的科学实验 - 隐藏实际上不可能完成的科学实验。比如在恒星上低空飞行之类之类的。";
                        continue;
                    case "* Use blizzy78's toolbar – If you have blizzy78’s toolbar installed then place the [x] Science! button on that instead of the stock \"Launcher\" toolbar.":
                        code.operand = "* 使用 blizzy78 的工具栏 – 如果你安装了blizzy78的工具栏(toolbar)，那么[x]Science！按钮将使用该 Mod 的实现代替，而不是右侧的原版工具栏按钮。";
                        continue;
                    case "* Right click [x] icon – Choose to open the Here and Now window by right clicking.  Hides the second window.  Otherwise mute music.":
                        code.operand = "* 右键 [x] 图标 – 将通过右键单击按钮的方式打开“此时此地”窗口。第二个窗口会被隐藏。或者设置将游戏音乐静音。";
                        continue;
                    case "* Music starts muted – Music is muted on load.":
                        code.operand = "* 初始时音乐静音 – 游戏音乐在加载时就会被静音。";
                        continue;
                    case "* Adjust UI Size – Change the scaling of the UI.":
                        code.operand = "* 调整界面大小 – 更改界面的缩放比例。";
                        continue;
                    case "Here and Now Window":
                        code.operand = "此时此地窗口";
                        continue;
                    case "The Here and Now Window will stop time-warp, display an alert message and play a noise when you enter a new situation.  To prevent this, close the window.":
                        code.operand = "“此时此地”窗口会自动停止时间加速，显示提醒消息，当在你处于新情境时响起铃声。要防止此类事件发生，请关闭此窗口。";
                        continue;
                    case "The Here and Now Window will show all outstanding experiments for the current situation that are possible with the current ship.":
                        code.operand = "“此时此地”窗口将显示当前载具在当前所处情境下可能进行的所有实验。";
                        continue;
                    case "To run an experiment, click the button.  If the button is greyed-out then you may need to reset the experiment or recover or transmit the science.":
                        code.operand = "要运行实验，请单击按钮。如果按钮为灰色不可按，那么你可能需要重置实验或先进行回收或传输科学。";
                        continue;
                    case "To perform an EVA report or surface sample, first EVA your Kerbal.  The window will react, allowing those buttons to be clicked.":
                        code.operand = "要执行EVA报告或拾起表面样本，请首先让你的坎巴拉人出舱。窗口会做出反应，并允许点击按钮。";
                        continue;
                    case "Did you know? (includes spoilers)":
                        code.operand = "你知道吗？（剧透警告）";
                        continue;
                    case "* In the VAB editor you can use the filter \"Show experiments available on this vessel\" to see what your vessel could collect before you launch it.":
                        code.operand = "* 在VAB编辑器中，你可以通过“显示载具上可用的实验”来查看您的载具在发射前可以收集到哪些科学。";
                        continue;
                    case "* Does the filter \"mun space high\" show mun’s highlands?  – use \"mun space –near\" instead.":
                        code.operand = "* 输入“Mun 远地太空”是否会显示 Mun的高地？ - 请改用“mun 太空 –近地”。";
                        continue;
                    case "* Need more science?  Go to Minmus.  It’s a little harder to get to but your fuel will last longer.  A single mission can collect thousands of science points before you have to come back.":
                        code.operand = "* 科学点数见底了？去 Minmus 吧。 虽然有点难到，但在那里你的燃料更加有效率。 单次任务就可收集到数千个科学点数。";
                        continue;
                    case "* Generally moons are easier - it is more efficient to collect science from the surface of Ike or Gilly than from Duna or Eve.  That said - beware Tylo, it's big and you can't aerobrake.":
                        code.operand = "* 一般来说，访问卫星会更容易 - 从 Ike 或 Gilly 的表面收集到的科学数据比从 Duna 或 Eve 收集科学数据效率更高。这也说明了 - 要小心 Tylo，它不仅质量大，还不能气动刹车。";
                        continue;
                    case "* Most of Kerbin’s biomes include both splashed and landed situations.  Landed at Kerbin’s water?  First build an aircraft carrier.":
                        code.operand = "* Kerbin的大部分生物群落都包含有溅落和着陆的情况。 想要着陆在Kerbin的水上？首先建造一艘航母。";
                        continue;
                }
            }
            return codeList.AsEnumerable();
        }
    }
}