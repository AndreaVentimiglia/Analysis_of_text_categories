
namespace User
{
    partial class FormInsertNewText
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
            this.labelheader = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelIsbn = new System.Windows.Forms.Label();
            this.labelEdition = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelTextFile = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxIsbn = new System.Windows.Forms.TextBox();
            this.textBoxTextFile = new System.Windows.Forms.TextBox();
            this.textBoxEdition = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelTitlePage = new System.Windows.Forms.Label();
            this.labelListRate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.LightGray;
            this.buttonClose.Location = new System.Drawing.Point(369, 346);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 37);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelheader
            // 
            this.labelheader.AutoSize = true;
            this.labelheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelheader.Location = new System.Drawing.Point(37, 78);
            this.labelheader.Name = "labelheader";
            this.labelheader.Size = new System.Drawing.Size(288, 25);
            this.labelheader.TabIndex = 1;
            this.labelheader.Text = "Enter the requested information:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(37, 121);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(61, 25);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "- Title";
            // 
            // labelIsbn
            // 
            this.labelIsbn.AutoSize = true;
            this.labelIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIsbn.Location = new System.Drawing.Point(37, 244);
            this.labelIsbn.Name = "labelIsbn";
            this.labelIsbn.Size = new System.Drawing.Size(70, 25);
            this.labelIsbn.TabIndex = 6;
            this.labelIsbn.Text = "- ISBN";
            // 
            // labelEdition
            // 
            this.labelEdition.AutoSize = true;
            this.labelEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEdition.Location = new System.Drawing.Point(37, 203);
            this.labelEdition.Name = "labelEdition";
            this.labelEdition.Size = new System.Drawing.Size(83, 25);
            this.labelEdition.TabIndex = 7;
            this.labelEdition.Text = "- Edition";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(37, 162);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(82, 25);
            this.labelAuthor.TabIndex = 8;
            this.labelAuthor.Text = "- Author";
            // 
            // labelTextFile
            // 
            this.labelTextFile.AutoSize = true;
            this.labelTextFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextFile.Location = new System.Drawing.Point(37, 285);
            this.labelTextFile.Name = "labelTextFile";
            this.labelTextFile.Size = new System.Drawing.Size(63, 25);
            this.labelTextFile.TabIndex = 9;
            this.labelTextFile.Text = "- Text";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(159, 122);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(300, 26);
            this.textBoxTitle.TabIndex = 10;
            this.textBoxTitle.Enter += new System.EventHandler(this.TextBoxTitle_Enter);
            // 
            // textBoxIsbn
            // 
            this.textBoxIsbn.Location = new System.Drawing.Point(159, 243);
            this.textBoxIsbn.Name = "textBoxIsbn";
            this.textBoxIsbn.Size = new System.Drawing.Size(300, 26);
            this.textBoxIsbn.TabIndex = 11;
            this.textBoxIsbn.Enter += new System.EventHandler(this.TextBoxIsbn_Enter);
            this.textBoxIsbn.Leave += new System.EventHandler(this.TextBoxIsbn_Leave);
            // 
            // textBoxTextFile
            // 
            this.textBoxTextFile.Enabled = false;
            this.textBoxTextFile.Location = new System.Drawing.Point(265, 292);
            this.textBoxTextFile.Name = "textBoxTextFile";
            this.textBoxTextFile.Size = new System.Drawing.Size(194, 26);
            this.textBoxTextFile.TabIndex = 12;
            // 
            // textBoxEdition
            // 
            this.textBoxEdition.Location = new System.Drawing.Point(159, 202);
            this.textBoxEdition.Name = "textBoxEdition";
            this.textBoxEdition.Size = new System.Drawing.Size(300, 26);
            this.textBoxEdition.TabIndex = 13;
            this.textBoxEdition.Enter += new System.EventHandler(this.TextBoxEdition_Enter);
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(159, 161);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(300, 26);
            this.textBoxAuthor.TabIndex = 14;
            this.textBoxAuthor.TextChanged += new System.EventHandler(this.TextBoxAuthor_TextChanged);
            this.textBoxAuthor.Enter += new System.EventHandler(this.TextBoxAuthor_Enter);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.BackColor = System.Drawing.Color.LightGray;
            this.buttonOpenFile.Location = new System.Drawing.Point(159, 281);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(94, 37);
            this.buttonOpenFile.TabIndex = 15;
            this.buttonOpenFile.Text = "Open file";
            this.buttonOpenFile.UseVisualStyleBackColor = false;
            this.buttonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.LightGray;
            this.buttonSend.Location = new System.Drawing.Point(159, 346);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(94, 37);
            this.buttonSend.TabIndex = 16;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // labelTitlePage
            // 
            this.labelTitlePage.AutoSize = true;
            this.labelTitlePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePage.ForeColor = System.Drawing.Color.DarkViolet;
            this.labelTitlePage.Location = new System.Drawing.Point(292, 32);
            this.labelTitlePage.Name = "labelTitlePage";
            this.labelTitlePage.Size = new System.Drawing.Size(184, 46);
            this.labelTitlePage.TabIndex = 17;
            this.labelTitlePage.Text = "New text";
            // 
            // labelListRate
            // 
            this.labelListRate.AutoSize = true;
            this.labelListRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListRate.Location = new System.Drawing.Point(517, 121);
            this.labelListRate.Name = "labelListRate";
            this.labelListRate.Size = new System.Drawing.Size(24, 25);
            this.labelListRate.TabIndex = 18;
            this.labelListRate.Text = "- ";
            this.labelListRate.Visible = false;
            // 
            // FormInsertNewText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(751, 429);
            this.Controls.Add(this.labelListRate);
            this.Controls.Add(this.labelTitlePage);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.textBoxEdition);
            this.Controls.Add(this.textBoxTextFile);
            this.Controls.Add(this.textBoxIsbn);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTextFile);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelEdition);
            this.Controls.Add(this.labelIsbn);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelheader);
            this.Controls.Add(this.buttonClose);
            this.Name = "FormInsertNewText";
            this.Text = "User - Insert new text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelheader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelIsbn;
        private System.Windows.Forms.Label labelEdition;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelTextFile;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxIsbn;
        private System.Windows.Forms.TextBox textBoxTextFile;
        private System.Windows.Forms.TextBox textBoxEdition;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label labelTitlePage;
        private System.Windows.Forms.Label labelListRate;
    }
}