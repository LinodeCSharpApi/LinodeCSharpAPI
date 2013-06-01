using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinodeCSharpAPI.Core
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
    static class Constants
    {
 
    }
}
