//
// This file is part of LinodeCSharpAPI.
//
// LinodeCSharpAPI is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// LinodeCSharpAPI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with LinodeCSharpAPI.  If not, see <http://www.gnu.org/licenses/>.
// 
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace JTraverso.LinodeCSharpAPI.Core
{
    class Network
    {
        private string protocol = "https://";
        private string apiEndPoint = "api.linode.com";
        private string apiURL = "";
        public event ResultEvent ResultAvailable;

        public string Method { get; private set; }
        public string UserAgent { get; set; }
        public Authentication Authentication { get; set; }

        public Network(Authentication auth)
        {
            this.UserAgent = "";
            this.Method = HttpMethod.Get;
            this.Authentication = auth;

            this.apiURL = protocol + this.apiEndPoint + "/";
            if (this.Authentication.ApiKey != "" && this.Authentication.UserName != "")
            {
                this.apiURL = protocol + this.Authentication.UserName + ":" + this.Authentication.ApiKey + "@" + this.apiEndPoint + "/";
            }
        }

        public string DoCall(Request apiRequest)
        {
            string url = apiURL + "?" + apiRequest.GetPOSTString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = this.Method;
            request.UserAgent = this.UserAgent;

            request.AllowWriteStreamBuffering = true;
            request.Method = this.Method;
            request.ContentLength = 0;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string resultado = sr.ReadToEnd();
                if (ResultAvailable != null)
                {
                    ResultAvailable(this, new ResultEventArgs(resultado));
                }
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
                catch (Exception netException)
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
