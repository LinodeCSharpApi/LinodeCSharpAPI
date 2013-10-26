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
using JTraverso.LinodeCSharpAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JTraverso.LinodeCSharpAPI
{
    public class LinodeAPI
    {
        Network network;

        public LinodeAPI()
        {
            Authentication auth = new Authentication();
            auth.UserName = "";
            auth.ApiKey = "";

            this.StartApi(auth);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="apikey"></param>
        public LinodeAPI(string username, string apikey)
        {
            Authentication auth = new Authentication();
            auth.UserName = username;
            auth.ApiKey = apikey;

            this.StartApi(auth);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth"></param>
        public LinodeAPI(Authentication auth)
        {
            this.StartApi(auth);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth"></param>
        private void StartApi(Authentication auth)
        {
            this.network = new Network(auth);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth"></param>
        public void SetAuthentication(Authentication auth)
        {
            this.network.Authentication = auth;
        }

        public IResponse Get(string action, Dictionary<string, string> parameters)
        {
            Request req = new Request(action, parameters);

            Response response = new Response(this.network.DoCall(req));

            return response;
        }

    }

}
