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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
    }
}
