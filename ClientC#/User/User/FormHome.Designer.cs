
namespace User
{
    partial class FormHome
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitlePage = new System.Windows.Forms.Label();
            this.buttonInsertNewText = new System.Windows.Forms.Button();
            this.labelNewText = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.buttonGoFrequencyGraphs = new System.Windows.Forms.Button();
            this.buttonTextComparison = new System.Windows.Forms.Button();
            this.buttonGoWordClound = new System.Windows.Forms.Button();
            this.labelWordCloud = new System.Windows.Forms.Label();
            this.labelFrequencyGraphs = new System.Windows.Forms.Label();
            this.labelTextComparison = new System.Windows.Forms.Label();
            this.buttonTextSearch = new System.Windows.Forms.Button();
            this.labelTextSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitlePage
            // 
            this.labelTitlePage.AutoSize = true;
            this.labelTitlePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePage.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelTitlePage.Location = new System.Drawing.Point(269, 38);
            this.labelTitlePage.Name = "labelTitlePage";
            this.labelTitlePage.Size = new System.Drawing.Size(195, 46);
            this.labelTitlePage.TabIndex = 0;
            this.labelTitlePage.Text = "Welcome";
            // 
            // buttonInsertNewText
            // 
            this.buttonInsertNewText.BackColor = System.Drawing.Color.LightGray;
            this.buttonInsertNewText.Location = new System.Drawing.Point(279, 140);
            this.buttonInsertNewText.Name = "buttonInsertNewText";
            this.buttonInsertNewText.Size = new System.Drawing.Size(99, 36);
            this.buttonInsertNewText.TabIndex = 1;
            this.buttonInsertNewText.Text = "Go";
            this.buttonInsertNewText.UseVisualStyleBackColor = false;
            this.buttonInsertNewText.Click += new System.EventHandler(this.ButtonInsertNewText_Click);
            // 
            // labelNewText
            // 
            this.labelNewText.AutoSize = true;
            this.labelNewText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewText.Location = new System.Drawing.Point(30, 144);
            this.labelNewText.Name = "labelNewText";
            this.labelNewText.Size = new System.Drawing.Size(174, 25);
            this.labelNewText.TabIndex = 3;
            this.labelNewText.Text = "1) Enter a new text";
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.Location = new System.Drawing.Point(30, 99);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(200, 25);
            this.labelHeader.TabIndex = 5;
            this.labelHeader.Text = "Choose an operation:";
            // 
            // buttonGoFrequencyGraphs
            // 
            this.buttonGoFrequencyGraphs.BackColor = System.Drawing.Color.LightGray;
            this.buttonGoFrequencyGraphs.Location = new System.Drawing.Point(279, 260);
            this.buttonGoFrequencyGraphs.Name = "buttonGoFrequencyGraphs";
            this.buttonGoFrequencyGraphs.Size = new System.Drawing.Size(101, 33);
            this.buttonGoFrequencyGraphs.TabIndex = 12;
            this.buttonGoFrequencyGraphs.Text = "Go";
            this.buttonGoFrequencyGraphs.UseVisualStyleBackColor = false;
            this.buttonGoFrequencyGraphs.Click += new System.EventHandler(this.ButtonGoFrequencyGraphs_Click);
            // 
            // buttonTextComparison
            // 
            this.buttonTextComparison.BackColor = System.Drawing.Color.LightGray;
            this.buttonTextComparison.Location = new System.Drawing.Point(279, 319);
            this.buttonTextComparison.Name = "buttonTextComparison";
            this.buttonTextComparison.Size = new System.Drawing.Size(99, 33);
            this.buttonTextComparison.TabIndex = 11;
            this.buttonTextComparison.Text = "Go";
            this.buttonTextComparison.UseVisualStyleBackColor = false;
            this.buttonTextComparison.Click += new System.EventHandler(this.ButtonTextComparison_Click);
            // 
            // buttonGoWordClound
            // 
            this.buttonGoWordClound.BackColor = System.Drawing.Color.LightGray;
            this.buttonGoWordClound.Location = new System.Drawing.Point(279, 201);
            this.buttonGoWordClound.Name = "buttonGoWordClound";
            this.buttonGoWordClound.Size = new System.Drawing.Size(99, 33);
            this.buttonGoWordClound.TabIndex = 10;
            this.buttonGoWordClound.Text = "Go";
            this.buttonGoWordClound.UseVisualStyleBackColor = false;
            this.buttonGoWordClound.Click += new System.EventHandler(this.ButtonGoWordClound_Click);
            // 
            // labelWordCloud
            // 
            this.labelWordCloud.AutoSize = true;
            this.labelWordCloud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWordCloud.Location = new System.Drawing.Point(30, 203);
            this.labelWordCloud.Name = "labelWordCloud";
            this.labelWordCloud.Size = new System.Drawing.Size(135, 25);
            this.labelWordCloud.TabIndex = 9;
            this.labelWordCloud.Text = "2) WordCloud";
            // 
            // labelFrequencyGraphs
            // 
            this.labelFrequencyGraphs.AutoSize = true;
            this.labelFrequencyGraphs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrequencyGraphs.Location = new System.Drawing.Point(30, 262);
            this.labelFrequencyGraphs.Name = "labelFrequencyGraphs";
            this.labelFrequencyGraphs.Size = new System.Drawing.Size(193, 25);
            this.labelFrequencyGraphs.TabIndex = 8;
            this.labelFrequencyGraphs.Text = "3) Frequency graphs";
            // 
            // labelTextComparison
            // 
            this.labelTextComparison.AutoSize = true;
            this.labelTextComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextComparison.Location = new System.Drawing.Point(30, 321);
            this.labelTextComparison.Name = "labelTextComparison";
            this.labelTextComparison.Size = new System.Drawing.Size(180, 25);
            this.labelTextComparison.TabIndex = 7;
            this.labelTextComparison.Text = "4) Text comparison";
            // 
            // buttonTextSearch
            // 
            this.buttonTextSearch.BackColor = System.Drawing.Color.LightGray;
            this.buttonTextSearch.Location = new System.Drawing.Point(279, 378);
            this.buttonTextSearch.Name = "buttonTextSearch";
            this.buttonTextSearch.Size = new System.Drawing.Size(99, 33);
            this.buttonTextSearch.TabIndex = 14;
            this.buttonTextSearch.Text = "Go";
            this.buttonTextSearch.UseVisualStyleBackColor = false;
            this.buttonTextSearch.Click += new System.EventHandler(this.ButtonTextSearch_Click);
            // 
            // labelTextSearch
            // 
            this.labelTextSearch.AutoSize = true;
            this.labelTextSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextSearch.Location = new System.Drawing.Point(30, 380);
            this.labelTextSearch.Name = "labelTextSearch";
            this.labelTextSearch.Size = new System.Drawing.Size(138, 25);
            this.labelTextSearch.TabIndex = 13;
            this.labelTextSearch.Text = "5) Text search";
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonTextSearch);
            this.Controls.Add(this.labelTextSearch);
            this.Controls.Add(this.buttonGoFrequencyGraphs);
            this.Controls.Add(this.buttonTextComparison);
            this.Controls.Add(this.buttonGoWordClound);
            this.Controls.Add(this.labelWordCloud);
            this.Controls.Add(this.labelFrequencyGraphs);
            this.Controls.Add(this.labelTextComparison);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.labelNewText);
            this.Controls.Add(this.buttonInsertNewText);
            this.Controls.Add(this.labelTitlePage);
            this.Name = "FormHome";
            this.Text = "User - Home";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitlePage;
        private System.Windows.Forms.Button buttonInsertNewText;
        private System.Windows.Forms.Label labelNewText;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button buttonGoFrequencyGraphs;
        private System.Windows.Forms.Button buttonTextComparison;
        private System.Windows.Forms.Button buttonGoWordClound;
        private System.Windows.Forms.Label labelWordCloud;
        private System.Windows.Forms.Label labelFrequencyGraphs;
        private System.Windows.Forms.Label labelTextComparison;
        private System.Windows.Forms.Button buttonTextSearch;
        private System.Windows.Forms.Label labelTextSearch;
    }
}

