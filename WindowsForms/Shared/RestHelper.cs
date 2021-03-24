﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Helper
{
    public static class RestHelper
    {
        private static readonly string baseURL = "https://localhost:44342/";
        public static async Task<string> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "users"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if(data!= null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
