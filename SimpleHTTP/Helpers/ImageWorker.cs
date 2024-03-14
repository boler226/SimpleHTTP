using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace SimpleHTTP.Helpers
{
    public class ImageWorker
    {
        public async Task<BitmapImage> DownloadImageAsync(string imageUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (Stream stream = await client.GetStreamAsync(imageUrl))
                    {
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = stream;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                        return bitmapImage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження зображення: {ex.Message}");
                return null;
            }
        }
    }
}
