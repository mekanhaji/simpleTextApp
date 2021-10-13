using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SimpletxtApp
{
    public partial class Form1 : Form
    {

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;

        string appName = " - Txt pad";

        public Form1()
        {
            InitializeComponent();
        }
        //New File Method!!
        private void NewFile()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.rtxt_mainSapce.Text))
                {
                    MessageBox.Show("You need to save it first!");
                }
                else
                {
                    this.rtxt_mainSapce.Text = string.Empty;
                    this.Text = "Untitleed" + appName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in New File Method!");
            }
            finally
            {

            }
        }

        //Save File Method!
        private void SaveFile()
        {
            try
            {
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File (*.txt) | *.txt";

                if (!string.IsNullOrEmpty(this.rtxt_mainSapce.Text))
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, this.rtxt_mainSapce.Text);
                    }
                }
                else
                {
                    MessageBox.Show("No trxt!!");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        //Open File Method!
        private void OpenFile()
        {
            try
            {
                openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.rtxt_mainSapce.Text = File.ReadAllText(openFileDialog.FileName);
                    this.Text = openFileDialog.FileName + appName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error From Open File Method!");
            }
            finally
            {
                openFileDialog = null;
            }
        }

        //Save File As Method!
        private void SaveFileAs()
        {
            try
            {
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File (*.txt) | *.txt | All Files (*.*) | *.*";

                if (!string.IsNullOrEmpty(this.rtxt_mainSapce.Text))
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, this.rtxt_mainSapce.Text);
                    }
                }
                else
                {
                    MessageBox.Show("No trxt!!");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        //Exit Method!
        private void Exit()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.rtxt_mainSapce.Text))
                {
                    SaveFile();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fontDialog = new FontDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           OpenFile();
        }

        private void seveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(fontDialog.ShowDialog() == DialogResult.OK)
                {
                    this.rtxt_mainSapce.Font = fontDialog.Font;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}
