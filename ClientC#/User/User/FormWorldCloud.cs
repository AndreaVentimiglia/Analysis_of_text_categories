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
    public partial class FormWorldCloud : Form
    {

        // Global variable
        private string cheekWC;
        readonly List<Text> textList = GlobalList.TextList;

        public FormWorldCloud()
        {
            InitializeComponent();
        }
        private void FormWorldCloud_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        /* --------------------- FUNCTIONS ---------------------*/
        void CheckRadioButton()
        {
            if(radioButtonDefault.Checked==true)
            {
                cheekWC = "default";
            }
            else if (radioButtonAC.Checked == true)
            {
                cheekWC = "assassins_creed";
            }
            else if (radioButtonSW.Checked == true)
            {
                cheekWC = "stormtrooper";
            }
            else if (radioButtonCrab.Checked == true)
            {
                cheekWC = "crab";
            }
        }

        private void EnabledComponent(bool control)
        { 
            comboBoxListText.Enabled = control;
            radioButtonDefault.Enabled = control;
            radioButtonAC.Enabled = control;
            radioButtonSW.Enabled = control;
            radioButtonCrab.Enabled = control;
            buttonSend.Enabled = control;
            buttonClose.Enabled = control;
        }

        void ResetColors(Color color, params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.BackColor = color;
            }
        }

        void SetComponents()
        {
            comboBoxListText.SelectedItem = null;
            comboBoxListText.SelectedIndex = -1;
            radioButtonDefault.Checked = true;
        }

        private  void FillComboBox()
        {
           // Fill the comboBox with the text list
           comboBoxListText.SelectedIndex = -1; 
           comboBoxListText.Items.AddRange(textList.Select(i =>i.Title + " - edition " + i.Edition).ToArray());
        }

        /* --------------------- EVENT: Click ---------------------*/
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void ButtonSend_Click(object sender, EventArgs e)
        {
            CheckRadioButton();

            // Verify that there is at least one element in the comboBox
            if (comboBoxListText.SelectedIndex >= 0)
            {   
                try
                {
                    // We retrieve the text selected in the comboBox from the text list
                    var selectedText = textList[comboBoxListText.SelectedIndex]; 

                    EnabledComponent(false);
 
                    var data = new
                    {
                        wcType = cheekWC,
                        words = selectedText.Words,
                    };

                    // Serialize JSON object to string
                    var jsonData = JsonConvert.SerializeObject(data);

                    // Create HttpClient
                    using (var client = new HttpClient())
                    {
                        // Set base URL of the REST API                        
                        var endPoint = new Uri(ConfigRest.UrlWordCloud);

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
                                pictureBoxWordCloud.Image = Image.FromStream(ms);
                                pictureBoxWordCloud.SizeMode = PictureBoxSizeMode.StretchImage;
                                labelPicture.Text = "- Title: " + selectedText.Title + "\n- Ediction: " + selectedText.Edition+ "\nClick the image to save it -->";
                                labelPicture.Visible = true;
                            }

                            ResetColors(SystemColors.Control, comboBoxListText, labelTextId);
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
                ResetColors(Color.LightSalmon, labelTextId, comboBoxListText);
            }
        }
        void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PictureBoxWordCloud_Click(object sender, EventArgs e)
        {
            // To save the image of the wordCloud
            if (pictureBoxWordCloud.Image != null)
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Title = "Salva immagine",
                    Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxWordCloud.Image.Save(dialog.FileName);
                }
            }
        }
    }
}

