
namespace User
{
    partial class FormWorldCloud
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTextId = new System.Windows.Forms.Label();
            this.labelheader = new System.Windows.Forms.Label();
            this.comboBoxListText = new System.Windows.Forms.ComboBox();
            this.labelWordCloud = new System.Windows.Forms.Label();
            this.radioButtonDefault = new System.Windows.Forms.RadioButton();
            this.radioButtonAC = new System.Windows.Forms.RadioButton();
            this.radioButtonCrab = new System.Windows.Forms.RadioButton();
            this.radioButtonSW = new System.Windows.Forms.RadioButton();
            this.buttonSend = new System.Windows.Forms.Button();
            this.pictureBoxWordCloud = new System.Windows.Forms.PictureBox();
            this.labelPicture = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWordCloud)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.LightGray;
            this.buttonClose.Location = new System.Drawing.Point(228, 383);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(95, 37);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelTitle.Location = new System.Drawing.Point(286, 23);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(244, 46);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "World cloud";
            // 
            // labelTextId
            // 
            this.labelTextId.AutoSize = true;
            this.labelTextId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextId.Location = new System.Drawing.Point(30, 130);
            this.labelTextId.Name = "labelTextId";
            this.labelTextId.Size = new System.Drawing.Size(87, 25);
            this.labelTextId.TabIndex = 12;
            this.labelTextId.Text = "- Text ID";
            // 
            // labelheader
            // 
            this.labelheader.AutoSize = true;
            this.labelheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelheader.Location = new System.Drawing.Point(30, 87);
            this.labelheader.Name = "labelheader";
            this.labelheader.Size = new System.Drawing.Size(288, 25);
            this.labelheader.TabIndex = 11;
            this.labelheader.Text = "Enter the requested information:";
            // 
            // comboBoxListText
            // 
            this.comboBoxListText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListText.FormattingEnabled = true;
            this.comboBoxListText.Location = new System.Drawing.Point(134, 127);
            this.comboBoxListText.Name = "comboBoxListText";
            this.comboBoxListText.Size = new System.Drawing.Size(337, 28);
            this.comboBoxListText.TabIndex = 15;
            // 
            // labelWordCloud
            // 
            this.labelWordCloud.AutoSize = true;
            this.labelWordCloud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWordCloud.Location = new System.Drawing.Point(30, 180);
            this.labelWordCloud.Name = "labelWordCloud";
            this.labelWordCloud.Size = new System.Drawing.Size(293, 25);
            this.labelWordCloud.TabIndex = 16;
            this.labelWordCloud.Text = "- Choose the type of word cloud:";
            // 
            // radioButtonDefault
            // 
            this.radioButtonDefault.AutoSize = true;
            this.radioButtonDefault.Checked = true;
            this.radioButtonDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDefault.Location = new System.Drawing.Point(60, 220);
            this.radioButtonDefault.Name = "radioButtonDefault";
            this.radioButtonDefault.Size = new System.Drawing.Size(98, 29);
            this.radioButtonDefault.TabIndex = 17;
            this.radioButtonDefault.TabStop = true;
            this.radioButtonDefault.Text = "Default";
            this.radioButtonDefault.UseVisualStyleBackColor = true;
            // 
            // radioButtonAC
            // 
            this.radioButtonAC.AutoSize = true;
            this.radioButtonAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAC.Location = new System.Drawing.Point(60, 255);
            this.radioButtonAC.Name = "radioButtonAC";
            this.radioButtonAC.Size = new System.Drawing.Size(185, 29);
            this.radioButtonAC.TabIndex = 18;
            this.radioButtonAC.TabStop = true;
            this.radioButtonAC.Text = "Assassin\'s creed";
            this.radioButtonAC.UseVisualStyleBackColor = true;
            // 
            // radioButtonCrab
            // 
            this.radioButtonCrab.AutoSize = true;
            this.radioButtonCrab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonCrab.Location = new System.Drawing.Point(60, 325);
            this.radioButtonCrab.Name = "radioButtonCrab";
            this.radioButtonCrab.Size = new System.Drawing.Size(80, 29);
            this.radioButtonCrab.TabIndex = 20;
            this.radioButtonCrab.TabStop = true;
            this.radioButtonCrab.Text = "Crab";
            this.radioButtonCrab.UseVisualStyleBackColor = true;
            // 
            // radioButtonSW
            // 
            this.radioButtonSW.AutoSize = true;
            this.radioButtonSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSW.Location = new System.Drawing.Point(60, 290);
            this.radioButtonSW.Name = "radioButtonSW";
            this.radioButtonSW.Size = new System.Drawing.Size(119, 29);
            this.radioButtonSW.TabIndex = 19;
            this.radioButtonSW.TabStop = true;
            this.radioButtonSW.Text = "Star wars";
            this.radioButtonSW.UseVisualStyleBackColor = true;
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.LightGray;
            this.buttonSend.Location = new System.Drawing.Point(60, 383);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(94, 37);
            this.buttonSend.TabIndex = 21;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // pictureBoxWordCloud
            // 
            this.pictureBoxWordCloud.Location = new System.Drawing.Point(352, 166);
            this.pictureBoxWordCloud.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxWordCloud.Name = "pictureBoxWordCloud";
            this.pictureBoxWordCloud.Size = new System.Drawing.Size(756, 574);
            this.pictureBoxWordCloud.TabIndex = 22;
            this.pictureBoxWordCloud.TabStop = false;
            this.pictureBoxWordCloud.Click += new System.EventHandler(this.PictureBoxWordCloud_Click);
            // 
            // labelPicture
            // 
            this.labelPicture.AutoSize = true;
            this.labelPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPicture.Location = new System.Drawing.Point(55, 451);
            this.labelPicture.Name = "labelPicture";
            this.labelPicture.Size = new System.Drawing.Size(61, 29);
            this.labelPicture.TabIndex = 23;
            this.labelPicture.Text = "Title";
            this.labelPicture.Visible = false;
            // 
            // FormWorldCloud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1124, 721);
            this.Controls.Add(this.labelPicture);
            this.Controls.Add(this.pictureBoxWordCloud);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.radioButtonCrab);
            this.Controls.Add(this.radioButtonSW);
            this.Controls.Add(this.radioButtonAC);
            this.Controls.Add(this.radioButtonDefault);
            this.Controls.Add(this.labelWordCloud);
            this.Controls.Add(this.comboBoxListText);
            this.Controls.Add(this.labelTextId);
            this.Controls.Add(this.labelheader);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonClose);
            this.Name = "FormWorldCloud";
            this.Text = "User - World cloud";
            this.Load += new System.EventHandler(this.FormWorldCloud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWordCloud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTextId;
        private System.Windows.Forms.Label labelheader;
        private System.Windows.Forms.ComboBox comboBoxListText;
        private System.Windows.Forms.Label labelWordCloud;
        private System.Windows.Forms.RadioButton radioButtonDefault;
        private System.Windows.Forms.RadioButton radioButtonAC;
        private System.Windows.Forms.RadioButton radioButtonCrab;
        private System.Windows.Forms.RadioButton radioButtonSW;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.PictureBox pictureBoxWordCloud;
        private System.Windows.Forms.Label labelPicture;
    }
}