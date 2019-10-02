using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App1.Entity;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MusicForm : Page
    {
        private const string ApiUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/post-free";
        public MusicForm()
        {
            this.InitializeComponent();
        }

        private void ButtonUpload_OnClick(object sender, RoutedEventArgs e)
        {
            Boolean submit = true;

            if (this.name.Text.Equals(""))
            {
                this.errorName.Text = "Name is required!";
                submit = false;
            }
            else
            {
                submit = true;
            }
            if (this.thumbnail.Text.Equals(""))
            {
                this.errorThumbnail.Text = "Thumbnail is required!";
                submit = false;
            }
            else
            {
                submit = true;
            }
            if (this.link.Text.Equals(""))
            {
                this.errorLink.Text = "Link is required!";
                submit = false;
            }
            else
            {
                submit = true;
            }

            if (submit)
            {
                var song = new Song
                {
                    name = this.name.Text,
                    description = this.description.Text,
                    singer = this.singer.Text,
                    author = this.author.Text,
                    thumbnail = this.thumbnail.Text,
                    link = this.link.Text
                };

                var httpClient = new HttpClient();
                HttpContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8,
                    "application/json");

                Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(ApiUrl, content);
                String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Response: " + responseContent);
            }
        }

        private void ButtonReset_OnClick(object sender, RoutedEventArgs e)
        {
            this.name.Text = string.Empty;
            this.errorName.Text = string.Empty;
            this.description.Text = string.Empty;
            this.singer.Text = string.Empty;
            this.author.Text = string.Empty;
            this.thumbnail.Text = string.Empty;
            this.errorThumbnail.Text = string.Empty;
            this.link.Text = string.Empty;
            this.errorLink.Text = string.Empty;
        }
    }
}
