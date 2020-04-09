using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System.Configuration;

namespace AWS.Utilites
{
    class CognitoUserStore
    {
        private readonly AmazonCognitoIdentityProviderClient _client =   new AmazonCognitoIdentityProviderClient();
        private readonly string _clientId = ConfigurationManager.AppSettings["CLIENT_ID"];
        private readonly string _poolId = ConfigurationManager.AppSettings["USERPOOL_ID"];


        public void AddToCognito(CognitoUser user)
        {
            try
            {

                SignUpRequest signUpRequest = new SignUpRequest();

                signUpRequest.ClientId = _clientId;
                signUpRequest.Username = user.Username;
                signUpRequest.Password = user.Password;

                SignUpResponse signUpResponse = new SignUpResponse();
                _client.SignUp(signUpRequest);
                Console.WriteLine(user.Username, " added successfully to Cognito");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        public Task CreateAsync(CognitoUser user)
        {
            // Register the user using Cognito
            var signUpRequest = new SignUpRequest
            {
                ClientId = ConfigurationManager.AppSettings["CLIENT_ID"],
                Password = user.Password,
                Username = user.Username,

            };

            /*

            var emailAttribute = new AttributeType
            {
                Name = "email",
                Value = user.Email
            };

              */

            //signUpRequest.UserAttributes.Add(emailAttribute);

            return _client.SignUpAsync(signUpRequest);
        }



    }

}
