using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Plugin_Naveego_Legacy.Helper
{
    public class RequestHelper
    {
        private readonly Authenticator _authenticator;
        private readonly HttpClient _client;
        
        public RequestHelper(Settings settings, HttpClient client)
        {
            _authenticator = new Authenticator(settings, client);
            _client = client;
        }

        /// <summary>
        /// Get Async request wrapper for making authenticated requests
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            string token;

            // get the token
            try
            {
                token = await _authenticator.GetToken();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
            
            // add token to the request and execute the request
            try
            {
                var client = _client;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync(uri);

                return response;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
        }
        
        public async Task<HttpResponseMessage> PostAsync(string uri, StringContent json)
        {
            string token;

            // get the token
            try
            {
                token = await _authenticator.GetToken();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
            
            // add token to the request and execute the request
            try
            {
                var client = _client;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsync(uri, json);

                return response;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string uri, StringContent json)
        {
            string token;

            // get the token
            try
            {
                token = await _authenticator.GetToken();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
            
            // add token to the request and execute the request
            try
            {
                var client = _client;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PutAsync(uri, json);

                return response;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
        }
    }
}