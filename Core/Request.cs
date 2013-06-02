using System;
using System.Collections.Generic;

namespace JTraverso.LinodeCSharpAPI.Core
{
    /// <summary>
    /// Linode API Request Object. Contains the action and the associated parameters, 
    /// except authentication related parameters like username or apikey.
    /// </summary>
    class Request : IRequest
    {
        /// <summary>
        /// Request's parameters
        /// </summary>
        Dictionary<string, string> parameters;

        /// <summary>
        /// Request's action.
        /// </summary>
        string action;

        /// <summary>
        /// Constructor
        /// </summary>
        public Request()
        {
            this.parameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Adds a parameter to the request.
        /// </summary>
        /// <param name="name">Parameter's name</param>
        /// <param name="value">Parameter's value</param>
        /// <returns>Request object, or false in case of error.</returns>
        public object AddParam(string name, string value)
        {
            if (name == "api_action")
            {
                return false;
            }

            try
            {
                this.parameters.Add(name, value);
            }
            catch (ArgumentNullException argNullException)
            {
                return false;
            }
            catch (ArgumentException argException)
            {
                this.parameters[name] = value;
                return this;
            }
            catch (Exception exception)
            {
                return false;
            }
            
            return this;
        }

        /// <summary>
        /// Checks if a parameter exists within the request.
        /// </summary>
        /// <param name="name">Parameter's name</param>
        /// <returns>Boolean</returns>
        public bool HasParam(string name)
        {
            return this.parameters.ContainsKey(name);
        }

        /// <summary>
        /// Removes a parameter from the request.
        /// </summary>
        /// <param name="name">Parameter's name</param>
        /// <returns>Request object, or false in case of error.</returns>
        public object RemoveParam(string name)
        {
            if (name == "api_action")
            {
                return false;
            }

            try
            {
                this.parameters.Remove(name);
            }
            catch (ArgumentNullException argNullException)
            {
                return false;
            }

            return this;
        }

        /// <summary>
        /// Gets a parameter's value.
        /// </summary>
        /// <param name="name">Parameter's name</param>
        /// <returns>The parameter value, or null in case of error / unexistent parameter.</returns>
        public object GetParam(string name) 
        {
            string output;
            bool retVal;
            
            try
            {
                retVal = this.parameters.TryGetValue(name, out output);
            }
            catch (ArgumentNullException argNullException)
            {
                return null;
            }

            if (!retVal) 
            {
                output = null;
            }

            return output;
        }

        /// <summary>
        /// Sets the Request's action
        /// </summary>
        /// <param name="action">API Action</param>
        /// <returns>Request object.</returns>
        public object SetApiAction(string action)
        {
            this.action = action;
            return this;
        }

        /// <summary>
        /// Gets the Request's action
        /// </summary>
        /// <returns>Request's action string.</returns>
        public string GetApiAction()
        {
            return this.action;
        }

        /// <summary>
        /// Gets all the Request's parameters and api_action encoded for HTTP POST.
        /// </summary>
        /// <returns>HTTP POST String</returns>
        public string GetPOSTString()
        {
            string output = "api_action=" + this.GetApiAction();
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                output = output + "&" + parameter.Key + "=" + parameter.Value;
            }

            return output;
        }

        public string GetJSON()
        {
            string output = "{\"api_action\": \"" + this.GetApiAction() + "\"";
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                output = output + ", \"" + parameter.Key + "\": \"" + parameter.Value + "\""; 
            }

            output = output + "}";

            return output;
        }
    }
}
