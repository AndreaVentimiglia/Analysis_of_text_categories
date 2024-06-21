using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace User
{
    public partial class FormFrequencyGraphs : Form
    {
        // Global varible
        readonly List<Text> textList = GlobalList.TextList;
        
        // Assumes all valid initially Assume tutti validi inizialmente
        private bool titleValid = true;
        private bool editionValid = true;
        private string cheekTypeGraph1;
        private string cheekTypeGraph2;
        private string cheekColor;

        public FormFrequencyGraphs()
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

        private void EnabledComponent(bool control)
        {
            textBoxTitle.Enabled = control;
            textBoxEdition.Enabled = control;
            buttonSend.Enabled = control;
            buttonClose.Enabled = control;
            groupBoxTypeGraph1.Enabled = control;
            groupBoxTypeGraph2.Enabled = control;
            groupBoxColor.Enabled = control;
        }

        private void CheckField(string title, string edition)
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


            if (string.IsNullOrEmpty(edition))
            {
                ResetColors(Color.LightSalmon, textBoxEdition);
                editionValid = false;
            }
            else
            {
                editionValid = true;
            }
        }

        private void SetComponents()
        {
            textBoxTitle.Clear();
            textBoxEdition.Clear();
            radioButtonRateCategory.Checked = true;
            radioButtonHistogram.Checked = true;
            radioButtonBlue.Checked = true;
        }

        void CheckRadioButton()
        {
            if (radioButtonFrequencyWords.Checked == true)
            {
                cheekTypeGraph1 = "FrequencyWords";
            }
            else if (radioButtonRateCategory.Checked == true)
            {
                cheekTypeGraph1 = "RateCategory";
            }

            if (radioButtonHistogram.Checked == true)
            {
                cheekTypeGraph2 = "Histogram";
                
                if (radioButtonBlue.Checked == true)
                {
                    cheekColor = "Blue";
                }
                else if (radioButtonRed.Checked == true)
                {
                    cheekColor = "Red";
                }
                else if (radioButtonGreen.Checked == true)
                {
                    cheekColor = "Green";
                }
                else if (radioButtonYellow.Checked == true)
                {
                    cheekColor = "Yellow";
                }
            }
            else if (radioButtonPie.Checked == true)
            {
                cheekTypeGraph2 = "pie";
                cheekColor = "";
            }
        }

        /* --------------------- EVENT: Click ---------------------*/
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void ButtonSend_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text.Trim();
            string edition = textBoxEdition.Text.Trim();
            title = textBoxTitle.Text.ToLower();
            edition = textBoxEdition.Text.ToLower();

            //checks if the fields have been selected
            CheckField(title, edition);

            if (titleValid && editionValid)
            {
                // Search for the corresponding book
                Text text = textList.FirstOrDefault(x => x.Title == title && x.Edition == edition);

                if (text != null)
                {
                    CheckRadioButton();
                    EnabledComponent(false);
                    try
                    {
                        var data = new{ 
                            title = text.Title, 
                            author = text.Author, 
                            edition = text.Edition, 
                            words = text.Words,
                            typeGraph1 = cheekTypeGraph1,
                            typeGraph2 = cheekTypeGraph2,
                            color = cheekColor,
                        };

                        // Serialize JSON object to string
                        var jsonData = JsonConvert.SerializeObject(data);

                        // Create HttpClient
                        
                        using (var client = new HttpClient())
                        {
                            // Set base URL of the REST API
                            var endPoint = new Uri(ConfigRest.UrlFrequencyGraphs);

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
                                    pictureBoxPlot.Visible = true;
                                }


                                SetComponents();
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
                    MessageBox.Show("Text not found");
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
        private void TextBoxTitle_Enter(object sender, EventArgs e)
        {
            // to strip the value from this textBox when we enter it
            if (titleValid == false)
            {
                textBoxTitle.Text = "";
            }
            ResetColors(SystemColors.Control, textBoxTitle);
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

        private void RadioButtonPie_Click(object sender, EventArgs e)
        {
            groupBoxColor.Enabled = false;
        }

        private void RadioButtonHistogram_Click(object sender, EventArgs e)
        {
            groupBoxColor.Enabled = true;
        }
    }
}
