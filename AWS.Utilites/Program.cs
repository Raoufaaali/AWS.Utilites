using Amazon.CognitoIdentityProvider.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWS.Utilites
{
    class Program
    {
        public static List<string> UserList = new List<string>();
        public static string FilePath = @"..\..\..\Users.csv";

        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Cognito Builk Signup Utility");

            LoadUserFile(FilePath);

            CognitoUser cognitoUser = new CognitoUser();
            cognitoUser.Password = "QWEqwe123!";
            CognitoUserStore cognitoUserStore = new CognitoUserStore();

            foreach (string username in UserList)
            {
                try
                {

                    cognitoUser.Username = username;
                    cognitoUser.Username.Trim();
                    Console.WriteLine("Attempting to sign up user {0} with PW: {1}", username, cognitoUser.Password);
                    cognitoUserStore.AddToCognito(cognitoUser);
                    Console.WriteLine(cognitoUser.Username, " added successfully to Cognito");
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            Console.ReadKey();
        }


        public static void LoadUserFile(string filepath)
        {
            if (!string.IsNullOrWhiteSpace(filepath))
            {
                UserList = File.ReadLines(FilePath).ToList();
            }
        }
    } 

}




