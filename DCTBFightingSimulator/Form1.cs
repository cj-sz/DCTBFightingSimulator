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
        /*Character Strings Database Here:
        */

        //For use in-simulation:
        private Character player1;
        private Character player2;
        int lastP1Move = 0;
        int lastP2Move = 0;

        public DCTBFightingSimulator()
        {
            InitializeComponent();
            disableAllElementalUI();
            startingPanel.Enabled = true;
            startingPanel.BringToFront();
            startingPanel.Show();
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

        //Elemental UI methods
        public void disableAllElementalUI()
        {
            //Welcome
            startingPanel.SendToBack();
            startingPanel.Hide();
            startingPanel.Enabled = false;
            //EvE
            hideEvEUI();
            //Character Creation
            hideAllCharacterCreation();
            //Character Database
            hideCharDatabaseUI();
        }
        public void disableAllButtons()
        {
            EvEStartButton.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            simulateEveButton.Enabled = false;
            pveButton.Enabled = false;
            pvpButton.Enabled = false;
            createCharButton.Enabled = false;
            charDatabaseButton.Enabled = false;
            changelogButton.Enabled = false;
            roadmapButton.Enabled = false;
        }
        public void enableAllButtons()
        {
            EvEStartButton.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            simulateEveButton.Enabled = true;
            pveButton.Enabled = true;
            pvpButton.Enabled = true;
            createCharButton.Enabled = true;
            charDatabaseButton.Enabled = true;
            changelogButton.Enabled = true;
            roadmapButton.Enabled = true;
        }
        public void hideAllCharacterCreation()
        {
            panel1.SendToBack();
            panel1.Hide();
            panel1.Enabled = false;
        }
        public void enableCharButtonElementalUI()
        {
            disableAllElementalUI();
            panel1.Enabled = true;
            panel1.BringToFront();
            panel1.Show();
        }
        public void enableCharDatabaseUI()
        {
            disableAllElementalUI();
            characterDatabasePanel.Enabled = true;
            characterDatabasePanel.BringToFront();
            characterDatabasePanel.Show();
        }
        public void hideCharDatabaseUI()
        {
            characterDatabasePanel.SendToBack();
            characterDatabasePanel.Hide();
            characterDatabasePanel.Enabled = false;
        }
        public void enableEvEUI()
        {
            disableAllElementalUI();
            EvEPanel.Enabled = true;
            EvEPanel.BringToFront();
            EvEPanel.Show();
        }
        public void hideEvEUI()
        {
            EvEPanel.SendToBack();
            EvEPanel.Hide();
            EvEPanel.Enabled = false;
        }

        //EvE Methods
        private void simulateEveButton_Click(object sender, EventArgs e)
        {
            enableEvEUI();
        }
        private void EvEStartButton_Click(object sender, EventArgs e)
        {
            //Perform checks - player 1
            if(player1SelectionEvE.Text == "" && player1ImportEvE.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Invalid: Character not selected for either player 1, player 2, or both.");
                return;
            }
            if (player2SelectionEvE.Text == "" && player2ImportEvE.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Invalid: Character not selected for either player 1, player 2, or both.");
                return;
            }
            if (player1SelectionEvE.Text == "")
            {
                if(checkImportString(player1ImportEvE.Text) != false)
                {
                    //Perform player 1 Imports based on the import string
                    player1ImportStringImports(player1ImportEvE.Text);
                }
                else
                {
                    return;
                }
            }
            else
            {
                //Perform player 1 Imports based on the selected dropdown
                player1DropdownImports();
            }
            //Perform checks - player 2
            if (player2SelectionEvE.Text == "")
            {
                if (checkImportString(player2ImportEvE.Text) != false)
                {
                    //Perform player 2 Imports based on the import string
                    player2ImportStringImports(player2ImportEvE.Text);
                }
                else
                {
                    return;
                }
            }
            else
            {
                //Perform player 2 Imports based on the selected dropdown
                player2DropdownImports();
            }
            EvESimulation();
        }
            //Player Imports
                //Player 1
        private void player1ImportStringImports(string importString)
        {
            player1 = new Character(importString);
            //Load in to all values visually
            loadPlayer1VisualStats();
        }
        private void player1DropdownImports()
        {

        }
                //Player 2
        private void player2ImportStringImports(string importString)
        {
            player2 = new Character(importString);
            //Load in to all values visually
            loadPlayer2VisualStats();
        }
        private void player2DropdownImports()
        {

        }
            //Visual Stats
                //Player 1
        private void loadPlayer1VisualStats()
        {
            p1Name.Text = player1.getName();
            p1Desc.Text = player1.getDesc();
            p1Hp.Value = player1.getHP();
            p1Atk.Value = player1.getAtk();
            p1Def.Value = player1.getDef();
            p1Acc.Value = player1.getAcc();
            p1Dge.Value = player1.getDge();
            p1Mv1.Text = player1.getMv1Name();
            p1Mv1Desc.Text = player1.getMv1Desc();
            p1Mv1AtkM.Value = (decimal)player1.getMv1M();
            p1Mv1Acc.Value = player1.getMv1Acc();
            p1Mv2.Text = player1.getMv2Name();
            p1Mv2Desc.Text = player1.getMv2Desc();
            p1Mv2AtkM.Value = (decimal)player1.getMv2M();
            p1Mv2Acc.Value = player1.getMv2Acc();
            p1Mv3.Text = player1.getMv3Name();
            p1Mv3Desc.Text = player1.getMv3Desc();
            p1Mv3AtkM.Value = (decimal)player1.getMv3M();
            p1Mv3Acc.Value = player1.getMv3Acc();
            p1Mv4.Text = player1.getMv4Name();
            p1Mv4Desc.Text = player1.getMv4Desc();
            p1Mv4AtkM.Value = (decimal)player1.getMv4M();
            p1Mv4Acc.Value = player1.getMv4Acc();
            p1Mv5.Text = player1.getMv5Name();
            p1Mv5Desc.Text = player1.getMv5Desc();
            p1Mv5AtkM.Value = (decimal)player1.getMv5M();
            p1Mv5Acc.Value = player1.getMv5Acc();
            if (player1.getIsStunned() == true)
            {
                p1Stunned.Text = "YES";
            }
            else
            {
                p1Stunned.Text = "NO";
            }
            if (player1.getIsPoisoned() == true)
            {
                p1Poisoned.Text = "YES";
            }
            else
            {
                p1Poisoned.Text = "NO";
            }
            if (player1.getIsBurned() == true)
            {
                p1Burned.Text = "YES";
            }
            else
            {
                p1Burned.Text = "NO";
            }
            if (player1.getIsCrippled() == true)
            {
                p1Crippled.Text = "YES";
            }
            else
            {
                p1Crippled.Text = "NO";
            }
            if (player1.getIsFrozen() == true)
            {
                p1Frozen.Text = "YES";
            }
            else
            {
                p1Frozen.Text = "NO";
            }
            if (player1.getIsBleeding() == true)
            {
                p1Bleeding.Text = "YES";
            }
            else
            {
                p1Bleeding.Text = "NO";
            }
            if (player1.getIsStupefied() == true)
            {
                p1Stupefied.Text = "YES";
            }
            else
            {
                p1Stupefied.Text = "NO";
            }
            if (player1.getIsWeak() == true)
            {
                p1Weak.Text = "YES";
            }
            else
            {
                p1Weak.Text = "NO";
            }
            if (player1.getIsDizzy() == true)
            {
                p1Dizzy.Text = "YES";
            }
            else
            {
                p1Dizzy.Text = "NO";
            }
        }
                //Player 2
        private void loadPlayer2VisualStats()
        {
            p2Name.Text = player2.getName();
            p2Desc.Text = player2.getDesc();
            p2Hp.Value = player2.getHP();
            p2Atk.Value = player2.getAtk();
            p2Def.Value = player2.getDef();
            p2Acc.Value = player2.getAcc();
            p2Dge.Value = player2.getDge();
            p2Mv1.Text = player2.getMv1Name();
            p2Mv1Desc.Text = player2.getMv1Desc();
            p2Mv1AtkM.Value = (decimal)player2.getMv1M();
            p2Mv1Acc.Value = player2.getMv1Acc();
            p2Mv2.Text = player2.getMv2Name();
            p2Mv2Desc.Text = player2.getMv2Desc();
            p2Mv2AtkM.Value = (decimal)player2.getMv2M();
            p2Mv2Acc.Value = player2.getMv2Acc();
            p2Mv3.Text = player2.getMv3Name();
            p2Mv3Desc.Text = player2.getMv3Desc();
            p2Mv3AtkM.Value = (decimal)player2.getMv3M();
            p2Mv3Acc.Value = player2.getMv3Acc();
            p2Mv4.Text = player2.getMv4Name();
            p2Mv4Desc.Text = player2.getMv4Desc();
            p2Mv4AtkM.Value = (decimal)player2.getMv4M();
            p2Mv4Acc.Value = player2.getMv4Acc();
            p2Mv5.Text = player2.getMv5Name();
            p2Mv5Desc.Text = player2.getMv5Desc();
            p2Mv5AtkM.Value = (decimal)player2.getMv5M();
            p2Mv5Acc.Value = player2.getMv5Acc();
            if (player2.getIsStunned() == true)
            {
                p2Stunned.Text = "YES";
            }
            else
            {
                p2Stunned.Text = "NO";
            }
            if (player2.getIsPoisoned() == true)
            {
                p2Poisoned.Text = "YES";
            }
            else
            {
                p2Poisoned.Text = "NO";
            }
            if (player2.getIsBurned() == true)
            {
                p2Burned.Text = "YES";
            }
            else
            {
                p2Burned.Text = "NO";
            }
            if (player2.getIsCrippled() == true)
            {
                p2Crippled.Text = "YES";
            }
            else
            {
                p2Crippled.Text = "NO";
            }
            if (player2.getIsFrozen() == true)
            {
                p2Frozen.Text = "YES";
            }
            else
            {
                p2Frozen.Text = "NO";
            }
            if (player2.getIsBleeding() == true)
            {
                p2Bleeding.Text = "YES";
            }
            else
            {
                p2Bleeding.Text = "NO";
            }
            if (player2.getIsStupefied() == true)
            {
                p2Stupefied.Text = "YES";
            }
            else
            {
                p2Stupefied.Text = "NO";
            }
            if (player2.getIsWeak() == true)
            {
                p2Weak.Text = "YES";
            }
            else
            {
                p2Weak.Text = "NO";
            }
            if (player2.getIsDizzy() == true)
            {
                p2Dizzy.Text = "YES";
            }
            else
            {
                p2Dizzy.Text = "NO";
            }
        }
        //EvE Simulation
        private void EvESimulation()
        {
            disableAllButtons();
            eveSimText.Text = "";
            lastP1Move = 0;
            lastP2Move = 0;
            eveSimText.Text = "";
            while (player1.getHP() > 0 && player2.getHP() > 0)
            {
                loadPlayer1VisualStats();
                loadPlayer2VisualStats();
                EvERandomAI1(player1);
                loadPlayer1VisualStats();
                loadPlayer2VisualStats();
                if(player1.getHP() <= 0 || player2.getHP() <= 0)
                {
                    break;
                }
                //System.Threading.Thread.Sleep(2000);
                EvERandomAI2(player2);
                loadPlayer1VisualStats();
                loadPlayer2VisualStats();
                if (player1.getHP() <= 0 || player2.getHP() <= 0)
                {
                    break;
                }
                //System.Threading.Thread.Sleep(2000);
            }
            enableAllButtons();
        }
            //EvE AIs
        private void EvERandomAI1(Character player1)
        {
                //PLAYER 1
                //First, check if the player 1 is stunned or frozen
                bool p1Skipped = stunFrozenChecksP1(player1);
                if (p1Skipped == true)
                {
                    //If they are, see if they take damage from statuses, and then see if they are dead
                    if (damageStatusChecksP1(player1) == true)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                        enableAllButtons();
                        return;
                    }
                    else
                    {
                        //If they don't die, modify their status turns if applicable
                        player1.modifyStatusTurns();
                        return;
                    }
                }
                //If they are not stunned or frozen
                else
                {
                    //Check to see if they are stupefied (chance to not attack)
                    if (player1.getIsStupefied() == true)
                    {
                        //If they are, chance to not attack
                        Random rand1 = new Random();
                        int notHit = rand1.Next(0, 2);
                        //If 50% chance is 0, don't hit
                        if(notHit == 0)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 is stupefied and was not able to attack!");
                            //Finish the turn with status checks and modifications
                            if (damageStatusChecksP1(player1) == true)
                            {
                                eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                                enableAllButtons();
                                return;
                            }
                            else
                            {
                                //If they don't die, modify their status turns if applicable
                                player1.modifyStatusTurns();
                                return;
                            }
                        }
                        else
                        {
                            //Perform a random move
                            Random rand = new Random();
                            int randMove = rand.Next(1, 6);
                            while (randMove == lastP1Move)
                            {
                                randMove = rand.Next(1, 6);
                            }
                            //Peform the move based on the rand
                            p1Moves(randMove);
                            if(player2DeathChecks(player2) == true)
                            {
                                loadPlayer2VisualStats();
                                eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                                enableAllButtons();
                                return;
                            }
                            else if(player1DeathChecks(player1) == true)
                            {
                                loadPlayer2VisualStats();
                                loadPlayer1VisualStats();
                                eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                                enableAllButtons();
                                return;
                            }
                            else
                            {
                                loadPlayer2VisualStats();
                                loadPlayer1VisualStats();
                                return;
                            }
                        }
                    }
                    //Perform a random move
                    else
                    {
                        Random rand = new Random();
                        int randMove = rand.Next(1, 6);
                        while (randMove == lastP1Move)
                        {
                            randMove = rand.Next(1, 6);
                        }
                        //Peform the move based on the rand
                        p1Moves(randMove);
                        if (player2DeathChecks(player2) == true)
                        {
                            loadPlayer2VisualStats();
                            eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                            enableAllButtons();
                            return;
                        }
                        else if (player1DeathChecks(player1) == true)
                        {
                            loadPlayer2VisualStats();
                            loadPlayer1VisualStats();
                            eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                            enableAllButtons();
                            return;
                        }
                        else
                        {
                            loadPlayer2VisualStats();
                            loadPlayer1VisualStats();
                            return;
                        }
                    }
                }
        }
        private void EvERandomAI2(Character player2)
        {
                //PLAYER 2
                //First, check if the player 2 is stunned or frozen
                bool p2Skipped = stunFrozenChecksP2(player2);
                if (p2Skipped == true)
                {
                    //If they are, see if they take damage from statuses, and then see if they are dead
                    if (damageStatusChecksP2(player2) == true)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                        enableAllButtons();
                        return;
                    }
                    else
                    {
                        //If they don't die, modify their status turns if applicable
                        player2.modifyStatusTurns();
                        return;
                    }
                }
                //If they are not stunned or frozen
                else
                {
                    //Check to see if they are stupefied (chance to not attack)
                    if (player2.getIsStupefied() == true)
                    {
                        //If they are, chance to not attack
                        Random rand1 = new Random();
                        int notHit = rand1.Next(0, 2);
                        //If 50% chance is 0, don't hit
                        if (notHit == 0)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 is stupefied and was not able to attack!");
                            //Finish the turn with status checks and modifications
                            if (damageStatusChecksP1(player1) == true)
                            {
                                eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 2 wins!");
                                enableAllButtons();
                                return;
                            }
                            else
                            {
                                //If they don't die, modify their status turns if applicable
                                player2.modifyStatusTurns();
                                return;
                            }
                        }
                        else
                        {
                            //Perform a random move
                            Random rand = new Random();
                            int randMove = rand.Next(1, 6);
                            while (randMove == lastP1Move)
                            {
                                randMove = rand.Next(1, 6);
                            }
                            //Peform the move based on the rand
                            p2Moves(randMove);
                            if (player1DeathChecks(player1) == true)
                            {
                                eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                                enableAllButtons();
                                return;
                            }
                            else if (player2DeathChecks(player2) == true)
                            {
                                eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                                enableAllButtons();
                                return;
                            }
                            else
                            {
                                loadPlayer2VisualStats();
                                loadPlayer1VisualStats();
                                return;
                            }
                        }
                    }
                    //Perform a random move
                    else
                    {
                        Random rand = new Random();
                        int randMove = rand.Next(1, 6);
                        while (randMove == lastP1Move)
                        {
                            randMove = rand.Next(1, 6);
                        }
                        //Peform the move based on the rand
                        p2Moves(randMove);
                        if (player1DeathChecks(player1) == true)
                        {
                            loadPlayer1VisualStats();
                            eveSimText.AppendText(Environment.NewLine + "Player 1 has died. Player 2 wins!");
                            enableAllButtons();
                            return;
                        }
                        else if (player2DeathChecks(player2) == true)
                        {
                            loadPlayer1VisualStats();
                            loadPlayer2VisualStats();
                            eveSimText.AppendText(Environment.NewLine + "Player 2 has died. Player 1 wins!");
                            enableAllButtons();
                            return;
                        }
                        else
                        {
                            loadPlayer2VisualStats();
                            loadPlayer1VisualStats();
                            return;
                        }
                    }
                }
        }

        //General Simulation Methods
            //Player 1 Checks and Methods
        private bool stunFrozenChecksP1(Character player1)
        {
            //Bool returns if cannot move, true is yes, false is no
            if(player1.getIsStunned() == true)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 is stunned and cannot move!");
                return true;
            }else if(player1.getIsFrozen() == true)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 1 is frozen and cannot move!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool damageStatusChecksP1(Character player1)
        {
            //Bool returns if is dead (true is yes, false is no)
            //Poison
            if(player1.getIsPoisoned() == true)
            {
                if(player1.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes 1 damage from poison.");
                    player1.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes " + (player1.getHP() * 0.03).ToString() + " damage from poison.");
                    player1.modifyHP(-(int)(player1.getHP() * 0.03));
                }
                if(player1DeathChecks(player1) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer1VisualStats();
                }
            }
            //Burn
            if (player1.getIsBurned() == true)
            {
                if (player1.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes 1 damage from burn.");
                    player1.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes " + (player1.getHP() * 0.03).ToString() + " damage from burn.");
                    player1.modifyHP(-(int)(player1.getHP() * 0.03));
                }
                if (player1DeathChecks(player1) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer1VisualStats();
                }
            }
            //Bleed
            if (player1.getIsBleeding() == true)
            {
                if (player1.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes 1 damage from bleeding.");
                    player1.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 1 takes " + (player1.getHP() * 0.03).ToString() + " damage from bleeding.");
                    player1.modifyHP(-(int)(player1.getHP() * 0.03));
                }
                if (player1DeathChecks(player1) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer1VisualStats();
                }
            }
            return false;
        }
        private bool player1DeathChecks(Character player1)
        {
            if(player1.getHP() <= 0)
            {
                player1.setHp(0);
                loadPlayer1VisualStats();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void p1Moves(int move)
        {
            int totalAcc1;
            //Modifiers
            float atkStatModValPsn = 1f;
            float atkStatModValWk = 1f;
            if(player1.getIsPoisoned() == true)
            {
                atkStatModValPsn = 0.9f;
            }
            if(player1.getIsWeak() == true)
            {
                atkStatModValWk = 0.75f;
            }
            //Move 1
            if(move == 1)
            {
                totalAcc1 = player1.getAcc() + player1.getMv1Acc() - player2.getDge();
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 1!");
                    int totalAtk = (int)(player1.getAtk() * player1.getMv1M() * atkStatModValPsn * atkStatModValWk);
                    int damageDealt = totalAtk ^ 2 / player2.getDef();
                    eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
                    player2.modifyHP(-damageDealt);
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv1Heal().ToString());
                    player1.modifyHP(player1.getMv1Heal());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv1AtkMod().ToString());
                    player1.modifyATK(player1.getMv1AtkMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv1DefMod().ToString());
                    player1.modifyDEF(player1.getMv1DefMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv1AccMod().ToString());
                    player1.modifyACC(player1.getMv1AccMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv1DgeMod().ToString());
                    player1.modifyDGE(player1.getMv1DgeMod());
                    //Induces effects?
                    if(player1.getMv1indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                        player2.induceStun();
                    }
                    if (player1.getMv1indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                        player2.inducePoison();
                    }
                    if (player1.getMv1indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                        player2.induceBurn();
                    }
                    if (player1.getMv1indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                        player2.induceCripple();
                    }
                    if (player1.getMv1indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                        player2.induceFrozen();
                    }
                    if (player1.getMv1indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                        player2.induceBleeding();
                    }
                    if (player1.getMv1indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                        player2.induceStupefy();
                    }
                    if (player1.getMv1indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                        player2.induceWeak();
                    }
                    if (player1.getMv1indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                        player2.induceDizzy();
                    }
                }
                else if(totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if(chance <= totalAcc1)
                    {
                        //The move lands
                        eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 1!");
                        int totalAtk = (int)(player1.getAtk() * player1.getMv1M() * atkStatModValPsn * atkStatModValWk);
                        int damageDealt = totalAtk ^ 2 / player2.getDef();
                        eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
                        player2.modifyHP(-damageDealt);
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv1Heal().ToString());
                        player1.modifyHP(player1.getMv1Heal());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv1AtkMod().ToString());
                        player1.modifyATK(player1.getMv1AtkMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv1DefMod().ToString());
                        player1.modifyDEF(player1.getMv1DefMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv1AccMod().ToString());
                        player1.modifyACC(player1.getMv1AccMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv1DgeMod().ToString());
                        player1.modifyDGE(player1.getMv1DgeMod());
                        //Induces effects?
                        if (player1.getMv1indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                            player2.induceStun();
                        }
                        if (player1.getMv1indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                            player2.inducePoison();
                        }
                        if (player1.getMv1indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                            player2.induceBurn();
                        }
                        if (player1.getMv1indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                            player2.induceCripple();
                        }
                        if (player1.getMv1indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                            player2.induceFrozen();
                        }
                        if (player1.getMv1indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                            player2.induceBleeding();
                        }
                        if (player1.getMv1indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                            player2.induceStupefy();
                        }
                        if (player1.getMv1indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                            player2.induceWeak();
                        }
                        if (player1.getMv1indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                            player2.induceDizzy();
                        }
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                }
            }
            //Move 2
            if (move == 2)
            {
                totalAcc1 = player1.getAcc() + player1.getMv2Acc() - player2.getDge();
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 2!");
                    int totalAtk = (int)(player1.getAtk() * player1.getMv2M() * atkStatModValPsn * atkStatModValWk);
                    int damageDealt = totalAtk ^ 2 / player2.getDef();
                    eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
                    player2.modifyHP(-damageDealt);
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv2Heal().ToString());
                    player1.modifyHP(player1.getMv2Heal());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv2AtkMod().ToString());
                    player1.modifyATK(player1.getMv2AtkMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv2DefMod().ToString());
                    player1.modifyDEF(player1.getMv2DefMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv2AccMod().ToString());
                    player1.modifyACC(player1.getMv2AccMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv2DgeMod().ToString());
                    player1.modifyDGE(player1.getMv2DgeMod());
                    //Induces effects?
                    if (player1.getMv2indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                        player2.induceStun();
                    }
                    if (player1.getMv2indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                        player2.inducePoison();
                    }
                    if (player1.getMv2indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                        player2.induceBurn();
                    }
                    if (player1.getMv2indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                        player2.induceCripple();
                    }
                    if (player1.getMv2indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                        player2.induceFrozen();
                    }
                    if (player1.getMv2indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                        player2.induceBleeding();
                    }
                    if (player1.getMv2indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                        player2.induceStupefy();
                    }
                    if (player1.getMv2indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                        player2.induceWeak();
                    }
                    if (player1.getMv2indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                        player2.induceDizzy();
                    }
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 2!");
                        int totalAtk = (int)(player1.getAtk() * player1.getMv2M() * atkStatModValPsn * atkStatModValWk);
                        int damageDealt = totalAtk ^ 2 / player2.getDef();
                        eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
                        player2.modifyHP(-damageDealt);
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv2Heal().ToString());
                        player1.modifyHP(player1.getMv2Heal());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv2AtkMod().ToString());
                        player1.modifyATK(player1.getMv2AtkMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv2DefMod().ToString());
                        player1.modifyDEF(player1.getMv2DefMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv2AccMod().ToString());
                        player1.modifyACC(player1.getMv2AccMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv2DgeMod().ToString());
                        player1.modifyDGE(player1.getMv2DgeMod());
                        //Induces effects?
                        if (player1.getMv2indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                            player2.induceStun();
                        }
                        if (player1.getMv2indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                            player2.inducePoison();
                        }
                        if (player1.getMv2indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                            player2.induceBurn();
                        }
                        if (player1.getMv2indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                            player2.induceCripple();
                        }
                        if (player1.getMv2indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                            player2.induceFrozen();
                        }
                        if (player1.getMv2indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                            player2.induceBleeding();
                        }
                        if (player1.getMv2indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                            player2.induceStupefy();
                        }
                        if (player1.getMv2indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                            player2.induceWeak();
                        }
                        if (player1.getMv2indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                            player2.induceDizzy();
                        }
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                }
            }
            //Move 3
            if (move == 3)
            {
                totalAcc1 = player1.getAcc() + player1.getMv3Acc() - player2.getDge();
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 3!");
                    int totalAtk = (int)(player1.getAtk() * player1.getMv3M() * atkStatModValPsn * atkStatModValWk);
                    int damageDealt = totalAtk ^ 2 / player2.getDef();
                    eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
                    player2.modifyHP(-damageDealt);
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv3Heal().ToString());
                    player1.modifyHP(player1.getMv3Heal());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv3AtkMod().ToString());
                    player1.modifyATK(player1.getMv3AtkMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv3DefMod().ToString());
                    player1.modifyDEF(player1.getMv3DefMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv3AccMod().ToString());
                    player1.modifyACC(player1.getMv3AccMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv3DgeMod().ToString());
                    player1.modifyDGE(player1.getMv3DgeMod());
                    //Induces effects?
                    if (player1.getMv3indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                        player2.induceStun();
                    }
                    if (player1.getMv3indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                        player2.inducePoison();
                    }
                    if (player1.getMv3indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                        player2.induceBurn();
                    }
                    if (player1.getMv3indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                        player2.induceCripple();
                    }
                    if (player1.getMv3indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                        player2.induceFrozen();
                    }
                    if (player1.getMv3indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                        player2.induceBleeding();
                    }
                    if (player1.getMv3indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                        player2.induceStupefy();
                    }
                    if (player1.getMv3indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                        player2.induceWeak();
                    }
                    if (player1.getMv3indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                        player2.induceDizzy();
                    }
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 3!");
                        int totalAtk = (int)(player1.getAtk() * player1.getMv3M() * atkStatModValPsn * atkStatModValWk);
                        int damageDealt = totalAtk ^ 2 / player2.getDef();
                        eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
                        player2.modifyHP(-damageDealt);
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv3Heal().ToString());
                        player1.modifyHP(player1.getMv3Heal());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv3AtkMod().ToString());
                        player1.modifyATK(player1.getMv3AtkMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv3DefMod().ToString());
                        player1.modifyDEF(player1.getMv3DefMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv3AccMod().ToString());
                        player1.modifyACC(player1.getMv3AccMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv3DgeMod().ToString());
                        player1.modifyDGE(player1.getMv3DgeMod());
                        //Induces effects?
                        if (player1.getMv3indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                            player2.induceStun();
                        }
                        if (player1.getMv3indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                            player2.inducePoison();
                        }
                        if (player1.getMv3indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                            player2.induceBurn();
                        }
                        if (player1.getMv3indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                            player2.induceCripple();
                        }
                        if (player1.getMv3indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                            player2.induceFrozen();
                        }
                        if (player1.getMv3indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                            player2.induceBleeding();
                        }
                        if (player1.getMv3indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                            player2.induceStupefy();
                        }
                        if (player1.getMv3indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                            player2.induceWeak();
                        }
                        if (player1.getMv3indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                            player2.induceDizzy();
                        }
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                }
            }
            //Move 4
            if (move == 4)
            {
                totalAcc1 = player1.getAcc() + player1.getMv4Acc() - player2.getDge();
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 4!");
                    int totalAtk = (int)(player1.getAtk() * player1.getMv4M() * atkStatModValPsn * atkStatModValWk);
                    int damageDealt = totalAtk ^ 2 / player2.getDef();
                    eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
                    player2.modifyHP(-damageDealt);
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv4Heal().ToString());
                    player1.modifyHP(player1.getMv4Heal());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv4AtkMod().ToString());
                    player1.modifyATK(player1.getMv4AtkMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv4DefMod().ToString());
                    player1.modifyDEF(player1.getMv4DefMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv4AccMod().ToString());
                    player1.modifyACC(player1.getMv4AccMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv4DgeMod().ToString());
                    player1.modifyDGE(player1.getMv4DgeMod());
                    //Induces effects?
                    if (player1.getMv4indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                        player2.induceStun();
                    }
                    if (player1.getMv4indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                        player2.inducePoison();
                    }
                    if (player1.getMv4indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                        player2.induceBurn();
                    }
                    if (player1.getMv4indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                        player2.induceCripple();
                    }
                    if (player1.getMv4indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                        player2.induceFrozen();
                    }
                    if (player1.getMv4indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                        player2.induceBleeding();
                    }
                    if (player1.getMv4indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                        player2.induceStupefy();
                    }
                    if (player1.getMv4indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                        player2.induceWeak();
                    }
                    if (player1.getMv4indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                        player2.induceDizzy();
                    }
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 4!");
                        int totalAtk = (int)(player1.getAtk() * player1.getMv4M() * atkStatModValPsn * atkStatModValWk);
                        int damageDealt = totalAtk ^ 2 / player2.getDef();
                        eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
                        player2.modifyHP(-damageDealt);
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv4Heal().ToString());
                        player1.modifyHP(player1.getMv4Heal());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv4AtkMod().ToString());
                        player1.modifyATK(player1.getMv4AtkMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv4DefMod().ToString());
                        player1.modifyDEF(player1.getMv4DefMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv4AccMod().ToString());
                        player1.modifyACC(player1.getMv4AccMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv4DgeMod().ToString());
                        player1.modifyDGE(player1.getMv4DgeMod());
                        //Induces effects?
                        if (player1.getMv4indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                            player2.induceStun();
                        }
                        if (player1.getMv4indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                            player2.inducePoison();
                        }
                        if (player1.getMv4indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                            player2.induceBurn();
                        }
                        if (player1.getMv4indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                            player2.induceCripple();
                        }
                        if (player1.getMv4indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                            player2.induceFrozen();
                        }
                        if (player1.getMv4indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                            player2.induceBleeding();
                        }
                        if (player1.getMv4indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                            player2.induceStupefy();
                        }
                        if (player1.getMv4indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                            player2.induceWeak();
                        }
                        if (player1.getMv4indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                            player2.induceDizzy();
                        }
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                }
            }
            //Move 5
            if (move == 5)
            {
                totalAcc1 = player1.getAcc() + player1.getMv5Acc() - player2.getDge();
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 5!");
                    int totalAtk = (int)(player1.getAtk() * player1.getMv4M() * atkStatModValPsn * atkStatModValWk);
                    int damageDealt = totalAtk ^ 2 / player2.getDef();
                    eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
                    player2.modifyHP(-damageDealt);
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv5Heal().ToString());
                    player1.modifyHP(player1.getMv5Heal());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv5AtkMod().ToString());
                    player1.modifyATK(player1.getMv5AtkMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv5DefMod().ToString());
                    player1.modifyDEF(player1.getMv5DefMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv5AccMod().ToString());
                    player1.modifyACC(player1.getMv5AccMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv5DgeMod().ToString());
                    player1.modifyDGE(player1.getMv5DgeMod());
                    //Induces effects?
                    if (player1.getMv5indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                        player2.induceStun();
                    }
                    if (player1.getMv5indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                        player2.inducePoison();
                    }
                    if (player1.getMv5indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                        player2.induceBurn();
                    }
                    if (player1.getMv5indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                        player2.induceCripple();
                    }
                    if (player1.getMv5indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                        player2.induceFrozen();
                    }
                    if (player1.getMv5indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                        player2.induceBleeding();
                    }
                    if (player1.getMv5indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                        player2.induceStupefy();
                    }
                    if (player1.getMv5indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                        player2.induceWeak();
                    }
                    if (player1.getMv5indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                        player2.induceDizzy();
                    }
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveSimText.AppendText(Environment.NewLine + "Player 1 lands their Move 5!");
                        int totalAtk = (int)(player1.getAtk() * player1.getMv4M() * atkStatModValPsn * atkStatModValWk);
                        int damageDealt = totalAtk ^ 2 / player2.getDef();
                        eveSimText.AppendText(Environment.NewLine + "Player 1 deals " + damageDealt.ToString() + " damage to Player 2.");
                        player2.modifyHP(-damageDealt);
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own HP by " + player1.getMv5Heal().ToString());
                        player1.modifyHP(player1.getMv5Heal());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ATK by " + player1.getMv5AtkMod().ToString());
                        player1.modifyATK(player1.getMv5AtkMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DEF by " + player1.getMv5DefMod().ToString());
                        player1.modifyDEF(player1.getMv5DefMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own ACC by " + player1.getMv5AccMod().ToString());
                        player1.modifyACC(player1.getMv5AccMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 1 modifies their own DGE by " + player1.getMv5DgeMod().ToString());
                        player1.modifyDGE(player1.getMv5DgeMod());
                        //Induces effects?
                        if (player1.getMv5indStun() == true && player2.getimnStun() == false && player2.getIsStunned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 stuns Player 2!");
                            player2.induceStun();
                        }
                        if (player1.getMv5indPsn() == true && player2.getimnPsn() == false && player2.getIsPoisoned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 poisons Player 2!");
                            player2.inducePoison();
                        }
                        if (player1.getMv5indBrn() == true && player2.getimnBrn() == false && player2.getIsBurned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 burns Player 2!");
                            player2.induceBurn();
                        }
                        if (player1.getMv5indCrpl() == true && player2.getimnCrpl() == false && player2.getIsCrippled() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 cripples Player 2!");
                            player2.induceCripple();
                        }
                        if (player1.getMv5indFrzn() == true && player2.getimnFrzn() == false && player2.getIsFrozen() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 freezes Player 2!");
                            player2.induceFrozen();
                        }
                        if (player1.getMv5indBld() == true && player2.getimnBld() == false && player2.getIsBleeding() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 slices Player 2, causing them to bleed!");
                            player2.induceBleeding();
                        }
                        if (player1.getMv5indStpf() == true && player2.getimnStpf() == false && player2.getIsStupefied() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 stupefies Player 2!");
                            player2.induceStupefy();
                        }
                        if (player1.getMv5indWk() == true && player2.getimnWk() == false && player2.getIsWeak() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 weakens Player 2!");
                            player2.induceWeak();
                        }
                        if (player1.getMv5indDzz() == true && player2.getimnDzz() == false && player2.getIsDizzy() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 1 causes Player 2 to become dizzy!");
                            player2.induceDizzy();
                        }
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 2 dodges the attack.");
                }
            }
        }
            //Player 2 Checks and Methods
        private bool stunFrozenChecksP2(Character player2)
        {
            //Bool returns if cannot move, true is yes, false is no
            if (player2.getIsStunned() == true)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 is stunned and cannot move!");
                return true;
            }
            else if (player2.getIsFrozen() == true)
            {
                eveSimText.AppendText(Environment.NewLine + "Player 2 is frozen and cannot move!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool damageStatusChecksP2(Character player2)
        {
            //Bool returns if is dead (true is yes, false is no)
            //Poison
            if (player2.getIsPoisoned() == true)
            {
                if (player2.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes 1 damage from poison.");
                    player2.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes " + (player2.getHP() * 0.03).ToString() + " damage from poison.");
                    player2.modifyHP(-(int)(player2.getHP() * 0.03));
                }
                if (player2DeathChecks(player2) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer2VisualStats();
                }
            }
            //Burn
            if (player2.getIsBurned() == true)
            {
                if (player2.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes 1 damage from burn.");
                    player2.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes " + (player2.getHP() * 0.03).ToString() + " damage from burn.");
                    player2.modifyHP(-(int)(player2.getHP() * 0.03));
                }
                if (player2DeathChecks(player2) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer2VisualStats();
                }
            }
            //Bleed
            if (player2.getIsBleeding() == true)
            {
                if (player2.getHP() < 30)
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes 1 damage from bleeding.");
                    player2.modifyHP(-1);
                }
                else
                {
                    eveSimText.AppendText(Environment.NewLine + "Player 2 takes " + (player2.getHP() * 0.03).ToString() + " damage from bleeding.");
                    player2.modifyHP(-(int)(player2.getHP() * 0.03));
                }
                if (player2DeathChecks(player2) == true)
                {
                    return true;
                }
                else
                {
                    loadPlayer2VisualStats();
                }
            }
            return false;
        }
        private bool player2DeathChecks(Character player2)
        {
            if (player2.getHP() <= 0)
            {
                player2.setHp(0);
                loadPlayer2VisualStats();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void p2Moves(int move)
        {
            int totalAcc1;
            //Modifiers
            float atkStatModValPsn = 1f;
            float atkStatModValWk = 1f;
            if (player2.getIsPoisoned() == true)
            {
                atkStatModValPsn = 0.9f;
            }
            if (player2.getIsWeak() == true)
            {
                atkStatModValWk = 0.75f;
            }
            //Move 1
            if (move == 1)
            {
                totalAcc1 = player2.getAcc() + player2.getMv1Acc() - player1.getDge();
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 1!");
                    int totalAtk = (int)(player2.getAtk() * player2.getMv1M() * atkStatModValPsn * atkStatModValWk);
                    int damageDealt = totalAtk ^ 2 / player1.getDef();
                    eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
                    player1.modifyHP(-damageDealt);
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv1Heal().ToString());
                    player2.modifyHP(player2.getMv1Heal());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv1AtkMod().ToString());
                    player2.modifyATK(player2.getMv1AtkMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv1DefMod().ToString());
                    player2.modifyDEF(player2.getMv1DefMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv1AccMod().ToString());
                    player2.modifyACC(player2.getMv1AccMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv1DgeMod().ToString());
                    player2.modifyDGE(player2.getMv1DgeMod());
                    //Induces effects?
                    if (player2.getMv1indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                        player1.induceStun();
                    }
                    if (player2.getMv1indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                        player1.inducePoison();
                    }
                    if (player2.getMv1indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                        player1.induceBurn();
                    }
                    if (player2.getMv1indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                        player1.induceCripple();
                    }
                    if (player2.getMv1indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                        player1.induceFrozen();
                    }
                    if (player2.getMv1indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                        player1.induceBleeding();
                    }
                    if (player2.getMv1indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                        player1.induceStupefy();
                    }
                    if (player2.getMv1indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                        player1.induceWeak();
                    }
                    if (player2.getMv1indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                        player1.induceDizzy();
                    }
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 1!");
                        int totalAtk = (int)(player2.getAtk() * player2.getMv1M() * atkStatModValPsn * atkStatModValWk);
                        int damageDealt = totalAtk ^ 2 / player1.getDef();
                        eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
                        player1.modifyHP(-damageDealt);
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv1Heal().ToString());
                        player2.modifyHP(player2.getMv1Heal());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv1AtkMod().ToString());
                        player2.modifyATK(player2.getMv1AtkMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv1DefMod().ToString());
                        player2.modifyDEF(player2.getMv1DefMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv1AccMod().ToString());
                        player2.modifyACC(player2.getMv1AccMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv1DgeMod().ToString());
                        player2.modifyDGE(player2.getMv1DgeMod());
                        //Induces effects?
                        if (player2.getMv1indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                            player1.induceStun();
                        }
                        if (player2.getMv1indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                            player1.inducePoison();
                        }
                        if (player2.getMv1indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                            player1.induceBurn();
                        }
                        if (player2.getMv1indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                            player1.induceCripple();
                        }
                        if (player2.getMv1indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                            player1.induceFrozen();
                        }
                        if (player2.getMv1indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                            player1.induceBleeding();
                        }
                        if (player2.getMv1indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                            player1.induceStupefy();
                        }
                        if (player2.getMv1indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                            player1.induceWeak();
                        }
                        if (player2.getMv1indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                            player1.induceDizzy();
                        }
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                }
            }
            //Move 2
            if (move == 2)
            {
                totalAcc1 = player2.getAcc() + player2.getMv2Acc() - player1.getDge();
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 2!");
                    int totalAtk = (int)(player2.getAtk() * player2.getMv2M() * atkStatModValPsn * atkStatModValWk);
                    int damageDealt = totalAtk ^ 2 / player1.getDef();
                    eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
                    player1.modifyHP(-damageDealt);
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv2Heal().ToString());
                    player2.modifyHP(player2.getMv2Heal());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv2AtkMod().ToString());
                    player2.modifyATK(player2.getMv2AtkMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv2DefMod().ToString());
                    player2.modifyDEF(player2.getMv2DefMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv2AccMod().ToString());
                    player2.modifyACC(player2.getMv2AccMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv2DgeMod().ToString());
                    player2.modifyDGE(player2.getMv2DgeMod());
                    //Induces effects?
                    if (player2.getMv2indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                        player1.induceStun();
                    }
                    if (player2.getMv2indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                        player1.inducePoison();
                    }
                    if (player2.getMv2indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                        player1.induceBurn();
                    }
                    if (player2.getMv2indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                        player1.induceCripple();
                    }
                    if (player2.getMv2indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                        player1.induceFrozen();
                    }
                    if (player2.getMv2indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                        player1.induceBleeding();
                    }
                    if (player2.getMv2indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                        player1.induceStupefy();
                    }
                    if (player2.getMv2indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                        player1.induceWeak();
                    }
                    if (player2.getMv2indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                        player1.induceDizzy();
                    }
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 2!");
                        int totalAtk = (int)(player2.getAtk() * player2.getMv2M() * atkStatModValPsn * atkStatModValWk);
                        int damageDealt = totalAtk ^ 2 / player1.getDef();
                        eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
                        player1.modifyHP(-damageDealt);
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv2Heal().ToString());
                        player2.modifyHP(player2.getMv2Heal());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv2AtkMod().ToString());
                        player2.modifyATK(player2.getMv2AtkMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv2DefMod().ToString());
                        player2.modifyDEF(player2.getMv2DefMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv2AccMod().ToString());
                        player2.modifyACC(player2.getMv2AccMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv2DgeMod().ToString());
                        player2.modifyDGE(player2.getMv2DgeMod());
                        //Induces effects?
                        if (player2.getMv2indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                            player1.induceStun();
                        }
                        if (player2.getMv2indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                            player1.inducePoison();
                        }
                        if (player2.getMv2indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                            player1.induceBurn();
                        }
                        if (player2.getMv2indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                            player1.induceCripple();
                        }
                        if (player2.getMv2indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                            player1.induceFrozen();
                        }
                        if (player2.getMv2indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                            player1.induceBleeding();
                        }
                        if (player2.getMv2indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                            player1.induceStupefy();
                        }
                        if (player2.getMv2indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                            player1.induceWeak();
                        }
                        if (player2.getMv2indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                            player1.induceDizzy();
                        }
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                }
            }
            //Move 3
            if (move == 3)
            {
                totalAcc1 = player2.getAcc() + player2.getMv3Acc() - player1.getDge();
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 3!");
                    int totalAtk = (int)(player2.getAtk() * player2.getMv3M() * atkStatModValPsn * atkStatModValWk);
                    int damageDealt = totalAtk ^ 2 / player1.getDef();
                    eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
                    player1.modifyHP(-damageDealt);
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv3Heal().ToString());
                    player2.modifyHP(player2.getMv3Heal());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv3AtkMod().ToString());
                    player2.modifyATK(player2.getMv3AtkMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv3DefMod().ToString());
                    player2.modifyDEF(player2.getMv3DefMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv3AccMod().ToString());
                    player2.modifyACC(player2.getMv3AccMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv3DgeMod().ToString());
                    player2.modifyDGE(player2.getMv3DgeMod());
                    //Induces effects?
                    if (player2.getMv3indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                        player1.induceStun();
                    }
                    if (player2.getMv3indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                        player1.inducePoison();
                    }
                    if (player2.getMv3indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                        player1.induceBurn();
                    }
                    if (player2.getMv3indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                        player1.induceCripple();
                    }
                    if (player2.getMv3indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                        player1.induceFrozen();
                    }
                    if (player2.getMv3indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                        player1.induceBleeding();
                    }
                    if (player2.getMv3indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                        player1.induceStupefy();
                    }
                    if (player2.getMv3indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                        player1.induceWeak();
                    }
                    if (player2.getMv3indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                        player1.induceDizzy();
                    }
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 3!");
                        int totalAtk = (int)(player2.getAtk() * player2.getMv3M() * atkStatModValPsn * atkStatModValWk);
                        int damageDealt = totalAtk ^ 2 / player1.getDef();
                        eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
                        player1.modifyHP(-damageDealt);
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv3Heal().ToString());
                        player2.modifyHP(player2.getMv3Heal());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv3AtkMod().ToString());
                        player2.modifyATK(player2.getMv3AtkMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv3DefMod().ToString());
                        player2.modifyDEF(player2.getMv3DefMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv3AccMod().ToString());
                        player2.modifyACC(player2.getMv3AccMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv3DgeMod().ToString());
                        player2.modifyDGE(player2.getMv3DgeMod());
                        //Induces effects?
                        if (player2.getMv3indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                            player1.induceStun();
                        }
                        if (player2.getMv3indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                            player1.inducePoison();
                        }
                        if (player2.getMv3indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                            player1.induceBurn();
                        }
                        if (player2.getMv3indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                            player1.induceCripple();
                        }
                        if (player2.getMv3indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                            player1.induceFrozen();
                        }
                        if (player2.getMv3indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                            player1.induceBleeding();
                        }
                        if (player2.getMv3indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                            player1.induceStupefy();
                        }
                        if (player2.getMv3indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                            player1.induceWeak();
                        }
                        if (player2.getMv3indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                            player1.induceDizzy();
                        }
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                }
            }
            //Move 4
            if (move == 4)
            {
                totalAcc1 = player2.getAcc() + player2.getMv4Acc() - player1.getDge();
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 4!");
                    int totalAtk = (int)(player2.getAtk() * player2.getMv4M() * atkStatModValPsn * atkStatModValWk);
                    int damageDealt = totalAtk ^ 2 / player1.getDef();
                    eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
                    player1.modifyHP(-damageDealt);
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv4Heal().ToString());
                    player2.modifyHP(player2.getMv4Heal());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv4AtkMod().ToString());
                    player2.modifyATK(player2.getMv4AtkMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv4DefMod().ToString());
                    player2.modifyDEF(player2.getMv4DefMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv4AccMod().ToString());
                    player2.modifyACC(player2.getMv4AccMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv4DgeMod().ToString());
                    player2.modifyDGE(player2.getMv4DgeMod());
                    //Induces effects?
                    if (player2.getMv4indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                        player1.induceStun();
                    }
                    if (player2.getMv4indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                        player1.inducePoison();
                    }
                    if (player2.getMv4indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                        player1.induceBurn();
                    }
                    if (player2.getMv4indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                        player1.induceCripple();
                    }
                    if (player2.getMv4indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                        player1.induceFrozen();
                    }
                    if (player2.getMv4indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                        player1.induceBleeding();
                    }
                    if (player2.getMv4indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                        player1.induceStupefy();
                    }
                    if (player2.getMv4indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                        player1.induceWeak();
                    }
                    if (player2.getMv4indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                        player1.induceDizzy();
                    }
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 4!");
                        int totalAtk = (int)(player2.getAtk() * player2.getMv4M() * atkStatModValPsn * atkStatModValWk);
                        int damageDealt = totalAtk ^ 2 / player1.getDef();
                        eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
                        player1.modifyHP(-damageDealt);
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv4Heal().ToString());
                        player2.modifyHP(player2.getMv4Heal());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv4AtkMod().ToString());
                        player2.modifyATK(player2.getMv4AtkMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv4DefMod().ToString());
                        player2.modifyDEF(player2.getMv4DefMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv4AccMod().ToString());
                        player2.modifyACC(player2.getMv4AccMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv4DgeMod().ToString());
                        player2.modifyDGE(player2.getMv4DgeMod());
                        //Induces effects?
                        if (player2.getMv4indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                            player1.induceStun();
                        }
                        if (player2.getMv4indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                            player1.inducePoison();
                        }
                        if (player2.getMv4indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                            player1.induceBurn();
                        }
                        if (player2.getMv4indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                            player1.induceCripple();
                        }
                        if (player2.getMv4indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                            player1.induceFrozen();
                        }
                        if (player2.getMv4indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                            player1.induceBleeding();
                        }
                        if (player2.getMv4indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                            player1.induceStupefy();
                        }
                        if (player2.getMv4indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                            player1.induceWeak();
                        }
                        if (player2.getMv4indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                            player1.induceDizzy();
                        }
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                }
            }
            //Move 5
            if (move == 5)
            {
                totalAcc1 = player2.getAcc() + player2.getMv5Acc() - player1.getDge();
                //Check if it was dodged
                if (totalAcc1 >= 100)
                {
                    //The move lands
                    eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 5!");
                    int totalAtk = (int)(player2.getAtk() * player2.getMv4M() * atkStatModValPsn * atkStatModValWk);
                    int damageDealt = totalAtk ^ 2 / player1.getDef();
                    eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
                    player1.modifyHP(-damageDealt);
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv5Heal().ToString());
                    player2.modifyHP(player2.getMv5Heal());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv5AtkMod().ToString());
                    player2.modifyATK(player2.getMv5AtkMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv5DefMod().ToString());
                    player2.modifyDEF(player2.getMv5DefMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv5AccMod().ToString());
                    player2.modifyACC(player2.getMv5AccMod());
                    eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv5DgeMod().ToString());
                    player2.modifyDGE(player2.getMv5DgeMod());
                    //Induces effects?
                    if (player2.getMv5indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                        player1.induceStun();
                    }
                    if (player2.getMv5indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                        player1.inducePoison();
                    }
                    if (player2.getMv5indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                        player1.induceBurn();
                    }
                    if (player2.getMv5indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                        player1.induceCripple();
                    }
                    if (player2.getMv5indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                        player1.induceFrozen();
                    }
                    if (player2.getMv5indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                        player1.induceBleeding();
                    }
                    if (player2.getMv5indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                        player1.induceStupefy();
                    }
                    if (player2.getMv5indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                        player1.induceWeak();
                    }
                    if (player2.getMv5indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
                    {
                        eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                        player1.induceDizzy();
                    }
                }
                else if (totalAcc1 > 0 && totalAcc1 < 100)
                {
                    Random chanceRand = new Random();
                    int chance = chanceRand.Next(0, totalAcc1);
                    if (chance <= totalAcc1)
                    {
                        //The move lands
                        eveSimText.AppendText(Environment.NewLine + "Player 2 lands their Move 5!");
                        int totalAtk = (int)(player2.getAtk() * player2.getMv4M() * atkStatModValPsn * atkStatModValWk);
                        int damageDealt = totalAtk ^ 2 / player1.getDef();
                        eveSimText.AppendText(Environment.NewLine + "Player 2 deals " + damageDealt.ToString() + " damage to Player 1.");
                        player1.modifyHP(-damageDealt);
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own HP by " + player2.getMv5Heal().ToString());
                        player2.modifyHP(player2.getMv5Heal());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ATK by " + player2.getMv5AtkMod().ToString());
                        player2.modifyATK(player2.getMv5AtkMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DEF by " + player2.getMv5DefMod().ToString());
                        player2.modifyDEF(player2.getMv5DefMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own ACC by " + player2.getMv5AccMod().ToString());
                        player2.modifyACC(player2.getMv5AccMod());
                        eveSimText.AppendText(Environment.NewLine + "Player 2 modifies their own DGE by " + player2.getMv5DgeMod().ToString());
                        player2.modifyDGE(player2.getMv5DgeMod());
                        //Induces effects?
                        if (player2.getMv5indStun() == true && player1.getimnStun() == false && player1.getIsStunned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 stuns Player 1!");
                            player1.induceStun();
                        }
                        if (player2.getMv5indPsn() == true && player1.getimnPsn() == false && player1.getIsPoisoned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 poisons Player 1!");
                            player1.inducePoison();
                        }
                        if (player2.getMv5indBrn() == true && player1.getimnBrn() == false && player1.getIsBurned() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 burns Player 1!");
                            player1.induceBurn();
                        }
                        if (player2.getMv5indCrpl() == true && player1.getimnCrpl() == false && player1.getIsCrippled() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 cripples Player 1!");
                            player1.induceCripple();
                        }
                        if (player2.getMv5indFrzn() == true && player1.getimnFrzn() == false && player1.getIsFrozen() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 freezes Player 1!");
                            player1.induceFrozen();
                        }
                        if (player2.getMv5indBld() == true && player1.getimnBld() == false && player1.getIsBleeding() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 slices Player 1, causing them to bleed!");
                            player1.induceBleeding();
                        }
                        if (player2.getMv5indStpf() == true && player1.getimnStpf() == false && player1.getIsStupefied() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 stupefies Player 1!");
                            player1.induceStupefy();
                        }
                        if (player2.getMv5indWk() == true && player1.getimnWk() == false && player1.getIsWeak() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 weakens Player 1!");
                            player1.induceWeak();
                        }
                        if (player2.getMv5indDzz() == true && player1.getimnDzz() == false && player1.getIsDizzy() == false)
                        {
                            eveSimText.AppendText(Environment.NewLine + "Player 2 causes Player 1 to become dizzy!");
                            player1.induceDizzy();
                        }
                    }
                    else
                    {
                        //The move doesn't hit
                        eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                    }
                }
                else
                {
                    //The move doesn't hit
                    eveSimText.AppendText(Environment.NewLine + "Player 1 dodges the attack.");
                }
            }
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

        //Character Database Methods
        private void charDatabaseButton_Click(object sender, EventArgs e)
        {
            enableCharDatabaseUI();
        }

        //UNEDITABLE/NON-REMOVABLE METHODS
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void CCL40_Click(object sender, EventArgs e)
        {

        }

        private void CCL58_Click(object sender, EventArgs e)
        {

        }

        private void CCL57_Click(object sender, EventArgs e)
        {

        }

        private void CCL56_Click(object sender, EventArgs e)
        {

        }

        private void CCL55_Click(object sender, EventArgs e)
        {

        }

        private void CCL54_Click(object sender, EventArgs e)
        {

        }

        private void CCL53_Click(object sender, EventArgs e)
        {

        }

        private void CCL52_Click(object sender, EventArgs e)
        {

        }

        private void CCL51_Click(object sender, EventArgs e)
        {

        }

        private void CCc29_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc28_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc27_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc26_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc25_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc30_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc24_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc23_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCc22_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCL50_Click(object sender, EventArgs e)
        {

        }

        private void CCL49_Click(object sender, EventArgs e)
        {

        }

        private void CCL48_Click(object sender, EventArgs e)
        {

        }

        private void CCL47_Click(object sender, EventArgs e)
        {

        }

        private void CCN18_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCN17_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCN16_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCN15_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCN14_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCL46_Click(object sender, EventArgs e)
        {

        }

        private void CCN13_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCL45_Click(object sender, EventArgs e)
        {

        }

        private void CCL44_Click(object sender, EventArgs e)
        {

        }

        private void CCN12_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CCc21_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CCL43_Click(object sender, EventArgs e)
        {

        }

        private void CCT6_TextChanged(object sender, EventArgs e)
        {

        }

        private void CCL42_Click(object sender, EventArgs e)
        {

        }

        private void CCT5_TextChanged(object sender, EventArgs e)
        {

        }

        private void CCL41_Click(object sender, EventArgs e)
        {

        }

        private void CCL59_Click(object sender, EventArgs e)
        {

        }

        private void CCP2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

       
    }
}
