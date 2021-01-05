using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KeelNotice.RestfulApi
{
    public class BaseRestfulApi : IRestfulApi
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// 基础服务调用
        /// </summary>
        /// <param name="httpClient"></param>
        public BaseRestfulApi(HttpClient httpClient)
        {
            //TODO:非正常关闭后，TCP连接好像没有断开 

            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            // _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            _httpClient.DefaultRequestHeaders.Add("Accept-Charset", "UTF-8");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "FinancialPlatform");
        }
        
        /// <inheritdoc />
        public async Task<T> GetAsync<T>(string requestUri, Dictionary<string, string> headers)
        {
            var content = await GetStringAsync(requestUri, headers);

            return string.IsNullOrEmpty(content) ? default(T) : JsonConvert.DeserializeObject<T>(content);
        }

        /// <inheritdoc />
        public async Task<string> GetStringAsync(string requestUri, Dictionary<string, string> headers)
        {
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    if (_httpClient.DefaultRequestHeaders.Contains(item.Key))
                    {
                        _httpClient.DefaultRequestHeaders.Remove(item.Key);
                    }

                    _httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }

            var response = await _httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception(response.ReasonPhrase)
            {
                Source = await response.Content.ReadAsStringAsync()
            };
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<T>(string requestUri)
        {
            var content = await GetStringAsync(requestUri);

            return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<T>(content);
        }

        /// <inheritdoc />
        public async Task<string> GetStringAsync(string requestUri)
        {
            return await GetStringAsync(requestUri, null);
        }

        /// <inheritdoc />
        public async Task<T> PostAsync<T>(string requestUri, object obj)
        {
            var json = obj != null ? JsonConvert.SerializeObject(obj) : string.Empty;

            return await PostAsync<T>(requestUri, json);
        }

        public async Task<T> PostAsync<T>(string requestUri, string json)
        {
            var content = await PostStringAsync(requestUri, json);

            return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<T>(content);
        }

        /// <inheritdoc />
        public async Task<string> PostStringAsync(string requestUri, object obj)
        {
            var json = obj != null ? JsonConvert.SerializeObject(obj) : string.Empty;

            return await PostStringAsync(requestUri, json);
        }

        public async Task<string> PostStringAsync(string requestUri, string json)
        {
            return await PostStringAsync(requestUri, json, null);
        }

        public async Task<byte[]> PostByteArrayAsync(string requestUri, string json)
        {
            HttpResponseMessage response;
            try
            {
                var httpContent = new StringContent(json ?? String.Empty, Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") { CharSet = "utf-8" };


                response = await _httpClient.PostAsync(requestUri, httpContent);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }

            throw new Exception(response.ReasonPhrase)
            {
                Source = await response.Content.ReadAsStringAsync()
            };
        }

        public async Task<T> PostAsync<T>(string requestUri, object obj, Dictionary<string, string> headers)
        {
            var content = await PostStringAsync(requestUri, headers);

            return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<T> PostAsync<T>(string requestUri, string json, Dictionary<string, string> headers)
        {
            var content = await PostStringAsync(requestUri, json, headers);

            return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<string> PostStringAsync(string requestUri, object obj, Dictionary<string, string> headers)
        {
            var json = obj != null ? JsonConvert.SerializeObject(obj) : string.Empty;

            return await PostStringAsync(requestUri, json, headers);
        }

        public async Task<string> PostStringAsync(string requestUri, string json, Dictionary<string, string> headers)
        {
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    if (_httpClient.DefaultRequestHeaders.Contains(item.Key))
                    {
                        _httpClient.DefaultRequestHeaders.Remove(item.Key);
                    }

                    _httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            
            HttpResponseMessage response;
            try
            {
                var httpContent = new StringContent(json ?? String.Empty, Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") { CharSet = "utf-8" };


                response = await _httpClient.PostAsync(requestUri, httpContent);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception(response.ReasonPhrase)
            {
                Source = await response.Content.ReadAsStringAsync()
            };
        }
    }
}
