using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCTBFightingSimulator
{
    public partial class DCTBFightingSimulator : Form
    {
        public DCTBFightingSimulator()
        {
            InitializeComponent();
            disableAllElementalUI();
            welcomeLabel1.Enabled = true;
            welcomeLabel2.Enabled = true;
            welcomeLabel1.Show();
            welcomeLabel2.Show();
        }

        //Button methods
        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Welcome to DCTBFightingSimulator v0.0.1. Please visit www.github.com/CJ5-Z/DCTBFightingSimulator to view the main page. In this simulator, you can use pre-existing builds or create your own to engage in simulated or interactive 1v1 fights in EvE, PvE, or PvP. You can also submit your own builds by generating an export string for any of your created builds and submitting the string through github. Please see the tooltips for additional information on the different aspects of the simulator; a comprehensive tutorial and instruction will be coming soon in a later version. Feel free to leave any questions, comments, or suggestions on the github page.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.github.com/CJ5-Z/DCTBFightingSimulator");
        }

        private void changelogButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Changelog (v0.0.1):" + Environment.NewLine + "- Initial version of DCTBFightingSimulator! Contains EvE, PvE, and PvP base functionality with a collection of quite a few different units. Additionally, functionality for creating a character is available.");
        }

        private void roadmapButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Roadmap:" + Environment.NewLine + "- Updated UI and UI cleanup" + Environment.NewLine + "- New, unique characters and movesets" + Environment.NewLine + "- Tutorial and further explanation of mechanics and functions");
        }

        //Character Creation Methods
        private void createCharButton_Click(object sender, EventArgs e)
        {
            disableAllElementalUI();
            enableCharButtonElementalUI();
        }
            //Export a Build
        private void exportCharStringButton_Click(object sender, EventArgs e)
        {
            //Generate the string
            ImportExportString importExportString = new ImportExportString();
            //General Attr
            string n = CCT1.Text;
            string d = CCT2.Text;
            string t = CCc1.Text;
            string[] ndt = new string[3];
            ndt[0] = n;
            ndt[1] = d;
            ndt[2] = t;
            for(int i = 0; i < ndt.Length; i++)
            {
                bool able = checkStringRestrictions(ndt[i]);
                if(able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type.");
                    return;
                }
            }
            int hp = (int)CCN40.Value;
            int atk = (int)CCN1.Value;
            int def = (int)CCN2.Value;
            int acc = (int)CCN3.Value;
            int dge = (int)CCN4.Value;
            importExportString.generateAttributesStringPart(n, d, t, hp, atk, def, acc, dge);
            //Immunities Attr
            bool[] immunities = new bool[9];
            string[] imnSel = new string[9];
            imnSel[0] = CCc2.Text;
            imnSel[1] = CCc3.Text;
            imnSel[2] = CCc4.Text;
            imnSel[3] = CCc5.Text;
            imnSel[4] = CCc6.Text;
            imnSel[5] = CCc7.Text;
            imnSel[6] = CCc8.Text;
            imnSel[7] = CCc9.Text;
            imnSel[8] = CCc10.Text;
            for(int i = 0; i < imnSel.Length; i++)
            {
                if(imnSel[i] == "YES")
                {
                    immunities[i] = true;
                }
                else if(imnSel[i] == "NO")
                {
                    immunities[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's immunity. Please check immunities and try again.");
                    return;
                }
            }
            importExportString.generateImmunitiesStringPart(immunities);
            //Move 1 Attr
            string m1n = CCT3.Text;
            string m1d = CCT4.Text;
            string m1t = CCc11.Text;
            string[] m1s = new string[3];
            m1s[0] = m1n;
            m1s[1] = m1d;
            m1s[2] = m1t;
            for (int i = 0; i < m1s.Length; i++)
            {
                bool able = checkStringRestrictions(m1s[i]);
                if (able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type for Move 1.");
                    return;
                }
            }
            float m1atkmm = (float)CCN5.Value;
            int m1acc = (int)CCN6.Value;
            int m1h = (int)CCN7.Value;
            int m1atkM = (int)CCN8.Value;
            int m1defM = (int)CCN9.Value;
            int m1accM = (int)CCN10.Value;
            int m1dgeM = (int)CCN11.Value;
            bool[] move1InducesBools = new bool[9];
            string[] move1InducesSelections = new string[9];
            move1InducesSelections[0] = CCc12.Text;
            move1InducesSelections[1] = CCc13.Text;
            move1InducesSelections[2] = CCc14.Text;
            move1InducesSelections[3] = CCc15.Text;
            move1InducesSelections[4] = CCc16.Text;
            move1InducesSelections[5] = CCc17.Text;
            move1InducesSelections[6] = CCc18.Text;
            move1InducesSelections[7] = CCc19.Text;
            move1InducesSelections[8] = CCc20.Text;
            for(int i = 0; i < move1InducesSelections.Length; i++)
            {
                if(move1InducesSelections[i] == "YES")
                {
                    move1InducesBools[i] = true;
                }else if(move1InducesSelections[i] == "NO")
                {
                    move1InducesBools[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's Move 1 induced status effects.");
                    return;
                }
            }
            importExportString.generateMoveOneStringPart(m1n, m1d, m1t, m1atkmm, m1acc, m1h, m1atkM, m1defM, m1accM, m1dgeM, move1InducesBools);
            //Move 2
            string m2n = CCT5.Text;
            string m2d = CCT6.Text;
            string m2t = CCc21.Text;
            string[] m2s = new string[3];
            m2s[0] = m2n;
            m2s[1] = m2d;
            m2s[2] = m2t;
            for (int i = 0; i < m2s.Length; i++)
            {
                bool able = checkStringRestrictions(m2s[i]);
                if (able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type for Move 2.");
                    return;
                }
            }
            float m2atkmm = (float)CCN12.Value;
            int m2acc = (int)CCN13.Value;
            int m2h = (int)CCN14.Value;
            int m2atkM = (int)CCN15.Value;
            int m2defM = (int)CCN16.Value;
            int m2accM = (int)CCN17.Value;
            int m2dgeM = (int)CCN18.Value;
            bool[] move2InducesBools = new bool[9];
            string[] move2InducesSelections = new string[9];
            move2InducesSelections[0] = CCc22.Text;
            move2InducesSelections[1] = CCc23.Text;
            move2InducesSelections[2] = CCc24.Text;
            move2InducesSelections[3] = CCc30.Text;
            move2InducesSelections[4] = CCc25.Text;
            move2InducesSelections[5] = CCc26.Text;
            move2InducesSelections[6] = CCc27.Text;
            move2InducesSelections[7] = CCc28.Text;
            move2InducesSelections[8] = CCc29.Text;
            for (int i = 0; i < move2InducesSelections.Length; i++)
            {
                if (move2InducesSelections[i] == "YES")
                {
                    move2InducesBools[i] = true;
                }
                else if (move2InducesSelections[i] == "NO")
                {
                    move2InducesBools[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's Move 2 induced status effects.");
                    return;
                }
            }
            importExportString.generateMoveTwoStringPart(m2n, m2d, m2t, m2atkmm, m2acc, m2h, m2atkM, m2defM, m2accM, m2dgeM, move2InducesBools);
            //Move 3
            string m3n = CCT7.Text;
            string m3d = CCT8.Text;
            string m3t = CCc31.Text;
            string[] m3s = new string[3];
            m3s[0] = m3n;
            m3s[1] = m3d;
            m3s[2] = m3t;
            for (int i = 0; i < m3s.Length; i++)
            {
                bool able = checkStringRestrictions(m3s[i]);
                if (able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type for Move 3.");
                    return;
                }
            }
            float m3atkmm = (float)CCN19.Value;
            int m3acc = (int)CCN20.Value;
            int m3h = (int)CCN21.Value;
            int m3atkM = (int)CCN22.Value;
            int m3defM = (int)CCN23.Value;
            int m3accM = (int)CCN24.Value;
            int m3dgeM = (int)CCN25.Value;
            bool[] move3InducesBools = new bool[9];
            string[] move3InducesSelections = new string[9];
            move3InducesSelections[0] = CCc32.Text;
            move3InducesSelections[1] = CCc33.Text;
            move3InducesSelections[2] = CCc34.Text;
            move3InducesSelections[3] = CCc35.Text;
            move3InducesSelections[4] = CCc36.Text;
            move3InducesSelections[5] = CCc37.Text;
            move3InducesSelections[6] = CCc38.Text;
            move3InducesSelections[7] = CCc39.Text;
            move3InducesSelections[8] = CCc40.Text;
            for (int i = 0; i < move3InducesSelections.Length; i++)
            {
                if (move3InducesSelections[i] == "YES")
                {
                    move3InducesBools[i] = true;
                }
                else if (move3InducesSelections[i] == "NO")
                {
                    move3InducesBools[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's Move 3 induced status effects.");
                    return;
                }
            }
            importExportString.generateMoveThreeStringPart(m3n, m3d, m3t, m3atkmm, m3acc, m3h, m3atkM, m3defM, m3accM, m3dgeM, move3InducesBools);
            //Move 4
            string m4n = CCT9.Text;
            string m4d = CCT10.Text;
            string m4t = CCc41.Text;
            string[] m4s = new string[3];
            m4s[0] = m4n;
            m4s[1] = m4d;
            m4s[2] = m4t;
            for (int i = 0; i < m4s.Length; i++)
            {
                bool able = checkStringRestrictions(m4s[i]);
                if (able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type for Move 4.");
                    return;
                }
            }
            float m4atkmm = (float)CCN26.Value;
            int m4acc = (int)CCN27.Value;
            int m4h = (int)CCN28.Value;
            int m4atkM = (int)CCN29.Value;
            int m4defM = (int)CCN30.Value;
            int m4accM = (int)CCN31.Value;
            int m4dgeM = (int)CCN32.Value;
            bool[] move4InducesBools = new bool[9];
            string[] move4InducesSelections = new string[9];
            move4InducesSelections[0] = CCc42.Text;
            move4InducesSelections[1] = CCc43.Text;
            move4InducesSelections[2] = CCc44.Text;
            move4InducesSelections[3] = CCc45.Text;
            move4InducesSelections[4] = CCc46.Text;
            move4InducesSelections[5] = CCc47.Text;
            move4InducesSelections[6] = CCc48.Text;
            move4InducesSelections[7] = CCc49.Text;
            move4InducesSelections[8] = CCc50.Text;
            for (int i = 0; i < move4InducesSelections.Length; i++)
            {
                if (move4InducesSelections[i] == "YES")
                {
                    move4InducesBools[i] = true;
                }
                else if (move4InducesSelections[i] == "NO")
                {
                    move4InducesBools[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's Move 4 induced status effects.");
                    return;
                }
            }
            importExportString.generateMoveFourStringPart(m4n, m4d, m4t, m4atkmm, m4acc, m4h, m4atkM, m4defM, m4accM, m4dgeM, move4InducesBools);
            //Move 5
            string m5n = CCT11.Text;
            string m5d = CCT12.Text;
            string m5t = CCc51.Text;
            string[] m5s = new string[3];
            m5s[0] = m5n;
            m5s[1] = m5d;
            m5s[2] = m5t;
            for (int i = 0; i < m5s.Length; i++)
            {
                bool able = checkStringRestrictions(m5s[i]);
                if (able == false)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Invalid name, description, or type for Move 5.");
                    return;
                }
            }
            float m5atkmm = (float)CCN33.Value;
            int m5acc = (int)CCN34.Value;
            int m5h = (int)CCN35.Value;
            int m5atkM = (int)CCN36.Value;
            int m5defM = (int)CCN37.Value;
            int m5accM = (int)CCN38.Value;
            int m5dgeM = (int)CCN39.Value;
            bool[] move5InducesBools = new bool[9];
            string[] move5InducesSelections = new string[9];
            move5InducesSelections[0] = CCc52.Text;
            move5InducesSelections[1] = CCc53.Text;
            move5InducesSelections[2] = CCc54.Text;
            move5InducesSelections[3] = CCc55.Text;
            move5InducesSelections[4] = CCc56.Text;
            move5InducesSelections[5] = CCc57.Text;
            move5InducesSelections[6] = CCc58.Text;
            move5InducesSelections[7] = CCc59.Text;
            move5InducesSelections[8] = CCc60.Text;
            for (int i = 0; i < move5InducesSelections.Length; i++)
            {
                if (move5InducesSelections[i] == "YES")
                {
                    move5InducesBools[i] = true;
                }
                else if (move5InducesSelections[i] == "NO")
                {
                    move5InducesBools[i] = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: invalid value assigned to a character's Move 5 induced status effects.");
                    return;
                }
            }
            importExportString.generateMoveFiveStringPart(m5n, m5d, m5t, m5atkmm, m5acc, m5h, m5atkM, m5defM, m5accM, m5dgeM, move5InducesBools);
            //Get
            exportStringTextBox.Text = importExportString.getImportExportString();
        }
        private bool checkStringRestrictions(string s)
        {
            //General parameter checks
            if(s == null || s == "" || s == "nX!wj@am!E" || s == "d@3MDMe#SC" || s == "t192y!@:PE22" || s == "at1!@!W0k" || s == "d%%23eFF" || s == "a1;c';c" || s == "dj1g><e" || s == "imnSTRT@@_!" || s == "imnEND@@_!")
            {
                return false;
            }
            //Move 1 checks
            else if(s == "nDCMmv1@@" || s == "dDCMv1@@" || s == "tDCMmv1@@" || s == "atmDCMmv1@@" || s == "accDCMmv1@@" || s == "hDCMmv1@@" || s == "atkDCMmv1@@" || s == "defDCMmv1@@" || s == "acmDCMmv1@@" || s == "dgeDCMmv1@@" || s == "indSTRTMmv1@@_!" || s == "indENDMmv1@@_!")
            {
                return false;
            }
            //Move 2 checks
            else if (s == "nDCMmv2@@" || s == "dDCMv2@@" || s == "tDCMmv2@@" || s == "atmDCMmv2@@" || s == "accDCMmv2@@" || s == "hDCMmv2@@" || s == "atkDCMmv2@@" || s == "defDCMmv2@@" || s == "acmDCMmv2@@" || s == "dgeDCMmv2@@" || s == "indSTRTMmv2@@_!" || s == "indENDMmv2@@_!")
            {
                return false;
            }
            //Move 3 checks
            else if (s == "nDCMmv3@@" || s == "dDCMv3@@" || s == "tDCMmv3@@" || s == "atmDCMmv3@@" || s == "accDCMmv3@@" || s == "hDCMmv3@@" || s == "atkDCMmv3@@" || s == "defDCMmv3@@" || s == "acmDCMmv3@@" || s == "dgeDCMmv3@@" || s == "indSTRTMmv3@@_!" || s == "indENDMmv3@@_!")
            {
                return false;
            }
            //Move 4 checks
            else if (s == "nDCMmv4@@" || s == "dDCMv4@@" || s == "tDCMmv4@@" || s == "atmDCMmv4@@" || s == "accDCMmv4@@" || s == "hDCMmv4@@" || s == "atkDCMmv4@@" || s == "defDCMmv4@@" || s == "acmDCMmv4@@" || s == "dgeDCMmv4@@" || s == "indSTRTMmv4@@_!" || s == "indENDMmv4@@_!")
            {
                return false;
            }
            //Move 5 checks
            else if (s == "nDCMmv5@@" || s == "dDCMv5@@" || s == "tDCMmv5@@" || s == "atmDCMmv5@@" || s == "accDCMmv5@@" || s == "hDCMmv5@@" || s == "atkDCMmv5@@" || s == "defDCMmv5@@" || s == "acmDCMmv5@@" || s == "dgeDCMmv5@@" || s == "indSTRTMmv5@@_!" || s == "indENDMmv5@@_!")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
            //Import a Build
        private void loadBuildButton_Click(object sender, EventArgs e)
        {
            string importString = loadBuildTextBox.Text;
            //Perform Checks first
            if(checkImportString(importString) == true)
            {
                Character loadedBuild = new Character(importString);
                loadBuildVisually(loadedBuild);
                System.Windows.Forms.MessageBox.Show("Build successfully loaded!");
            }
        }
        private void loadBuildVisually(Character character)
        {
            //Character Attr
            CCT1.Text = character.getName();
            CCT2.Text = character.getDesc();
            CCc1.Text = character.getType();
            CCN40.Value = character.getHP();
            CCN1.Value = character.getAtk();
            CCN2.Value = character.getDef();
            CCN3.Value = character.getAcc();
            CCN4.Value = character.getDge();
            //Immunities
            if(character.getimnStun() == true)
            {
                CCc2.Text = "YES";
            }
            else
            {
                CCc2.Text = "NO";
            }
            if (character.getimnPsn() == true)
            {
                CCc3.Text = "YES";
            }
            else
            {
                CCc3.Text = "NO";
            }
            if (character.getimnBrn() == true)
            {
                CCc4.Text = "YES";
            }
            else
            {
                CCc4.Text = "NO";
            }
            if (character.getimnCrpl() == true)
            {
                CCc5.Text = "YES";
            }
            else
            {
                CCc5.Text = "NO";
            }
            if (character.getimnFrzn() == true)
            {
                CCc6.Text = "YES";
            }
            else
            {
                CCc6.Text = "NO";
            }
            if (character.getimnFrzn() == true)
            {
                CCc7.Text = "YES";
            }
            else
            {
                CCc7.Text = "NO";
            }
            if (character.getimnBld() == true)
            {
                CCc8.Text = "YES";
            }
            else
            {
                CCc8.Text = "NO";
            }
            if (character.getimnStpf() == true)
            {
                CCc9.Text = "YES";
            }
            else
            {
                CCc9.Text = "NO";
            }
            if (character.getimnWk() == true)
            {
                CCc10.Text = "YES";
            }
            else
            {
                CCc10.Text = "NO";
            }
            if (character.getimnDzz() == true)
            {
                CCc11.Text = "YES";
            }
            else
            {
                CCc11.Text = "NO";
            }
            //Move 1 Attr
            CCT3.Text = character.getMv1Name();
            CCT4.Text = character.getMv1Desc();
            CCc11.Text = character.getMv1Type();
            CCN5.Value = (decimal)character.getMv1M();
            CCN6.Value = character.getMv1Acc();
            CCN7.Value = character.getMv1Heal();
            CCN8.Value = character.getMv1AtkMod();
            CCN9.Value = character.getMv1DefMod();
            CCN10.Value = character.getMv1AccMod();
            CCN11.Value = character.getMv1DgeMod();
            //Move 1 Induces
            if(character.getMv1indStun() == true)
            {
                CCc12.Text = "YES";
            }
            else
            {
                CCc12.Text = "NO";
            }
            if (character.getMv1indPsn() == true)
            {
                CCc13.Text = "YES";
            }
            else
            {
                CCc13.Text = "NO";
            }
            if (character.getMv1indBrn() == true)
            {
                CCc14.Text = "YES";
            }
            else
            {
                CCc14.Text = "NO";
            }
            if (character.getMv1indCrpl() == true)
            {
                CCc15.Text = "YES";
            }
            else
            {
                CCc15.Text = "NO";
            }
            if (character.getMv1indFrzn() == true)
            {
                CCc16.Text = "YES";
            }
            else
            {
                CCc16.Text = "NO";
            }
            if (character.getMv1indBld() == true)
            {
                CCc17.Text = "YES";
            }
            else
            {
                CCc17.Text = "NO";
            }
            if (character.getMv1indStpf() == true)
            {
                CCc18.Text = "YES";
            }
            else
            {
                CCc18.Text = "NO";
            }
            if (character.getMv1indWk() == true)
            {
                CCc19.Text = "YES";
            }
            else
            {
                CCc19.Text = "NO";
            }
            if (character.getMv1indDzz() == true)
            {
                CCc20.Text = "YES";
            }
            else
            {
                CCc20.Text = "NO";
            }
            //Move 2 Attr
            CCT5.Text = character.getMv2Name();
            CCT6.Text = character.getMv2Desc();
            CCc21.Text = character.getMv2Type();
            CCN12.Value = (decimal)character.getMv2M();
            CCN13.Value = character.getMv2Acc();
            CCN14.Value = character.getMv2Heal();
            CCN15.Value = character.getMv2AtkMod();
            CCN16.Value = character.getMv2DefMod();
            CCN17.Value = character.getMv2AccMod();
            CCN18.Value = character.getMv2DgeMod();
            //Move 2 Induces
            if (character.getMv2indStun() == true)
            {
                CCc22.Text = "YES";
            }
            else
            {
                CCc22.Text = "NO";
            }
            if (character.getMv2indPsn() == true)
            {
                CCc23.Text = "YES";
            }
            else
            {
                CCc23.Text = "NO";
            }
            if (character.getMv2indBrn() == true)
            {
                CCc24.Text = "YES";
            }
            else
            {
                CCc24.Text = "NO";
            }
            if (character.getMv2indCrpl() == true)
            {
                CCc30.Text = "YES";
            }
            else
            {
                CCc30.Text = "NO";
            }
            if (character.getMv2indFrzn() == true)
            {
                CCc25.Text = "YES";
            }
            else
            {
                CCc25.Text = "NO";
            }
            if (character.getMv2indBld() == true)
            {
                CCc26.Text = "YES";
            }
            else
            {
                CCc26.Text = "NO";
            }
            if (character.getMv2indStpf() == true)
            {
                CCc27.Text = "YES";
            }
            else
            {
                CCc27.Text = "NO";
            }
            if (character.getMv2indWk() == true)
            {
                CCc28.Text = "YES";
            }
            else
            {
                CCc28.Text = "NO";
            }
            if (character.getMv2indDzz() == true)
            {
                CCc29.Text = "YES";
            }
            else
            {
                CCc29.Text = "NO";
            }
            //Move 3 Attr
            CCT7.Text = character.getMv3Name();
            CCT8.Text = character.getMv3Desc();
            CCc31.Text = character.getMv3Type();
            CCN19.Value = (decimal)character.getMv3M();
            CCN20.Value = character.getMv3Acc();
            CCN21.Value = character.getMv3Heal();
            CCN22.Value = character.getMv3AtkMod();
            CCN23.Value = character.getMv3DefMod();
            CCN24.Value = character.getMv3AccMod();
            CCN25.Value = character.getMv3DgeMod();
            //Move 3 Induces
            if (character.getMv3indStun() == true)
            {
                CCc32.Text = "YES";
            }
            else
            {
                CCc32.Text = "NO";
            }
            if (character.getMv3indPsn() == true)
            {
                CCc33.Text = "YES";
            }
            else
            {
                CCc33.Text = "NO";
            }
            if (character.getMv3indBrn() == true)
            {
                CCc34.Text = "YES";
            }
            else
            {
                CCc34.Text = "NO";
            }
            if (character.getMv3indCrpl() == true)
            {
                CCc35.Text = "YES";
            }
            else
            {
                CCc35.Text = "NO";
            }
            if (character.getMv3indFrzn() == true)
            {
                CCc36.Text = "YES";
            }
            else
            {
                CCc36.Text = "NO";
            }
            if (character.getMv3indBld() == true)
            {
                CCc37.Text = "YES";
            }
            else
            {
                CCc37.Text = "NO";
            }
            if (character.getMv3indStpf() == true)
            {
                CCc38.Text = "YES";
            }
            else
            {
                CCc38.Text = "NO";
            }
            if (character.getMv3indWk() == true)
            {
                CCc39.Text = "YES";
            }
            else
            {
                CCc39.Text = "NO";
            }
            if (character.getMv3indDzz() == true)
            {
                CCc40.Text = "YES";
            }
            else
            {
                CCc40.Text = "NO";
            }
            //Move 4 Attr
            CCT9.Text = character.getMv4Name();
            CCT10.Text = character.getMv4Desc();
            CCc41.Text = character.getMv4Type();
            CCN26.Value = (decimal)character.getMv4M();
            CCN27.Value = character.getMv4Acc();
            CCN28.Value = character.getMv4Heal();
            CCN29.Value = character.getMv4AtkMod();
            CCN30.Value = character.getMv4DefMod();
            CCN31.Value = character.getMv4AccMod();
            CCN32.Value = character.getMv4DgeMod();
            //Move 4 Induces
            if (character.getMv4indStun() == true)
            {
                CCc42.Text = "YES";
            }
            else
            {
                CCc42.Text = "NO";
            }
            if (character.getMv4indPsn() == true)
            {
                CCc43.Text = "YES";
            }
            else
            {
                CCc43.Text = "NO";
            }
            if (character.getMv4indBrn() == true)
            {
                CCc44.Text = "YES";
            }
            else
            {
                CCc44.Text = "NO";
            }
            if (character.getMv4indCrpl() == true)
            {
                CCc45.Text = "YES";
            }
            else
            {
                CCc45.Text = "NO";
            }
            if (character.getMv4indFrzn() == true)
            {
                CCc46.Text = "YES";
            }
            else
            {
                CCc46.Text = "NO";
            }
            if (character.getMv4indBld() == true)
            {
                CCc47.Text = "YES";
            }
            else
            {
                CCc47.Text = "NO";
            }
            if (character.getMv4indStpf() == true)
            {
                CCc48.Text = "YES";
            }
            else
            {
                CCc48.Text = "NO";
            }
            if (character.getMv4indWk() == true)
            {
                CCc49.Text = "YES";
            }
            else
            {
                CCc49.Text = "NO";
            }
            if (character.getMv4indDzz() == true)
            {
                CCc50.Text = "YES";
            }
            else
            {
                CCc50.Text = "NO";
            }
            //Move 5 Attr
            CCT11.Text = character.getMv5Name();
            CCT12.Text = character.getMv5Desc();
            CCc51.Text = character.getMv5Type();
            CCN33.Value = (decimal)character.getMv5M();
            CCN34.Value = character.getMv5Acc();
            CCN35.Value = character.getMv5Heal();
            CCN36.Value = character.getMv5AtkMod();
            CCN37.Value = character.getMv5DefMod();
            CCN38.Value = character.getMv5AccMod();
            CCN39.Value = character.getMv5DgeMod();
            //Move 5 Induces
            if (character.getMv5indStun() == true)
            {
                CCc52.Text = "YES";
            }
            else
            {
                CCc52.Text = "NO";
            }
            if (character.getMv5indPsn() == true)
            {
                CCc53.Text = "YES";
            }
            else
            {
                CCc53.Text = "NO";
            }
            if (character.getMv5indBrn() == true)
            {
                CCc54.Text = "YES";
            }
            else
            {
                CCc54.Text = "NO";
            }
            if (character.getMv5indCrpl() == true)
            {
                CCc55.Text = "YES";
            }
            else
            {
                CCc55.Text = "NO";
            }
            if (character.getMv5indFrzn() == true)
            {
                CCc56.Text = "YES";
            }
            else
            {
                CCc56.Text = "NO";
            }
            if (character.getMv5indBld() == true)
            {
                CCc57.Text = "YES";
            }
            else
            {
                CCc57.Text = "NO";
            }
            if (character.getMv5indStpf() == true)
            {
                CCc58.Text = "YES";
            }
            else
            {
                CCc58.Text = "NO";
            }
            if (character.getMv5indWk() == true)
            {
                CCc59.Text = "YES";
            }
            else
            {
                CCc59.Text = "NO";
            }
            if (character.getMv5indDzz() == true)
            {
                CCc60.Text = "YES";
            }
            else
            {
                CCc60.Text = "NO";
            }
        }
        private bool checkImportString(string importString)
        {
            //Main attributes
                //Name
            int descriptionLocatorStartIndex = importString.IndexOf("d@3MDMe#SC");
            if(descriptionLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'description' indicator.");
                return false;
            }
            int nameLocatorEndIndex = importString.IndexOf("nX!wj@am!E");
            if (nameLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'character name' indicator.");
                return false;
            }
            nameLocatorEndIndex = 9;
            if(descriptionLocatorStartIndex - 9 <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character name.");
                return false;
            }
            else if(checkStringRestrictions(importString.Substring(10, descriptionLocatorStartIndex - 9)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character name.");
                return false;
            }
                //Description
            int typeLocatorStartIndex = importString.IndexOf("t192y!@:PE22");
            if (typeLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'type' indicator.");
                return false;
            }
            int descriptionLocatorEndIndex = importString.IndexOf("d@3MDMe#SC");
            if (descriptionLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'description' indicator.");
                return false;
            }
            descriptionLocatorEndIndex = importString.IndexOf("d@3MDMe#SC") + "d@3MDMe#SC".Length - 1;
            if (typeLocatorStartIndex - descriptionLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character description.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(descriptionLocatorEndIndex + 1, typeLocatorStartIndex - descriptionLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character description.");
                return false;
            }
                //TYPE
            int hpLocatorStartIndex = importString.IndexOf("h!*##p2@<#");
            if (hpLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'HP' indicator 1.");
                return false;
            }
            int typeLocatorEndIndex = importString.IndexOf("t192y!@:PE22");
            if (typeLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Type' indicator.");
                return false;
            }
            typeLocatorEndIndex = importString.IndexOf("t192y!@:PE22") + "t192y!@:PE22".Length - 1;
            if (hpLocatorStartIndex - typeLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character type.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(typeLocatorEndIndex + 1, hpLocatorStartIndex - typeLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character type.");
                return false;
            }
                //HP
            int atkLocatorStartIndex = importString.IndexOf("at1!@!W0k");
            if (atkLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Attack' indicator.");
                return false;
            }
            int hpLocatorEndIndex = importString.IndexOf("h!*##p2@<#");
            if (hpLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'HP' indicator. 2");
                return false;
            }
            hpLocatorEndIndex = importString.IndexOf("h!*##p2@<#") + "h!*##p2@<#".Length - 1;
            if (atkLocatorStartIndex - hpLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character HP.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(hpLocatorEndIndex + 1, atkLocatorStartIndex - hpLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character HP.");
                return false;
            }
            //ATK
            int defLocatorStartIndex = importString.IndexOf("d%%23eFF");
            if (defLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Defense' indicator.");
                return false;
            }
            int atkLocatorEndIndex = importString.IndexOf("at1!@!W0k");
            if (atkLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Attack' indicator.");
                return false;
            }
            atkLocatorEndIndex = importString.IndexOf("at1!@!W0k") + "at1!@!W0k".Length - 1;
            if (defLocatorStartIndex - atkLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(atkLocatorEndIndex + 1, defLocatorStartIndex - atkLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character attack value.");
                return false;
            }
                //DEF
            int accLocatorStartIndex = importString.IndexOf("a1;c';c");
            if (accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Accuracy' indicator.");
                return false;
            }
            int defLocatorEndIndex = importString.IndexOf("d%%23eFF");
            if (defLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Defense' indicator.");
                return false;
            }
            defLocatorEndIndex = importString.IndexOf("d%%23eFF") + "d%%23eFF".Length - 1;
            if (accLocatorStartIndex - defLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character defense value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(defLocatorEndIndex + 1, accLocatorStartIndex - defLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character defense value.");
                return false;
            }
                //ACC
            int dgeLocatorStartIndex = importString.IndexOf("dj1g><e");
            if (dgeLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Dodge' indicator.");
                return false;
            }
            int accLocatorEndIndex = importString.IndexOf("a1;c';c");
            if (accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Accuracy' indicator.");
                return false;
            }
            accLocatorEndIndex = importString.IndexOf("a1;c';c") + "a1;c';c".Length - 1;
            if (dgeLocatorStartIndex - accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(accLocatorEndIndex + 1, dgeLocatorStartIndex - accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character accuracy value.");
                return false;
            }
                //DGE
            int imnLocatorStartIndex = importString.IndexOf("imnSTRT@@_!");
            if (imnLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Immunities Start' indicator.");
                return false;
            }
            int dgeLocatorEndIndex = importString.IndexOf("dj1g><e");
            if (dgeLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Dodge' indicator.");
                return false;
            }
            dgeLocatorEndIndex = importString.IndexOf("dj1g><e") + "dj1g><e".Length - 1;
            if (imnLocatorStartIndex - dgeLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Dodge value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(dgeLocatorEndIndex + 1, imnLocatorStartIndex - dgeLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Dodge value.");
                return false;
            }
                //IMMUNITIES
            int imn2LocatorStartIndex = importString.IndexOf("imnEND@@_!");
            if (imn2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Immunities End' indicator.");
                return false;
            }
            int imnLocatorEndIndex = importString.IndexOf("imnSTRT@@_!");
            if (imnLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Immunities Start' indicator.");
                return false;
            }
            imnLocatorEndIndex = importString.IndexOf("imnSTRT@@_!") + "imnSTRT@@_!".Length - 1;
            if (imn2LocatorStartIndex - imnLocatorEndIndex !=10)
            {
                System.Windows.Forms.MessageBox.Show("Error with character immunities data 1.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(imnLocatorEndIndex + 1, imn2LocatorStartIndex - imnLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character immunities data 2.");
                return false;
            }
            else
            {
                string check = importString.Substring(imnLocatorEndIndex + 1, 9);
                for(int i = 0; i < check.Length; i++)
                {
                    if(check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with character immunities data 3.");
                        return false;
                    }
                }
            }
                //Move 1 Name
            int mv1dLocatorStartIndex = importString.IndexOf("dDCMv1@@");
            if (mv1dLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Description' indicator.");
                return false;
            }
            int mv1nLocatorEndIndex = importString.IndexOf("nDCMmv1@@");
            if (mv1nLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Name' indicator.");
                return false;
            }
            mv1nLocatorEndIndex = importString.IndexOf("nDCMmv1@@") + "nDCMmv1@@".Length - 1;
            if (mv1dLocatorStartIndex - mv1nLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Name value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1nLocatorEndIndex + 1, mv1dLocatorStartIndex - mv1nLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Name value.");
                return false;
            }
                //Move 1 Desc
            int mv1tLocatorStartIndex = importString.IndexOf("tDCMmv1@@");
            if (mv1tLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Type' indicator.");
                return false;
            }
            int mv1dLocatorEndIndex = importString.IndexOf("dDCMv1@@");
            if (mv1dLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Description' indicator.");
                return false;
            }
            mv1dLocatorEndIndex = importString.IndexOf("dDCMv1@@") + "dDCMv1@@".Length - 1;
            if (mv1tLocatorStartIndex - mv1dLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Description value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1dLocatorEndIndex + 1, mv1tLocatorStartIndex - mv1dLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Description value.");
                return false;
            }
                //Move 1 Type
            int mv1atmLocatorStartIndex = importString.IndexOf("atmDCMmv1@@");
            if (mv1atmLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Attack' indicator.");
                return false;
            }
            int mv1tLocatorEndIndex = importString.IndexOf("tDCMmv1@@");
            if (mv1tLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Type' indicator.");
                return false;
            }
            mv1tLocatorEndIndex = importString.IndexOf("tDCMmv1@@") + "tDCMmv1@@".Length - 1;
            if (mv1atmLocatorStartIndex - mv1tLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Type value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1tLocatorEndIndex + 1, mv1atmLocatorStartIndex - mv1tLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Type value.");
                return false;
            }
                //Move 1 Atk Multiplier
            int mv1accLocatorStartIndex = importString.IndexOf("accDCMmv1@@");
            if (mv1accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Accuracy' indicator.");
                return false;
            }
            int mv1atmLocatorEndIndex = importString.IndexOf("atmDCMmv1@@");
            if (mv1atmLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Attack' indicator.");
                return false;
            }
            mv1atmLocatorEndIndex = importString.IndexOf("atmDCMmv1@@") + "atmDCMmv1@@".Length - 1;
            if (mv1accLocatorStartIndex - mv1atmLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1atmLocatorEndIndex + 1, mv1accLocatorStartIndex - mv1atmLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Attack value.");
                return false;
            }
                //Move 1 Accuracy
            int mv1hLocatorStartIndex = importString.IndexOf("hDCMmv1@@");
            if (mv1hLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Healing' indicator.");
                return false;
            }
            int mv1accLocatorEndIndex = importString.IndexOf("accDCMmv1@@");
            if (mv1accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Accuracy' indicator.");
                return false;
            }
            mv1accLocatorEndIndex = importString.IndexOf("accDCMmv1@@") + "accDCMmv1@@".Length - 1;
            if (mv1hLocatorStartIndex - mv1accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1accLocatorEndIndex + 1, mv1hLocatorStartIndex - mv1accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Accuracy value.");
                return false;
            }
                //Move 1 Healing
            int mv1atkMLocatorStartIndex = importString.IndexOf("atkDCMmv1@@");
            if (mv1atkMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Attack Modifier' indicator.");
                return false;
            }
            int mv1hLocatorEndIndex = importString.IndexOf("hDCMmv1@@");
            if (mv1hLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Healing' indicator.");
                return false;
            }
            mv1hLocatorEndIndex = importString.IndexOf("hDCMmv1@@") + "hDCMmv1@@".Length - 1;
            if (mv1atkMLocatorStartIndex - mv1hLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Healing value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1hLocatorEndIndex + 1, mv1atkMLocatorStartIndex - mv1hLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Healing value.");
                return false;
            }
                //Move 1 Attack Modifier
            int mv1defMLocatorStartIndex = importString.IndexOf("defDCMmv1@@");
            if (mv1defMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Defense Modifier' indicator.");
                return false;
            }
            int mv1atkMLocatorEndIndex = importString.IndexOf("atkDCMmv1@@");
            if (mv1atkMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Attack Modifier' indicator.");
                return false;
            }
            mv1atkMLocatorEndIndex = importString.IndexOf("atkDCMmv1@@") + "atkDCMmv1@@".Length - 1;
            if (mv1defMLocatorStartIndex - mv1atkMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Attack Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1atkMLocatorEndIndex + 1, mv1defMLocatorStartIndex - mv1atkMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Attack Modifier value.");
                return false;
            }
                //Move 1 Defense Modifier
            int mv1accMLocatorStartIndex = importString.IndexOf("acmDCMmv1@@");
            if (mv1accMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Accuracy Modifier' indicator.");
                return false;
            }
            int mv1defMLocatorEndIndex = importString.IndexOf("defDCMmv1@@");
            if (mv1defMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Defense Modifier' indicator.");
                return false;
            }
            mv1defMLocatorEndIndex = importString.IndexOf("defDCMmv1@@") + "defDCMmv1@@".Length - 1;
            if (mv1accMLocatorStartIndex - mv1defMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Defense Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1defMLocatorEndIndex + 1, mv1accMLocatorStartIndex - mv1defMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Defense Modifier value.");
                return false;
            }
                //Move 1 Accuracy Modifier
            int mv1dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv1@@");
            if (mv1dgeMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Dodge Modifier' indicator.");
                return false;
            }
            int mv1accMLocatorEndIndex = importString.IndexOf("acmDCMmv1@@");
            if (mv1accMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Accuracy Modifier' indicator.");
                return false;
            }
            mv1accMLocatorEndIndex = importString.IndexOf("acmDCMmv1@@") + "acmDCMmv1@@".Length - 1;
            if (mv1dgeMLocatorStartIndex - mv1accMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Accuracy Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1accMLocatorEndIndex + 1, mv1dgeMLocatorStartIndex - mv1accMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Accuracy Modifier value.");
                return false;
            }
                //Move 1 Dodge Modifier
            int mv1indMLocatorStartIndex = importString.IndexOf("indSTRTMmv1@@_!");
            if (mv1indMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Induces Start' indicator.");
                return false;
            }
            int mv1dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv1@@");
            if (mv1dgeMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 1 Dodge Modifier' indicator.");
                return false;
            }
            mv1dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv1@@") + "dgeDCMmv1@@".Length - 1;
            if (mv1indMLocatorStartIndex - mv1dgeMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Dodge Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1dgeMLocatorEndIndex + 1, mv1indMLocatorStartIndex - mv1dgeMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 1 Dodge Modifier value.");
                return false;
            }
                //Move 1 Induces
            int mv1ind2LocatorStartIndex = importString.IndexOf("indENDMmv1@@_!");
            if (mv1ind2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces End' indicator.");
                return false;
            }
            int mv1indLocatorEndIndex = importString.IndexOf("indSTRTMmv1@@_!");
            if (mv1indLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces Start' indicator.");
                return false;
            }
            mv1indLocatorEndIndex = importString.IndexOf("indSTRTMmv1@@_!") + "indSTRTMmv1@@_!".Length - 1;
            if (mv1ind2LocatorStartIndex - mv1indLocatorEndIndex != 10)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 1 Induces data.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv1indLocatorEndIndex + 1, mv1ind2LocatorStartIndex - mv1indLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 1 Induces data.");
                return false;
            }
            else
            {
                string check = importString.Substring(mv1indLocatorEndIndex + 1, 9);
                for (int i = 0; i < check.Length; i++)
                {
                    if (check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with Move 1 Induces data.");
                        return false;
                    }
                }
            }
                //Move 2 Name
            int mv2dLocatorStartIndex = importString.IndexOf("dDCMv2@@");
            if (mv2dLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Description' indicator.");
                return false;
            }
            int mv2nLocatorEndIndex = importString.IndexOf("nDCMmv2@@");
            if (mv2nLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Name' indicator.");
                return false;
            }
            mv2nLocatorEndIndex = importString.IndexOf("nDCMmv2@@") + "nDCMmv2@@".Length - 1;
            if (mv2dLocatorStartIndex - mv2nLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Name value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2nLocatorEndIndex + 1, mv2dLocatorStartIndex - mv2nLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Name value.");
                return false;
            }
                //Move 2 Desc
            int mv2tLocatorStartIndex = importString.IndexOf("tDCMmv2@@");
            if (mv2tLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Type' indicator.");
                return false;
            }
            int mv2dLocatorEndIndex = importString.IndexOf("dDCMv2@@");
            if (mv2dLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Description' indicator.");
                return false;
            }
            mv2dLocatorEndIndex = importString.IndexOf("dDCMv2@@") + "dDCMv2@@".Length - 1;
            if (mv2tLocatorStartIndex - mv2dLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Description value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2dLocatorEndIndex + 1, mv2tLocatorStartIndex - mv2dLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Description value.");
                return false;
            }
                //Move 2 Type
            int mv2atmLocatorStartIndex = importString.IndexOf("atmDCMmv2@@");
            if (mv2atmLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Attack' indicator.");
                return false;
            }
            int mv2tLocatorEndIndex = importString.IndexOf("tDCMmv2@@");
            if (mv2tLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Type' indicator.");
                return false;
            }
            mv2tLocatorEndIndex = importString.IndexOf("tDCMmv2@@") + "tDCMmv2@@".Length - 1;
            if (mv2atmLocatorStartIndex - mv2tLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Type value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2tLocatorEndIndex + 1, mv2atmLocatorStartIndex - mv2tLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Type value.");
                return false;
            }
                //Move 2 Atk Multiplier
            int mv2accLocatorStartIndex = importString.IndexOf("accDCMmv2@@");
            if (mv2accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Accuracy' indicator.");
                return false;
            }
            int mv2atmLocatorEndIndex = importString.IndexOf("atmDCMmv2@@");
            if (mv2atmLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Attack' indicator.");
                return false;
            }
            mv2atmLocatorEndIndex = importString.IndexOf("atmDCMmv2@@") + "atmDCMmv2@@".Length - 1;
            if (mv2accLocatorStartIndex - mv2atmLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2atmLocatorEndIndex + 1, mv2accLocatorStartIndex - mv2atmLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Attack value.");
                return false;
            }
                //Move 2 Accuracy
            int mv2hLocatorStartIndex = importString.IndexOf("hDCMmv2@@");
            if (mv2hLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Healing' indicator.");
                return false;
            }
            int mv2accLocatorEndIndex = importString.IndexOf("accDCMmv2@@");
            if (mv2accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Accuracy' indicator.");
                return false;
            }
            mv2accLocatorEndIndex = importString.IndexOf("accDCMmv2@@") + "accDCMmv2@@".Length - 1;
            if (mv2hLocatorStartIndex - mv2accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2accLocatorEndIndex + 1, mv2hLocatorStartIndex - mv2accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Accuracy value.");
                return false;
            }
                //Move 2 Healing
            int mv2atkMLocatorStartIndex = importString.IndexOf("atkDCMmv2@@");
            if (mv2atkMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Attack Modifier' indicator.");
                return false;
            }
            int mv2hLocatorEndIndex = importString.IndexOf("hDCMmv2@@");
            if (mv2hLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Healing' indicator.");
                return false;
            }
            mv2hLocatorEndIndex = importString.IndexOf("hDCMmv2@@") + "hDCMmv2@@".Length - 1;
            if (mv2atkMLocatorStartIndex - mv2hLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Healing value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2hLocatorEndIndex + 1, mv2atkMLocatorStartIndex - mv2hLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Healing value.");
                return false;
            }
                //Move 2 Attack Modifier
            int mv2defMLocatorStartIndex = importString.IndexOf("defDCMmv2@@");
            if (mv2defMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Defense Modifier' indicator.");
                return false;
            }
            int mv2atkMLocatorEndIndex = importString.IndexOf("atkDCMmv2@@");
            if (mv2atkMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Attack Modifier' indicator.");
                return false;
            }
            mv2atkMLocatorEndIndex = importString.IndexOf("atkDCMmv2@@") + "atkDCMmv2@@".Length - 1;
            if (mv2defMLocatorStartIndex - mv2atkMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Attack Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2atkMLocatorEndIndex + 1, mv2defMLocatorStartIndex - mv2atkMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Attack Modifier value.");
                return false;
            }
                //Move 2 Defense Modifier
            int mv2accMLocatorStartIndex = importString.IndexOf("acmDCMmv2@@");
            if (mv2accMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Accuracy Modifier' indicator.");
                return false;
            }
            int mv2defMLocatorEndIndex = importString.IndexOf("defDCMmv2@@");
            if (mv2defMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Defense Modifier' indicator.");
                return false;
            }
            mv2defMLocatorEndIndex = importString.IndexOf("defDCMmv2@@") + "defDCMmv2@@".Length - 1;
            if (mv2accMLocatorStartIndex - mv2defMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Defense Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2defMLocatorEndIndex + 1, mv2accMLocatorStartIndex - mv2defMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Defense Modifier value.");
                return false;
            }
                //Move 2 Accuracy Modifier
            int mv2dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv2@@");
            if (mv2dgeMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Dodge Modifier' indicator.");
                return false;
            }
            int mv2accMLocatorEndIndex = importString.IndexOf("acmDCMmv2@@");
            if (mv2accMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Accuracy Modifier' indicator.");
                return false;
            }
            mv2accMLocatorEndIndex = importString.IndexOf("acmDCMmv2@@") + "acmDCMmv2@@".Length - 1;
            if (mv2dgeMLocatorStartIndex - mv2accMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Accuracy Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2accMLocatorEndIndex + 1, mv2dgeMLocatorStartIndex - mv2accMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Accuracy Modifier value.");
                return false;
            }
                //Move 2 Dodge Modifier
            int mv2indMLocatorStartIndex = importString.IndexOf("indSTRTMmv2@@_!");
            if (mv2indMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Induces Start' indicator.");
                return false;
            }
            int mv2dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv2@@");
            if (mv2dgeMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 2 Dodge Modifier' indicator.");
                return false;
            }
            mv2dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv2@@") + "dgeDCMmv2@@".Length - 1;
            if (mv2indMLocatorStartIndex - mv2dgeMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Dodge Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2dgeMLocatorEndIndex + 1, mv2indMLocatorStartIndex - mv2dgeMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 2 Dodge Modifier value.");
                return false;
            }
                //Move 2 Induces
            int mv2ind2LocatorStartIndex = importString.IndexOf("indENDMmv2@@_!");
            if (mv2ind2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces End' indicator.");
                return false;
            }
            int mv2indLocatorEndIndex = importString.IndexOf("indSTRTMmv2@@_!");
            if (mv2indLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces Start' indicator.");
                return false;
            }
            mv2indLocatorEndIndex = importString.IndexOf("indSTRTMmv2@@_!") + "indSTRTMmv2@@_!".Length - 1;
            if (mv2ind2LocatorStartIndex - mv2indLocatorEndIndex != 10)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 2 Induces data.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv2indLocatorEndIndex + 1, mv2ind2LocatorStartIndex - mv2indLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 2 Induces data.");
                return false;
            }
            else
            {
                string check = importString.Substring(mv2indLocatorEndIndex + 1, 9);
                for (int i = 0; i < check.Length; i++)
                {
                    if (check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with Move 2 Induces data.");
                        return false;
                    }
                }
            }
                //Move 3 Name
            int mv3dLocatorStartIndex = importString.IndexOf("dDCMv3@@");
            if (mv3dLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Description' indicator.");
                return false;
            }
            int mv3nLocatorEndIndex = importString.IndexOf("nDCMmv3@@");
            if (mv3nLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Name' indicator.");
                return false;
            }
            mv3nLocatorEndIndex = importString.IndexOf("nDCMmv3@@") + "nDCMmv3@@".Length - 1;
            if (mv3dLocatorStartIndex - mv3nLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Name value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3nLocatorEndIndex + 1, mv3dLocatorStartIndex - mv3nLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Name value.");
                return false;
            }
                //Move 3 Desc
            int mv3tLocatorStartIndex = importString.IndexOf("tDCMmv3@@");
            if (mv3tLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Type' indicator.");
                return false;
            }
            int mv3dLocatorEndIndex = importString.IndexOf("dDCMv3@@");
            if (mv3dLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Description' indicator.");
                return false;
            }
            mv3dLocatorEndIndex = importString.IndexOf("dDCMv3@@") + "dDCMv3@@".Length - 1;
            if (mv3tLocatorStartIndex - mv3dLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Description value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3dLocatorEndIndex + 1, mv3tLocatorStartIndex - mv3dLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Description value.");
                return false;
            }
                //Move 3 Type
            int mv3atmLocatorStartIndex = importString.IndexOf("atmDCMmv3@@");
            if (mv3atmLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Attack' indicator.");
                return false;
            }
            int mv3tLocatorEndIndex = importString.IndexOf("tDCMmv3@@");
            if (mv3tLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Type' indicator.");
                return false;
            }
            mv3tLocatorEndIndex = importString.IndexOf("tDCMmv3@@") + "tDCMmv3@@".Length - 1;
            if (mv3atmLocatorStartIndex - mv3tLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Type value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3tLocatorEndIndex + 1, mv3atmLocatorStartIndex - mv3tLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Type value.");
                return false;
            }
                //Move 3 Atk Multiplier
            int mv3accLocatorStartIndex = importString.IndexOf("accDCMmv3@@");
            if (mv3accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Accuracy' indicator.");
                return false;
            }
            int mv3atmLocatorEndIndex = importString.IndexOf("atmDCMmv3@@");
            if (mv3atmLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Attack' indicator.");
                return false;
            }
            mv3atmLocatorEndIndex = importString.IndexOf("atmDCMmv3@@") + "atmDCMmv3@@".Length - 1;
            if (mv3accLocatorStartIndex - mv3atmLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3atmLocatorEndIndex + 1, mv3accLocatorStartIndex - mv3atmLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Attack value.");
                return false;
            }
                //Move 3 Accuracy
            int mv3hLocatorStartIndex = importString.IndexOf("hDCMmv3@@");
            if (mv3hLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Healing' indicator.");
                return false;
            }
            int mv3accLocatorEndIndex = importString.IndexOf("accDCMmv3@@");
            if (mv3accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Accuracy' indicator.");
                return false;
            }
            mv3accLocatorEndIndex = importString.IndexOf("accDCMmv3@@") + "accDCMmv3@@".Length - 1;
            if (mv3hLocatorStartIndex - mv3accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3accLocatorEndIndex + 1, mv3hLocatorStartIndex - mv3accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Accuracy value.");
                return false;
            }
                //Move 3 Healing
            int mv3atkMLocatorStartIndex = importString.IndexOf("atkDCMmv3@@");
            if (mv3atkMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Attack Modifier' indicator.");
                return false;
            }
            int mv3hLocatorEndIndex = importString.IndexOf("hDCMmv3@@");
            if (mv3hLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Healing' indicator.");
                return false;
            }
            mv3hLocatorEndIndex = importString.IndexOf("hDCMmv3@@") + "hDCMmv3@@".Length - 1;
            if (mv3atkMLocatorStartIndex - mv3hLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Healing value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3hLocatorEndIndex + 1, mv3atkMLocatorStartIndex - mv3hLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Healing value.");
                return false;
            }
                //Move 3 Attack Modifier
            int mv3defMLocatorStartIndex = importString.IndexOf("defDCMmv3@@");
            if (mv3defMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Defense Modifier' indicator.");
                return false;
            }
            int mv3atkMLocatorEndIndex = importString.IndexOf("atkDCMmv3@@");
            if (mv3atkMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Attack Modifier' indicator.");
                return false;
            }
            mv3atkMLocatorEndIndex = importString.IndexOf("atkDCMmv3@@") + "atkDCMmv3@@".Length - 1;
            if (mv3defMLocatorStartIndex - mv3atkMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Attack Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3atkMLocatorEndIndex + 1, mv3defMLocatorStartIndex - mv3atkMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Attack Modifier value.");
                return false;
            }
                //Move 3 Defense Modifier
            int mv3accMLocatorStartIndex = importString.IndexOf("acmDCMmv3@@");
            if (mv3accMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Accuracy Modifier' indicator.");
                return false;
            }
            int mv3defMLocatorEndIndex = importString.IndexOf("defDCMmv3@@");
            if (mv3defMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Defense Modifier' indicator.");
                return false;
            }
            mv3defMLocatorEndIndex = importString.IndexOf("defDCMmv3@@") + "defDCMmv3@@".Length - 1;
            if (mv3accMLocatorStartIndex - mv3defMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Defense Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3defMLocatorEndIndex + 1, mv3accMLocatorStartIndex - mv3defMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Defense Modifier value.");
                return false;
            }
                //Move 3 Accuracy Modifier
            int mv3dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv3@@");
            if (mv3dgeMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Dodge Modifier' indicator.");
                return false;
            }
            int mv3accMLocatorEndIndex = importString.IndexOf("acmDCMmv3@@");
            if (mv3accMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Accuracy Modifier' indicator.");
                return false;
            }
            mv3accMLocatorEndIndex = importString.IndexOf("acmDCMmv3@@") + "acmDCMmv3@@".Length - 1;
            if (mv3dgeMLocatorStartIndex - mv3accMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Accuracy Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3accMLocatorEndIndex + 1, mv3dgeMLocatorStartIndex - mv3accMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Accuracy Modifier value.");
                return false;
            }
                //Move 3 Dodge Modifier
            int mv3indMLocatorStartIndex = importString.IndexOf("indSTRTMmv3@@_!");
            if (mv3indMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Induces Start' indicator.");
                return false;
            }
            int mv3dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv3@@");
            if (mv3dgeMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 3 Dodge Modifier' indicator.");
                return false;
            }
            mv3dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv3@@") + "dgeDCMmv3@@".Length - 1;
            if (mv3indMLocatorStartIndex - mv3dgeMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Dodge Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3dgeMLocatorEndIndex + 1, mv3indMLocatorStartIndex - mv3dgeMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 3 Dodge Modifier value.");
                return false;
            }
                //Move 3 Induces
            int mv3ind2LocatorStartIndex = importString.IndexOf("indENDMmv3@@_!");
            if (mv3ind2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces End' indicator.");
                return false;
            }
            int mv3indLocatorEndIndex = importString.IndexOf("indSTRTMmv3@@_!");
            if (mv3indLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces Start' indicator.");
                return false;
            }
            mv3indLocatorEndIndex = importString.IndexOf("indSTRTMmv3@@_!") + "indSTRTMmv3@@_!".Length - 1;
            if (mv3ind2LocatorStartIndex - mv3indLocatorEndIndex != 10)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 3 Induces data.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv3indLocatorEndIndex + 1, mv3ind2LocatorStartIndex - mv3indLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 3 Induces data.");
                return false;
            }
            else
            {
                string check = importString.Substring(mv3indLocatorEndIndex + 1, 9);
                for (int i = 0; i < check.Length; i++)
                {
                    if (check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with Move 3 Induces data.");
                        return false;
                    }
                }
            }
                //Move 4 Name
            int mv4dLocatorStartIndex = importString.IndexOf("dDCMv4@@");
            if (mv4dLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Description' indicator.");
                return false;
            }
            int mv4nLocatorEndIndex = importString.IndexOf("nDCMmv4@@");
            if (mv4nLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Name' indicator.");
                return false;
            }
            mv4nLocatorEndIndex = importString.IndexOf("nDCMmv4@@") + "nDCMmv4@@".Length - 1;
            if (mv4dLocatorStartIndex - mv4nLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Name value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4nLocatorEndIndex + 1, mv4dLocatorStartIndex - mv4nLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Name value.");
                return false;
            }
                //Move 4 Desc
            int mv4tLocatorStartIndex = importString.IndexOf("tDCMmv4@@");
            if (mv4tLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Type' indicator.");
                return false;
            }
            int mv4dLocatorEndIndex = importString.IndexOf("dDCMv4@@");
            if (mv4dLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Description' indicator.");
                return false;
            }
            mv4dLocatorEndIndex = importString.IndexOf("dDCMv4@@") + "dDCMv4@@".Length - 1;
            if (mv4tLocatorStartIndex - mv4dLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Description value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4dLocatorEndIndex + 1, mv4tLocatorStartIndex - mv4dLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Description value.");
                return false;
            }
                //Move 4 Type
            int mv4atmLocatorStartIndex = importString.IndexOf("atmDCMmv4@@");
            if (mv4atmLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Attack' indicator.");
                return false;
            }
            int mv4tLocatorEndIndex = importString.IndexOf("tDCMmv4@@");
            if (mv4tLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Type' indicator.");
                return false;
            }
            mv4tLocatorEndIndex = importString.IndexOf("tDCMmv4@@") + "tDCMmv4@@".Length - 1;
            if (mv4atmLocatorStartIndex - mv4tLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Type value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4tLocatorEndIndex + 1, mv4atmLocatorStartIndex - mv4tLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Type value.");
                return false;
            }
                //Move 4 Atk Multiplier
            int mv4accLocatorStartIndex = importString.IndexOf("accDCMmv4@@");
            if (mv4accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Accuracy' indicator.");
                return false;
            }
            int mv4atmLocatorEndIndex = importString.IndexOf("atmDCMmv4@@");
            if (mv4atmLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Attack' indicator.");
                return false;
            }
            mv4atmLocatorEndIndex = importString.IndexOf("atmDCMmv4@@") + "atmDCMmv4@@".Length - 1;
            if (mv4accLocatorStartIndex - mv4atmLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4atmLocatorEndIndex + 1, mv4accLocatorStartIndex - mv4atmLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Attack value.");
                return false;
            }
                //Move 4 Accuracy
            int mv4hLocatorStartIndex = importString.IndexOf("hDCMmv4@@");
            if (mv4hLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Healing' indicator.");
                return false;
            }
            int mv4accLocatorEndIndex = importString.IndexOf("accDCMmv4@@");
            if (mv4accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Accuracy' indicator.");
                return false;
            }
            mv4accLocatorEndIndex = importString.IndexOf("accDCMmv4@@") + "accDCMmv4@@".Length - 1;
            if (mv4hLocatorStartIndex - mv4accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4accLocatorEndIndex + 1, mv4hLocatorStartIndex - mv4accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Accuracy value.");
                return false;
            }
                //Move 4 Healing
            int mv4atkMLocatorStartIndex = importString.IndexOf("atkDCMmv4@@");
            if (mv4atkMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Attack Modifier' indicator.");
                return false;
            }
            int mv4hLocatorEndIndex = importString.IndexOf("hDCMmv4@@");
            if (mv4hLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Healing' indicator.");
                return false;
            }
            mv4hLocatorEndIndex = importString.IndexOf("hDCMmv4@@") + "hDCMmv4@@".Length - 1;
            if (mv4atkMLocatorStartIndex - mv4hLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Healing value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4hLocatorEndIndex + 1, mv4atkMLocatorStartIndex - mv4hLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Healing value.");
                return false;
            }
                //Move 4 Attack Modifier
            int mv4defMLocatorStartIndex = importString.IndexOf("defDCMmv4@@");
            if (mv4defMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Defense Modifier' indicator.");
                return false;
            }
            int mv4atkMLocatorEndIndex = importString.IndexOf("atkDCMmv4@@");
            if (mv4atkMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Attack Modifier' indicator.");
                return false;
            }
            mv4atkMLocatorEndIndex = importString.IndexOf("atkDCMmv4@@") + "atkDCMmv4@@".Length - 1;
            if (mv4defMLocatorStartIndex - mv4atkMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Attack Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4atkMLocatorEndIndex + 1, mv4defMLocatorStartIndex - mv4atkMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Attack Modifier value.");
                return false;
            }
                //Move 4 Defense Modifier
            int mv4accMLocatorStartIndex = importString.IndexOf("acmDCMmv4@@");
            if (mv4accMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Accuracy Modifier' indicator.");
                return false;
            }
            int mv4defMLocatorEndIndex = importString.IndexOf("defDCMmv4@@");
            if (mv4defMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Defense Modifier' indicator.");
                return false;
            }
            mv4defMLocatorEndIndex = importString.IndexOf("defDCMmv4@@") + "defDCMmv4@@".Length - 1;
            if (mv4accMLocatorStartIndex - mv4defMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Defense Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4defMLocatorEndIndex + 1, mv4accMLocatorStartIndex - mv4defMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Defense Modifier value.");
                return false;
            }
                //Move 4 Accuracy Modifier
            int mv4dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv4@@");
            if (mv4dgeMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Dodge Modifier' indicator.");
                return false;
            }
            int mv4accMLocatorEndIndex = importString.IndexOf("acmDCMmv4@@");
            if (mv4accMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Accuracy Modifier' indicator.");
                return false;
            }
            mv4accMLocatorEndIndex = importString.IndexOf("acmDCMmv4@@") + "acmDCMmv4@@".Length - 1;
            if (mv4dgeMLocatorStartIndex - mv4accMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Accuracy Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4accMLocatorEndIndex + 1, mv4dgeMLocatorStartIndex - mv4accMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Accuracy Modifier value.");
                return false;
            }
                //Move 4 Dodge Modifier
            int mv4indMLocatorStartIndex = importString.IndexOf("indSTRTMmv4@@_!");
            if (mv4indMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Induces Start' indicator.");
                return false;
            }
            int mv4dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv4@@");
            if (mv4dgeMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 4 Dodge Modifier' indicator.");
                return false;
            }
            mv4dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv4@@") + "dgeDCMmv4@@".Length - 1;
            if (mv4indMLocatorStartIndex - mv4dgeMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Dodge Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4dgeMLocatorEndIndex + 1, mv4indMLocatorStartIndex - mv4dgeMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 4 Dodge Modifier value.");
                return false;
            }
                //Move 4 Induces
            int mv4ind2LocatorStartIndex = importString.IndexOf("indENDMmv4@@_!");
            if (mv4ind2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces End' indicator.");
                return false;
            }
            int mv4indLocatorEndIndex = importString.IndexOf("indSTRTMmv4@@_!");
            if (mv4indLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces Start' indicator.");
                return false;
            }
            mv4indLocatorEndIndex = importString.IndexOf("indSTRTMmv4@@_!") + "indSTRTMmv4@@_!".Length - 1;
            if (mv4ind2LocatorStartIndex - mv4indLocatorEndIndex != 10)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 4 Induces data.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv4indLocatorEndIndex + 1, mv4ind2LocatorStartIndex - mv4indLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 4 Induces data.");
                return false;
            }
            else
            {
                string check = importString.Substring(mv4indLocatorEndIndex + 1, 9);
                for (int i = 0; i < check.Length; i++)
                {
                    if (check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with Move 4 Induces data.");
                        return false;
                    }
                }
            }
                //Move 5 Name
            int mv5dLocatorStartIndex = importString.IndexOf("dDCMv5@@");
            if (mv5dLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Description' indicator.");
                return false;
            }
            int mv5nLocatorEndIndex = importString.IndexOf("nDCMmv5@@");
            if (mv5nLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Name' indicator.");
                return false;
            }
            mv5nLocatorEndIndex = importString.IndexOf("nDCMmv5@@") + "nDCMmv5@@".Length - 1;
            if (mv5dLocatorStartIndex - mv5nLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Name value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5nLocatorEndIndex + 1, mv5dLocatorStartIndex - mv5nLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Name value.");
                return false;
            }
                //Move 5 Desc
            int mv5tLocatorStartIndex = importString.IndexOf("tDCMmv5@@");
            if (mv5tLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Type' indicator.");
                return false;
            }
            int mv5dLocatorEndIndex = importString.IndexOf("dDCMv5@@");
            if (mv5dLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Description' indicator.");
                return false;
            }
            mv5dLocatorEndIndex = importString.IndexOf("dDCMv5@@") + "dDCMv5@@".Length - 1;
            if (mv5tLocatorStartIndex - mv5dLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Description value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5dLocatorEndIndex + 1, mv5tLocatorStartIndex - mv5dLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Description value.");
                return false;
            }
                //Move 5 Type
            int mv5atmLocatorStartIndex = importString.IndexOf("atmDCMmv5@@");
            if (mv5atmLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Attack' indicator.");
                return false;
            }
            int mv5tLocatorEndIndex = importString.IndexOf("tDCMmv5@@");
            if (mv5tLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Type' indicator.");
                return false;
            }
            mv5tLocatorEndIndex = importString.IndexOf("tDCMmv5@@") + "tDCMmv5@@".Length - 1;
            if (mv5atmLocatorStartIndex - mv5tLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Type value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5tLocatorEndIndex + 1, mv5atmLocatorStartIndex - mv5tLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Type value.");
                return false;
            }
                //Move 5 Atk Multiplier
            int mv5accLocatorStartIndex = importString.IndexOf("accDCMmv5@@");
            if (mv5accLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Accuracy' indicator.");
                return false;
            }
            int mv5atmLocatorEndIndex = importString.IndexOf("atmDCMmv5@@");
            if (mv5atmLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Attack' indicator.");
                return false;
            }
            mv5atmLocatorEndIndex = importString.IndexOf("atmDCMmv5@@") + "atmDCMmv5@@".Length - 1;
            if (mv5accLocatorStartIndex - mv5atmLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Attack value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5atmLocatorEndIndex + 1, mv5accLocatorStartIndex - mv5atmLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Attack value.");
                return false;
            }
                //Move 5 Accuracy
            int mv5hLocatorStartIndex = importString.IndexOf("hDCMmv5@@");
            if (mv5hLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Healing' indicator.");
                return false;
            }
            int mv5accLocatorEndIndex = importString.IndexOf("accDCMmv5@@");
            if (mv5accLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Accuracy' indicator.");
                return false;
            }
            mv5accLocatorEndIndex = importString.IndexOf("accDCMmv5@@") + "accDCMmv5@@".Length - 1;
            if (mv5hLocatorStartIndex - mv5accLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Accuracy value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5accLocatorEndIndex + 1, mv5hLocatorStartIndex - mv5accLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Accuracy value.");
                return false;
            }
                //Move 5 Healing
            int mv5atkMLocatorStartIndex = importString.IndexOf("atkDCMmv5@@");
            if (mv5atkMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Attack Modifier' indicator.");
                return false;
            }
            int mv5hLocatorEndIndex = importString.IndexOf("hDCMmv5@@");
            if (mv5hLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Healing' indicator.");
                return false;
            }
            mv5hLocatorEndIndex = importString.IndexOf("hDCMmv5@@") + "hDCMmv5@@".Length - 1;
            if (mv5atkMLocatorStartIndex - mv5hLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Healing value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5hLocatorEndIndex + 1, mv5atkMLocatorStartIndex - mv5hLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Healing value.");
                return false;
            }
                //Move 5 Attack Modifier
            int mv5defMLocatorStartIndex = importString.IndexOf("defDCMmv5@@");
            if (mv5defMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Defense Modifier' indicator.");
                return false;
            }
            int mv5atkMLocatorEndIndex = importString.IndexOf("atkDCMmv5@@");
            if (mv5atkMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Attack Modifier' indicator.");
                return false;
            }
            mv5atkMLocatorEndIndex = importString.IndexOf("atkDCMmv5@@") + "atkDCMmv5@@".Length - 1;
            if (mv5defMLocatorStartIndex - mv5atkMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Attack Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5atkMLocatorEndIndex + 1, mv5defMLocatorStartIndex - mv5atkMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Attack Modifier value.");
                return false;
            }
                //Move 5 Defense Modifier
            int mv5accMLocatorStartIndex = importString.IndexOf("acmDCMmv5@@");
            if (mv5accMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Accuracy Modifier' indicator.");
                return false;
            }
            int mv5defMLocatorEndIndex = importString.IndexOf("defDCMmv5@@");
            if (mv5defMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Defense Modifier' indicator.");
                return false;
            }
            mv5defMLocatorEndIndex = importString.IndexOf("defDCMmv5@@") + "defDCMmv5@@".Length - 1;
            if (mv5accMLocatorStartIndex - mv5defMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Defense Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5defMLocatorEndIndex + 1, mv5accMLocatorStartIndex - mv5defMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Defense Modifier value.");
                return false;
            }
                //Move 5 Accuracy Modifier
            int mv5dgeMLocatorStartIndex = importString.IndexOf("dgeDCMmv5@@");
            if (mv5dgeMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Dodge Modifier' indicator.");
                return false;
            }
            int mv5accMLocatorEndIndex = importString.IndexOf("acmDCMmv5@@");
            if (mv5accMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Accuracy Modifier' indicator.");
                return false;
            }
            mv5accMLocatorEndIndex = importString.IndexOf("acmDCMmv5@@") + "acmDCMmv5@@".Length - 1;
            if (mv5dgeMLocatorStartIndex - mv5accMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Accuracy Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5accMLocatorEndIndex + 1, mv5dgeMLocatorStartIndex - mv5accMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Accuracy Modifier value.");
                return false;
            }
                //Move 5 Dodge Modifier
            int mv5indMLocatorStartIndex = importString.IndexOf("indSTRTMmv5@@_!");
            if (mv5indMLocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Induces Start' indicator.");
                return false;
            }
            int mv5dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv5@@");
            if (mv5dgeMLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Move 5 Dodge Modifier' indicator.");
                return false;
            }
            mv5dgeMLocatorEndIndex = importString.IndexOf("dgeDCMmv5@@") + "dgeDCMmv5@@".Length - 1;
            if (mv5indMLocatorStartIndex - mv5dgeMLocatorEndIndex <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Dodge Modifier value.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5dgeMLocatorEndIndex + 1, mv5indMLocatorStartIndex - mv5dgeMLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with character Move 5 Dodge Modifier value.");
                return false;
            }
                //Move 5 Induces
            int mv5ind2LocatorStartIndex = importString.IndexOf("indENDMmv5@@_!");
            if (mv5ind2LocatorStartIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces End' indicator.");
                return false;
            }
            int mv5indLocatorEndIndex = importString.IndexOf("indSTRTMmv5@@_!");
            if (mv5indLocatorEndIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Error with 'Induces Start' indicator.");
                return false;
            }
            mv5indLocatorEndIndex = importString.IndexOf("indSTRTMmv5@@_!") + "indSTRTMmv5@@_!".Length - 1;
            if (mv5ind2LocatorStartIndex - mv5indLocatorEndIndex != 10)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 5 Induces data.");
                return false;
            }
            else if (checkStringRestrictions(importString.Substring(mv5indLocatorEndIndex + 1, mv5ind2LocatorStartIndex - mv5indLocatorEndIndex)) == false)
            {
                System.Windows.Forms.MessageBox.Show("Error with Move 5 Induces data.");
                return false;
            }
            else
            {
                string check = importString.Substring(mv5indLocatorEndIndex + 1, 9);
                for (int i = 0; i < check.Length; i++)
                {
                    if (check.Substring(i, 1) != "y" && check.Substring(i, 1) != "n")
                    {
                        System.Windows.Forms.MessageBox.Show("Error with Move 5 Induces data.");
                        return false;
                    }
                }
            }
            //Valid!
            return true;
        }

        //Elemental UI methods
        public void disableAllElementalUI()
        {
            //Welcome
            welcomeLabel1.Enabled = false;
            welcomeLabel2.Enabled = false;
            welcomeLabel1.Hide();
            welcomeLabel2.Hide();
            //Character Creation
            hideAllCharacterCreation();
        }
        public void hideAllCharacterCreation()
        {
            CCL120.Enabled = false;
            CCL120.Hide();
            CCN40.Enabled = false;
            CCN40.Hide();
            characterCreationTitle.Enabled = false;
            characterCreationTitle.Hide();
            characterCreationDesc.Enabled = false;
            characterCreationDesc.Hide();
            horizCharCreationBar.Enabled = false;
            horizCharCreationBar.Hide();
            exportStringDescription.Enabled = false;
            exportStringDescription.Hide();
            CCL1.Enabled = false;
            CCL1.Hide();
            CCL2.Enabled = false;
            CCL2.Hide();
            CCL3.Enabled = false;
            CCL3.Hide();
            CCL4.Enabled = false;
            CCL4.Hide();
            CCL5.Enabled = false;
            CCL5.Hide();
            CCL6.Enabled = false;
            CCL6.Hide();
            CCL7.Enabled = false;
            CCL7.Hide();
            CCL8.Enabled = false;
            CCL8.Hide();
            CCL9.Enabled = false;
            CCL9.Hide();
            CCL10.Enabled = false;
            CCL10.Hide();
            CCL11.Enabled = false;
            CCL11.Hide();
            CCL12.Enabled = false;
            CCL12.Hide();
            CCL13.Enabled = false;
            CCL13.Hide();
            CCL14.Enabled = false;
            CCL14.Hide();
            CCL15.Enabled = false;
            CCL15.Hide();
            CCL16.Enabled = false;
            CCL16.Hide();
            CCL17.Enabled = false;
            CCL17.Hide();
            CCL18.Enabled = false;
            CCL18.Hide();
            CCL19.Enabled = false;
            CCL19.Hide();
            CCL20.Enabled = false;
            CCL20.Hide();
            CCL21.Enabled = false;
            CCL21.Hide();
            CCL22.Enabled = false;
            CCL22.Hide();
            CCL23.Enabled = false;
            CCL23.Hide();
            CCL24.Enabled = false;
            CCL24.Hide();
            CCL25.Enabled = false;
            CCL25.Hide();
            CCL26.Enabled = false;
            CCL26.Hide();
            CCL27.Enabled = false;
            CCL27.Hide();
            CCL29.Enabled = false;
            CCL29.Hide();
            CCL30.Enabled = false;
            CCL30.Hide();
            CCL31.Enabled = false;
            CCL31.Hide();
            CCL32.Enabled = false;
            CCL32.Hide();
            CCL33.Enabled = false;
            CCL33.Hide();
            CCL34.Enabled = false;
            CCL34.Hide();
            CCL35.Enabled = false;
            CCL35.Hide();
            CCL36.Enabled = false;
            CCL36.Hide();
            CCL37.Enabled = false;
            CCL37.Hide();
            CCL38.Enabled = false;
            CCL38.Hide();
            CCL39.Enabled = false;
            CCL39.Hide();
            CCL40.Enabled = false;
            CCL40.Hide();
            CCL41.Enabled = false;
            CCL41.Hide();
            CCL42.Enabled = false;
            CCL42.Hide();
            CCL43.Enabled = false;
            CCL43.Hide();
            CCL44.Enabled = false;
            CCL44.Hide();
            CCL45.Enabled = false;
            CCL45.Hide();
            CCL46.Enabled = false;
            CCL46.Hide();
            CCL47.Enabled = false;
            CCL47.Hide();
            CCL48.Enabled = false;
            CCL48.Hide();
            CCL49.Enabled = false;
            CCL49.Hide();
            CCL50.Enabled = false;
            CCL50.Hide();
            CCL51.Enabled = false;
            CCL51.Hide();
            CCL52.Enabled = false;
            CCL52.Hide();
            CCL53.Enabled = false;
            CCL53.Hide();
            CCL54.Enabled = false;
            CCL54.Hide();
            CCL55.Enabled = false;
            CCL55.Hide();
            CCL56.Enabled = false;
            CCL56.Hide();
            CCL57.Enabled = false;
            CCL57.Hide();
            CCL58.Enabled = false;
            CCL58.Hide();
            CCL59.Enabled = false;
            CCL59.Hide();
            CCL60.Enabled = false;
            CCL60.Hide();
            CCL61.Enabled = false;
            CCL61.Hide();
            CCL62.Enabled = false;
            CCL62.Hide();
            CCL63.Enabled = false;
            CCL63.Hide();
            CCL64.Enabled = false;
            CCL64.Hide();
            CCL65.Enabled = false;
            CCL65.Hide();
            CCL66.Enabled = false;
            CCL66.Hide();
            CCL67.Enabled = false;
            CCL67.Hide();
            CCL68.Enabled = false;
            CCL68.Hide();
            CCL69.Enabled = false;
            CCL69.Hide();
            CCL70.Enabled = false;
            CCL70.Hide();
            CCL71.Enabled = false;
            CCL71.Hide();
            CCL72.Enabled = false;
            CCL72.Hide();
            CCL73.Enabled = false;
            CCL73.Hide();
            CCL74.Enabled = false;
            CCL74.Hide();
            CCL75.Enabled = false;
            CCL75.Hide();
            CCL76.Enabled = false;
            CCL76.Hide();
            CCL77.Enabled = false;
            CCL77.Hide();
            CCL78.Enabled = false;
            CCL78.Hide();
            CCL79.Enabled = false;
            CCL79.Hide();
            CCL80.Enabled = false;
            CCL80.Hide();
            CCL81.Enabled = false;
            CCL81.Hide();
            CCL82.Enabled = false;
            CCL82.Hide();
            CCL83.Enabled = false;
            CCL83.Hide();
            CCL84.Enabled = false;
            CCL84.Hide();
            CCL85.Enabled = false;
            CCL85.Hide();
            CCL86.Enabled = false;
            CCL86.Hide();
            CCL87.Enabled = false;
            CCL87.Hide();
            CCL88.Enabled = false;
            CCL88.Hide();
            CCL89.Enabled = false;
            CCL89.Hide();
            CCL90.Enabled = false;
            CCL90.Hide();
            CCL91.Enabled = false;
            CCL91.Hide();
            CCL92.Enabled = false;
            CCL92.Hide();
            CCL93.Enabled = false;
            CCL93.Hide();
            CCL94.Enabled = false;
            CCL94.Hide();
            CCL95.Enabled = false;
            CCL95.Hide();
            CCL96.Enabled = false;
            CCL96.Hide();
            CCL97.Enabled = false;
            CCL97.Hide();
            CCL98.Enabled = false;
            CCL98.Hide();
            CCL99.Enabled = false;
            CCL99.Hide();
            CCL100.Enabled = false;
            CCL100.Hide();
            CCL101.Enabled = false;
            CCL101.Hide();
            CCL102.Enabled = false;
            CCL102.Hide();
            CCL103.Enabled = false;
            CCL103.Hide();
            CCL104.Enabled = false;
            CCL104.Hide();
            CCL105.Enabled = false;
            CCL105.Hide();
            CCL106.Enabled = false;
            CCL106.Hide();
            CCL107.Enabled = false;
            CCL107.Hide();
            CCL108.Enabled = false;
            CCL108.Hide();
            CCL109.Enabled = false;
            CCL109.Hide();
            CCL110.Enabled = false;
            CCL110.Hide();
            CCL111.Enabled = false;
            CCL111.Hide();
            CCL112.Enabled = false;
            CCL112.Hide();
            CCL113.Enabled = false;
            CCL113.Hide();
            CCL114.Enabled = false;
            CCL114.Hide();
            CCL115.Enabled = false;
            CCL115.Hide();
            CCL116.Enabled = false;
            CCL116.Hide();
            CCL117.Enabled = false;
            CCL117.Hide();
            CCL118.Enabled = false;
            CCL118.Hide();
            CCL119.Enabled = false;
            CCL119.Hide();
            CCT1.Enabled = false;
            CCT1.Hide();
            CCT2.Enabled = false;
            CCT2.Hide();
            CCT3.Enabled = false;
            CCT3.Hide();
            CCT4.Enabled = false;
            CCT4.Hide();
            CCT5.Enabled = false;
            CCT5.Hide();
            CCT6.Enabled = false;
            CCT6.Hide();
            CCT7.Enabled = false;
            CCT7.Hide();
            CCT8.Enabled = false;
            CCT8.Hide();
            CCT9.Enabled = false;
            CCT9.Hide();
            CCT10.Enabled = false;
            CCT10.Hide();
            CCT11.Enabled = false;
            CCT11.Hide();
            CCT12.Enabled = false;
            CCT12.Hide();
            CCN1.Enabled = false;
            CCN1.Hide();
            CCN2.Enabled = false;
            CCN2.Hide();
            CCN3.Enabled = false;
            CCN3.Hide();
            CCN4.Enabled = false;
            CCN4.Hide();
            CCN5.Enabled = false;
            CCN5.Hide();
            CCN6.Enabled = false;
            CCN6.Hide();
            CCN7.Enabled = false;
            CCN7.Hide();
            CCN8.Enabled = false;
            CCN8.Hide();
            CCN9.Enabled = false;
            CCN9.Hide();
            CCN10.Enabled = false;
            CCN10.Hide();
            CCN11.Enabled = false;
            CCN11.Hide();
            CCN12.Enabled = false;
            CCN12.Hide();
            CCN13.Enabled = false;
            CCN13.Hide();
            CCN14.Enabled = false;
            CCN14.Hide();
            CCN15.Enabled = false;
            CCN15.Hide();
            CCN16.Enabled = false;
            CCN16.Hide();
            CCN17.Enabled = false;
            CCN17.Hide();
            CCN18.Enabled = false;
            CCN18.Hide();
            CCN19.Enabled = false;
            CCN19.Hide();
            CCN20.Enabled = false;
            CCN20.Hide();
            CCN21.Enabled = false;
            CCN21.Hide();
            CCN22.Enabled = false;
            CCN22.Hide();
            CCN23.Enabled = false;
            CCN23.Hide();
            CCN24.Enabled = false;
            CCN24.Hide();
            CCN25.Enabled = false;
            CCN25.Hide();
            CCN26.Enabled = false;
            CCN26.Hide();
            CCN27.Enabled = false;
            CCN27.Hide();
            CCN28.Enabled = false;
            CCN28.Hide();
            CCN29.Enabled = false;
            CCN29.Hide();
            CCN30.Enabled = false;
            CCN30.Hide();
            CCN31.Enabled = false;
            CCN31.Hide();
            CCN32.Enabled = false;
            CCN32.Hide();
            CCN33.Enabled = false;
            CCN33.Hide();
            CCN34.Enabled = false;
            CCN34.Hide();
            CCN35.Enabled = false;
            CCN35.Hide();
            CCN36.Enabled = false;
            CCN36.Hide();
            CCN37.Enabled = false;
            CCN37.Hide();
            CCN38.Enabled = false;
            CCN38.Hide();
            CCN39.Enabled = false;
            CCN39.Hide();
            CCc1.Enabled = false;
            CCc1.Hide();
            CCc2.Enabled = false;
            CCc2.Hide();
            CCc3.Enabled = false;
            CCc3.Hide();
            CCc4.Enabled = false;
            CCc4.Hide();
            CCc5.Enabled = false;
            CCc5.Hide();
            CCc6.Enabled = false;
            CCc6.Hide();
            CCc7.Enabled = false;
            CCc7.Hide();
            CCc8.Enabled = false;
            CCc8.Hide();
            CCc9.Enabled = false;
            CCc9.Hide();
            CCc10.Enabled = false;
            CCc10.Hide();
            CCc11.Enabled = false;
            CCc11.Hide();
            CCc12.Enabled = false;
            CCc12.Hide();
            CCc13.Enabled = false;
            CCc13.Hide();
            CCc14.Enabled = false;
            CCc14.Hide();
            CCc15.Enabled = false;
            CCc15.Hide();
            CCc16.Enabled = false;
            CCc16.Hide();
            CCc17.Enabled = false;
            CCc17.Hide();
            CCc18.Enabled = false;
            CCc18.Hide();
            CCc19.Enabled = false;
            CCc19.Hide();
            CCc20.Enabled = false;
            CCc20.Hide();
            CCc21.Enabled = false;
            CCc21.Hide();
            CCc22.Enabled = false;
            CCc22.Hide();
            CCc23.Enabled = false;
            CCc23.Hide();
            CCc24.Enabled = false;
            CCc24.Hide();
            CCc25.Enabled = false;
            CCc25.Hide();
            CCc26.Enabled = false;
            CCc26.Hide();
            CCc27.Enabled = false;
            CCc27.Hide();
            CCc28.Enabled = false;
            CCc28.Hide();
            CCc29.Enabled = false;
            CCc29.Hide();
            CCc30.Enabled = false;
            CCc30.Hide();
            CCc31.Enabled = false;
            CCc31.Hide();
            CCc32.Enabled = false;
            CCc32.Hide();
            CCc33.Enabled = false;
            CCc33.Hide();
            CCc34.Enabled = false;
            CCc34.Hide();
            CCc35.Enabled = false;
            CCc35.Hide();
            CCc36.Enabled = false;
            CCc36.Hide();
            CCc37.Enabled = false;
            CCc37.Hide();
            CCc38.Enabled = false;
            CCc38.Hide();
            CCc39.Enabled = false;
            CCc39.Hide();
            CCc40.Enabled = false;
            CCc40.Hide();
            CCc41.Enabled = false;
            CCc41.Hide();
            CCc42.Enabled = false;
            CCc42.Hide();
            CCc43.Enabled = false;
            CCc43.Hide();
            CCc44.Enabled = false;
            CCc44.Hide();
            CCc45.Enabled = false;
            CCc45.Hide();
            CCc46.Enabled = false;
            CCc46.Hide();
            CCc47.Enabled = false;
            CCc47.Hide();
            CCc48.Enabled = false;
            CCc48.Hide();
            CCc49.Enabled = false;
            CCc49.Hide();
            CCc50.Enabled = false;
            CCc50.Hide();
            CCc51.Enabled = false;
            CCc51.Hide();
            CCc52.Enabled = false;
            CCc52.Hide();
            CCc53.Enabled = false;
            CCc53.Hide();
            CCc54.Enabled = false;
            CCc54.Hide();
            CCc55.Enabled = false;
            CCc55.Hide();
            CCc56.Enabled = false;
            CCc56.Hide();
            CCc57.Enabled = false;
            CCc57.Hide();
            CCc58.Enabled = false;
            CCc58.Hide();
            CCc59.Enabled = false;
            CCc59.Hide();
            CCc60.Enabled = false;
            CCc60.Hide();
            CCP1.Enabled = false;
            CCP1.Hide();
            CCP2.Enabled = false;
            CCP2.Hide();
            CCP3.Enabled = false;
            CCP3.Hide();
            CCP4.Enabled = false;
            CCP4.Hide();
            CCP5.Enabled = false;
            CCP5.Hide();
            CCP6.Enabled = false;
            CCP6.Hide();
            exportCharStringButton.Enabled = false;
            exportCharStringButton.Hide();
            exportStringTextBox.Enabled = false;
            exportStringTextBox.Hide();
            loadBuildButton.Enabled = false;
            loadBuildButton.Hide();
            loadBuildTextBox.Enabled = false;
            loadBuildTextBox.Hide();
        }
        public void enableCharButtonElementalUI()
        {
            //Upper labels
            characterCreationTitle.Enabled = true;
            characterCreationTitle.Show();
            characterCreationDesc.Enabled = true;
            characterCreationDesc.Show();
            horizCharCreationBar.Enabled = true;
            horizCharCreationBar.Show();
            //Export UI
            exportCharStringButton.Enabled = true;
            exportCharStringButton.Show();
            exportStringTextBox.Enabled = true;
            exportStringTextBox.Show();
            exportStringDescription.Enabled = true;
            exportStringDescription.Show();
            loadBuildButton.Enabled = true;
            loadBuildButton.Show();
            loadBuildTextBox.Enabled = true;
            loadBuildTextBox.Show();
            //Gen Attributes
            CCL120.Enabled = true;
            CCN40.Show();
            CCN40.Enabled = true;
            CCN40.Show();
            CCL1.Enabled = true;
            CCL1.Show();
            CCL2.Enabled = true;
            CCL2.Show();
            CCL3.Enabled = true;
            CCL3.Show();
            CCL4.Enabled = true;
            CCL4.Show();
            CCL5.Enabled = true;
            CCL5.Show();
            CCL6.Enabled = true;
            CCL6.Show();
            CCL7.Enabled = true;
            CCL7.Show();
            CCL8.Enabled = true;
            CCL8.Show();
            CCL9.Enabled = true;
            CCL9.Show();
            CCL10.Enabled = true;
            CCL10.Show();
            CCL11.Enabled = true;
            CCL11.Show();
            CCL12.Enabled = true;
            CCL12.Show();
            CCL13.Enabled = true;
            CCL13.Show();
            CCL14.Enabled = true;
            CCL14.Show();
            CCL15.Enabled = true;
            CCL15.Show();
            CCL16.Enabled = true;
            CCL16.Show();
            CCL17.Enabled = true;
            CCL17.Show();
            CCL18.Enabled = true;
            CCL18.Show();
            CCT1.Enabled = true;
            CCT1.Show();
            CCT2.Enabled = true;
            CCT2.Show();
            CCN1.Enabled = true;
            CCN1.Show();
            CCN2.Enabled = true;
            CCN2.Show();
            CCN3.Enabled = true;
            CCN3.Show();
            CCN4.Enabled = true;
            CCN4.Show();
            CCc1.Enabled = true;
            CCc1.Show();
            CCc2.Enabled = true;
            CCc2.Show();
            CCc3.Enabled = true;
            CCc3.Show();
            CCc4.Enabled = true;
            CCc4.Show();
            CCc5.Enabled = true;
            CCc5.Show();
            CCc6.Enabled = true;
            CCc6.Show();
            CCc7.Enabled = true;
            CCc7.Show();
            CCc8.Enabled = true;
            CCc8.Show();
            CCc9.Enabled = true;
            CCc9.Show();
            CCc10.Enabled = true;
            CCc10.Show();
            CCP1.Enabled = true;
            CCP1.Show();
            //Move 1
            CCL19.Enabled = true;
            CCL19.Show();
            CCL20.Enabled = true;
            CCL20.Show();
            CCL21.Enabled = true;
            CCL21.Show();
            CCL22.Enabled = true;
            CCL22.Show();
            CCL23.Enabled = true;
            CCL23.Show();
            CCL24.Enabled = true;
            CCL24.Show();
            CCL25.Enabled = true;
            CCL25.Show();
            CCL26.Enabled = true;
            CCL26.Show();
            CCL27.Enabled = true;
            CCL27.Show();
            CCL29.Enabled = true;
            CCL29.Show();
            CCL30.Enabled = true;
            CCL30.Show();
            CCL31.Enabled = true;
            CCL31.Show();
            CCL32.Enabled = true;
            CCL32.Show();
            CCL33.Enabled = true;
            CCL33.Show();
            CCL34.Enabled = true;
            CCL34.Show();
            CCL35.Enabled = true;
            CCL35.Show();
            CCL36.Enabled = true;
            CCL36.Show();
            CCL37.Enabled = true;
            CCL37.Show();
            CCL38.Enabled = true;
            CCL38.Show();
            CCL39.Enabled = true;
            CCL39.Show();
            CCT3.Enabled = true;
            CCT3.Show();
            CCT4.Enabled = true;
            CCT4.Show();
            CCN5.Enabled = true;
            CCN5.Show();
            CCN6.Enabled = true;
            CCN6.Show();
            CCN7.Enabled = true;
            CCN7.Show();
            CCN8.Enabled = true;
            CCN8.Show();
            CCN9.Enabled = true;
            CCN9.Show();
            CCN10.Enabled = true;
            CCN10.Show();
            CCN11.Enabled = true;
            CCN11.Show();
            CCc11.Enabled = true;
            CCc11.Show();
            CCc12.Enabled = true;
            CCc12.Show();
            CCc13.Enabled = true;
            CCc13.Show();
            CCc14.Enabled = true;
            CCc14.Show();
            CCc15.Enabled = true;
            CCc15.Show();
            CCc16.Enabled = true;
            CCc16.Show();
            CCc17.Enabled = true;
            CCc17.Show();
            CCc18.Enabled = true;
            CCc18.Show();
            CCc19.Enabled = true;
            CCc19.Show();
            CCc20.Enabled = true;
            CCc20.Show();
            CCP2.Enabled = true;
            CCP2.Show();
            //Move 2
            CCL40.Enabled = true;
            CCL40.Show();
            CCL41.Enabled = true;
            CCL41.Show();
            CCL42.Enabled = true;
            CCL42.Show();
            CCL43.Enabled = true;
            CCL43.Show();
            CCL44.Enabled = true;
            CCL44.Show();
            CCL45.Enabled = true;
            CCL45.Show();
            CCL46.Enabled = true;
            CCL46.Show();
            CCL47.Enabled = true;
            CCL47.Show();
            CCL48.Enabled = true;
            CCL48.Show();
            CCL49.Enabled = true;
            CCL49.Show();
            CCL50.Enabled = true;
            CCL50.Show();
            CCL51.Enabled = true;
            CCL51.Show();
            CCL52.Enabled = true;
            CCL52.Show();
            CCL53.Enabled = true;
            CCL53.Show();
            CCL54.Enabled = true;
            CCL54.Show();
            CCL55.Enabled = true;
            CCL55.Show();
            CCL56.Enabled = true;
            CCL56.Show();
            CCL57.Enabled = true;
            CCL57.Show();
            CCL58.Enabled = true;
            CCL58.Show();
            CCL59.Enabled = true;
            CCL59.Show();
            CCT5.Enabled = true;
            CCT5.Show();
            CCT6.Enabled = true;
            CCT6.Show();
            CCN12.Enabled = true;
            CCN12.Show();
            CCN13.Enabled = true;
            CCN13.Show();
            CCN14.Enabled = true;
            CCN14.Show();
            CCN15.Enabled = true;
            CCN15.Show();
            CCN16.Enabled = true;
            CCN16.Show();
            CCN17.Enabled = true;
            CCN17.Show();
            CCN18.Enabled = true;
            CCN18.Show();
            CCc21.Enabled = true;
            CCc21.Show();
            CCc22.Enabled = true;
            CCc22.Show();
            CCc23.Enabled = true;
            CCc23.Show();
            CCc24.Enabled = true;
            CCc24.Show();
            CCc25.Enabled = true;
            CCc25.Show();
            CCc26.Enabled = true;
            CCc26.Show();
            CCc27.Enabled = true;
            CCc27.Show();
            CCc28.Enabled = true;
            CCc28.Show();
            CCc29.Enabled = true;
            CCc29.Show();
            CCc30.Enabled = true;
            CCc30.Show();
            CCP3.Enabled = true;
            CCP3.Show();
            //Move 3
            CCL60.Enabled = true;
            CCL60.Show();
            CCL61.Enabled = true;
            CCL61.Show();
            CCL62.Enabled = true;
            CCL62.Show();
            CCL63.Enabled = true;
            CCL63.Show();
            CCL64.Enabled = true;
            CCL64.Show();
            CCL65.Enabled = true;
            CCL65.Show();
            CCL66.Enabled = true;
            CCL66.Show();
            CCL67.Enabled = true;
            CCL67.Show();
            CCL68.Enabled = true;
            CCL68.Show();
            CCL69.Enabled = true;
            CCL69.Show();
            CCL70.Enabled = true;
            CCL70.Show();
            CCL71.Enabled = true;
            CCL71.Show();
            CCL72.Enabled = true;
            CCL72.Show();
            CCL73.Enabled = true;
            CCL73.Show();
            CCL74.Enabled = true;
            CCL74.Show();
            CCL75.Enabled = true;
            CCL75.Show();
            CCL76.Enabled = true;
            CCL76.Show();
            CCL77.Enabled = true;
            CCL77.Show();
            CCL78.Enabled = true;
            CCL78.Show();
            CCL79.Enabled = true;
            CCL79.Show();
            CCT7.Enabled = true;
            CCT7.Show();
            CCT8.Enabled = true;
            CCT8.Show();
            CCN19.Enabled = true;
            CCN19.Show();
            CCN20.Enabled = true;
            CCN20.Show();
            CCN21.Enabled = true;
            CCN21.Show();
            CCN22.Enabled = true;
            CCN22.Show();
            CCN23.Enabled = true;
            CCN23.Show();
            CCN24.Enabled = true;
            CCN24.Show();
            CCN25.Enabled = true;
            CCN25.Show();
            CCc31.Enabled = true;
            CCc31.Show();
            CCc32.Enabled = true;
            CCc32.Show();
            CCc33.Enabled = true;
            CCc33.Show();
            CCc34.Enabled = true;
            CCc34.Show();
            CCc35.Enabled = true;
            CCc35.Show();
            CCc36.Enabled = true;
            CCc36.Show();
            CCc37.Enabled = true;
            CCc37.Show();
            CCc38.Enabled = true;
            CCc38.Show();
            CCc39.Enabled = true;
            CCc39.Show();
            CCc40.Enabled = true;
            CCc40.Show();
            CCP4.Enabled = true;
            CCP4.Show();
            //Move 4
            CCL80.Enabled = true;
            CCL80.Show();
            CCL81.Enabled = true;
            CCL81.Show();
            CCL82.Enabled = true;
            CCL82.Show();
            CCL83.Enabled = true;
            CCL83.Show();
            CCL84.Enabled = true;
            CCL84.Show();
            CCL85.Enabled = true;
            CCL85.Show();
            CCL86.Enabled = true;
            CCL86.Show();
            CCL87.Enabled = true;
            CCL87.Show();
            CCL88.Enabled = true;
            CCL88.Show();
            CCL89.Enabled = true;
            CCL89.Show();
            CCL90.Enabled = true;
            CCL90.Show();
            CCL91.Enabled = true;
            CCL91.Show();
            CCL92.Enabled = true;
            CCL92.Show();
            CCL93.Enabled = true;
            CCL93.Show();
            CCL94.Enabled = true;
            CCL94.Show();
            CCL95.Enabled = true;
            CCL95.Show();
            CCL96.Enabled = true;
            CCL96.Show();
            CCL97.Enabled = true;
            CCL97.Show();
            CCL98.Enabled = true;
            CCL98.Show();
            CCL99.Enabled = true;
            CCL99.Show();
            CCT9.Enabled = true;
            CCT9.Show();
            CCT10.Enabled = true;
            CCT10.Show();
            CCN26.Enabled = true;
            CCN26.Show();
            CCN27.Enabled = true;
            CCN27.Show();
            CCN28.Enabled = true;
            CCN28.Show();
            CCN29.Enabled = true;
            CCN29.Show();
            CCN30.Enabled = true;
            CCN30.Show();
            CCN31.Enabled = true;
            CCN31.Show();
            CCN32.Enabled = true;
            CCN32.Show();
            CCc41.Enabled = true;
            CCc41.Show();
            CCc42.Enabled = true;
            CCc42.Show();
            CCc43.Enabled = true;
            CCc43.Show();
            CCc44.Enabled = true;
            CCc44.Show();
            CCc45.Enabled = true;
            CCc45.Show();
            CCc46.Enabled = true;
            CCc46.Show();
            CCc47.Enabled = true;
            CCc47.Show();
            CCc48.Enabled = true;
            CCc48.Show();
            CCc49.Enabled = true;
            CCc49.Show();
            CCc50.Enabled = true;
            CCc50.Show();
            CCP5.Enabled = true;
            CCP5.Show();
            //Move 5
            CCL100.Enabled = true;
            CCL100.Show();
            CCL101.Enabled = true;
            CCL101.Show();
            CCL102.Enabled = true;
            CCL102.Show();
            CCL103.Enabled = true;
            CCL103.Show();
            CCL104.Enabled = true;
            CCL104.Show();
            CCL105.Enabled = true;
            CCL105.Show();
            CCL106.Enabled = true;
            CCL106.Show();
            CCL107.Enabled = true;
            CCL107.Show();
            CCL108.Enabled = true;
            CCL108.Show();
            CCL109.Enabled = true;
            CCL109.Show();
            CCL110.Enabled = true;
            CCL110.Show();
            CCL111.Enabled = true;
            CCL111.Show();
            CCL112.Enabled = true;
            CCL112.Show();
            CCL113.Enabled = true;
            CCL113.Show();
            CCL114.Enabled = true;
            CCL114.Show();
            CCL115.Enabled = true;
            CCL115.Show();
            CCL116.Enabled = true;
            CCL116.Show();
            CCL117.Enabled = true;
            CCL117.Show();
            CCL118.Enabled = true;
            CCL118.Show();
            CCL119.Enabled = true;
            CCL119.Show();
            CCT11.Enabled = true;
            CCT11.Show();
            CCT12.Enabled = true;
            CCT12.Show();
            CCN33.Enabled = true;
            CCN33.Show();
            CCN34.Enabled = true;
            CCN34.Show();
            CCN35.Enabled = true;
            CCN35.Show();
            CCN36.Enabled = true;
            CCN36.Show();
            CCN37.Enabled = true;
            CCN37.Show();
            CCN38.Enabled = true;
            CCN38.Show();
            CCN39.Enabled = true;
            CCN39.Show();
            CCc51.Enabled = true;
            CCc51.Show();
            CCc52.Enabled = true;
            CCc52.Show();
            CCc53.Enabled = true;
            CCc53.Show();
            CCc54.Enabled = true;
            CCc54.Show();
            CCc55.Enabled = true;
            CCc55.Show();
            CCc56.Enabled = true;
            CCc56.Show();
            CCc57.Enabled = true;
            CCc57.Show();
            CCc58.Enabled = true;
            CCc58.Show();
            CCc59.Enabled = true;
            CCc59.Show();
            CCc60.Enabled = true;
            CCc60.Show();
            CCP6.Enabled = true;
            CCP6.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        
    }
}
