using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinodeCSharpAPI.Core
{
    /// <summary>
    /// Linode API Request Object. Contains the action and the associated parameters, 
    /// except authentication related parameters like username or apikey.
    /// </summary>
    class Request
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
        public object addParam(string name, string value)
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
        public bool hasParam(string name)
        {
            return this.parameters.ContainsKey(name);
        }

        /// <summary>
        /// Removes a parameter from the request.
        /// </summary>
        /// <param name="name">Parameter's name</param>
        /// <returns>Request object, or false in case of error.</returns>
        public object removeParam(string name)
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
        /// <returns>The parameter value, or false in case of error.</returns>
        public object getParam(string name) 
        {
            string output;
            
            try
            {
                this.parameters.TryGetValue(name, out output);
            }
            catch (ArgumentNullException argNullException)
            {
                return false;
            }

            return output;
        }

        /// <summary>
        /// Sets the Request's action
        /// </summary>
        /// <param name="action">API Action</param>
        /// <returns>Request object.</returns>
        public object setApiAction(string action)
        {
            this.action = action;
            return this;
        }

        /// <summary>
        /// Gets the Request's action
        /// </summary>
        /// <returns>Request's action string.</returns>
        public string getApiAction()
        {
            return this.action;
        }

        /// <summary>
        /// Gets all the Request's parameters and api_action encoded for HTTP POST.
        /// </summary>
        /// <returns>HTTP POST String</returns>
        public string getPOSTString()
        {
            //TODO
        }
    }
}
