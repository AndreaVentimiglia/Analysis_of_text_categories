using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;


namespace Administrator
{

    public partial class FormAdministration : Form
    {
        // Global variables
        string fileContents;
        private bool categoryValid = true;
        private bool fileTextValid= true;

        public FormAdministration()
        {
            InitializeComponent();
        }
        //It is used to activate or deactivate components of the form
        private void EnabledComponent(bool control)
        {
            textBoxCategory.Enabled = control;
            buttonOpenFile.Enabled = control;
            buttonSend.Enabled = control;
        }
        void SetBackColor(Color color, params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.BackColor = color;
            }
        }
        private void SetComponents()
        {
            textBoxCategory.Clear();
            textBoxTextFile.Clear();
            fileContents = "";
        }
        private void CheckField(string category, string textFile)
        {
            if (string.IsNullOrEmpty(category) && string.IsNullOrEmpty(textFile))
            {
                SetBackColor(Color.LightSalmon, textBoxTextFile, textBoxCategory);
                fileTextValid = false;
                categoryValid = false;
                //MessageBox.Show("Enter both the category and the text file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(category))
            {
                textBoxCategory.BackColor = Color.LightSalmon;
                textBoxTextFile.BackColor = SystemColors.Control;
                fileTextValid = true;
                categoryValid = false;
                //MessageBox.Show("Enter the category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(textFile))
            {
                textBoxCategory.BackColor = SystemColors.Control;
                textBoxTextFile.BackColor = Color.LightSalmon;
                fileTextValid = false;
                categoryValid = true;
                //MessageBox.Show("Enter the contents of the text file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fileTextValid = true;
                categoryValid = true;
            }
        }


        /* --------------------- EVENT: Click ---------------------*/
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
                    SetBackColor(Color.LightSalmon, textBoxTextFile);
                }
                else
                {
                    textBoxTextFile.Text = "File inserted successfully";
                    SetBackColor(SystemColors.Control, textBoxTextFile);
                }
            }

        }

        private async void ButtonSend_Click(object sender, EventArgs e)
        {
            string category = textBoxCategory.Text.Trim();
            string textFile = fileContents;

            CheckField(category, textFile);

            if(categoryValid && fileTextValid)
            {
                var data = new{category,textFile};

                // Serialize JSON object to string
                var jsonData = JsonConvert.SerializeObject(data);

                try
                {
                    EnabledComponent(false);
                    // Create HttpClient
                    using (var client = new HttpClient())
                    {
                        // Set base URL of the REST API
                        string hostName = "localhost";
                        string portNumber8080 = "8080";
                        string frequencyCategoryRest = "/frequency-category";

                        var endPoint = new Uri("http://"+ hostName+":"+ portNumber8080 + frequencyCategoryRest); 

                        // Create StringContent from the JSON string
                        var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        // Send POST request to the REST API
                        var response = await client.PostAsync(endPoint, payload);

                        // Check if the request was successful
                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            ResponseMessage responceContent = JsonConvert.DeserializeObject<ResponseMessage>(content);

                            if (responceContent.Message.Equals("New category entered correctly"))
                                MessageBox.Show("JSON file sent successfully."+ "\n"+ responceContent.Message + "\n\nCategory: " + category);
                            else if(responceContent.Message.Equals("Update Category"))
                                MessageBox.Show("JSON file sent successfully." + "\n"+ responceContent.Message+": " + category);

                            
                            textFile = "";
                            SetBackColor(SystemColors.Control, textBoxCategory, textBoxTextFile);
                            EnabledComponent(true);
                            SetComponents();
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
        }

        void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /* --------------------- EVENT: Enter and Leave ---------------------*/
        private void TextBoxCategory_Enter(object sender, EventArgs e)
        {
            SetBackColor(SystemColors.Control, textBoxCategory);
        }
        private void TextBoxCategory_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCategory.Text))
                SetBackColor(Color.LightSalmon, textBoxCategory);
        }


    }

    // ResponseMessage class declaration
    public class ResponseMessage
    {
        public string Message { get; set; }
        public bool Result { get; set; }
    }
}
