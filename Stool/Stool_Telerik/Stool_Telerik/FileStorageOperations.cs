using Stool_Telerik.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Stool_Telerik
{
    class FileStorageOperations
    {
        /// <summary>
        /// Saves a string to a file using the WP8 APIs - not supported in WP7.1
        /// </summary>
        /// <param name="logData">string data to save</param>
        public async static Task SaveToLocalFolderAsync(List<LogData> lista)
        {
            // Get a reference to the Local Folder
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            // Create the file in the local folder, or if it already exists, just open it
            Windows.Storage.StorageFile storageFile =
                await localFolder.CreateFileAsync("Stool.store", CreationCollisionOption.OpenIfExists);

            Stream writeStream = await storageFile.OpenStreamForWriteAsync();
            using (var writer = new BinaryWriter(writeStream))
            {
                writer.Write(lista.Count);
                foreach (var el in lista)
                {
                    //writer.Write(el.Log);
                    writer.Write(el.Log);
                    writer.Write(el.DateTime.ToString());
                }
            }
        }
        public async static Task<List<LogData>> LoadFromLocalFolderAsync()
        {
            //string data = string.Empty;

            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var lista = new List<LogData>();

            // Create the file in the local folder, or if it already exists, just open it
            try
            {
                var storageFile =
                        await localFolder.GetFileAsync("Stool.store");

                using (var readStream = await storageFile.OpenStreamForReadAsync())
                using (var reader = new BinaryReader(readStream))
                {
                    var count = 0;
                    count = reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        var data = new LogData();
                        data.Log = reader.ReadString();
                        data.DateTime = DateTime.Parse(reader.ReadString());
                        lista.Add(data);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lista;
        }
    }
}
