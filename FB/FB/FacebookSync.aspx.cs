using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using System.Net;
using System.IO;

namespace FB
{
    public partial class FacebookSync : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FacebookCheckAuthorization();
        }

        private void FacebookCheckAuthorization()
        {
            //eChalkApp Id and Secret  
            //string appId = "288890157955347";
            // string appSecret = "807cddd3baa680891e68433fcc784106";

            //eChalkApp-Test1 Id and Secret 
            string appId = "289263874584642";
            string appSecret = "ab67e6bfe1bb983799ec3703fd336a7f";
            //string scope = "publish_actions,manage_pages";
            string scope = "publish_actions";

            if (Request["code"] == null)
            {
                Response.Redirect(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    appId, Request.Url.AbsoluteUri, scope));
            }
            else
            {

                var tokens = new Dictionary<string, string>();
                string url =
                    string.Format(
                        "https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                        appId, Request.Url.AbsoluteUri, scope, Request["code"], appSecret);

                var request = WebRequest.Create(url) as HttpWebRequest;
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    string vals = reader.ReadToEnd();
                    foreach (string token in vals.Split('&'))
                    {
                        tokens.Add(
                            token.Substring(0, token.IndexOf("=")),
                            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1)
                            );
                    }
                    string accessToken = tokens["access_token"];

                    var client = new FacebookClient(accessToken);

                    client.Post("/me/feed", new { message = "Testing submitting message from eChalk Announcement to Facebook." });
                }

            }
        }
    }

}