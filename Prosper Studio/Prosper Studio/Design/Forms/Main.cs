using System;
using System.Windows.Forms;
using XRPCLib;
using XDevkitPlusPlus;
using System.Drawing;
using System.Diagnostics;

namespace Prosper_Studio.Desing.Forms
{
    public partial class Main : Form
    {
        /* Creating a new instance of the XRPC class. */
        XRPC RGH = new XRPC();

        public Main()
        {
            InitializeComponent();

            /* It's just setting the text of the labels to the values of the variables. */
            this.TitleBarStatusLabel.ForeColor = Color.Red;

        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Connectbtn_Click(object sender, System.EventArgs e)
        {
           /* Trying to connect to the Xbox 360. */
            try
            {
                RGH.Connect();
                if (RGH.activeConnection == true)
                {
                    this.TitleBarStatusLabel.ForeColor = Color.Green;
                    this.TitleBarStatusLabel.Text = "Connected";
                }
                else
                {
                    MessageBox.Show("Connection Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.TitleBarStatusLabel.ForeColor = Color.Red;
                    this.TitleBarStatusLabel.Text = "Not connected";
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Do you have your system set in neighborhood?", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TitleBarStatusLabel.ForeColor = Color.Red;
            }
        }


        private void sendbo1zCMD(string command)
        {
           /* It's calling the function that is used to send commands to the game. */
            RGH.Call(0x8230FD58, 0, command);
        }

        private void cmderror()
        {
            /* It's showing a messagebox with the text "Command Failed" and the title "Error". */
            MessageBox.Show("Command Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void bo1zpromod_Click(object sender, EventArgs e)
        {
            /* It's sending a command to the game. */
            try
            {
                sendbo1zCMD("cg_fov 120");
            }
            catch (Exception)
            {
                cmderror();
            }
        }

        private void bo1zgivepointsbtn_Click(object sender, EventArgs e)
        {
            /* It's writing a value to the memory address 0x82DC33B4. */
            try
            {
                RGH.xbCon.DebugTarget.WriteInt32(Convert.ToUInt32(0x82DC33B4), Convert.ToInt32(bo1zgivepointstextbox.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Enter A Number Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bo1zruncommandbtn_Click(object sender, EventArgs e)
        {
            /* It's sending a command to the game. */
            try
            {
                sendbo1zCMD(bo1zcommandtextbox.Text);
            }
            catch (Exception)
            {
                cmderror();
            }
        }

        private void bo1zgiveweaponbtn_Click(object sender, EventArgs e)
        {
            /* It's sending a command to the game. */
            try
            {
                sendbo1zCMD("give " + bo1zgiveweaponscombobox.SelectedItem);
            }
            catch (Exception)
            {
                cmderror();
            }
        }

        private void bo1zsetplayerspeedbtn_Click(object sender, EventArgs e)
        {
            /* It's sending a command to the game. */
            try
            {
                sendbo1zCMD("g_speed " + bo1zplayerspeedtrackbar.Value);
            }
            catch (Exception)
            {
                cmderror();
            }
        }

        private void bo1zsetfov_Click(object sender, EventArgs e)
        {
            /* Sending a command to the game. */
            try
            {
                sendbo1zCMD("cg_fov " + bo1zfovtrackbar.Value);
            }
            catch (Exception)
            {
                cmderror();
            }
        }

        private void bo1zinfammobtn_Click(object sender, EventArgs e)
        {
            /* It's writing a value to the memory address 0x82DC33B4. */
            RGH.SetMemory(2182364812U, new byte[4] { 96, 0, 0, 0 });
        }

        private void bo1zgodmodetoggle_CheckedChanged(object sender, EventArgs e)
        {
            /* Sending a command to the game. */
            try
            {
                if (bo1zgodmodetoggle.Checked)
                {
                    sendbo1zCMD("god");
                }
                else if (!bo1zgodmodetoggle.Checked)
                {
                    sendbo1zCMD("god");
                }
            }
            catch (Exception)
            {
                cmderror();
            }
        }

        private void bo1znocliptoggle_CheckedChanged(object sender, EventArgs e)
        {
           /* Sending a command to the game. */
            try
            {
                if (bo1znocliptoggle.Checked)
                {
                    sendbo1zCMD("noclip");
                }
                else if (!bo1znocliptoggle.Checked)
                {
                    sendbo1zCMD("noclip");
                }
            }
            catch (Exception)
            {
                cmderror();
            }
        }

        private void bo1zthirdpersontoggle_CheckedChanged(object sender, EventArgs e)
        {
            /* Toggling third person on and off. */
            try
            {
                if (bo1zthirdpersontoggle.Checked)
                {
                    sendbo1zCMD("toggle cg_thirdperson");
                }
                else if (!bo1zthirdpersontoggle.Checked)
                {
                    sendbo1zCMD("toggle cg_thirdperson");
                }
            }
            catch (Exception)
            {
                cmderror();
            }
        }

        private void github_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bruhunison/Prosper-Bo1Z");
        }
    }
}