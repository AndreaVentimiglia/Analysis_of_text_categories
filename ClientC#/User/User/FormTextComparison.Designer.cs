
namespace User
{
    partial class FormTextComparison
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
            this.comboBoxListText1 = new System.Windows.Forms.ComboBox();
            this.labelTextId1 = new System.Windows.Forms.Label();
            this.labelheader = new System.Windows.Forms.Label();
            this.comboBoxListText2 = new System.Windows.Forms.ComboBox();
            this.labelTextId2 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.pictureBoxPlotRate = new System.Windows.Forms.PictureBox();
            this.pictureBoxWord = new System.Windows.Forms.PictureBox();
            this.labelText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlotRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWord)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.LightGray;
            this.buttonClose.Location = new System.Drawing.Point(355, 254);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 37);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelTitlePage
            // 
            this.labelTitlePage.AutoSize = true;
            this.labelTitlePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePage.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelTitlePage.Location = new System.Drawing.Point(229, 30);
            this.labelTitlePage.Name = "labelTitlePage";
            this.labelTitlePage.Size = new System.Drawing.Size(332, 46);
            this.labelTitlePage.TabIndex = 3;
            this.labelTitlePage.Text = "Text comparison";
            // 
            // comboBoxListText1
            // 
            this.comboBoxListText1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListText1.FormattingEnabled = true;
            this.comboBoxListText1.Location = new System.Drawing.Point(148, 128);
            this.comboBoxListText1.Name = "comboBoxListText1";
            this.comboBoxListText1.Size = new System.Drawing.Size(337, 28);
            this.comboBoxListText1.TabIndex = 21;
            this.comboBoxListText1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxListText1_SelectedIndexChanged);
            this.comboBoxListText1.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxListText1_SelectionChangeCommitted);
            // 
            // labelTextId1
            // 
            this.labelTextId1.AutoSize = true;
            this.labelTextId1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextId1.Location = new System.Drawing.Point(30, 128);
            this.labelTextId1.Name = "labelTextId1";
            this.labelTextId1.Size = new System.Drawing.Size(103, 25);
            this.labelTextId1.TabIndex = 20;
            this.labelTextId1.Text = "- Text ID 1";
            // 
            // labelheader
            // 
            this.labelheader.AutoSize = true;
            this.labelheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelheader.Location = new System.Drawing.Point(30, 87);
            this.labelheader.Name = "labelheader";
            this.labelheader.Size = new System.Drawing.Size(330, 25);
            this.labelheader.TabIndex = 19;
            this.labelheader.Text = "Select the texts you want to compare";
            // 
            // comboBoxListText2
            // 
            this.comboBoxListText2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListText2.FormattingEnabled = true;
            this.comboBoxListText2.Location = new System.Drawing.Point(148, 190);
            this.comboBoxListText2.Name = "comboBoxListText2";
            this.comboBoxListText2.Size = new System.Drawing.Size(337, 28);
            this.comboBoxListText2.TabIndex = 23;
            this.comboBoxListText2.SelectedIndexChanged += new System.EventHandler(this.ComboBoxListText2_SelectedIndexChanged);
            this.comboBoxListText2.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxListText2_SelectionChangeCommitted);
            // 
            // labelTextId2
            // 
            this.labelTextId2.AutoSize = true;
            this.labelTextId2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextId2.Location = new System.Drawing.Point(30, 190);
            this.labelTextId2.Name = "labelTextId2";
            this.labelTextId2.Size = new System.Drawing.Size(103, 25);
            this.labelTextId2.TabIndex = 22;
            this.labelTextId2.Text = "- Text ID 2";
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.LightGray;
            this.buttonSend.Location = new System.Drawing.Point(237, 254);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(94, 37);
            this.buttonSend.TabIndex = 24;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // pictureBoxPlotRate
            // 
            this.pictureBoxPlotRate.Location = new System.Drawing.Point(35, 365);
            this.pictureBoxPlotRate.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxPlotRate.Name = "pictureBoxPlotRate";
            this.pictureBoxPlotRate.Size = new System.Drawing.Size(756, 574);
            this.pictureBoxPlotRate.TabIndex = 34;
            this.pictureBoxPlotRate.TabStop = false;
            // 
            // pictureBoxWord
            // 
            this.pictureBoxWord.Location = new System.Drawing.Point(859, 365);
            this.pictureBoxWord.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxWord.Name = "pictureBoxWord";
            this.pictureBoxWord.Size = new System.Drawing.Size(756, 574);
            this.pictureBoxWord.TabIndex = 35;
            this.pictureBoxWord.TabStop = false;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.Location = new System.Drawing.Point(30, 319);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(19, 25);
            this.labelText.TabIndex = 36;
            this.labelText.Text = "-";
            this.labelText.Visible = false;
            // 
            // FormTextComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1711, 1037);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.pictureBoxWord);
            this.Controls.Add(this.pictureBoxPlotRate);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.comboBoxListText2);
            this.Controls.Add(this.labelTextId2);
            this.Controls.Add(this.comboBoxListText1);
            this.Controls.Add(this.labelTextId1);
            this.Controls.Add(this.labelheader);
            this.Controls.Add(this.labelTitlePage);
            this.Controls.Add(this.buttonClose);
            this.Name = "FormTextComparison";
            this.Text = "FormTextComparison";
            this.Load += new System.EventHandler(this.FormTextComparison_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlotRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelTitlePage;
        private System.Windows.Forms.ComboBox comboBoxListText1;
        private System.Windows.Forms.Label labelTextId1;
        private System.Windows.Forms.Label labelheader;
        private System.Windows.Forms.ComboBox comboBoxListText2;
        private System.Windows.Forms.Label labelTextId2;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.PictureBox pictureBoxPlotRate;
        private System.Windows.Forms.PictureBox pictureBoxWord;
        private System.Windows.Forms.Label labelText;
    }
}