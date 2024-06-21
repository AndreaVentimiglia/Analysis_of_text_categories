using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace User
{
    public partial class FormInsertNewText : Form
    {
        // Global variables
        private string fileContents;
        readonly List<Text> textList = GlobalList.TextList;

        // Assumes all valid initially Assume tutti validi inizialmente
        private bool idValid = false;
        private bool titleValid = true;
        private bool authorValid = true;
        private bool editionValid = true;
        private bool isbnValid = true;
        private bool textFileValid = true;
        
        public FormInsertNewText()
        {
            InitializeComponent();
        }

        /* --------------------- FUNCTION ---------------------*/
        private void CheckField(string title, string author, string edition, string isbn, string textFile, string id)
        {
            // Check empty fields
            if (string.IsNullOrEmpty(title))
            {
                ResetColors(Color.LightSalmon, textBoxTitle);
                titleValid = false;
            }
            else
            {
                titleValid = true;
            }

            if (string.IsNullOrEmpty(author))
            {
                ResetColors(Color.LightSalmon, textBoxAuthor);
                authorValid = false;
            }
            else
            {
                authorValid = true;
            }

            if (string.IsNullOrEmpty(textFile))
            {
                ResetColors(Color.LightSalmon, textBoxTextFile);
                textFileValid = false;
            }
            else
            {
                textFileValid = true;
            }


            // checks if the entered text is not the list
            for (int i = 0; i < textList.Count; i++)
            {
                if (textList[i].Id == id)
                {
                    idValid = true;
                    break;
                }
                else
                {
                    idValid = false;
                }
            }

            // Check only if numbers for edition and ISBN
            if (string.IsNullOrEmpty(edition))
            {
                ResetColors(Color.LightSalmon, textBoxEdition);
                editionValid = false;
            }
            else
            {
                editionValid = true;
            }


            if (string.IsNullOrEmpty(isbn))
            {
                ResetColors(Color.LightSalmon, textBoxIsbn);
                isbnValid = false;
            }
            else
            {
                isbnValid = true;
            }
        }
        private void ClearFields()
        {
            textBoxTitle.Clear();
            textBoxAuthor.Clear();
            textBoxEdition.Clear();
            textBoxIsbn.Clear();
            textBoxTextFile.Clear();

            fileContents = "";
            textBoxIsbn.Text = "";
            textBoxTextFile.Text = "";
        }

        private  void ResetColors(Color color, params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.BackColor = color;
            }
        }

        private void EnabledComponent(bool control)
        {
            textBoxTitle.Enabled = control;
            textBoxAuthor.Enabled = control;
            textBoxEdition.Enabled = control;
            textBoxIsbn.Enabled = control;
            buttonOpenFile.Enabled = control;
            buttonSend.Enabled = control;
            buttonClose.Enabled = control;
        }

        /* --------------------- EVENT: Click ---------------------*/
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            //opening a file of only .txt
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text File|*.txt",
                Title = "Select a text file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                fileContents = File.ReadAllText(filePath); // Retrieve the contents of the file

                // Check if the file content is empty or not
                if (string.IsNullOrEmpty(fileContents))
                {
                    textBoxTextFile.Text = "Uploaded file is empty";
                    ResetColors(Color.LightSalmon, textBoxTextFile);
                }
                else
                {
                    textBoxTextFile.Text = "File inserted successfully";
                    ResetColors(SystemColors.Control, textBoxTextFile);
                }
            }
        }

        private async void ButtonSend_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text.Trim();
            string author = textBoxAuthor.Text.Trim();
            string edition = textBoxEdition.Text.Trim();
            string isbn = textBoxIsbn.Text.Trim();
            string textFile = fileContents;
            string id = title + " - edition " + edition;
            //checks if the fields have been selected
            CheckField(title, author, edition, isbn, textFile, id);

            if (titleValid && authorValid && editionValid && isbnValid && textFileValid)
            {
                EnabledComponent(false);
                try
                {
                    var data = new { title, author, edition, isbn, textFile };

                    // Serialize JSON object to string
                    var jsonData = JsonConvert.SerializeObject(data);

                    // Create HttpClient
                    using (var client = new HttpClient())
                    {
                        // Set base URL of the REST API
                        var endPoint = new Uri(ConfigRest.UrlInsertNewText);

                        // Create StringContent from the JSON string
                        var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        // Send POST request to the REST API
                        var response = await client.PostAsync(endPoint, payload);
                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            ResponseMessage2 responseContent = JsonConvert.DeserializeObject<ResponseMessage2>(content);

                            // we insert a new text into the text list
                            if (!idValid)
                            {
                                Text newText = new Text(title, author, edition, isbn, responseContent.Words);
                                GlobalList.SortTextListByTitle();
                            }
                            labelListRate.Text = responseContent.Message;
                            labelListRate.Visible = true;

                            ClearFields();
                            ResetColors(SystemColors.Control, textBoxTitle, textBoxAuthor, textBoxEdition, textBoxIsbn, textBoxTextFile);
                            EnabledComponent(true);

                            // Enable automatic form resizingc
                            this.AutoSize = true;
                            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        }
                        else
                        {
                            MessageBox.Show("Failed to send JSON file. Status code: " + response.StatusCode);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill in all required fields");
            }
        }

        void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /* --------------------- EVENT: TextChanged ---------------------*/
        private void TextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            ResetColors(SystemColors.Control, textBoxTitle);
        }

        private void TextBoxAuthor_TextChanged(object sender, EventArgs e)
        {
            ResetColors(SystemColors.Control, textBoxAuthor);
        }


        /* --------------------- EVENT: Enter and Leave ---------------------*/
        private void TextBoxIsbn_Enter(object sender, EventArgs e)
        {
            // to strip the value from this textBox when we enter it
            if (isbnValid == false)
            {
                textBoxIsbn.Text = "";
            }
            ResetColors(SystemColors.Control, textBoxIsbn);
        }

        private void TextBoxIsbn_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxIsbn.Text))
            {
                ResetColors(Color.LightSalmon, textBoxIsbn);
            }
        }

        private void TextBoxEdition_Enter(object sender, EventArgs e)
        {
            // to strip the value from this textBox when we enter it
            if (editionValid == false)
            {
                textBoxEdition.Text = "";
            }
            ResetColors(SystemColors.Control, textBoxEdition);
        }

        private void TextBoxAuthor_Enter(object sender, EventArgs e)
        {
            ResetColors(SystemColors.Control, textBoxAuthor);
        }

        private void TextBoxTitle_Enter(object sender, EventArgs e)
        {
            ResetColors(SystemColors.Control, textBoxTitle);
        }
    }    
}
