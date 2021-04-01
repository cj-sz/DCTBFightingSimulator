using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTBFightingSimulator
{
    class ImportExportString
    {
        /*Import / Export String Class
         * This class can get data from a variety of fields by being called from certain methods and buttons in the character creation interface.
         * It generates a prodecural string, which can then be exported, and then read by the character class.
         * All fields must be filled out to generate a string.
         * See the main method for details.
         */
        //Guide for creating strings procedurally (split into smaller funcs)
        /*First, do checks to ensure all fields filled out and valid. Checks are performed in the main form class.
             * Identifiers:
             * Name: "nX!wj@am!E" (restriction check)
             * Desc: "d@3MDMe#SC" (restriction check)
             * Type: "t192y!@:PE22"
             * ATK: "at1!@!W0k"
             * DEF: "d%%23eFF"
             * ACC: "a1;c';c"
             * DGE: "dj1g><e"
             * Immunities:
             *      Stun: "i!n!d!STN99@"
             *      Poison: "i!n!d!PSN99@"
             *      Burn: "i!n!d!BRN99@"
             *      Cripple: "i!n!d!CRP99@"
             *      Frozen: "i!n!d!FRZ99@"
             *      Bleeding: "i!n!d!BLD99@"
             *      Stupefied: "i!n!d!STP99@"
             *      Weak: "i!n!d!WAK99@"
             *      Dizzy: "i!n!d!DZY99@"
             * Move 1:
             *      Name: "nDCMmv1@@" (restriction check)
             *      Desc: "dDCMv1@@" (restriction check)
             *      Type: "tDCMmv1@@"
             *      Atk Mult: "atmDCMmv1@@"
             *      ACC: "accDCMmv1@@"
             *      Heal: "hDCMmv1@@"
             *      ATK Mod: "atkDCMmv1@@"
             *      DEF Mod: "defDCMmv1@@"
             *      ACC Mod: "acmDCMmv1@@"
             *      DGE Mod: "dgeDCMmv1@@"
             *      Induces:
             *          Stun: "stnDCMmv1@@"
             *          Poison: "psnDCMmv1@@"
             *          Burn: "brnDCMmv1@@"
             *          Cripple: "crplDCMmv1@@"
             *          Frozen: "frznDCMmv1@@"
             *          Bleeding: "bldDCMmv1@@"
             *          Stupefied: "stpfDCMmv1@@"
             *          Weak: "wkDCMmv1@@"
             *          Dizzy: "dzyDCMmv1@@"
             * All other moves are the same, but with the number changed to the number of the respective move.
             * Generate string based on given values.
             */
        private string importExportString;

        public ImportExportString()
        {
            //Empty constructor, done by methods below.
        }

        public void generateAttributesStringPart(string n, string d, string t, int atk, int def, int acc, int dge)
        {
            
        }
        public string getImportExportString()
        {
            return importExportString;
        }
    }
}
