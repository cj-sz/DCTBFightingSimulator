﻿using System;
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
        private void exportCharStringButton_Click(object sender, EventArgs e)
        {
            //Generate the string
            ImportExportString importExportString = new ImportExportString();
            //General Attr
            string n = CCT1.Text;
            string d = CCT2.Text;
            string t = CCc1.Text;
            int atk = (int)CCN1.Value;
            int def = (int)CCN2.Value;
            int acc = (int)CCN3.Value;
            int dge = (int)CCN4.Value;
            importExportString.generateAttributesStringPart(n, d, t, atk, def, acc, dge);
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
            characterCreationTitle.Enabled = false;
            characterCreationTitle.Hide();
            characterCreationDesc.Enabled = false;
            characterCreationDesc.Hide();
            horizCharCreationBar.Enabled = false;
            horizCharCreationBar.Hide();
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
            //Gen Attributes
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
