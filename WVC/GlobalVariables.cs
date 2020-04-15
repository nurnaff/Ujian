using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WVC
{
    public static class GlobalVariables
    {
        public static HttpClient WebAplClient = new HttpClient();
        static GlobalVariables()
        {
            WebAplClient.BaseAddress = new Uri("http://localhost:57956/api/");
            WebAplClient.DefaultRequestHeaders.Clear();
            WebAplClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}