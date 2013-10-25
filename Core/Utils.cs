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
using JTraverso.LinodeCSharpAPI.Core.Payloads;
using System;

namespace JTraverso.LinodeCSharpAPI.Core
{
    /*
        0: ok
        1: Bad request
        2: No action was requested
        3: The requested class does not exist
        4: Authentication failed
        5: Object not found
        6: A required property is missing for this action
        7: Property is invalid
        8: A data validation error has occurred
        9: Method Not Implemented
        10: Too many batched requests
        11: RequestArray isn't valid JSON or WDDX
        12: Batch approaching timeout. Stopping here.
        13: Permission denied
        14: API rate limit exceeded
        30: Charging the credit card failed
        31: Credit card is expired
        40: Limit of Linodes added per hour reached
        41: Linode must have no disks before delete
    */   
    enum ErrorCodes 
    {
        OK = 0,
        BAD_REQUEST = 1,
        NO_ACTION_REQUESTED = 2,
        REQUESTED_CLASS_NOT_EXIST = 3,
        AUTHENTICATION_FAILED = 4,
        OBJECT_NOT_FOUND = 5,
        PROPERTY_MISSING = 6,
        PROPERTY_INVALID = 7,
        VALIDATION_ERROR = 8,
        NOT_IMPLEMENTED = 9,
        TOO_MANY_BATCHED = 10,
        REQUESTARRAY_INVALID = 11,
        BATCH_TIMEOUT = 12,
        PERMISSION_DENIED = 13,
        RATE_LIMIT = 14,
        CREDIT_CARD_FAILED = 30,
        CREDIT_CARD_EXPIRED = 31,
        LINODE_ADD_LIMIT = 40,
        MUST_HAVE_NO_DISKS = 41,

    }

    static class Utils
    {
        public static IResponsePayload GetPayloadClass(string action)
        {
            try
            {
                string className = action.Substring(0, 1).ToString().ToUpper() + String.Join("", action.Substring(1));
                return (IResponsePayload)Activator.CreateInstance(Type.GetType("JTraverso.LinodeCSharpAPI.Core.Payloads." + className + "Payload"));
            }
            catch (Exception classException)
            {
                return null;
            }
        }
    }
}
