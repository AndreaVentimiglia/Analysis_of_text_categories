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
    public partial class FormTextComparison : Form
    {
        // Global variable
        private bool comboBox1Valid = true;
        private bool comboBox2Valid = true;
        readonly List<Text> textList = GlobalList.TextList;

        public FormTextComparison()
        {
            InitializeComponent();
           
        }

        private void FormTextComparison_Load(object sender, EventArgs e)
        {
            FillComboBoxX2();
        }

        /* --------------------- FUNCTIONS ---------------------*/
        void FillComboBoxX2()
        {
            comboBoxListText1.SelectedIndex = -1;
            comboBoxListText2.SelectedIndex = -1;

            //add items to both combos
            comboBoxListText1.Items.AddRange(textList.Select(i => i.Title + " - edition " + i.Edition).ToArray());
            comboBoxListText2.Items.AddRange(textList.Select(i => i.Title + " - edition " + i.Edition).ToArray());

            // Assign event handlers for selection change
            comboBoxListText1.SelectedIndexChanged += ComboBoxListText1_SelectedIndexChanged;
            comboBoxListText1.SelectionChangeCommitted += ComboBoxListText1_SelectionChangeCommitted;

            comboBoxListText2.SelectedIndexChanged += ComboBoxListText2_SelectedIndexChanged;
            comboBoxListText2.SelectionChangeCommitted += ComboBoxListText2_SelectionChangeCommitted;
        }

        void SetBackColor(Color color, params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.BackColor = color;
            }
        }

        private void EnabledComponent(bool control)
        {
            comboBoxListText1.Enabled = control;
            comboBoxListText2.Enabled = control;
            buttonSend.Enabled = control;
            buttonClose.Enabled = control;
        }

        private void SetComponents()
        {
            comboBoxListText1.SelectedItem = null;
            comboBoxListText2.SelectedItem = null;
            comboBoxListText1.SelectedIndex = -1;
            comboBoxListText2.SelectedIndex = -1;
        }

        void CheckField(int comboBoxSelectedIndex1, int comboBoxSelectedIndex2)
        {
            if (comboBoxSelectedIndex1 >= 0 && comboBoxSelectedIndex2 >= 0)
            {
                SetBackColor(SystemColors.Control, comboBoxListText1, comboBoxListText2, labelTextId1, labelTextId2);
                comboBox1Valid = true;
                comboBox2Valid = true;
            }
            else
            {
                SetBackColor(Color.LightSalmon, comboBoxListText1, comboBoxListText2, labelTextId1, labelTextId2);
                comboBox1Valid = false;
                comboBox2Valid = false;
            }

            if (comboBoxSelectedIndex1 < 0)
            {
                SetBackColor(Color.LightSalmon, comboBoxListText1, labelTextId1);
                comboBox1Valid = false;
            }
            else
            {
                SetBackColor(SystemColors.Control, comboBoxListText1, labelTextId1);
                comboBox1Valid = true;
            }
            
            if (comboBoxSelectedIndex2 < 0)
            {
                SetBackColor(Color.LightSalmon, comboBoxListText2, labelTextId2);
                comboBox2Valid = false;
            }
            else
            {
                SetBackColor(SystemColors.Control, comboBoxListText2, labelTextId2);
                comboBox2Valid = true;
            }

        }

        /* --------------------- EVENT: SelectedIndexChanged and SelectionChangeCommitted ---------------------*/
        private void ComboBoxListText1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxListText1.SelectedIndex != -1) {
                //remove selected item from comboBoxListText2
                string selected = comboBoxListText1.SelectedItem.ToString();
                comboBoxListText2.Items.Remove(selected);
            }
        }
        private void ComboBoxListText1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // add item to comboBoxListText2
            string deselected = comboBoxListText1.SelectedItem.ToString();
            comboBoxListText2.Items.Add(deselected);
        }

        private void ComboBoxListText2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxListText2.SelectedIndex != -1)
            {
                //remove selected item from comboBoxListText1
                string selected = comboBoxListText2.SelectedItem.ToString();
                comboBoxListText1.Items.Remove(selected);
            }
        }
        private void ComboBoxListText2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // add item to comboBoxListText1
            string deselected = comboBoxListText2.SelectedItem.ToString();
            comboBoxListText1.Items.Add(deselected);
        }

        /* --------------------- EVENT: Click ---------------------*/
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void ButtonSend_Click(object sender, EventArgs e)
        {
            //Checks if the fields have been selected
            CheckField(comboBoxListText1.SelectedIndex, comboBoxListText2.SelectedIndex);
            if (comboBox1Valid && comboBox2Valid)
            {   
                try
                {
                    // We retrieve the text selected in the comboBox from the text list
                    var selectedText1 = textList.Find(x => x.Id == (string)comboBoxListText1.SelectedItem);
                    var selectedText2 = textList.Find(x => x.Id == (string)comboBoxListText2.SelectedItem);

                    EnabledComponent(false);
                
                    var data = new
                    {
                        words1 = selectedText1.Words,
                        words2 = selectedText2.Words,
                        title1 = selectedText1.Title,
                        title2 = selectedText2.Title,
                    };

                    // Serialize JSON object to string
                    var jsonData = JsonConvert.SerializeObject(data);

                    // Create HttpClient
                    using (var client = new HttpClient())
                    {
                        // Set base URL of the REST API
                        var endPoint = new Uri(ConfigRest.UrlTextComparison);

                        // Create StringContent from the JSON string
                        var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        // Send POST request to the REST API
                        var response = await client.PostAsync(endPoint, payload);
                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            ResponseMessage3 responseContent = JsonConvert.DeserializeObject<ResponseMessage3>(content);

                            // Extraction of the base64 string from the "Message" field
                            string base64Image1 = responseContent.Img1;

                            // Convert base64 string to byte[] 
                            byte[] imageBytes1 = Convert.FromBase64String(base64Image1);

                            // Upload byte array to MemoryStream
                            using (MemoryStream ms1 = new MemoryStream(imageBytes1))
                            {
                                // Load image from MemoryStream to PictureBox
                                pictureBoxPlotRate.Image = Image.FromStream(ms1);
                                pictureBoxPlotRate.SizeMode = PictureBoxSizeMode.StretchImage;
                            }

                            if (String.IsNullOrEmpty(responseContent.Img2))
                            {
                                labelText.Text = "The two texts have no words in common";
                                labelText.Visible = true;
                                pictureBoxWord.Visible = false;
                            }
                            else
                            {
                                // Extraction of the base64 string from the "Message" field
                                string base64Image2 = responseContent.Img2;

                                // Convert base64 string to byte[]
                                byte[] imageBytes2 = Convert.FromBase64String(base64Image2);

                                // Upload byte array to MemoryStream
                                using (MemoryStream ms2 = new MemoryStream(imageBytes2))
                                {
                                    // Load image from MemoryStream to PictureBox
                                    pictureBoxWord.Image = Image.FromStream(ms2);
                                    pictureBoxWord.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBoxWord.Visible = true;
                                    labelText.Visible = false;
                                }
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
                MessageBox.Show("Fill in all required fields");
            }
        }

        void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
