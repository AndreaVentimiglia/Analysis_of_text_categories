using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace User
{
    public partial class FormTextSearch : Form
    {
        // Global varible
        readonly List<Text> textList = GlobalList.TextList;

        // Assumes all valid initially Assume tutti validi inizialmente
        private bool authorValid = true;

        public FormTextSearch()
        {
            InitializeComponent();
        }

        /* --------------------- FUNCTIONS ---------------------*/
        private void ResetColors(Color color, params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.BackColor = color;
            }
        }

        private void CheckField(string title)
        {
            // Check empty fields
            if (string.IsNullOrEmpty(title))
            {
                ResetColors(Color.LightSalmon, textBoxAuthor);
                authorValid = false;
            }
            else
            {
                authorValid = true;
            }
        }
        private void EnabledComponent(bool control)
        { 
            textBoxAuthor.Enabled = control;
            buttonClose.Enabled = control;
            buttonSend.Enabled = control;
        }

        private void SetComponents()
        {
            textBoxAuthor.Clear();
            labelTexList.Visible = true;
        }

        /* --------------------- EVENT: Click ---------------------*/
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void ButtonSend_Click(object sender, EventArgs e)
        {
            string author = textBoxAuthor.Text.Trim();
            author = textBoxAuthor.Text.ToLower();
            //checks if the fields have been selected
            CheckField(author);
            if (authorValid)
            {
                //Search for the corresponding book
                String textListAuthor = "The texts of the author "+ author + " are: ";
                List<Text> texts = textList.Where(x => x.Author == author).ToList();
                List<string> textListWords = new List<string>();
                
                if (texts != null)
                {
                    EnabledComponent(false);
                    foreach (Text text in texts)
                    {
                        textListAuthor += "\n- "+ text.Title + " - Edition: "+ text.Edition;
                        textListWords.Add(text.Words);
                    }

                    try
                    {
                        // Serialize JSON object to string
                        var jsonData = JsonConvert.SerializeObject(textListWords);

                        // Create HttpClient
                        using (var client = new HttpClient())
                        {
                            // Set base URL of the REST API
                            var endPoint = new Uri(ConfigRest.UrlTextSearch);

                            // Create StringContent from the JSON string
                            var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");

                            // Send POST request to the REST API
                            var response = await client.PostAsync(endPoint, payload);
                            if (response.IsSuccessStatusCode)
                            {
                                string content = await response.Content.ReadAsStringAsync();
                                ResponseMessage responseContent = JsonConvert.DeserializeObject<ResponseMessage>(content);

                                // Extraction of the base64 string from the "Message" field
                                string base64Image = responseContent.Message;

                                // Convert base64 string to byte[] 
                                byte[] imageBytes = Convert.FromBase64String(base64Image);

                                // Upload byte array to MemoryStream
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    // Load image from MemoryStream to PictureBox
                                    pictureBoxPlot.Image = Image.FromStream(ms);
                                    pictureBoxPlot.SizeMode = PictureBoxSizeMode.StretchImage;
                                }

                                SetComponents();
                                EnabledComponent(true);

                                labelTexList.Text = textListAuthor;

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
                    MessageBox.Show("Empty list");
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
        private void TextBoxAuthor_Enter(object sender, EventArgs e)
        {
            // to strip the value from this textBox when we enter it
            if (authorValid == false)
            {
                textBoxAuthor.Text = "";
            }
            ResetColors(SystemColors.Control, textBoxAuthor);
        }
    }
}
