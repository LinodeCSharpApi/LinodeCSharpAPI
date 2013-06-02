using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace LinodeCSharpAPI.Core
{
    class Network
    {
        private string protocol = "https://";
        private string apiEndPoint = "api.linode.com";
        private string apiURL = "";
        public event ResultEvent ResultAvailable;

        public string Method { get; private set; }
        public string UserAgent { get; set; }
        public Authentication Authentication { get; private set; }

        public Network(Authentication auth)
        {
            this.UserAgent = "";
            this.Method = HttpMethod.Post;
            this.Authentication = auth;

            this.apiURL = protocol + this.Authentication.UserName + ":" + this.Authentication.ApiKey + "@" + this.apiEndPoint + "/";
        }

        public string DoCall(Request apiRequest)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
            request.Method = this.Method;
            request.UserAgent = this.UserAgent;

            request.AllowWriteStreamBuffering = true;
            request.Method = this.Method;
            string post = apiRequest.GetPOSTString();
            request.ContentLength = post.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(post);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string resultado = sr.ReadToEnd();
                ResultAvailable(this, new ResultEventArgs(resultado));
                return resultado;
            }
        }
    }

    public static class HttpExtensions
    {
        private const int DefaultRequestTimeout = 15000;

        public static HttpWebResponse GetResponse(this HttpWebRequest request)
        {
            var dataReady = new AutoResetEvent(false);
            HttpWebResponse response = null;
            var callback = new AsyncCallback(delegate(IAsyncResult asynchronousResult)
            {
                try
                {
                    response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                    dataReady.Set();
                }
                catch (Exception e)
                {
                    dataReady.Set();
                }
            });

            request.BeginGetResponse(callback, request);

            if (dataReady.WaitOne(DefaultRequestTimeout))
            {
                return response;
            }

            return null;
        }

        public static Stream GetRequestStream(this HttpWebRequest request)
        {
            var dataReady = new AutoResetEvent(false);
            Stream stream = null;
            var callback = new AsyncCallback(delegate(IAsyncResult asynchronousResult)
            {
                stream = (Stream)request.EndGetRequestStream(asynchronousResult);
                dataReady.Set();
            });

            request.BeginGetRequestStream(callback, request);
            if (!dataReady.WaitOne(DefaultRequestTimeout))
            {
                return null;
            }

            return stream;
        }
    }


    public static class HttpMethod
    {
        public static string Head { get { return "HEAD"; } }
        public static string Post { get { return "POST"; } }
        public static string Put { get { return "PUT"; } }
        public static string Get { get { return "GET"; } }
        public static string Delete { get { return "DELETE"; } }
        public static string Trace { get { return "TRACE"; } }
        public static string Options { get { return "OPTIONS"; } }
        public static string Connect { get { return "CONNECT"; } }
        public static string Patch { get { return "PATCH"; } }
    }

    public delegate void ResultEvent(object sender, ResultEventArgs e);

    public class ResultEventArgs : EventArgs
    {
        public string Result { get; set; }

        public ResultEventArgs(string data)
        {
            Result = data;
        }
    }

}
