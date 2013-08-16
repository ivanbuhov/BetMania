using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Spring.IO;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.Social.OAuth1;

namespace BetMania.AvatarUploader
{
    public class AvatarUploader
    {
        // Register your own Dropbox app at https://www.dropbox.com/developers/apps
        // with "Full Dropbox" access level and set your app keys and app secret below
        private const string DropboxAppKey = "babqx6idqfu1i71";
        private const string DropboxAppSecret = "5h7t7v5gkqmxj4k";
        private const string DropboxAccessKey = "z6ojellh53i911ko";
        private const string DropboxAccessSecret = "oieg1uoe1nnz516";

        //private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

        public static string Upload(string username, string path)
        {
            DropboxServiceProvider dropboxServiceProvider =
                new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            //// Authenticate the application (if not authenticated) and load the OAuth token
            //if (!File.Exists(OAuthTokenFileName))
            //{
            //    AuthorizeAppOAuth(dropboxServiceProvider);
            //}

            //OAuthToken oauthAccessToken = LoadOAuthToken();

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(DropboxAccessKey, DropboxAccessSecret);

            // Display user name (from his profile)
            DropboxProfile profile = dropbox.GetUserProfileAsync().Result;
            Console.WriteLine("Hi " + profile.DisplayName + "!");

            // Create new folder
            string newFolderName = username;
            Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
            Console.WriteLine("Created folder: {0}", createFolderEntry.Path);

            // Upload a file
            var filename = Path.GetFileName(path);
            Entry uploadFileEntry = dropbox.UploadFileAsync(
                new FileResource(path),
                "/" + newFolderName + "/" + filename).Result;
            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);

            // Share a file
            DropboxLink sharedUrl = dropbox.GetMediaLinkAsync(uploadFileEntry.Path).Result;

            return sharedUrl.Url;
        }

        //private static OAuthToken LoadOAuthToken()
        //{
        //    string[] lines = File.ReadAllLines(OAuthTokenFileName);
        //    OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
        //    return oauthAccessToken;
        //}

        //private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        //{
        //    // Authorization without callback url
        //    Console.Write("Getting request token...");
        //    OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
        //    Console.WriteLine("Done.");

        //    OAuth1Parameters parameters = new OAuth1Parameters();
        //    string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
        //        oauthToken.Value, parameters);
        //    Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
        //    Process.Start(authenticateUrl);
        //    Console.Write("Press [Enter] when authorization attempt has succeeded.");
        //    Console.ReadLine();

        //    Console.Write("Getting access token...");
        //    AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
        //    OAuthToken oauthAccessToken =
        //        dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
        //    Console.WriteLine("Done.");

        //    string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
        //    File.WriteAllLines(OAuthTokenFileName, oauthData);
        //}
    }
}
