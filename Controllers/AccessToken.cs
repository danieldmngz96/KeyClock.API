using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using KeyClock.API.Models;

namespace KeyClock.API.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class AccessTokenController : Controller
    {
        public string url = "https://fu.thomasgreg.com:8444/";
        /// <summary> 
        /// Metodo <c>GetTokenUser </c> obtiene el token de keyclock 
        /// </summary> 
        [Route("GetTokenUser")]
        [HttpPost]
        public async Task<string> GetTokenUser(string realm, string user, string password, string client)
        {
            string urlToRequest = url + "/auth/realms/" + realm + "/protocol/openid-connect/token";
            Token objResult;



            try
            {
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("client_id", client));
                nvc.Add(new KeyValuePair<string, string>("username", user));
                nvc.Add(new KeyValuePair<string, string>("password", password));
                nvc.Add(new KeyValuePair<string, string>("grant_type", "password"));



                HttpContent body = new FormUrlEncodedContent(nvc);
                body.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                using (HttpClient request = new HttpClient())
                {



                    request.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));



                    var response = await request.PostAsync(new Uri(urlToRequest), body);



                    response.EnsureSuccessStatusCode();
                    var stream = response.Content.ReadAsStream();



                    using (var reader = new StreamReader(stream))
                    {
                        DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(Token));
                        objResult = (Token)sr.ReadObject(stream);



                    }
                    return objResult.access_token;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("GetTokenServiceAccount")]
        [HttpPost]
        /// <summary> 
        /// Metodo <c>GetTokenServiceAccount </c> obtiene el token por un service account 
        /// </summary>
        public async Task<string> GetTokenServiceAccount(string realm, string clientSecret)
        {
            string urlToRequest = url + "/auth/realms/" + realm + "/protocol/openid-connect/token";
            Token objResult;
            try
            {
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("client_id", "service-acocount"));
                nvc.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
                nvc.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                HttpContent body = new FormUrlEncodedContent(nvc);
                body.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                using (HttpClient request = new HttpClient())
                {



                    request.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));



                    var response = await request.PostAsync(new Uri(urlToRequest), body);



                    response.EnsureSuccessStatusCode();
                    var stream = response.Content.ReadAsStream();



                    using (var reader = new StreamReader(stream))
                    {
                        DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(Token));
                        objResult = (Token)sr.ReadObject(stream);



                    }
                    return objResult.access_token;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary> 
        /// Metodo <c>RetrieveToken </c> nose xdxdx
        /// </summary>
        [Route("RetrieveToken")]
        [HttpPost]
        public async Task<string> RetrieveToken(string username, string password ,
            string client_id , string client_secret, string realm){
            string urlToRequest = url + "/auth/realms/" + realm + "/protocol/openid-connect/token";
            Token objResult;
            try
            {
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("username", "tester"));
                nvc.Add(new KeyValuePair<string, string>("password", "test"));
                nvc.Add(new KeyValuePair<string, string>("grant_type", "password"));
                nvc.Add(new KeyValuePair<string, string>("client_id", client_id));
                nvc.Add(new KeyValuePair<string, string>("password", password));
                nvc.Add(new KeyValuePair<string, string>("scope", "openid"));
                

                HttpContent body = new FormUrlEncodedContent(nvc);
                body.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                using (HttpClient request = new HttpClient())
                {



                    request.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));



                    var response = await request.PostAsync(new Uri(urlToRequest), body);



                    response.EnsureSuccessStatusCode();
                    var stream = response.Content.ReadAsStream();



                    using (var reader = new StreamReader(stream))
                    {
                        DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(Token));
                        objResult = (Token)sr.ReadObject(stream);



                    }
                    return objResult.access_token;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
