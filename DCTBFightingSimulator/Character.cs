using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
         */

        //Constructor (takes an input string)
        public Character(ImportExportString importString)
        {

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
            //Tendencies
        private bool cbStun; //Can be stunned... etc.
        private bool cbPsn;
        private bool cbBrn;
        private bool cbCrpl;
        private bool cbFrzn;
        private bool cbBld;
        private bool cbStpf;
        private bool cbWk;
        private bool cbDzz;

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
        public bool getcbStun()
        {
            return cbStun;
        }
        public bool getcbPsn()
        {
            return cbPsn;
        }
        public bool getcbBrn()
        {
            return cbBrn;
        }
        public bool getcbCrpl()
        {
            return cbCrpl;
        }
        public bool getcbFrzn()
        {
            return cbFrzn;
        }
        public bool getcbBld()
        {
            return cbBld;
        }
        public bool getcbStpf()
        {
            return cbStpf;
        }
        public bool getcbWk()
        {
            return cbWk;
        }
        public bool getcbDzz()
        {
            return cbDzz;
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
    }
}
