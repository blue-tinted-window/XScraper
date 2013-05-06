namespace WP_Plugin_Downloader
{
    partial class ScraperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScraperForm));
            this.lblSearchTag = new System.Windows.Forms.Label();
            this.lblStartPage = new System.Windows.Forms.Label();
            this.lblPageStop = new System.Windows.Forms.Label();
            this.mTxtBoxStartPage = new System.Windows.Forms.MaskedTextBox();
            this.mTxtBoxStopPage = new System.Windows.Forms.MaskedTextBox();
            this.txtBoxTag = new System.Windows.Forms.TextBox();
            this.grpBoxOutput = new System.Windows.Forms.GroupBox();
            this.btnScrape = new System.Windows.Forms.Button();
            this.rTxtBoxOutput = new System.Windows.Forms.RichTextBox();
            this.txtSaveLocation = new System.Windows.Forms.TextBox();
            this.lblSaveLocation = new System.Windows.Forms.Label();
            this.grpBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSearchTag
            // 
            this.lblSearchTag.AutoSize = true;
            this.lblSearchTag.Location = new System.Drawing.Point(9, 12);
            this.lblSearchTag.Name = "lblSearchTag";
            this.lblSearchTag.Size = new System.Drawing.Size(88, 15);
            this.lblSearchTag.TabIndex = 0;
            this.lblSearchTag.Text = "Tag To Search:";
            // 
            // lblStartPage
            // 
            this.lblStartPage.AutoSize = true;
            this.lblStartPage.Location = new System.Drawing.Point(9, 39);
            this.lblStartPage.Name = "lblStartPage";
            this.lblStartPage.Size = new System.Drawing.Size(102, 15);
            this.lblStartPage.TabIndex = 1;
            this.lblStartPage.Text = "Page To Start On:";
            // 
            // lblPageStop
            // 
            this.lblPageStop.AutoSize = true;
            this.lblPageStop.Location = new System.Drawing.Point(9, 66);
            this.lblPageStop.Name = "lblPageStop";
            this.lblPageStop.Size = new System.Drawing.Size(102, 15);
            this.lblPageStop.TabIndex = 2;
            this.lblPageStop.Text = "Page To Stop On:";
            // 
            // mTxtBoxStartPage
            // 
            this.mTxtBoxStartPage.Location = new System.Drawing.Point(132, 36);
            this.mTxtBoxStartPage.Mask = "000000";
            this.mTxtBoxStartPage.Name = "mTxtBoxStartPage";
            this.mTxtBoxStartPage.Size = new System.Drawing.Size(187, 21);
            this.mTxtBoxStartPage.TabIndex = 3;
            this.mTxtBoxStartPage.TabStop = false;
            // 
            // mTxtBoxStopPage
            // 
            this.mTxtBoxStopPage.Location = new System.Drawing.Point(132, 63);
            this.mTxtBoxStopPage.Mask = "000000";
            this.mTxtBoxStopPage.Name = "mTxtBoxStopPage";
            this.mTxtBoxStopPage.Size = new System.Drawing.Size(187, 21);
            this.mTxtBoxStopPage.TabIndex = 4;
            this.mTxtBoxStopPage.TabStop = false;
            // 
            // txtBoxTag
            // 
            this.txtBoxTag.Location = new System.Drawing.Point(132, 9);
            this.txtBoxTag.Name = "txtBoxTag";
            this.txtBoxTag.Size = new System.Drawing.Size(187, 21);
            this.txtBoxTag.TabIndex = 5;
            this.txtBoxTag.TabStop = false;
            // 
            // grpBoxOutput
            // 
            this.grpBoxOutput.Controls.Add(this.rTxtBoxOutput);
            this.grpBoxOutput.Location = new System.Drawing.Point(12, 117);
            this.grpBoxOutput.Name = "grpBoxOutput";
            this.grpBoxOutput.Size = new System.Drawing.Size(307, 143);
            this.grpBoxOutput.TabIndex = 6;
            this.grpBoxOutput.TabStop = false;
            this.grpBoxOutput.Text = "Output:";
            // 
            // btnScrape
            // 
            this.btnScrape.Location = new System.Drawing.Point(12, 267);
            this.btnScrape.Name = "btnScrape";
            this.btnScrape.Size = new System.Drawing.Size(307, 23);
            this.btnScrape.TabIndex = 7;
            this.btnScrape.Text = "Scrape";
            this.btnScrape.UseVisualStyleBackColor = true;
            this.btnScrape.Click += new System.EventHandler(this.btnScrape_Click);
            // 
            // rTxtBoxOutput
            // 
            this.rTxtBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtBoxOutput.Location = new System.Drawing.Point(3, 17);
            this.rTxtBoxOutput.Name = "rTxtBoxOutput";
            this.rTxtBoxOutput.ReadOnly = true;
            this.rTxtBoxOutput.Size = new System.Drawing.Size(301, 123);
            this.rTxtBoxOutput.TabIndex = 0;
            this.rTxtBoxOutput.TabStop = false;
            this.rTxtBoxOutput.Text = "";
            // 
            // txtSaveLocation
            // 
            this.txtSaveLocation.Location = new System.Drawing.Point(132, 90);
            this.txtSaveLocation.Name = "txtSaveLocation";
            this.txtSaveLocation.Size = new System.Drawing.Size(184, 21);
            this.txtSaveLocation.TabIndex = 8;
            // 
            // lblSaveLocation
            // 
            this.lblSaveLocation.AutoSize = true;
            this.lblSaveLocation.Location = new System.Drawing.Point(9, 93);
            this.lblSaveLocation.Name = "lblSaveLocation";
            this.lblSaveLocation.Size = new System.Drawing.Size(53, 15);
            this.lblSaveLocation.TabIndex = 9;
            this.lblSaveLocation.Text = "Save To:";
            // 
            // ScraperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 302);
            this.Controls.Add(this.lblSaveLocation);
            this.Controls.Add(this.txtSaveLocation);
            this.Controls.Add(this.btnScrape);
            this.Controls.Add(this.grpBoxOutput);
            this.Controls.Add(this.txtBoxTag);
            this.Controls.Add(this.mTxtBoxStopPage);
            this.Controls.Add(this.mTxtBoxStartPage);
            this.Controls.Add(this.lblPageStop);
            this.Controls.Add(this.lblStartPage);
            this.Controls.Add(this.lblSearchTag);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScraperForm";
            this.Text = "ScraperForm";
            this.grpBoxOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchTag;
        private System.Windows.Forms.Label lblStartPage;
        private System.Windows.Forms.Label lblPageStop;
        private System.Windows.Forms.MaskedTextBox mTxtBoxStartPage;
        private System.Windows.Forms.MaskedTextBox mTxtBoxStopPage;
        private System.Windows.Forms.TextBox txtBoxTag;
        private System.Windows.Forms.GroupBox grpBoxOutput;
        private System.Windows.Forms.RichTextBox rTxtBoxOutput;
        private System.Windows.Forms.Button btnScrape;
        private System.Windows.Forms.TextBox txtSaveLocation;
        private System.Windows.Forms.Label lblSaveLocation;
    }
}