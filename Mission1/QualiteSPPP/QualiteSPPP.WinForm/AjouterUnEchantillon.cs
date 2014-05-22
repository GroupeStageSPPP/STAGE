﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualiteSPPP.WinForm
{
    public partial class AjouterUnEchantillon : Form
    {
        public AjouterUnEchantillon()
        {
            InitializeComponent();
        }

        private void comboBoxProduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduit.SelectedItem == "Autre")
            {
                buttonNewProduit.Enabled = true;
            }
            else
            {
                buttonNewProduit.Enabled = false;
            }
        }
    }
}
