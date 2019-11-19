using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace VitecData
{
    public static class APICommunicationHelper
    {
        public static void GetData<T>(string connectionString, out List<T> ts)
        {
            string data;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(connectionString);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream ?? throw new InvalidOperationException()))
            {
                data = reader.ReadToEnd();
            }

            var model = JsonConvert.DeserializeObject<List<T>>(data);

            ts = model;
        }
    }
}
