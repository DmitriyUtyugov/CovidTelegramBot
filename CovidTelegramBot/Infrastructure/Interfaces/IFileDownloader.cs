using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTelegramBot.Infrastructure.Interfaces
{
    public interface IFileDownloader
    {
        void GetFileFromUrl(Uri uri);
        bool FileExists(Uri uri);
    }
}
