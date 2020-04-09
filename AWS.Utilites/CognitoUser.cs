using Amazon.CognitoIdentityProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace AWS.Utilites
{
    
    public class CognitoUser 
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserStatusType Status { get; set; }
    }
}
