namespace DblMetaData
{
    partial class BookCheck
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
            this.Instructions = new System.Windows.Forms.TextBox();
            this.bookTree = new System.Windows.Forms.TreeView();
            this.ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Instructions
            // 
            this.Instructions.BackColor = System.Drawing.SystemColors.Window;
            this.Instructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Instructions.Enabled = false;
            this.Instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Instructions.Location = new System.Drawing.Point(13, 13);
            this.Instructions.Multiline = true;
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(306, 112);
            this.Instructions.TabIndex = 0;
            this.Instructions.Text = "This form lists the books to include in the default book list for the bundle. Ple" +
    "ase uncheck any that are not to be included.";
            // 
            // bookTree
            // 
            this.bookTree.CheckBoxes = true;
            this.bookTree.Location = new System.Drawing.Point(13, 131);
            this.bookTree.Name = "bookTree";
            this.bookTree.Size = new System.Drawing.Size(306, 359);
            this.bookTree.TabIndex = 1;
            this.bookTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.bookTree_AfterCheck);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(126, 510);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(78, 27);
            this.ok.TabIndex = 2;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // BookCheck
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 554);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.bookTree);
            this.Controls.Add(this.Instructions);
            this.Name = "BookCheck";
            this.Text = "BookCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Instructions;
        private System.Windows.Forms.TreeView bookTree;
        private System.Windows.Forms.Button ok;

    }
}