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
             *      y/n for all
             *      Start indicated by "imnSTRT@@_!"
             *      end indicated by "imnEND@@_!"
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
             *          y/n for all
             *          start indicated by "indSTRTMmv1@@_!"
             *          end indicated by indENDMmv1@@_!"
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
            importExportString = "";
            importExportString = importExportString + "nX!wj@am!E" + n + "d@3MDMe#SC" + d + "t192y!@:PE22" + t + "at1!@!W0k" + atk.ToString() + "d%%23eFF" + def.ToString() + "a1;c';c" + acc.ToString() + "dj1g><e" + dge.ToString();
        }
        public void generateImmunitiesStringPart(bool[] immunities)
        {
            importExportString = importExportString + "imnSTRT@@_!";
            for(int index = 0; index < immunities.Length; index++)
            {
                if(immunities[index] == true)
                {
                    importExportString = importExportString + "y";
                }
                else
                {
                    importExportString = importExportString + "n";
                }
            }
        }
        public string getImportExportString()
        {
            return importExportString;
        }
    }
}
