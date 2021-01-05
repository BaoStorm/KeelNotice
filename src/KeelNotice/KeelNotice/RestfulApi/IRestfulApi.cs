using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeelNotice.RestfulApi
{
    public interface IRestfulApi
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="headers"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> GetAsync<T>(string requestUri, Dictionary<string, string> headers);

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<string> GetStringAsync(string requestUri, Dictionary<string, string> headers);
        
        
        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri">requestUri</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string requestUri);

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <returns></returns>
        Task<string> GetStringAsync(string requestUri);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri">requestUri</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string requestUri, object obj);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri">requestUri</param>
        /// <param name="json"></param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string requestUri, string json);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<string> PostStringAsync(string requestUri, object obj);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <param name="json"></param>
        /// <returns></returns>
        Task<string> PostStringAsync(string requestUri, string json);

        Task<byte[]> PostByteArrayAsync(string requestUri, string json);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri">requestUri</param>
        /// <param name="obj"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string requestUri, object obj, Dictionary<string, string> headers);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri">requestUri</param>
        /// <param name="json"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string requestUri, string json, Dictionary<string, string> headers);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <param name="obj"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<string> PostStringAsync(string requestUri, object obj, Dictionary<string, string> headers);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <param name="json"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<string> PostStringAsync(string requestUri, string json, Dictionary<string, string> headers);
    }
}
