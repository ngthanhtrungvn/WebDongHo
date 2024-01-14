using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace DuAnWebsite
{
    public class Global
    {
        public static HttpClient WebAPIClient = new HttpClient();
        static Global()
        {
            WebAPIClient.BaseAddress = new Uri("http://localhost:2631/api/");
            WebAPIClient.DefaultRequestHeaders.Clear();
            WebAPIClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}