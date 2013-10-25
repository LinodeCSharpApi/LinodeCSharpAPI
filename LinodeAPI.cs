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
        Dictionary<string, Type> classes;
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
            this.classes = getClasses();
            this.network = new Network(auth);
        }

        public void SetAuthentication(Authentication auth)
        {
            this.network.Authentication = auth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Type> getClasses()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Dictionary<string, Type> classes = new Dictionary<string, Type>();

            foreach (Type type in currentAssembly.GetTypes())
            {
                if (type.Name.Substring(Math.Max(0, type.Name.Length - "Action".Length), Math.Min("Action".Length, type.Name.Length)) == "Action" && type.Name != "IAction")
                {
                    classes.Add(type.Name, type);
                }
            }

            return classes;
        }
    }

}
