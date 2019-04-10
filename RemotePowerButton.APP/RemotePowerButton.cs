using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemotePowerButton.API.Connector;

namespace RemotePowerButton.APP
{
    public partial class RemotePowerButton : Form
    {
        protected readonly ApiConnector ApiConnector;

        public RemotePowerButton()
        {
            InitializeComponent();
            var apiAddress = ConfigurationManager.AppSettings["apiAddress"];
            var accessToken = ConfigurationManager.AppSettings["accessToken"];
            ApiConnector = new ApiConnector(apiAddress, accessToken);
        }

        private async void ButShort_Click(object sender, EventArgs e)
        {
            await PerformCommand(async () => await ApiConnector.SendShortButtonPress());
        }

        private async void ButLong_Click(object sender, EventArgs e)
        {
            await PerformCommand(async () => await ApiConnector.SendShortButtonPress());
        }

        private async Task PerformCommand(Func<Task<HttpResponseMessage>> apiCall)
        {
            ToggleUILock();
            statusLabel.ForeColor = Color.Black;
            statusLabel.Text = "Executing short power button press.";
            try
            {
                var response = await apiCall();
                if (response.IsSuccessStatusCode)
                {
                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = "Short power button press executed.";
                }
                else
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = response.ReasonPhrase;
                }
            }
            catch (Exception)
            {
                statusLabel.ForeColor = Color.Red;
            }
            finally
            {
                ToggleUILock();
            }
        }

        private void ToggleUILock()
        {
            butShort.Enabled = !butShort.Enabled;
            butLong.Enabled = !butLong.Enabled;
        }

    }
}
