using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace User
{
    public partial class FormHome : Form
    {
        List<Text> textList = GlobalList.TextList;
        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            FillList(); // To recover the text list
        }

        /* --------------------- FUNCTIONS ---------------------*/
        private async void FillList()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Set base URL of the REST API
                    var endPoint = new Uri(ConfigRest.UrlRetrieveTextList);

                    // Send POST request to the REST API
                    var response = await client.GetAsync(endPoint);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        textList = JsonConvert.DeserializeObject<List<Text>>(content);
                        GlobalList.SortTextListByTitle();
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

        void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /* --------------------- EVENT: Click ---------------------*/
        private void ButtonInsertNewText_Click(object sender, EventArgs e)
        {
            FormInsertNewText insertNewText = new FormInsertNewText();
            insertNewText.ShowDialog(); // This way I can go back to the home screen only when the new screen is closed
        }

        private void ButtonGoWordClound_Click(object sender, EventArgs e)
        {
            FormWorldCloud worldCloud = new FormWorldCloud();
            worldCloud.ShowDialog(); // This way I can go back to the home screen only when the new screen is closed
        }

        private void ButtonGoFrequencyGraphs_Click(object sender, EventArgs e)
        {
            FormFrequencyGraphs frequencyGraphs = new FormFrequencyGraphs();
            frequencyGraphs.ShowDialog(); // This way I can go back to the home screen only when the new screen is closed
        }

        private void ButtonTextComparison_Click(object sender, EventArgs e)
        {
            FormTextComparison textComparison = new FormTextComparison();
            textComparison.ShowDialog(); // This way I can go back to the home screen only when the new screen is closed
        }

        private void ButtonTextSearch_Click(object sender, EventArgs e)
        {
            FormTextSearch textSearch = new FormTextSearch();
            textSearch.ShowDialog(); // This way I can go back to the home screen only when the new screen is closed
        }
    }
}
