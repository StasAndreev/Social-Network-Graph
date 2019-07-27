using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using SocialGraph.DataAccess;

namespace SocialGraph.DesktopClient
{
    class HttpHandler
    {
        static private string Adress = "http://localhost:61209/";
        public bool Connected { get; private set; }

        MainViewModel VMref = null;

        public HttpHandler(MainViewModel VMref)
        {
            this.VMref = VMref;
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Adress);
            Request.ContentType = "application/json; charset=utf-8";
            Request.Method = "GET";
            try
            {
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                VMref.StatusText = "Connection successfull";
                Connected = true;
            } catch (WebException)
            {
                VMref.StatusText = "Unable to connect the server";
                Connected = false;
            }
        }

        public List<UserSummary> GetUserList()
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Adress + "/api/User");
                Request.ContentType = "application/json; charset=utf-8";
                Request.Method = "GET";

                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();

                using (var StreamReader = new StreamReader(Response.GetResponseStream()))
                {
                    string ResponseText = StreamReader.ReadToEnd();

                    return new JavaScriptSerializer().Deserialize<List<UserSummary>>(ResponseText);
                }
            }
            catch (WebException e)  // Возникла ошибка при получении Response
            {
                HttpWebResponse Response = (HttpWebResponse)e.Response;
                if (Response == null)
                {
                    VMref.StatusText = "Unable to connect the server";
                } else
                {
                    VMref.StatusText = "HttpResult:" + Response.StatusCode.ToString();
                }
                return null;
            }
        }
        public UserFull GetUser(System.Guid Id)
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Adress + "/api/User/" + Id.ToString());
                Request.ContentType = "application/json; charset=utf-8";
                Request.Method = "GET";

                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();

                using (var StreamReader = new StreamReader(Response.GetResponseStream()))
                {
                    string ResponseText = StreamReader.ReadToEnd();
                    VMref.StatusText = "HttpResult:OK";

                    return new JavaScriptSerializer().Deserialize<UserFull>(ResponseText);
                }
            }
            catch (WebException e)  // Возникла ошибка при получении Response
            {
                HttpWebResponse Response = (HttpWebResponse)e.Response;
                if (Response == null)
                {
                    VMref.StatusText = "Unable to connect the server";
                }
                else
                {
                    VMref.StatusText = "HttpResult:" + Response.StatusCode.ToString();
                }
                return null;
            }
        }
    }
}