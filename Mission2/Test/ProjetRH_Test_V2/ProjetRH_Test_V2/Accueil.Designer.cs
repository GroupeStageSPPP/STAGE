namespace ProjetRH_Test_V2
{
    partial class Accueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxAxePrincipal = new System.Windows.Forms.GroupBox();
            this.comboBoxAP_3 = new System.Windows.Forms.ComboBox();
            this.comboBoxAP_2 = new System.Windows.Forms.ComboBox();
            this.comboBoxAP_1 = new System.Windows.Forms.ComboBox();
            this.groupBoxAxesSecondaires = new System.Windows.Forms.GroupBox();
            this.comboBoxAS1_3 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS1_2 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS1_1 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS1_4 = new System.Windows.Forms.ComboBox();
            this.textBoxAS1 = new System.Windows.Forms.TextBox();
            this.buttonAjouterCondition2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxAxePrincipal.SuspendLayout();
            this.groupBoxAxesSecondaires.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxAxePrincipal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxAxesSecondaires);
            this.splitContainer1.Size = new System.Drawing.Size(984, 362);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxAxePrincipal
            // 
            this.groupBoxAxePrincipal.Controls.Add(this.comboBoxAP_3);
            this.groupBoxAxePrincipal.Controls.Add(this.comboBoxAP_2);
            this.groupBoxAxePrincipal.Controls.Add(this.comboBoxAP_1);
            this.groupBoxAxePrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAxePrincipal.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAxePrincipal.Name = "groupBoxAxePrincipal";
            this.groupBoxAxePrincipal.Size = new System.Drawing.Size(984, 53);
            this.groupBoxAxePrincipal.TabIndex = 0;
            this.groupBoxAxePrincipal.TabStop = false;
            this.groupBoxAxePrincipal.Text = "Orientation de la recherche";
            // 
            // comboBoxAP_3
            // 
            this.comboBoxAP_3.FormattingEnabled = true;
            this.comboBoxAP_3.Location = new System.Drawing.Point(341, 18);
            this.comboBoxAP_3.Name = "comboBoxAP_3";
            this.comboBoxAP_3.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAP_3.TabIndex = 2;
            this.comboBoxAP_3.Visible = false;
            // 
            // comboBoxAP_2
            // 
            this.comboBoxAP_2.FormattingEnabled = true;
            this.comboBoxAP_2.Location = new System.Drawing.Point(180, 19);
            this.comboBoxAP_2.Name = "comboBoxAP_2";
            this.comboBoxAP_2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAP_2.TabIndex = 1;
            this.comboBoxAP_2.Visible = false;
            this.comboBoxAP_2.SelectedIndexChanged += new System.EventHandler(this.comboBoxAP_2_SelectedIndexChanged);
            // 
            // comboBoxAP_1
            // 
            this.comboBoxAP_1.FormattingEnabled = true;
            this.comboBoxAP_1.Items.AddRange(new object[] {
            "Personne",
            "Entretien",
            "Statistique"});
            this.comboBoxAP_1.Location = new System.Drawing.Point(24, 20);
            this.comboBoxAP_1.Name = "comboBoxAP_1";
            this.comboBoxAP_1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAP_1.TabIndex = 0;
            this.comboBoxAP_1.SelectedIndexChanged += new System.EventHandler(this.comboBoxAP1_SelectedIndexChanged);
            // 
            // groupBoxAxesSecondaires
            // 
            this.groupBoxAxesSecondaires.Controls.Add(this.buttonAjouterCondition2);
            this.groupBoxAxesSecondaires.Controls.Add(this.textBoxAS1);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS1_4);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS1_3);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS1_2);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS1_1);
            this.groupBoxAxesSecondaires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAxesSecondaires.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAxesSecondaires.Name = "groupBoxAxesSecondaires";
            this.groupBoxAxesSecondaires.Size = new System.Drawing.Size(984, 305);
            this.groupBoxAxesSecondaires.TabIndex = 0;
            this.groupBoxAxesSecondaires.TabStop = false;
            this.groupBoxAxesSecondaires.Text = "Précisions de recherche";
            // 
            // comboBoxAS1_3
            // 
            this.comboBoxAS1_3.FormattingEnabled = true;
            this.comboBoxAS1_3.Location = new System.Drawing.Point(341, 28);
            this.comboBoxAS1_3.Name = "comboBoxAS1_3";
            this.comboBoxAS1_3.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS1_3.TabIndex = 1;
            this.comboBoxAS1_3.Visible = false;
            this.comboBoxAS1_3.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS1_3_SelectedIndexChanged);
            // 
            // comboBoxAS1_2
            // 
            this.comboBoxAS1_2.FormattingEnabled = true;
            this.comboBoxAS1_2.Location = new System.Drawing.Point(180, 28);
            this.comboBoxAS1_2.Name = "comboBoxAS1_2";
            this.comboBoxAS1_2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS1_2.TabIndex = 0;
            this.comboBoxAS1_2.Visible = false;
            this.comboBoxAS1_2.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS1_2_SelectedIndexChanged);
            // 
            // comboBoxAS1_1
            // 
            this.comboBoxAS1_1.FormattingEnabled = true;
            this.comboBoxAS1_1.Items.AddRange(new object[] {
            "Personne",
            "Entretien"});
            this.comboBoxAS1_1.Location = new System.Drawing.Point(24, 28);
            this.comboBoxAS1_1.Name = "comboBoxAS1_1";
            this.comboBoxAS1_1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS1_1.TabIndex = 0;
            this.comboBoxAS1_1.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS1_1_SelectedIndexChanged);
            // 
            // comboBoxAS1_4
            // 
            this.comboBoxAS1_4.FormattingEnabled = true;
            this.comboBoxAS1_4.Location = new System.Drawing.Point(496, 28);
            this.comboBoxAS1_4.Name = "comboBoxAS1_4";
            this.comboBoxAS1_4.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS1_4.TabIndex = 2;
            this.comboBoxAS1_4.Visible = false;
            // 
            // textBoxAS1
            // 
            this.textBoxAS1.Location = new System.Drawing.Point(654, 28);
            this.textBoxAS1.Name = "textBoxAS1";
            this.textBoxAS1.Size = new System.Drawing.Size(123, 20);
            this.textBoxAS1.TabIndex = 3;
            this.textBoxAS1.Visible = false;
            // 
            // buttonAjouterCondition2
            // 
            this.buttonAjouterCondition2.Location = new System.Drawing.Point(806, 25);
            this.buttonAjouterCondition2.Name = "buttonAjouterCondition2";
            this.buttonAjouterCondition2.Size = new System.Drawing.Size(148, 23);
            this.buttonAjouterCondition2.TabIndex = 4;
            this.buttonAjouterCondition2.Text = "Ajouter une condition";
            this.buttonAjouterCondition2.UseVisualStyleBackColor = true;
            this.buttonAjouterCondition2.Visible = false;
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 362);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Accueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recherche";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxAxePrincipal.ResumeLayout(false);
            this.groupBoxAxesSecondaires.ResumeLayout(false);
            this.groupBoxAxesSecondaires.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxAxePrincipal;
        private System.Windows.Forms.ComboBox comboBoxAP_2;
        private System.Windows.Forms.ComboBox comboBoxAP_1;
        private System.Windows.Forms.GroupBox groupBoxAxesSecondaires;
        private System.Windows.Forms.ComboBox comboBoxAS1_1;
        private System.Windows.Forms.ComboBox comboBoxAS1_2;
        private System.Windows.Forms.ComboBox comboBoxAS1_3;
        private System.Windows.Forms.ComboBox comboBoxAP_3;
        private System.Windows.Forms.ComboBox comboBoxAS1_4;
        private System.Windows.Forms.Button buttonAjouterCondition2;
        private System.Windows.Forms.TextBox textBoxAS1;
    }
}

