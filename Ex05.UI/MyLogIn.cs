using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interface
{
    public partial class MyLogIn : Form
    {
        public MyLogIn()
        {
            InitializeComponent();
        }

        private void m_Player2CheckBox_Click(object sender, EventArgs e)
        {
            this.m_TextBoxPlayer2.Enabled = true;
            this.m_TextBoxPlayer2.Text = string.Empty;
        }
        public string FirstPlayerName
        {
            get { return m_TextBoxPlayer1.Text; }
            set { m_TextBoxPlayer1.Text = value; }
        }
        public string SecondPlayerName
        {
            get
            {
                return m_TextBoxPlayer2.Text;
            }

            set
            {
                this.m_TextBoxPlayer2.Text = value;
            }
        }
        public bool CheckBoxOfPlayer2IsChecked
        {
            get
            {
                return m_CheckBoxPlayer2.Checked;
            }
        }

        public bool RadioButtonBoardSize6X6IsChecked
        {
            get
            {
                return m_RadioButton6X6.Checked;
            }
        }
        public bool RadioButtonBoardSize8X8IsChecked
        {
            get
            {
                return m_RdioButtom8X8.Checked;
            }
        }
        public bool RadioButtonBoardSize10X10IsChecked
        {
            get
            {
                return m_RadioButton10X10.Checked;
            }
        }

        private void m_ButtonDone_Click(object sender, EventArgs e)
        {
            this.m_ButtonDone.DialogResult = DialogResult.OK;
        }

      
    }
}
