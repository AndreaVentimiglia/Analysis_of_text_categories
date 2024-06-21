
namespace User
{
    partial class FormFrequencyGraphs
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelTitlePage = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelheader = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxEdition = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelEdition = new System.Windows.Forms.Label();
            this.radioButtonFrequencyWords = new System.Windows.Forms.RadioButton();
            this.radioButtonRateCategory = new System.Windows.Forms.RadioButton();
            this.labelWordCloud = new System.Windows.Forms.Label();
            this.groupBoxTypeGraph1 = new System.Windows.Forms.GroupBox();
            this.groupBoxTypeGraph2 = new System.Windows.Forms.GroupBox();
            this.radioButtonHistogram = new System.Windows.Forms.RadioButton();
            this.radioButtonPie = new System.Windows.Forms.RadioButton();
            this.groupBoxColor = new System.Windows.Forms.GroupBox();
            this.radioButtonGreen = new System.Windows.Forms.RadioButton();
            this.radioButtonYellow = new System.Windows.Forms.RadioButton();
            this.radioButtonBlue = new System.Windows.Forms.RadioButton();
            this.radioButtonRed = new System.Windows.Forms.RadioButton();
            this.pictureBoxPlot = new System.Windows.Forms.PictureBox();
            this.groupBoxTypeGraph1.SuspendLayout();
            this.groupBoxTypeGraph2.SuspendLayout();
            this.groupBoxColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(360, 501);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 37);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelTitlePage
            // 
            this.labelTitlePage.AutoSize = true;
            this.labelTitlePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePage.ForeColor = System.Drawing.Color.Green;
            this.labelTitlePage.Location = new System.Drawing.Point(216, 27);
            this.labelTitlePage.Name = "labelTitlePage";
            this.labelTitlePage.Size = new System.Drawing.Size(356, 46);
            this.labelTitlePage.TabIndex = 4;
            this.labelTitlePage.Text = "Frequency graphs";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(30, 136);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(61, 25);
            this.labelTitle.TabIndex = 17;
            this.labelTitle.Text = "- Title";
            // 
            // labelheader
            // 
            this.labelheader.AutoSize = true;
            this.labelheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelheader.Location = new System.Drawing.Point(30, 87);
            this.labelheader.Name = "labelheader";
            this.labelheader.Size = new System.Drawing.Size(288, 25);
            this.labelheader.TabIndex = 16;
            this.labelheader.Text = "Enter the requested information:";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(230, 501);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(94, 37);
            this.buttonSend.TabIndex = 22;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // textBoxEdition
            // 
            this.textBoxEdition.Location = new System.Drawing.Point(150, 176);
            this.textBoxEdition.Name = "textBoxEdition";
            this.textBoxEdition.Size = new System.Drawing.Size(300, 26);
            this.textBoxEdition.TabIndex = 25;
            this.textBoxEdition.Enter += new System.EventHandler(this.TextBoxEdition_Enter);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(150, 137);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(300, 26);
            this.textBoxTitle.TabIndex = 24;
            this.textBoxTitle.Enter += new System.EventHandler(this.TextBoxTitle_Enter);
            // 
            // labelEdition
            // 
            this.labelEdition.AutoSize = true;
            this.labelEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEdition.Location = new System.Drawing.Point(30, 177);
            this.labelEdition.Name = "labelEdition";
            this.labelEdition.Size = new System.Drawing.Size(83, 25);
            this.labelEdition.TabIndex = 23;
            this.labelEdition.Text = "- Edition";
            // 
            // radioButtonFrequencyWords
            // 
            this.radioButtonFrequencyWords.AutoSize = true;
            this.radioButtonFrequencyWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFrequencyWords.Location = new System.Drawing.Point(26, 64);
            this.radioButtonFrequencyWords.Name = "radioButtonFrequencyWords";
            this.radioButtonFrequencyWords.Size = new System.Drawing.Size(187, 29);
            this.radioButtonFrequencyWords.TabIndex = 28;
            this.radioButtonFrequencyWords.TabStop = true;
            this.radioButtonFrequencyWords.Text = "Frequency words";
            this.radioButtonFrequencyWords.UseVisualStyleBackColor = true;
            // 
            // radioButtonRateCategory
            // 
            this.radioButtonRateCategory.AutoSize = true;
            this.radioButtonRateCategory.Checked = true;
            this.radioButtonRateCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonRateCategory.Location = new System.Drawing.Point(26, 29);
            this.radioButtonRateCategory.Name = "radioButtonRateCategory";
            this.radioButtonRateCategory.Size = new System.Drawing.Size(157, 29);
            this.radioButtonRateCategory.TabIndex = 27;
            this.radioButtonRateCategory.TabStop = true;
            this.radioButtonRateCategory.Text = "Rate category";
            this.radioButtonRateCategory.UseVisualStyleBackColor = true;
            // 
            // labelWordCloud
            // 
            this.labelWordCloud.AutoSize = true;
            this.labelWordCloud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWordCloud.Location = new System.Drawing.Point(30, 221);
            this.labelWordCloud.Name = "labelWordCloud";
            this.labelWordCloud.Size = new System.Drawing.Size(174, 25);
            this.labelWordCloud.TabIndex = 26;
            this.labelWordCloud.Text = "- Choose the grapf";
            // 
            // groupBoxTypeGraph1
            // 
            this.groupBoxTypeGraph1.Controls.Add(this.radioButtonRateCategory);
            this.groupBoxTypeGraph1.Controls.Add(this.radioButtonFrequencyWords);
            this.groupBoxTypeGraph1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTypeGraph1.Location = new System.Drawing.Point(50, 257);
            this.groupBoxTypeGraph1.Name = "groupBoxTypeGraph1";
            this.groupBoxTypeGraph1.Size = new System.Drawing.Size(298, 100);
            this.groupBoxTypeGraph1.TabIndex = 31;
            this.groupBoxTypeGraph1.TabStop = false;
            this.groupBoxTypeGraph1.Text = "- Choose what to calculate";
            // 
            // groupBoxTypeGraph2
            // 
            this.groupBoxTypeGraph2.Controls.Add(this.radioButtonHistogram);
            this.groupBoxTypeGraph2.Controls.Add(this.radioButtonPie);
            this.groupBoxTypeGraph2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTypeGraph2.Location = new System.Drawing.Point(50, 379);
            this.groupBoxTypeGraph2.Name = "groupBoxTypeGraph2";
            this.groupBoxTypeGraph2.Size = new System.Drawing.Size(298, 100);
            this.groupBoxTypeGraph2.TabIndex = 32;
            this.groupBoxTypeGraph2.TabStop = false;
            this.groupBoxTypeGraph2.Text = "- Choose the type of graph";
            // 
            // radioButtonHistogram
            // 
            this.radioButtonHistogram.AutoSize = true;
            this.radioButtonHistogram.Checked = true;
            this.radioButtonHistogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonHistogram.Location = new System.Drawing.Point(26, 29);
            this.radioButtonHistogram.Name = "radioButtonHistogram";
            this.radioButtonHistogram.Size = new System.Drawing.Size(125, 29);
            this.radioButtonHistogram.TabIndex = 27;
            this.radioButtonHistogram.TabStop = true;
            this.radioButtonHistogram.Text = "Histogram";
            this.radioButtonHistogram.UseVisualStyleBackColor = true;
            this.radioButtonHistogram.Click += new System.EventHandler(this.RadioButtonHistogram_Click);
            // 
            // radioButtonPie
            // 
            this.radioButtonPie.AutoSize = true;
            this.radioButtonPie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPie.Location = new System.Drawing.Point(26, 64);
            this.radioButtonPie.Name = "radioButtonPie";
            this.radioButtonPie.Size = new System.Drawing.Size(65, 29);
            this.radioButtonPie.TabIndex = 28;
            this.radioButtonPie.TabStop = true;
            this.radioButtonPie.Text = "Pie";
            this.radioButtonPie.UseVisualStyleBackColor = true;
            this.radioButtonPie.Click += new System.EventHandler(this.RadioButtonPie_Click);
            // 
            // groupBoxColor
            // 
            this.groupBoxColor.Controls.Add(this.radioButtonGreen);
            this.groupBoxColor.Controls.Add(this.radioButtonYellow);
            this.groupBoxColor.Controls.Add(this.radioButtonBlue);
            this.groupBoxColor.Controls.Add(this.radioButtonRed);
            this.groupBoxColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxColor.Location = new System.Drawing.Point(416, 257);
            this.groupBoxColor.Name = "groupBoxColor";
            this.groupBoxColor.Size = new System.Drawing.Size(298, 180);
            this.groupBoxColor.TabIndex = 33;
            this.groupBoxColor.TabStop = false;
            this.groupBoxColor.Text = "- Choose color";
            // 
            // radioButtonGreen
            // 
            this.radioButtonGreen.AutoSize = true;
            this.radioButtonGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGreen.Location = new System.Drawing.Point(26, 99);
            this.radioButtonGreen.Name = "radioButtonGreen";
            this.radioButtonGreen.Size = new System.Drawing.Size(91, 29);
            this.radioButtonGreen.TabIndex = 29;
            this.radioButtonGreen.Text = "Green";
            this.radioButtonGreen.UseVisualStyleBackColor = true;
            // 
            // radioButtonYellow
            // 
            this.radioButtonYellow.AutoSize = true;
            this.radioButtonYellow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonYellow.Location = new System.Drawing.Point(26, 134);
            this.radioButtonYellow.Name = "radioButtonYellow";
            this.radioButtonYellow.Size = new System.Drawing.Size(94, 29);
            this.radioButtonYellow.TabIndex = 30;
            this.radioButtonYellow.Text = "Yellow";
            this.radioButtonYellow.UseVisualStyleBackColor = true;
            // 
            // radioButtonBlue
            // 
            this.radioButtonBlue.AutoSize = true;
            this.radioButtonBlue.Checked = true;
            this.radioButtonBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBlue.Location = new System.Drawing.Point(26, 29);
            this.radioButtonBlue.Name = "radioButtonBlue";
            this.radioButtonBlue.Size = new System.Drawing.Size(76, 29);
            this.radioButtonBlue.TabIndex = 27;
            this.radioButtonBlue.TabStop = true;
            this.radioButtonBlue.Text = "Blue";
            this.radioButtonBlue.UseVisualStyleBackColor = true;
            // 
            // radioButtonRed
            // 
            this.radioButtonRed.AutoSize = true;
            this.radioButtonRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonRed.Location = new System.Drawing.Point(26, 64);
            this.radioButtonRed.Name = "radioButtonRed";
            this.radioButtonRed.Size = new System.Drawing.Size(72, 29);
            this.radioButtonRed.TabIndex = 28;
            this.radioButtonRed.Text = "Red";
            this.radioButtonRed.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPlot
            // 
            this.pictureBoxPlot.Location = new System.Drawing.Point(820, 221);
            this.pictureBoxPlot.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxPlot.Name = "pictureBoxPlot";
            this.pictureBoxPlot.Size = new System.Drawing.Size(756, 574);
            this.pictureBoxPlot.TabIndex = 35;
            this.pictureBoxPlot.TabStop = false;
            this.pictureBoxPlot.Visible = false;
            // 
            // FormFrequencyGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(728, 568);
            this.Controls.Add(this.pictureBoxPlot);
            this.Controls.Add(this.groupBoxColor);
            this.Controls.Add(this.groupBoxTypeGraph2);
            this.Controls.Add(this.groupBoxTypeGraph1);
            this.Controls.Add(this.labelWordCloud);
            this.Controls.Add(this.textBoxEdition);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelEdition);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelheader);
            this.Controls.Add(this.labelTitlePage);
            this.Controls.Add(this.buttonClose);
            this.Name = "FormFrequencyGraphs";
            this.Text = "User - Frequency graphs";
            this.groupBoxTypeGraph1.ResumeLayout(false);
            this.groupBoxTypeGraph1.PerformLayout();
            this.groupBoxTypeGraph2.ResumeLayout(false);
            this.groupBoxTypeGraph2.PerformLayout();
            this.groupBoxColor.ResumeLayout(false);
            this.groupBoxColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelTitlePage;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelheader;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxEdition;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelEdition;
        private System.Windows.Forms.RadioButton radioButtonFrequencyWords;
        private System.Windows.Forms.RadioButton radioButtonRateCategory;
        private System.Windows.Forms.Label labelWordCloud;
        private System.Windows.Forms.GroupBox groupBoxTypeGraph1;
        private System.Windows.Forms.GroupBox groupBoxTypeGraph2;
        private System.Windows.Forms.RadioButton radioButtonHistogram;
        private System.Windows.Forms.RadioButton radioButtonPie;
        private System.Windows.Forms.GroupBox groupBoxColor;
        internal System.Windows.Forms.RadioButton radioButtonGreen;
        private System.Windows.Forms.RadioButton radioButtonYellow;
        private System.Windows.Forms.RadioButton radioButtonBlue;
        private System.Windows.Forms.RadioButton radioButtonRed;
        private System.Windows.Forms.PictureBox pictureBoxPlot;
    }
}