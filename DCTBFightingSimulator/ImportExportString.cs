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
             *          end indicated by "indENDMmv1@@_!"
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
            importExportString = importExportString + "imnEND@@_!";
        }
        public void generateMoveOneStringPart(string n, string d, string t, float atm, int acc, int h, int atkM, int defM, int accM, int dgeM, bool[] induces)
        {
            importExportString = importExportString + "nDCMmv1@@" + n + "dDCMv1@@" + d + "tDCMmv1@@" + t + "atmDCMmv1@@" + atm.ToString() + "accDCMmv1@@" + acc.ToString() + "hDCMmv1@@" + h.ToString() + "atkDCMmv1@@" + atkM.ToString() + "defDCMmv1@@" + defM.ToString() + "acmDCMmv1@@" + accM.ToString() + "dgeDCMmv1@@" + dgeM.ToString();
            importExportString = importExportString + "indSTRTMmv1@@_!";
            for(int i = 0; i < induces.Length; i++)
            {
                if(induces[i] == true)
                {
                    importExportString = importExportString + "y";
                }
                else
                {
                    importExportString = importExportString + "n";
                }
            }
            importExportString = importExportString + "indENDMmv1@@_!";
        }
        public void generateMoveTwoStringPart(string n, string d, string t, float atm, int acc, int h, int atkM, int defM, int accM, int dgeM, bool[] induces)
        {
            importExportString = importExportString + "nDCMmv2@@" + n + "dDCMv2@@" + d + "tDCMmv2@@" + t + "atmDCMmv2@@" + atm.ToString() + "accDCMmv2@@" + acc.ToString() + "hDCMmv2@@" + h.ToString() + "atkDCMmv2@@" + atkM.ToString() + "defDCMmv2@@" + defM.ToString() + "acmDCMmv2@@" + accM.ToString() + "dgeDCMmv2@@" + dgeM.ToString();
            importExportString = importExportString + "indSTRTMmv2@@_!";
            for (int i = 0; i < induces.Length; i++)
            {
                if (induces[i] == true)
                {
                    importExportString = importExportString + "y";
                }
                else
                {
                    importExportString = importExportString + "n";
                }
            }
            importExportString = importExportString + "indENDMmv2@@_!";
        }
        public void generateMoveThreeStringPart(string n, string d, string t, float atm, int acc, int h, int atkM, int defM, int accM, int dgeM, bool[] induces)
        {
            importExportString = importExportString + "nDCMmv3@@" + n + "dDCMv3@@" + d + "tDCMmv3@@" + t + "atmDCMmv3@@" + atm.ToString() + "accDCMmv3@@" + acc.ToString() + "hDCMmv3@@" + h.ToString() + "atkDCMmv3@@" + atkM.ToString() + "defDCMmv3@@" + defM.ToString() + "acmDCMmv3@@" + accM.ToString() + "dgeDCMmv3@@" + dgeM.ToString();
            importExportString = importExportString + "indSTRTMmv3@@_!";
            for (int i = 0; i < induces.Length; i++)
            {
                if (induces[i] == true)
                {
                    importExportString = importExportString + "y";
                }
                else
                {
                    importExportString = importExportString + "n";
                }
            }
            importExportString = importExportString + "indENDMmv3@@_!";
        }
        public void generateMoveFourStringPart(string n, string d, string t, float atm, int acc, int h, int atkM, int defM, int accM, int dgeM, bool[] induces)
        {
            importExportString = importExportString + "nDCMmv4@@" + n + "dDCMv4@@" + d + "tDCMmv4@@" + t + "atmDCMmv4@@" + atm.ToString() + "accDCMmv4@@" + acc.ToString() + "hDCMmv4@@" + h.ToString() + "atkDCMmv4@@" + atkM.ToString() + "defDCMmv4@@" + defM.ToString() + "acmDCMmv4@@" + accM.ToString() + "dgeDCMmv4@@" + dgeM.ToString();
            importExportString = importExportString + "indSTRTMmv4@@_!";
            for (int i = 0; i < induces.Length; i++)
            {
                if (induces[i] == true)
                {
                    importExportString = importExportString + "y";
                }
                else
                {
                    importExportString = importExportString + "n";
                }
            }
            importExportString = importExportString + "indENDMmv4@@_!";
        }
        public void generateMoveFiveStringPart(string n, string d, string t, float atm, int acc, int h, int atkM, int defM, int accM, int dgeM, bool[] induces)
        {
            importExportString = importExportString + "nDCMmv5@@" + n + "dDCMv5@@" + d + "tDCMmv5@@" + t + "atmDCMmv5@@" + atm.ToString() + "accDCMmv5@@" + acc.ToString() + "hDCMmv5@@" + h.ToString() + "atkDCMmv5@@" + atkM.ToString() + "defDCMmv5@@" + defM.ToString() + "acmDCMmv5@@" + accM.ToString() + "dgeDCMmv5@@" + dgeM.ToString();
            importExportString = importExportString + "indSTRTMmv5@@_!";
            for (int i = 0; i < induces.Length; i++)
            {
                if (induces[i] == true)
                {
                    importExportString = importExportString + "y";
                }
                else
                {
                    importExportString = importExportString + "n";
                }
            }
            importExportString = importExportString + "indENDMmv5@@_!";
        }

        public string getImportExportString()
        {
            return importExportString;
        }
    }
}
