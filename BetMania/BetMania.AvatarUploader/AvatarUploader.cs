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
        private const string DropboxAppKey = "babqx6idqfu1i71";
        private const string DropboxAppSecret = "5h7t7v5gkqmxj4k";

        private const string OAuthTokenFileName = "../../OAuthTokenFileName.txt";

        public static string Upload(string username, string path)
        {
            DropboxServiceProvider dropboxServiceProvider =
            new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            // Authenticate the application (if not authenticated) and load the OAuth token
            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth(dropboxServiceProvider);
            }
            OAuthToken oauthAccessToken = LoadOAuthToken();

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            // Create new folder
            string newFolderName = username;

            // Upload a file
            var filename = Path.GetFileName(path);
            Entry uploadFileEntry = dropbox.UploadFileAsync(
                new FileResource(path),
                "/" + newFolderName + "/" + filename).Result;

            // Share a file
            DropboxLink sharedUrl = dropbox.GetMediaLinkAsync(uploadFileEntry.Path).Result;        
            return sharedUrl.Url;
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        {
            // Authorization without callback url
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
                oauthToken.Value, parameters);
            
            Process.Start(authenticateUrl);

            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken =
                dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }
    }
}
