using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class ListSongs : Page
    {
        private const string ApiListSong = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/get-free-songs";

        public ListSongs()
        {
            var httpClient = new HttpClient();
            Task<HttpResponseMessage> httpRequestMessage = httpClient.GetAsync(ApiListSong);
            String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            List<Song> listSong = JsonConvert.DeserializeObject<List<Song>>(responseContent);
        }
    }
}
