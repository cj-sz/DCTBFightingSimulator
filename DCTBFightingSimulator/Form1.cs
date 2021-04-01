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

        private void createCharButton_Click(object sender, EventArgs e)
        {
            disableAllElementalUI();
            enableCharButtonElementalUI();
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
            CCP1.Enabled = false;
            CCP1.Hide();
            CCP2.Enabled = false;
            CCP2.Hide();
            CCP3.Enabled = false;
            CCP3.Hide();
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
