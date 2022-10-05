using Microsoft.AspNetCore.Mvc;
using KeyClock.API.Models;
using System.Net;
using System.Text;
using System.Runtime.Serialization.Json;

namespace KeyClock.API.Controllers
{
    public class UserController : Controller
    {
        public string url = "https://fu.thomasgreg.com:8444";
        /// <summary> 
        /// Metodo <c>GetTokenUser </c> obtiene el token de keyclock 
        /// </summary> 
        [Route("GetUsers")]
        [HttpGet]
        public List<User> GetUsers(string realm, string token, string firstName = "", 
            string username = "", string briefRepresentation = "" , string email = "",
            string first = "", string lastName = "", string max = "", string search = "",
            string exact = ""){

            List<User> user = new List<User>();

            string urlToRequest = url + "/auth/admin/realms/" + realm + "/users";
            string urlfilter = ""; 
            if (firstName != ""){
                urlfilter = urlfilter + "firstName=" + firstName + "&";
            }
            if (username != ""){
                urlfilter = urlfilter + "username=" + username + "&";
            }
            if (briefRepresentation != ""){
                urlfilter = urlfilter + "briefRepresentation=" + briefRepresentation + "&";
            }
            if (email != ""){
                urlfilter = urlfilter + "email=" + email + "&";
            }
            if (first != ""){
                urlfilter = urlfilter + "first=" + first + "&";
            }
            if (lastName != ""){
                urlfilter = urlfilter + "lastName=" + lastName + "&";
            }
            if (max != ""){
                urlfilter = urlfilter + "max=" + max + "&";
            }
            if (search != ""){
                urlfilter = urlfilter + "search=" + search + "&";
            }
            if (exact != "")
            {
                urlfilter = urlfilter + "exact=" + exact + "&";
            }

            if (urlfilter != "")
            {
                urlfilter = "?" + urlfilter.Substring(0,urlfilter.Length -1);
            }

            urlToRequest = urlToRequest + urlfilter;

            Uri requestUri = new Uri(urlToRequest);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "*/*";
            WebHeaderCollection myWebHeaderCollection = httpWebRequest.Headers;
            myWebHeaderCollection.Add("Authorization", "Bearer " + token);

            
            

            try{
                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var stream = httpWebResponse.GetResponseStream();

                if ((httpWebResponse.StatusCode == HttpStatusCode.OK))
                {
                    var encoding = ASCIIEncoding.ASCII;
                    using (var reader = new StreamReader(stream))
                    {
                        DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(List<User>));
                        var a = (List<User>)sr.ReadObject(stream);
                        user = a; 

                    }
                    return user;
                }
                else
                {
                    string statusError = httpWebResponse.StatusCode.ToString();
                    return null;
                }
            }
            catch{

            }




            return user;

        }


    }

}
