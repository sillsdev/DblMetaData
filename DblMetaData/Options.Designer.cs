namespace DblMetaData
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AlwaysNT = new System.Windows.Forms.CheckBox();
            this.TranslationAgency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Ldml = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.PublisherHoldsRights = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AlwaysNT
            // 
            this.AlwaysNT.AutoSize = true;
            this.AlwaysNT.Checked = true;
            this.AlwaysNT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AlwaysNT.Location = new System.Drawing.Point(21, 12);
            this.AlwaysNT.Name = "AlwaysNT";
            this.AlwaysNT.Size = new System.Drawing.Size(232, 21);
            this.AlwaysNT.TabIndex = 0;
            this.AlwaysNT.Text = "Scope is always New Testament";
            this.AlwaysNT.UseVisualStyleBackColor = true;
            this.AlwaysNT.CheckedChanged += new System.EventHandler(this.AlwaysNT_CheckedChanged);
            // 
            // TranslationAgency
            // 
            this.TranslationAgency.Location = new System.Drawing.Point(154, 66);
            this.TranslationAgency.Name = "TranslationAgency";
            this.TranslationAgency.Size = new System.Drawing.Size(404, 22);
            this.TranslationAgency.TabIndex = 1;
            this.TranslationAgency.Text = "Wycliffe Inc.";
            this.TranslationAgency.TextChanged += new System.EventHandler(this.TranslationAgency_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Translation Agency";
            // 
            // Ldml
            // 
            this.Ldml.FormattingEnabled = true;
            this.Ldml.Location = new System.Drawing.Point(132, 106);
            this.Ldml.Name = "Ldml";
            this.Ldml.Size = new System.Drawing.Size(121, 24);
            this.Ldml.TabIndex = 3;
            this.Ldml.Text = "en";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Email Language";
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(23, 136);
            this.Email.Multiline = true;
            this.Email.Name = "Email";
            this.Email.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Email.Size = new System.Drawing.Size(535, 287);
            this.Email.TabIndex = 5;
            this.Email.TextChanged += new System.EventHandler(this.Email_TextChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(252, 439);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "&Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // PublisherHoldsRights
            // 
            this.PublisherHoldsRights.AutoSize = true;
            this.PublisherHoldsRights.Checked = true;
            this.PublisherHoldsRights.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PublisherHoldsRights.Location = new System.Drawing.Point(21, 39);
            this.PublisherHoldsRights.Name = "PublisherHoldsRights";
            this.PublisherHoldsRights.Size = new System.Drawing.Size(186, 21);
            this.PublisherHoldsRights.TabIndex = 7;
            this.PublisherHoldsRights.Text = "Publisher is rights holder";
            this.PublisherHoldsRights.UseVisualStyleBackColor = true;
            this.PublisherHoldsRights.CheckedChanged += new System.EventHandler(this.PublisherHoldsRights_CheckedChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 474);
            this.Controls.Add(this.PublisherHoldsRights);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ldml);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TranslationAgency);
            this.Controls.Add(this.AlwaysNT);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AlwaysNT;
        private System.Windows.Forms.TextBox TranslationAgency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Ldml;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.CheckBox PublisherHoldsRights;
    }
}