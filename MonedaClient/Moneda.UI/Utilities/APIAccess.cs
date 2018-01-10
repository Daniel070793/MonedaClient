using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Moneda.UI.Utilities
{
    public class APIAccess : IAPIAccess
    {
        string _baseAddress;
        HttpClient _client;

        public APIAccess()
        {
            _baseAddress = "http://localhost:3465/api/";
            _client = new HttpClient();
        }

        // Post
        public async Task Post<T>(string url, T obj)
        {
            var address = _baseAddress + url;

            HttpResponseMessage response;
            try
            {
                var data = Serialize(obj);
                response = await _client.PostAsync(address, data);

                if (!response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (HttpRequestException)
            {
                // log exception (serilog?) 
                throw new Exception("API Connection error");
            }
        }

        // Get
        //public async Task<T> Get<T>(string url)
        //{
        //    var address = _baseAddress + url;

        //    try
        //    {
        //        HttpResponseMessage response = await _client.GetAsync(address);
        //        T result = await Deserialize<T>(response);
        //        return result;
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        // log exception (serilog?) 
        //        throw new Exception("API Connection error");
        //    }
        //}

        // Put
        //public async Task<Response> Put<T>(string url, T obj)
        //{
        //    var address = _baseAddress + url;

        //    try
        //    {
        //        var data = Serialize(obj);
        //        HttpResponseMessage response = await _client.PutAsync(address, data);
        //        Response result = await Deserialize<Response>(response);
        //        return result;
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        // log exception (serilog?) 
        //        throw new Exception("API Connection error");
        //    }
        //}

        // Delete
        //public async Task<Response> Delete(string url)
        //{
        //    var address = _baseAddress + url;

        //    try
        //    {
        //        HttpResponseMessage response = await _client.DeleteAsync(address);
        //        Response result = await Deserialize<Response>(response);
        //        return result;
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        // log exception (serilog?) 
        //        throw new Exception("API Connection error");
        //    }

        //}

        // JSON serialize
        StringContent Serialize<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            StringContent stringify = new StringContent(json, Encoding.UTF8, "application/json");
            return stringify;
        }

        // JSON deserialize
        async Task<T> Deserialize<T>(HttpResponseMessage res)
        {
            var content = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
