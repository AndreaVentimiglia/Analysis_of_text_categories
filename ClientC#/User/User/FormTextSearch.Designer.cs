
namespace User
{
    partial class FormTextSearch
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
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelheader = new System.Windows.Forms.Label();
            this.labelTitlePage = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelTexList = new System.Windows.Forms.Label();
            this.pictureBoxPlot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(150, 137);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(300, 26);
            this.textBoxAuthor.TabIndex = 28;
            this.textBoxAuthor.Enter += new System.EventHandler(this.TextBoxAuthor_Enter);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(30, 136);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(82, 25);
            this.labelAuthor.TabIndex = 27;
            this.labelAuthor.Text = "- Author";
            // 
            // labelheader
            // 
            this.labelheader.AutoSize = true;
            this.labelheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelheader.Location = new System.Drawing.Point(30, 87);
            this.labelheader.Name = "labelheader";
            this.labelheader.Size = new System.Drawing.Size(218, 25);
            this.labelheader.TabIndex = 26;
            this.labelheader.Text = "Enter the author\'s name";
            // 
            // labelTitlePage
            // 
            this.labelTitlePage.AutoSize = true;
            this.labelTitlePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePage.ForeColor = System.Drawing.Color.Crimson;
            this.labelTitlePage.Location = new System.Drawing.Point(216, 27);
            this.labelTitlePage.Name = "labelTitlePage";
            this.labelTitlePage.Size = new System.Drawing.Size(240, 46);
            this.labelTitlePage.TabIndex = 25;
            this.labelTitlePage.Text = "Text search";
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.LightGray;
            this.buttonSend.Location = new System.Drawing.Point(555, 132);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(94, 37);
            this.buttonSend.TabIndex = 31;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.LightGray;
            this.buttonClose.Location = new System.Drawing.Point(688, 132);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 37);
            this.buttonClose.TabIndex = 30;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelTexList
            // 
            this.labelTexList.AutoSize = true;
            this.labelTexList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexList.Location = new System.Drawing.Point(30, 198);
            this.labelTexList.Name = "labelTexList";
            this.labelTexList.Size = new System.Drawing.Size(49, 25);
            this.labelTexList.TabIndex = 32;
            this.labelTexList.Text = "Title";
            this.labelTexList.Visible = false;
            // 
            // pictureBoxPlot
            // 
            this.pictureBoxPlot.Location = new System.Drawing.Point(452, 198);
            this.pictureBoxPlot.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxPlot.Name = "pictureBoxPlot";
            this.pictureBoxPlot.Size = new System.Drawing.Size(756, 574);
            this.pictureBoxPlot.TabIndex = 33;
            this.pictureBoxPlot.TabStop = false;
            // 
            // FormTextSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1237, 796);
            this.Controls.Add(this.pictureBoxPlot);
            this.Controls.Add(this.labelTexList);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelheader);
            this.Controls.Add(this.labelTitlePage);
            this.Name = "FormTextSearch";
            this.Text = "FormTextSearch";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelheader;
        private System.Windows.Forms.Label labelTitlePage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelTexList;
        private System.Windows.Forms.PictureBox pictureBoxPlot;
    }
}