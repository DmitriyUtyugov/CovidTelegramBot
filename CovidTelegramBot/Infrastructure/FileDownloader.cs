using CovidTelegramBot.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CovidTelegramBot.Infrastructure
{
    public class FileDownloader : IFileDownloader
    {
        public bool FileExists(Uri uri)
        {
            bool exists = false;

            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Method = "HEAD";
            HttpWebResponse webResponse = null;

            try
            {
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                exists = true;
            }
            catch (WebException exception)
            {
                Debug.WriteLine($"{uri} does not exists: {exception.Message}");
            }
            finally
            {
                if (webResponse != null)
                    webResponse.Close();
            }

            return exists;
        }

        public void GetFileFromUrl(Uri uri)
        {
            string regexPattern = @"[0-3]?[0-9].[0-3]?[0-9].(?:[0-9]{2})?[0-9]{2}";
            string extractedDate = Regex.Match(uri.OriginalString, regexPattern).Value;

            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(uri, $"{extractedDate}.csv");
            }
        }
    }
}
