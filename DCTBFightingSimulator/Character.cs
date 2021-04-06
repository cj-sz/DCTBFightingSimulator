using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DCTBFightingSimulator
{
    class Character
    {
        /*Notes on all character values:
         * - Values are split up into categories. There is no concept of progression or levels. Values are only edited within the context of a game, then
         * returned to normal.
         * - Explanation of categories:
         *      - Typing: Characters have types, and moves also have types. Type effectiveness: NONE > VOID > EARTHLY > AIR > GROUND > ELECTRIC > METAL > 
         *      INTELLIGENT > FORCE > ICE > FIRE > NATURAL > PSYCHIC > MORTAL > GHOST > NONE
         *          - the above is subject to change as concepts are suggested.
         *      - Character Attributes: see the section for individual attributes. Include HP, base values (such as ATK and DEF), ability to have certain status
         *      effects imposed (these are all ints based on the equations). Finally, characters can have optional descriptions, which can include the lore 
         *      of their creators.
         *          - current status effects and data: STUNNED (cannot move for 1 turn); POISONED (continuous damage taken for 3 turns); BURNED (continuous damage
         *          taken for 3 turns); CRIPPLED (DEF multiplier of 0.75 for 2 turns); FROZEN (cannot move for 1 turn); BLEEDING (continuous minor damage taken
         *          for 5 turns); STUPEFIED (ACC multiplied by 0.5 for 2 turns); WEAK (ATK multiplied by 0.75 for 2 turns); DIZZY (ACC multiplied by 0.75 for 3 turns)
         *      - Moves: each character is built with 5 moves. Moves have various attributes (tendencies to inflict all above, change stats, change personal
         *      stats, etc.) Additionally, moves have specific typing. In future class updates, moves may gain turn-based buffs, but for now the only
         *      turn-dependent mechanics are status effects.
         *      - Methods: character methods are used for referencing when importing and exporting character strings. These strings are created and imported
         *      in other classes, respectively.
         *      
         *      Reference Equations:
         *          Damage = (atk * mm * eff)^2 / opDef (this atk times move multiplier times effectiveness, squared, divided by target's def)
         *          Note about effectiveness: if types are the same or not related, x1. If attacker has better type, x1.25. If attacker has weaker type, x0.75.
         *          Hit made? = ACC + mACC - opDc (accuracy + move accuracy - opponent's chance to dodge)
         *              if >= 100, hits
         *              if 0 < ans < 100, randomized (ex. if 80, 80% chance)
         *              if <= 0, misses
         *          ATK, DEF, ACC, and DGE chances modified by multipliers, not raw values.
         *          
         *  At the bottom is all of the methods for in-match modifications. A character is imported with a string build, then the data is moved visually, and then
         *  temporary edits are made until the match is complete, upon which the object is terminated.
         */

        //Constructor (takes an input string)
        public Character(ImportExportString importString)
        {
            //Import-export string interpreter after checks (see Form1 class)

        }
        public Character(string importString)
        {
            //String interpreter after checks (see Form1 class)
            interpretString(importString);
        }

        //Interpreter
        public void interpretString(string importString)
        {
            //Name
            int descriptionLocatorStartIndex = importString.IndexOf("d@3MDMe#SC");
            charName = importString.Substring(10, descriptionLocatorStartIndex - 10);
            //Description
            int typeLocatorStartIndex = importString.IndexOf("t192y!@:PE22");
            int descriptionLocatorEndIndex = importString.IndexOf("d@3MDMe#SC") + "d@3MDMe#SC".Length - 1;
            charDesc = importString.Substring(descriptionLocatorEndIndex + 1, typeLocatorStartIndex - descriptionLocatorEndIndex-1);
            //Type
            int hpLocatorStartIndex = importString.IndexOf("h!*##p2@<#");
            int typeLocatorEndIndex = importString.IndexOf("t192y!@:PE22") + "t192y!@:PE22".Length - 1;
            charType = importString.Substring(typeLocatorEndIndex + 1, hpLocatorStartIndex - typeLocatorEndIndex - 1);
            Debug.WriteLine(charType);
            //HP
            int atkLocatorStartIndex = importString.IndexOf("at1!@!W0k");
            int hpLocatorEndIndex = importString.IndexOf("h!*##p2@<#") + "h!*##p2@<#".Length - 1;
            hp = Int32.Parse(importString.Substring(hpLocatorEndIndex + 1, atkLocatorStartIndex - hpLocatorEndIndex-1));
            //ATK
            int defLocatorStartIndex = importString.IndexOf("d%%23eFF");
            int atkLocatorEndIndex = importString.IndexOf("at1!@!W0k") + "at1!@!W0k".Length - 1;
            atk = Int32.Parse(importString.Substring(atkLocatorEndIndex + 1, defLocatorStartIndex - atkLocatorEndIndex-1));
            //DEF
            int accLocatorStartIndex = importString.IndexOf("a1;c';c");
            int defLocatorEndIndex = importString.IndexOf("d%%23eFF") + "d%%23eFF".Length - 1;
            def = Int32.Parse(importString.Substring(defLocatorEndIndex + 1, accLocatorStartIndex - defLocatorEndIndex-1));
            //ACC
            int dgeLocatorStartIndex = importString.IndexOf("dj1g><e");
            int accLocatorEndIndex = importString.IndexOf("a1;c';c") + "a1;c';c".Length - 1;
            acc = Int32.Parse(importString.Substring(accLocatorEndIndex + 1, dgeLocatorStartIndex - accLocatorEndIndex-1));
            //DGE
            int imnLocatorStartIndex = importString.IndexOf("imnSTRT@@_!");
            int dgeLocatorEndIndex = importString.IndexOf("dj1g><e") + "dj1g><e".Length - 1;
            dge = Int32.Parse(importString.Substring(dgeLocatorEndIndex + 1, imnLocatorStartIndex - dgeLocatorEndIndex-1));
            //IMMUNITIES
            int imn2LocatorStartIndex = importString.IndexOf("imnEND@@_!");
            int imnLocatorEndIndex = importString.IndexOf("imnSTRT@@_!") + "imnSTRT@@_!".Length - 1;
            string immunitiesList = importString.Substring(imnLocatorEndIndex + 1, imn2LocatorStartIndex - imnLocatorEndIndex);
            if (immunitiesList.Substring(0, 1) == "y")
            {
                imnStun = true;
            }
            else
            {
                imnStun = false;
            }
            if (immunitiesList.Substring(1, 1) == "y")
            {
                imnPsn = true;
            }
            else
            {
                imnPsn = false;
            }
            if (immunitiesList.Substring(2, 1) == "y")
            {
                imnBrn = true;
            }
            else
            {
                imnBrn = false;
            }
            if (immunitiesList.Substring(3, 1) == "y")
            {
                imnCrpl = true;
            }
            else
            {
                imnCrpl = false;
            }
            if (immunitiesList.Substring(4, 1) == "y")
            {
                imnFrzn = true;
            }
            else
            {
                imnFrzn = false;
            }
            if (immunitiesList.Substring(5, 1) == "y")
            {
                imnBld = true;
            }
            else
            {
                imnBld = false;
            }
            if (immunitiesList.Substring(6, 1) == "y")
            {
                imnStpf = true;
            }
            else
            {
                imnStpf = false;
            }
            if (immunitiesList.Substring(7, 1) == "y")
            {
                imnWk = true;
            }
            else
            {
                imnWk = false;
            }
            if (immunitiesList.Substring(8, 1) == "y")
            {
                imnDzz = true;
            }
            else
            {
                imnDzz = false;
            }
            //Move 1 Name
            int mv1dLocatorStartIndex = importString.IndexOf("dDCMv1@@");
            int mv1nLocatorEndIndex = importString.IndexOf("nDCMmv1@@") + "nDCMmv1@@".Length - 1;
            mv1N = importString.Substring(mv1nLocatorEndIndex + 1, mv1dLocatorStartIndex - mv1nLocatorEndIndex-1);
            //Move 1 Desc
            int mv1tLocatorStartIndex = importString.IndexOf("tDCMmv1@@");
            int mv1dLocatorEndIndex = importString.IndexOf("dDCMv1@@") + "dDCMv1@@".Length - 1;
            mv1Desc = importString.Substring(mv1dLocatorEndIndex + 1, mv1tLocatorStartIndex - mv1dLocatorEndIndex-1);
            //Move 1 Type
            int mv1atmLocatorStartIndex = importString.IndexOf("atmDCMmv1@@");
            int mv1tLocatorEndIndex = importString.IndexOf("tDCMmv1@@") + "tDCMmv1@@".Length - 1;
            mv1Type = importString.Substring(mv1tLocatorEndIndex + 1, mv1atmLocatorStartIndex - mv1tLocatorEndIndex-1);
            //Move 1 Atk Multiplier
            int mv1accLocatorStartIndex = importString.IndexOf("accDCMmv1@@");
            int mv1atmLocatorEndIndex = importString.IndexOf("atmDCMmv1@@") + "atmDCMmv1@@".Length - 1;
            mv1m = float.Parse(importString.Substring(mv1atmLocatorEndIndex + 1, mv1accLocatorStartIndex - mv1atmLocatorEndIndex-1));
            //Move 1 Acc
            int mv1hLocatorStartIndex = importString.IndexOf("hDCMmv1@@");
            int mv1accLocatorEndIndex = importString.IndexOf("accDCMmv1@@") + "accDCMmv1@@".Length - 1;
            mv1acc = Int32.Parse(importString.Substring(mv1accLocatorEndIndex + 1, mv1hLocatorStartIndex - mv1accLocatorEndIndex-1));
            //Move 1 Healing
            int mv1atkMLocatorStartIndex = importString.IndexOf("atkDCMmv1@@");
            int mv1hLocatorEndIndex = importString.IndexOf("hDCMmv1@@") + "hDCMmv1@@".Length - 1;
            mv1Heal = Int32.Parse(importString.Substring(mv1hLocatorEndIndex + 1, mv1atkMLocatorStartIndex - mv1hLocatorEndIndex-1));
            //Move 1 Atk Mod
            int mv1defMLocatorStartIndex = importString.IndexOf("defDCMmv1@@");
            int mv1atkMLocatorEndIndex = importString.IndexOf("atkDCMmv1@@") + "atkDCMmv1@@".Length - 1;
            mv1atkMod = Int32.Parse(importString.Substring(mv1atkMLocatorEndIndex + 1, mv1defMLocatorStartIndex - mv1atkMLocatorEndIndex-1));
            //Move 1 Def Mod
            int mv1accMLocatorStartIndex = importString.IndexOf("acmDCMmv1@@");
            int mv1defMLocatorEndIndex = importString.IndexOf("defDCMmv1@@") + "defDCMmv1@@".Length - 1;
            mv1defMod = Int32.Parse(importString.Substring(mv1defMLocatorEndIndex + 1, mv1accMLocatorStartIndex - mv1defMLocatorEndIndex-1));
            //Move 1 Acc Mod
            int mv1dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv1@@");
            int mv1accMLocatorEndIndex = importString.IndexOf("acmDCMmv1@@") + "acmDCMmv1@@".Length - 1;
            mv1accMod = Int32.Parse(importString.Substring(mv1accMLocatorEndIndex + 1, mv1dgeMLocatorStartIndex - mv1accMLocatorEndIndex-1));
            //Move 1 Dge Mod
            int mv1indMLocatorStartIndex = importString.IndexOf("indSTRTMmv1@@_!");
            int mv1dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv1@@") + "dgeDCMmv1@@".Length - 1;
            mv1dgeMod = Int32.Parse(importString.Substring(mv1dgeMLocatorEndIndex + 1, mv1indMLocatorStartIndex - mv1dgeMLocatorEndIndex-1));
            //Move 1 Induces
            int mv1ind2LocatorStartIndex = importString.IndexOf("indENDMmv1@@_!");
            int mv1indLocatorEndIndex = importString.IndexOf("indSTRTMmv1@@_!") + "indSTRTMmv1@@_!".Length - 1;
            string mv1Induces = importString.Substring(mv1indLocatorEndIndex + 1, mv1ind2LocatorStartIndex - mv1indLocatorEndIndex);
            if(mv1Induces.Substring(0,1) == "y")
            {
                mv1IndStun = true;
            }
            else
            {
                mv1IndStun = false;
            }
            if (mv1Induces.Substring(1, 1) == "y")
            {
                mv1IndPsn = true;
            }
            else
            {
                mv1IndPsn = false;
            }
            if (mv1Induces.Substring(2, 1) == "y")
            {
                mv1IndBrn = true;
            }
            else
            {
                mv1IndBrn = false;
            }
            if (mv1Induces.Substring(3, 1) == "y")
            {
                mv1IndCrpl = true;
            }
            else
            {
                mv1IndCrpl = false;
            }
            if (mv1Induces.Substring(4, 1) == "y")
            {
                mv1IndFrzn = true;
            }
            else
            {
                mv1IndFrzn = false;
            }
            if (mv1Induces.Substring(5, 1) == "y")
            {
                mv1IndBld = true;
            }
            else
            {
                mv1IndBld = false;
            }
            if (mv1Induces.Substring(6, 1) == "y")
            {
                mv1IndStpf = true;
            }
            else
            {
                mv1IndStpf = false;
            }
            if (mv1Induces.Substring(7, 1) == "y")
            {
                mv1IndWk = true;
            }
            else
            {
                mv1IndWk = false;
            }
            if (mv1Induces.Substring(8, 1) == "y")
            {
                mv1IndDzz = true;
            }
            else
            {
                mv1IndDzz = false;
            }
            //Move 2 Name
            int mv2dLocatorStartIndex = importString.IndexOf("dDCMv2@@");
            int mv2nLocatorEndIndex = importString.IndexOf("nDCMmv2@@") + "nDCMmv2@@".Length - 1;
            mv2N = importString.Substring(mv2nLocatorEndIndex + 1, mv2dLocatorStartIndex - mv2nLocatorEndIndex-1);
            //Move 2 Desc
            int mv2tLocatorStartIndex = importString.IndexOf("tDCMmv2@@");
            int mv2dLocatorEndIndex = importString.IndexOf("dDCMv2@@") + "dDCMv2@@".Length - 1;
            mv2Desc = importString.Substring(mv2dLocatorEndIndex + 1, mv2tLocatorStartIndex - mv2dLocatorEndIndex-1);
            //Move 2 Type
            int mv2atmLocatorStartIndex = importString.IndexOf("atmDCMmv2@@");
            int mv2tLocatorEndIndex = importString.IndexOf("tDCMmv2@@") + "tDCMmv2@@".Length - 1;
            mv2Type = importString.Substring(mv2tLocatorEndIndex + 1, mv2atmLocatorStartIndex - mv2tLocatorEndIndex-1);
            //Move 2 Atk Multiplier
            int mv2accLocatorStartIndex = importString.IndexOf("accDCMmv2@@");
            int mv2atmLocatorEndIndex = importString.IndexOf("atmDCMmv2@@") + "atmDCMmv2@@".Length - 1;
            mv2m = float.Parse(importString.Substring(mv2atmLocatorEndIndex + 1, mv2accLocatorStartIndex - mv2atmLocatorEndIndex-1));
            //Move 2 Acc
            int mv2hLocatorStartIndex = importString.IndexOf("hDCMmv2@@");
            int mv2accLocatorEndIndex = importString.IndexOf("accDCMmv2@@") + "accDCMmv2@@".Length - 1;
            mv2acc = Int32.Parse(importString.Substring(mv2accLocatorEndIndex + 1, mv2hLocatorStartIndex - mv2accLocatorEndIndex-1));
            //Move 2 Healing
            int mv2atkMLocatorStartIndex = importString.IndexOf("atkDCMmv2@@");
            int mv2hLocatorEndIndex = importString.IndexOf("hDCMmv2@@") + "hDCMmv2@@".Length - 1;
            mv2Heal = Int32.Parse(importString.Substring(mv2hLocatorEndIndex + 1, mv2atkMLocatorStartIndex - mv2hLocatorEndIndex-1));
            //Move 2 Atk Mod
            int mv2defMLocatorStartIndex = importString.IndexOf("defDCMmv2@@");
            int mv2atkMLocatorEndIndex = importString.IndexOf("atkDCMmv2@@") + "atkDCMmv2@@".Length - 1;
            mv2atkMod = Int32.Parse(importString.Substring(mv2atkMLocatorEndIndex + 1, mv2defMLocatorStartIndex - mv2atkMLocatorEndIndex-1));
            //Move 2 Def Mod
            int mv2accMLocatorStartIndex = importString.IndexOf("acmDCMmv2@@");
            int mv2defMLocatorEndIndex = importString.IndexOf("defDCMmv2@@") + "defDCMmv2@@".Length - 1;
            mv2defMod = Int32.Parse(importString.Substring(mv2defMLocatorEndIndex + 1, mv2accMLocatorStartIndex - mv2defMLocatorEndIndex-1));
            //Move 2 Acc Mod
            int mv2dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv2@@");
            int mv2accMLocatorEndIndex = importString.IndexOf("acmDCMmv2@@") + "acmDCMmv2@@".Length - 1;
            mv2accMod = Int32.Parse(importString.Substring(mv2accMLocatorEndIndex + 1, mv2dgeMLocatorStartIndex - mv2accMLocatorEndIndex-1));
            //Move 2 Dge Mod
            int mv2indMLocatorStartIndex = importString.IndexOf("indSTRTMmv2@@_!");
            int mv2dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv2@@") + "dgeDCMmv2@@".Length - 1;
            mv2dgeMod = Int32.Parse(importString.Substring(mv2dgeMLocatorEndIndex + 1, mv2indMLocatorStartIndex - mv2dgeMLocatorEndIndex-1));
            //Move 2 Induces
            int mv2ind2LocatorStartIndex = importString.IndexOf("indENDMmv2@@_!");
            int mv2indLocatorEndIndex = importString.IndexOf("indSTRTMmv2@@_!") + "indSTRTMmv2@@_!".Length - 1;
            string mv2Induces = importString.Substring(mv2indLocatorEndIndex + 1, mv2ind2LocatorStartIndex - mv2indLocatorEndIndex);
            if (mv2Induces.Substring(0, 1) == "y")
            {
                mv2IndStun = true;
            }
            else
            {
                mv2IndStun = false;
            }
            if (mv2Induces.Substring(1, 1) == "y")
            {
                mv2IndPsn = true;
            }
            else
            {
                mv2IndPsn = false;
            }
            if (mv2Induces.Substring(2, 1) == "y")
            {
                mv2IndBrn = true;
            }
            else
            {
                mv2IndBrn = false;
            }
            if (mv2Induces.Substring(3, 1) == "y")
            {
                mv2IndCrpl = true;
            }
            else
            {
                mv2IndCrpl = false;
            }
            if (mv2Induces.Substring(4, 1) == "y")
            {
                mv2IndFrzn = true;
            }
            else
            {
                mv2IndFrzn = false;
            }
            if (mv2Induces.Substring(5, 1) == "y")
            {
                mv2IndBld = true;
            }
            else
            {
                mv2IndBld = false;
            }
            if (mv2Induces.Substring(6, 1) == "y")
            {
                mv2IndStpf = true;
            }
            else
            {
                mv2IndStpf = false;
            }
            if (mv2Induces.Substring(7, 1) == "y")
            {
                mv2IndWk = true;
            }
            else
            {
                mv2IndWk = false;
            }
            if (mv2Induces.Substring(8, 1) == "y")
            {
                mv2IndDzz = true;
            }
            else
            {
                mv2IndDzz = false;
            }
            //Move 3 Name
            int mv3dLocatorStartIndex = importString.IndexOf("dDCMv3@@");
            int mv3nLocatorEndIndex = importString.IndexOf("nDCMmv3@@") + "nDCMmv3@@".Length - 1;
            mv3N = importString.Substring(mv3nLocatorEndIndex + 1, mv3dLocatorStartIndex - mv3nLocatorEndIndex-1);
            //Move 3 Desc
            int mv3tLocatorStartIndex = importString.IndexOf("tDCMmv3@@");
            int mv3dLocatorEndIndex = importString.IndexOf("dDCMv3@@") + "dDCMv3@@".Length - 1;
            mv3Desc = importString.Substring(mv3dLocatorEndIndex + 1, mv3tLocatorStartIndex - mv3dLocatorEndIndex-1);
            //Move 3 Type
            int mv3atmLocatorStartIndex = importString.IndexOf("atmDCMmv3@@");
            int mv3tLocatorEndIndex = importString.IndexOf("tDCMmv3@@") + "tDCMmv3@@".Length - 1;
            mv3Type = importString.Substring(mv3tLocatorEndIndex + 1, mv3atmLocatorStartIndex - mv3tLocatorEndIndex-1);
            //Move 3 Atk Multiplier
            int mv3accLocatorStartIndex = importString.IndexOf("accDCMmv3@@");
            int mv3atmLocatorEndIndex = importString.IndexOf("atmDCMmv3@@") + "atmDCMmv3@@".Length - 1;
            mv3m = float.Parse(importString.Substring(mv3atmLocatorEndIndex + 1, mv3accLocatorStartIndex - mv3atmLocatorEndIndex-1));
            //Move 3 Acc
            int mv3hLocatorStartIndex = importString.IndexOf("hDCMmv3@@");
            int mv3accLocatorEndIndex = importString.IndexOf("accDCMmv3@@") + "accDCMmv3@@".Length - 1;
            mv3acc = Int32.Parse(importString.Substring(mv3accLocatorEndIndex + 1, mv3hLocatorStartIndex - mv3accLocatorEndIndex-1));
            //Move 3 Healing
            int mv3atkMLocatorStartIndex = importString.IndexOf("atkDCMmv3@@");
            int mv3hLocatorEndIndex = importString.IndexOf("hDCMmv3@@") + "hDCMmv3@@".Length - 1;
            mv3Heal = Int32.Parse(importString.Substring(mv3hLocatorEndIndex + 1, mv3atkMLocatorStartIndex - mv3hLocatorEndIndex-1));
            //Move 3 Atk Mod
            int mv3defMLocatorStartIndex = importString.IndexOf("defDCMmv3@@");
            int mv3atkMLocatorEndIndex = importString.IndexOf("atkDCMmv3@@") + "atkDCMmv3@@".Length - 1;
            mv3atkMod = Int32.Parse(importString.Substring(mv3atkMLocatorEndIndex + 1, mv3defMLocatorStartIndex - mv3atkMLocatorEndIndex-1));
            //Move 3 Def Mod
            int mv3accMLocatorStartIndex = importString.IndexOf("acmDCMmv3@@");
            int mv3defMLocatorEndIndex = importString.IndexOf("defDCMmv3@@") + "defDCMmv3@@".Length - 1;
            mv3defMod = Int32.Parse(importString.Substring(mv3defMLocatorEndIndex + 1, mv3accMLocatorStartIndex - mv3defMLocatorEndIndex-1));
            //Move 3 Acc Mod
            int mv3dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv3@@");
            int mv3accMLocatorEndIndex = importString.IndexOf("acmDCMmv3@@") + "acmDCMmv3@@".Length - 1;
            mv3accMod = Int32.Parse(importString.Substring(mv3accMLocatorEndIndex + 1, mv3dgeMLocatorStartIndex - mv3accMLocatorEndIndex-1));
            //Move 3 Dge Mod
            int mv3indMLocatorStartIndex = importString.IndexOf("indSTRTMmv3@@_!");
            int mv3dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv3@@") + "dgeDCMmv3@@".Length - 1;
            mv3dgeMod = Int32.Parse(importString.Substring(mv3dgeMLocatorEndIndex + 1, mv3indMLocatorStartIndex - mv3dgeMLocatorEndIndex-1));
            //Move 3 Induces
            int mv3ind2LocatorStartIndex = importString.IndexOf("indENDMmv3@@_!");
            int mv3indLocatorEndIndex = importString.IndexOf("indSTRTMmv3@@_!") + "indSTRTMmv3@@_!".Length - 1;
            string mv3Induces = importString.Substring(mv3indLocatorEndIndex + 1, mv3ind2LocatorStartIndex - mv3indLocatorEndIndex);
            if (mv3Induces.Substring(0, 1) == "y")
            {
                mv3IndStun = true;
            }
            else
            {
                mv3IndStun = false;
            }
            if (mv3Induces.Substring(1, 1) == "y")
            {
                mv3IndPsn = true;
            }
            else
            {
                mv3IndPsn = false;
            }
            if (mv3Induces.Substring(2, 1) == "y")
            {
                mv3IndBrn = true;
            }
            else
            {
                mv3IndBrn = false;
            }
            if (mv3Induces.Substring(3, 1) == "y")
            {
                mv3IndCrpl = true;
            }
            else
            {
                mv3IndCrpl = false;
            }
            if (mv3Induces.Substring(4, 1) == "y")
            {
                mv3IndFrzn = true;
            }
            else
            {
                mv3IndFrzn = false;
            }
            if (mv3Induces.Substring(5, 1) == "y")
            {
                mv3IndBld = true;
            }
            else
            {
                mv3IndBld = false;
            }
            if (mv3Induces.Substring(6, 1) == "y")
            {
                mv3IndStpf = true;
            }
            else
            {
                mv3IndStpf = false;
            }
            if (mv3Induces.Substring(7, 1) == "y")
            {
                mv3IndWk = true;
            }
            else
            {
                mv3IndWk = false;
            }
            if (mv3Induces.Substring(8, 1) == "y")
            {
                mv3IndDzz = true;
            }
            else
            {
                mv3IndDzz = false;
            }
            //Move 4 Name
            int mv4dLocatorStartIndex = importString.IndexOf("dDCMv4@@");
            int mv4nLocatorEndIndex = importString.IndexOf("nDCMmv4@@") + "nDCMmv4@@".Length - 1;
            mv4N = importString.Substring(mv4nLocatorEndIndex + 1, mv4dLocatorStartIndex - mv4nLocatorEndIndex-1);
            //Move 4 Desc
            int mv4tLocatorStartIndex = importString.IndexOf("tDCMmv4@@");
            int mv4dLocatorEndIndex = importString.IndexOf("dDCMv4@@") + "dDCMv4@@".Length - 1;
            mv4Desc = importString.Substring(mv4dLocatorEndIndex + 1, mv4tLocatorStartIndex - mv4dLocatorEndIndex-1);
            //Move 4 Type
            int mv4atmLocatorStartIndex = importString.IndexOf("atmDCMmv4@@");
            int mv4tLocatorEndIndex = importString.IndexOf("tDCMmv4@@") + "tDCMmv4@@".Length - 1;
            mv4Type = importString.Substring(mv4tLocatorEndIndex + 1, mv4atmLocatorStartIndex - mv4tLocatorEndIndex-1);
            //Move 4 Atk Multiplier
            int mv4accLocatorStartIndex = importString.IndexOf("accDCMmv4@@");
            int mv4atmLocatorEndIndex = importString.IndexOf("atmDCMmv4@@") + "atmDCMmv4@@".Length - 1;
            mv4m = float.Parse(importString.Substring(mv4atmLocatorEndIndex + 1, mv4accLocatorStartIndex - mv4atmLocatorEndIndex-1));
            //Move 4 Acc
            int mv4hLocatorStartIndex = importString.IndexOf("hDCMmv4@@");
            int mv4accLocatorEndIndex = importString.IndexOf("accDCMmv4@@") + "accDCMmv4@@".Length - 1;
            mv4acc = Int32.Parse(importString.Substring(mv4accLocatorEndIndex + 1, mv4hLocatorStartIndex - mv4accLocatorEndIndex-1));
            //Move 4 Healing
            int mv4atkMLocatorStartIndex = importString.IndexOf("atkDCMmv4@@");
            int mv4hLocatorEndIndex = importString.IndexOf("hDCMmv4@@") + "hDCMmv4@@".Length - 1;
            mv4Heal = Int32.Parse(importString.Substring(mv4hLocatorEndIndex + 1, mv4atkMLocatorStartIndex - mv4hLocatorEndIndex-1));
            //Move 4 Atk Mod
            int mv4defMLocatorStartIndex = importString.IndexOf("defDCMmv4@@");
            int mv4atkMLocatorEndIndex = importString.IndexOf("atkDCMmv4@@") + "atkDCMmv4@@".Length - 1;
            mv4atkMod = Int32.Parse(importString.Substring(mv4atkMLocatorEndIndex + 1, mv4defMLocatorStartIndex - mv4atkMLocatorEndIndex-1));
            //Move 4 Def Mod
            int mv4accMLocatorStartIndex = importString.IndexOf("acmDCMmv4@@");
            int mv4defMLocatorEndIndex = importString.IndexOf("defDCMmv4@@") + "defDCMmv4@@".Length - 1;
            mv4defMod = Int32.Parse(importString.Substring(mv4defMLocatorEndIndex + 1, mv4accMLocatorStartIndex - mv4defMLocatorEndIndex-1));
            //Move 4 Acc Mod
            int mv4dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv4@@");
            int mv4accMLocatorEndIndex = importString.IndexOf("acmDCMmv4@@") + "acmDCMmv4@@".Length - 1;
            mv4accMod = Int32.Parse(importString.Substring(mv4accMLocatorEndIndex + 1, mv4dgeMLocatorStartIndex - mv4accMLocatorEndIndex-1));
            //Move 4 Dge Mod
            int mv4indMLocatorStartIndex = importString.IndexOf("indSTRTMmv4@@_!");
            int mv4dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv4@@") + "dgeDCMmv4@@".Length - 1;
            mv4dgeMod = Int32.Parse(importString.Substring(mv4dgeMLocatorEndIndex + 1, mv4indMLocatorStartIndex - mv4dgeMLocatorEndIndex-1));
            //Move 4 Induces
            int mv4ind2LocatorStartIndex = importString.IndexOf("indENDMmv4@@_!");
            int mv4indLocatorEndIndex = importString.IndexOf("indSTRTMmv4@@_!") + "indSTRTMmv4@@_!".Length - 1;
            string mv4Induces = importString.Substring(mv4indLocatorEndIndex + 1, mv4ind2LocatorStartIndex - mv4indLocatorEndIndex);
            if (mv4Induces.Substring(0, 1) == "y")
            {
                mv4IndStun = true;
            }
            else
            {
                mv4IndStun = false;
            }
            if (mv4Induces.Substring(1, 1) == "y")
            {
                mv4IndPsn = true;
            }
            else
            {
                mv4IndPsn = false;
            }
            if (mv4Induces.Substring(2, 1) == "y")
            {
                mv4IndBrn = true;
            }
            else
            {
                mv4IndBrn = false;
            }
            if (mv4Induces.Substring(3, 1) == "y")
            {
                mv4IndCrpl = true;
            }
            else
            {
                mv4IndCrpl = false;
            }
            if (mv4Induces.Substring(4, 1) == "y")
            {
                mv4IndFrzn = true;
            }
            else
            {
                mv4IndFrzn = false;
            }
            if (mv4Induces.Substring(5, 1) == "y")
            {
                mv4IndBld = true;
            }
            else
            {
                mv4IndBld = false;
            }
            if (mv4Induces.Substring(6, 1) == "y")
            {
                mv4IndStpf = true;
            }
            else
            {
                mv4IndStpf = false;
            }
            if (mv4Induces.Substring(7, 1) == "y")
            {
                mv4IndWk = true;
            }
            else
            {
                mv4IndWk = false;
            }
            if (mv4Induces.Substring(8, 1) == "y")
            {
                mv4IndDzz = true;
            }
            else
            {
                mv4IndDzz = false;
            }
            //Move 5 Name
            int mv5dLocatorStartIndex = importString.IndexOf("dDCMv5@@");
            int mv5nLocatorEndIndex = importString.IndexOf("nDCMmv5@@") + "nDCMmv5@@".Length - 1;
            mv5N = importString.Substring(mv5nLocatorEndIndex + 1, mv5dLocatorStartIndex - mv5nLocatorEndIndex-1);
            //Move 5 Desc
            int mv5tLocatorStartIndex = importString.IndexOf("tDCMmv5@@");
            int mv5dLocatorEndIndex = importString.IndexOf("dDCMv5@@") + "dDCMv5@@".Length - 1;
            mv5Desc = importString.Substring(mv5dLocatorEndIndex + 1, mv5tLocatorStartIndex - mv5dLocatorEndIndex-1);
            //Move 5 Type
            int mv5atmLocatorStartIndex = importString.IndexOf("atmDCMmv5@@");
            int mv5tLocatorEndIndex = importString.IndexOf("tDCMmv5@@") + "tDCMmv5@@".Length - 1;
            mv5Type = importString.Substring(mv5tLocatorEndIndex + 1, mv5atmLocatorStartIndex - mv5tLocatorEndIndex-1);
            //Move 5 Atk Multiplier
            int mv5accLocatorStartIndex = importString.IndexOf("accDCMmv5@@");
            int mv5atmLocatorEndIndex = importString.IndexOf("atmDCMmv5@@") + "atmDCMmv5@@".Length - 1;
            mv5m = float.Parse(importString.Substring(mv5atmLocatorEndIndex + 1, mv5accLocatorStartIndex - mv5atmLocatorEndIndex-1));
            //Move 5 Acc
            int mv5hLocatorStartIndex = importString.IndexOf("hDCMmv5@@");
            int mv5accLocatorEndIndex = importString.IndexOf("accDCMmv5@@") + "accDCMmv5@@".Length - 1;
            mv5acc = Int32.Parse(importString.Substring(mv5accLocatorEndIndex + 1, mv5hLocatorStartIndex - mv5accLocatorEndIndex-1));
            //Move 5 Healing
            int mv5atkMLocatorStartIndex = importString.IndexOf("atkDCMmv5@@");
            int mv5hLocatorEndIndex = importString.IndexOf("hDCMmv5@@") + "hDCMmv5@@".Length - 1;
            mv5Heal = Int32.Parse(importString.Substring(mv5hLocatorEndIndex + 1, mv5atkMLocatorStartIndex - mv5hLocatorEndIndex-1));
            //Move 5 Atk Mod
            int mv5defMLocatorStartIndex = importString.IndexOf("defDCMmv5@@");
            int mv5atkMLocatorEndIndex = importString.IndexOf("atkDCMmv5@@") + "atkDCMmv5@@".Length - 1;
            mv5atkMod = Int32.Parse(importString.Substring(mv5atkMLocatorEndIndex + 1, mv5defMLocatorStartIndex - mv5atkMLocatorEndIndex-1));
            //Move 5 Def Mod
            int mv5accMLocatorStartIndex = importString.IndexOf("acmDCMmv5@@");
            int mv5defMLocatorEndIndex = importString.IndexOf("defDCMmv5@@") + "defDCMmv5@@".Length - 1;
            mv5defMod = Int32.Parse(importString.Substring(mv5defMLocatorEndIndex + 1, mv5accMLocatorStartIndex - mv5defMLocatorEndIndex-1));
            //Move 5 Acc Mod
            int mv5dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv5@@");
            int mv5accMLocatorEndIndex = importString.IndexOf("acmDCMmv5@@") + "acmDCMmv5@@".Length - 1;
            mv5accMod = Int32.Parse(importString.Substring(mv5accMLocatorEndIndex + 1, mv5dgeMLocatorStartIndex - mv5accMLocatorEndIndex-1));
            //Move 5 Dge Mod
            int mv5indMLocatorStartIndex = importString.IndexOf("indSTRTMmv5@@_!");
            int mv5dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv5@@") + "dgeDCMmv5@@".Length - 1;
            mv5dgeMod = Int32.Parse(importString.Substring(mv5dgeMLocatorEndIndex + 1, mv5indMLocatorStartIndex - mv5dgeMLocatorEndIndex-1));
            //Move 5 Induces
            int mv5ind2LocatorStartIndex = importString.IndexOf("indENDMmv5@@_!");
            int mv5indLocatorEndIndex = importString.IndexOf("indSTRTMmv5@@_!") + "indSTRTMmv5@@_!".Length - 1;
            string mv5Induces = importString.Substring(mv5indLocatorEndIndex + 1, mv5ind2LocatorStartIndex - mv5indLocatorEndIndex);
            if (mv5Induces.Substring(0, 1) == "y")
            {
                mv5IndStun = true;
            }
            else
            {
                mv5IndStun = false;
            }
            if (mv5Induces.Substring(1, 1) == "y")
            {
                mv5IndPsn = true;
            }
            else
            {
                mv5IndPsn = false;
            }
            if (mv5Induces.Substring(2, 1) == "y")
            {
                mv5IndBrn = true;
            }
            else
            {
                mv5IndBrn = false;
            }
            if (mv5Induces.Substring(3, 1) == "y")
            {
                mv5IndCrpl = true;
            }
            else
            {
                mv5IndCrpl = false;
            }
            if (mv5Induces.Substring(4, 1) == "y")
            {
                mv5IndFrzn = true;
            }
            else
            {
                mv5IndFrzn = false;
            }
            if (mv5Induces.Substring(5, 1) == "y")
            {
                mv5IndBld = true;
            }
            else
            {
                mv5IndBld = false;
            }
            if (mv5Induces.Substring(6, 1) == "y")
            {
                mv5IndStpf = true;
            }
            else
            {
                mv5IndStpf = false;
            }
            if (mv5Induces.Substring(7, 1) == "y")
            {
                mv5IndWk = true;
            }
            else
            {
                mv5IndWk = false;
            }
            if (mv5Induces.Substring(8, 1) == "y")
            {
                mv5IndDzz = true;
            }
            else
            {
                mv5IndDzz = false;
            }
        }

        //OVERARCHING VALUES - Note that these are imported to the PlayingCharacter class during battle, which contains real-time stats. These are just base values.

        //Typing
        private string charType; //Strings as seen above. Determined by a dropdown menu in creation screen.

        //Character Attributes
        //General
        private string charName;
        private string charDesc;
        //Values
        private int hp;
        private int atk;
        private int def;
        private int acc;
        private int dge;
        //Immunities
        private bool imnStun; //Can be stunned... etc.
        private bool imnPsn;
        private bool imnBrn;
        private bool imnCrpl;
        private bool imnFrzn;
        private bool imnBld;
        private bool imnStpf;
        private bool imnWk;
        private bool imnDzz;

        //Moves
        //Move 1
        //General data
        private string mv1N; //move name
        private string mv1Desc;
        private string mv1Type;
        private float mv1m; //move atk multiplier
        private int mv1acc; //move additional accuracy
                            //Modifiers
        private bool mv1IndStun; //induces stun?... etc.
        private bool mv1IndPsn;
        private bool mv1IndBrn;
        private bool mv1IndCrpl;
        private bool mv1IndFrzn;
        private bool mv1IndBld;
        private bool mv1IndStpf;
        private bool mv1IndWk;
        private bool mv1IndDzz;
        private int mv1Heal;
        private int mv1atkMod;
        private int mv1defMod;
        private int mv1accMod;
        private int mv1dgeMod;
        //Move 2
        //General data
        private string mv2N;
        private string mv2Desc;
        private string mv2Type;
        private float mv2m;
        private int mv2acc;
        //Modifiers
        private bool mv2IndStun;
        private bool mv2IndPsn;
        private bool mv2IndBrn;
        private bool mv2IndCrpl;
        private bool mv2IndFrzn;
        private bool mv2IndBld;
        private bool mv2IndStpf;
        private bool mv2IndWk;
        private bool mv2IndDzz;
        private int mv2Heal;
        private int mv2atkMod;
        private int mv2defMod;
        private int mv2accMod;
        private int mv2dgeMod;
        //Move 3
        //General data
        private string mv3N;
        private string mv3Desc;
        private string mv3Type;
        private float mv3m;
        private int mv3acc;
        //Modifiers
        private bool mv3IndStun;
        private bool mv3IndPsn;
        private bool mv3IndBrn;
        private bool mv3IndCrpl;
        private bool mv3IndFrzn;
        private bool mv3IndBld;
        private bool mv3IndStpf;
        private bool mv3IndWk;
        private bool mv3IndDzz;
        private int mv3Heal;
        private int mv3atkMod;
        private int mv3defMod;
        private int mv3accMod;
        private int mv3dgeMod;
        //Move 4
        //General data
        private string mv4N;
        private string mv4Desc;
        private string mv4Type;
        private float mv4m;
        private int mv4acc;
        //Modifiers
        private bool mv4IndStun;
        private bool mv4IndPsn;
        private bool mv4IndBrn;
        private bool mv4IndCrpl;
        private bool mv4IndFrzn;
        private bool mv4IndBld;
        private bool mv4IndStpf;
        private bool mv4IndWk;
        private bool mv4IndDzz;
        private int mv4Heal;
        private int mv4atkMod;
        private int mv4defMod;
        private int mv4accMod;
        private int mv4dgeMod;
        //Move 5
        //General data
        private string mv5N;
        private string mv5Desc;
        private string mv5Type;
        private float mv5m;
        private int mv5acc;
        //Modifiers
        private bool mv5IndStun;
        private bool mv5IndPsn;
        private bool mv5IndBrn;
        private bool mv5IndCrpl;
        private bool mv5IndFrzn;
        private bool mv5IndBld;
        private bool mv5IndStpf;
        private bool mv5IndWk;
        private bool mv5IndDzz;
        private int mv5Heal;
        private int mv5atkMod;
        private int mv5defMod;
        private int mv5accMod;
        private int mv5dgeMod;

        //Methods
        //Typing
        public string getType()
        {
            return charType;
        }
        public string getName()
        {
            return charName;
        }
        public string getDesc()
        {
            return charDesc;
        }
        //Attributes - Values
        public int getHP()
        {
            return hp;
        }
        public int getAtk()
        {
            return atk;
        }
        public int getDef()
        {
            return def;
        }
        public int getAcc()
        {
            return acc;
        }
        public int getDge()
        {
            return dge;
        }
        //Attributes - Tendencies
        public bool getimnStun()
        {
            return imnStun;
        }
        public bool getimnPsn()
        {
            return imnPsn;
        }
        public bool getimnBrn()
        {
            return imnBrn;
        }
        public bool getimnCrpl()
        {
            return imnCrpl;
        }
        public bool getimnFrzn()
        {
            return imnFrzn;
        }
        public bool getimnBld()
        {
            return imnBld;
        }
        public bool getimnStpf()
        {
            return imnStpf;
        }
        public bool getimnWk()
        {
            return imnWk;
        }
        public bool getimnDzz()
        {
            return imnDzz;
        }
        //Move 1 - Attributes
        public string getMv1Name()
        {
            return mv1N;
        }
        public string getMv1Desc()
        {
            return mv1Desc;
        }
        public string getMv1Type()
        {
            return mv1Type;
        }
        public float getMv1M()
        {
            return mv1m;
        }
        public int getMv1Acc()
        {
            return mv1acc;
        }
        //Move 1 - Modifiers
        public bool getMv1indStun()
        {
            return mv1IndStun;
        }
        public bool getMv1indPsn()
        {
            return mv1IndPsn;
        }
        public bool getMv1indBrn()
        {
            return mv1IndBrn;
        }
        public bool getMv1indCrpl()
        {
            return mv1IndCrpl;
        }
        public bool getMv1indFrzn()
        {
            return mv1IndFrzn;
        }
        public bool getMv1indBld()
        {
            return mv1IndBld;
        }
        public bool getMv1indStpf()
        {
            return mv1IndStpf;
        }
        public bool getMv1indWk()
        {
            return mv1IndWk;
        }
        public bool getMv1indDzz()
        {
            return mv1IndDzz;
        }
        public int getMv1Heal()
        {
            return mv1Heal;
        }
        public int getMv1AtkMod()
        {
            return mv1atkMod;
        }
        public int getMv1DefMod()
        {
            return mv1defMod;
        }
        public int getMv1AccMod()
        {
            return mv1accMod;
        }
        public int getMv1DgeMod()
        {
            return mv1dgeMod;
        }
        //Move 2 - Attributes
        public string getMv2Name()
        {
            return mv2N;
        }
        public string getMv2Desc()
        {
            return mv2Desc;
        }
        public string getMv2Type()
        {
            return mv2Type;
        }
        public float getMv2M()
        {
            return mv2m;
        }
        public int getMv2Acc()
        {
            return mv2acc;
        }
        //Move 2 - Modifiers
        public bool getMv2indStun()
        {
            return mv2IndStun;
        }
        public bool getMv2indPsn()
        {
            return mv2IndPsn;
        }
        public bool getMv2indBrn()
        {
            return mv2IndBrn;
        }
        public bool getMv2indCrpl()
        {
            return mv2IndCrpl;
        }
        public bool getMv2indFrzn()
        {
            return mv2IndFrzn;
        }
        public bool getMv2indBld()
        {
            return mv2IndBld;
        }
        public bool getMv2indStpf()
        {
            return mv2IndStpf;
        }
        public bool getMv2indWk()
        {
            return mv2IndWk;
        }
        public bool getMv2indDzz()
        {
            return mv2IndDzz;
        }
        public int getMv2Heal()
        {
            return mv2Heal;
        }
        public int getMv2AtkMod()
        {
            return mv2atkMod;
        }
        public int getMv2DefMod()
        {
            return mv2defMod;
        }
        public int getMv2AccMod()
        {
            return mv2accMod;
        }
        public int getMv2DgeMod()
        {
            return mv1dgeMod;
        }
        //Move 3 - Attributes
        public string getMv3Name()
        {
            return mv3N;
        }
        public string getMv3Desc()
        {
            return mv3Desc;
        }
        public string getMv3Type()
        {
            return mv3Type;
        }
        public float getMv3M()
        {
            return mv3m;
        }
        public int getMv3Acc()
        {
            return mv3acc;
        }
        //Move 3 - Modifiers
        public bool getMv3indStun()
        {
            return mv3IndStun;
        }
        public bool getMv3indPsn()
        {
            return mv3IndPsn;
        }
        public bool getMv3indBrn()
        {
            return mv3IndBrn;
        }
        public bool getMv3indCrpl()
        {
            return mv3IndCrpl;
        }
        public bool getMv3indFrzn()
        {
            return mv3IndFrzn;
        }
        public bool getMv3indBld()
        {
            return mv3IndBld;
        }
        public bool getMv3indStpf()
        {
            return mv3IndStpf;
        }
        public bool getMv3indWk()
        {
            return mv3IndWk;
        }
        public bool getMv3indDzz()
        {
            return mv3IndDzz;
        }
        public int getMv3Heal()
        {
            return mv3Heal;
        }
        public int getMv3AtkMod()
        {
            return mv3atkMod;
        }
        public int getMv3DefMod()
        {
            return mv3defMod;
        }
        public int getMv3AccMod()
        {
            return mv3accMod;
        }
        public int getMv3DgeMod()
        {
            return mv3dgeMod;
        }
        //Move 4 - Attributes
        public string getMv4Name()
        {
            return mv4N;
        }
        public string getMv4Desc()
        {
            return mv4Desc;
        }
        public string getMv4Type()
        {
            return mv4Type;
        }
        public float getMv4M()
        {
            return mv1m;
        }
        public int getMv4Acc()
        {
            return mv1acc;
        }
        //Move 4 - Modifiers
        public bool getMv4indStun()
        {
            return mv4IndStun;
        }
        public bool getMv4indPsn()
        {
            return mv4IndPsn;
        }
        public bool getMv4indBrn()
        {
            return mv4IndBrn;
        }
        public bool getMv4indCrpl()
        {
            return mv4IndCrpl;
        }
        public bool getMv4indFrzn()
        {
            return mv4IndFrzn;
        }
        public bool getMv4indBld()
        {
            return mv4IndBld;
        }
        public bool getMv4indStpf()
        {
            return mv4IndStpf;
        }
        public bool getMv4indWk()
        {
            return mv4IndWk;
        }
        public bool getMv4indDzz()
        {
            return mv4IndDzz;
        }
        public int getMv4Heal()
        {
            return mv4Heal;
        }
        public int getMv4AtkMod()
        {
            return mv4atkMod;
        }
        public int getMv4DefMod()
        {
            return mv4defMod;
        }
        public int getMv4AccMod()
        {
            return mv4accMod;
        }
        public int getMv4DgeMod()
        {
            return mv4dgeMod;
        }
        //Move 5 - Attributes
        public string getMv5Name()
        {
            return mv5N;
        }
        public string getMv5Desc()
        {
            return mv5Desc;
        }
        public string getMv5Type()
        {
            return mv5Type;
        }
        public float getMv5M()
        {
            return mv5m;
        }
        public int getMv5Acc()
        {
            return mv5acc;
        }
        //Move 5 - Modifiers
        public bool getMv5indStun()
        {
            return mv5IndStun;
        }
        public bool getMv5indPsn()
        {
            return mv5IndPsn;
        }
        public bool getMv5indBrn()
        {
            return mv5IndBrn;
        }
        public bool getMv5indCrpl()
        {
            return mv5IndCrpl;
        }
        public bool getMv5indFrzn()
        {
            return mv5IndFrzn;
        }
        public bool getMv5indBld()
        {
            return mv5IndBld;
        }
        public bool getMv5indStpf()
        {
            return mv5IndStpf;
        }
        public bool getMv5indWk()
        {
            return mv5IndWk;
        }
        public bool getMv5indDzz()
        {
            return mv5IndDzz;
        }
        public int getMv5Heal()
        {
            return mv5Heal;
        }
        public int getMv5AtkMod()
        {
            return mv5atkMod;
        }
        public int getMv5DefMod()
        {
            return mv5defMod;
        }
        public int getMv5AccMod()
        {
            return mv5accMod;
        }
        public int getMv5DgeMod()
        {
            return mv5dgeMod;
        }

        //In-match modifications
            /*Status effects and turns
             * Stuns: 1 turn, can't attack
             * Poisoned: 3 turns, -3% HP and ATK x 0.9
             * Burned: 5 turns, -3% HP
             * Crippled: 3 turns, DEF x 0.75
             * Frozen: 1 turn, can't attack
             * Bleeding: 5 turns, -3% HP and ACC - 20
             * Stupefied: 2 turns, 50% chance to not attack
             * Weak: 3 turns, ATK x 0.75
             * Dizzy: 3 turns, ACC - 25
             */
        private bool isStunned = false;
        private int stunTurns = 0;
        private bool isPoisoned = false;
        private int poisonTurns = 0;
        private bool isBurned = false;
        private int burnTurns = 0;
        private bool isCrippled = false;
        private int crippleTurns = 0;
        private bool isFrozen = false;
        private int frozenTurns = 0;
        private bool isBleeding = false;
        private int bleedingTurns = 0;
        private bool isStupefied = false;
        private int stupefiedTurns = 0;
        private bool isWeak = false;
        private int weakTurns = 0;
        private bool isDizzy = false;
        private int dizzyTurns = 0;

        public void modifyHP(int HPMod)
        {
            hp += HPMod;
        }
        public void modifyATK(int atkMod)
        {
            atk += atkMod;
        }
        public void modifyDEF(int defMod)
        {
            def += defMod;
        }
        public void modifyACC(int accMod)
        {
            acc += accMod;
        }
        public void modifyDGE(int dgeMod)
        {
            dge += dgeMod;
        }

        //If vals are zero
        public void setHp(int set)
        {
            hp = set;
        }
            //Get statuses
        public bool getIsStunned()
        {
            return isStunned;
        }
        public bool getIsPoisoned()
        {
            return isPoisoned;
        }
        public bool getIsBurned()
        {
            return isBurned;
        }
        public bool getIsCrippled()
        {
            return isCrippled;
        }
        public bool getIsFrozen()
        {
            return isFrozen;
        }
        public bool getIsBleeding()
        {
            return isBleeding;
        }
        public bool getIsStupefied()
        {
            return isStupefied;
        }
        public bool getIsWeak()
        {
            return isWeak;
        }
        public bool getIsDizzy()
        {
            return isDizzy;
        }

        public void induceStun()
        {
            isStunned = true;
            stunTurns = 1;
        }
        public void inducePoison()
        {
            isPoisoned = true;
            poisonTurns = 3;
        }
        public void induceBurn()
        {
            isBurned = true;
            burnTurns = 5;
        }
        public void induceCripple()
        {
            isCrippled = true;
            crippleTurns = 3;
        }
        public void induceFrozen()
        {
            isFrozen = true;
            frozenTurns = 1;
        }
        public void induceBleeding()
        {
            isBleeding = true;
            bleedingTurns = 5;
        }
        public void induceStupefy()
        {
            isStupefied = true;
            stupefiedTurns = 2;
        }
        public void induceWeak()
        {
            isWeak = true;
            weakTurns = 3;
        }
        public void induceDizzy()
        {
            isDizzy = true;
            dizzyTurns = 3;
        }

            //Modify turns - THIS IS ALWAYS DONE AFTER THE MOVE IS OVER
        public void modifyStatusTurns()
        {
            if(stunTurns != 0)
            {
                stunTurns--;
                if(stunTurns == 0)
                {
                    isStunned = false;
                }
            }
            if(poisonTurns != 0)
            {
                poisonTurns--;
                if(poisonTurns == 0)
                {
                    isPoisoned = false;
                }
            }
            if (burnTurns != 0)
            {
                burnTurns--;
                if (burnTurns == 0)
                {
                    isBurned = false;
                }
            }
            if(crippleTurns != 0)
            {
                crippleTurns--;
                if(crippleTurns == 0)
                {
                    isCrippled = false;
                }
            }
            if(frozenTurns != 0)
            {
                frozenTurns--;
                if(frozenTurns == 0)
                {
                    isFrozen = false;
                }
            }
            if(bleedingTurns != 0)
            {
                bleedingTurns--;
                if(bleedingTurns == 0)
                {
                    isBleeding = false;
                }
            }
            if(stupefiedTurns != 0)
            {
                stupefiedTurns--;
                if(stupefiedTurns == 0)
                {
                    isStupefied = false;
                }
            }
            if(weakTurns != 0)
            {
                weakTurns--;
                if(weakTurns == 0)
                {
                    isWeak = false;
                }
            }
            if(dizzyTurns != 0)
            {
                dizzyTurns--;
                if(dizzyTurns == 0)
                {
                    isDizzy = false;
                }
            }
        }
    }
}
