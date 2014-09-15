using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace TimeTracker.Common
{
    public class LogHelper
    {
        public static string FormatLog(HttpRequest request)
        {
            string url = request.Url.ToString();
            string client = string.Format("{0} ({1})", request.UserHostAddress, request.UserHostName);
            string httpMethod = request.HttpMethod;
            string result = string.Format("HTTP Request\n" +
            "Requested URL: {0}\n" +
            "Client: {1}\n" +
            "HTTP method: {2}",
            url, client, httpMethod);
            if (httpMethod.Equals("POST"))
            {
                StringBuilder received = new StringBuilder("\n{ \n");
                NameValueCollection form = request.Form;
                bool first = true;
                foreach (string key in form.Keys)
                {
                    if (!first)
                    {
                        received.Append(",\n");
                    }
                    else
                    {
                        first = false;
                    }
                    string val = form[key];
                    var secrets = new[] {
                        "password", "passwd", "pass",
                        "confirmpassword", "confirmpasswd", "confirmpass",
                        "confpassword", "confpasswd", "confpass",
                        "confirm", "conf",
                        "newpassword", "oldpassword"
                    };
                    if (secrets.Contains(key.ToLower()))
                    {
                        val = new string('*', val.Length);
                    }
                    received.Append(string.Format("\t{0}: \"{1}\"", key, val));
                }
                received.Append("\n}");
                return result + received;
            }
            return result;
        }
        public static string FormatLog(HttpResponse response)
        {
            return string.Format("HTTP Response: {0}", response.Status);
        }
    }
}