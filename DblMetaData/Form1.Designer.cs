namespace DblMetaData
{
    partial class Form1
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
            this.save = new System.Windows.Forms.Button();
            this.reap = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.review = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(855, 636);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.button1_Click);
            // 
            // reap
            // 
            this.reap.Location = new System.Drawing.Point(687, 636);
            this.reap.Name = "reap";
            this.reap.Size = new System.Drawing.Size(75, 23);
            this.reap.TabIndex = 1;
            this.reap.Text = "Go Reap";
            this.reap.UseVisualStyleBackColor = true;
            this.reap.Click += new System.EventHandler(this.reap_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(918, 618);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("https://www.reap.insitehome.org/advanced-search", System.UriKind.Absolute);
            // 
            // review
            // 
            this.review.Location = new System.Drawing.Point(774, 636);
            this.review.Name = "review";
            this.review.Size = new System.Drawing.Size(75, 23);
            this.review.TabIndex = 2;
            this.review.Text = "Review";
            this.review.UseVisualStyleBackColor = true;
            this.review.Click += new System.EventHandler(this.review_Click);
            // 
            // options
            // 
            this.options.Location = new System.Drawing.Point(606, 636);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(75, 23);
            this.options.TabIndex = 4;
            this.options.Text = "Options";
            this.options.UseVisualStyleBackColor = true;
            this.options.Click += new System.EventHandler(this.options_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 669);
            this.Controls.Add(this.options);
            this.Controls.Add(this.review);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.reap);
            this.Controls.Add(this.save);
            this.MinimumSize = new System.Drawing.Size(960, 714);
            this.Name = "Form1";
            this.Text = "DBL Meta Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button reap;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button review;
        private System.Windows.Forms.Button options;

    }
}

