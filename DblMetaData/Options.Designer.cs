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
            this.SuspendLayout();
            // 
            // AlwaysNT
            // 
            this.AlwaysNT.AutoSize = true;
            this.AlwaysNT.Checked = true;
            this.AlwaysNT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AlwaysNT.Location = new System.Drawing.Point(21, 28);
            this.AlwaysNT.Name = "AlwaysNT";
            this.AlwaysNT.Size = new System.Drawing.Size(232, 21);
            this.AlwaysNT.TabIndex = 0;
            this.AlwaysNT.Text = "Scope is always New Testament";
            this.AlwaysNT.UseVisualStyleBackColor = true;
            this.AlwaysNT.CheckedChanged += new System.EventHandler(this.AlwaysNT_CheckedChanged);
            // 
            // TranslationAgency
            // 
            this.TranslationAgency.Location = new System.Drawing.Point(154, 67);
            this.TranslationAgency.Name = "TranslationAgency";
            this.TranslationAgency.Size = new System.Drawing.Size(100, 22);
            this.TranslationAgency.TabIndex = 1;
            this.TranslationAgency.Text = "Wycliffe Inc.";
            this.TranslationAgency.TextChanged += new System.EventHandler(this.TranslationAgency_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Translation Agency";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TranslationAgency);
            this.Controls.Add(this.AlwaysNT);
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AlwaysNT;
        private System.Windows.Forms.TextBox TranslationAgency;
        private System.Windows.Forms.Label label1;
    }
}