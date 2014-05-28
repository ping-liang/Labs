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
    public partial class fbsync2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FacebookCheckAuthorization();
        }

        //This is the approach I prefer
        private void FacebookCheckAuthorization()
        {
            //eChalkApp Id and Secret  
            //string appId = "288890157955347";
            // string appSecret = "807cddd3baa680891e68433fcc784106";

            //eChalkApp-Test1 Id and Secret 
            string appId = "289263874584642";
            string appSecret = "ab67e6bfe1bb983799ec3703fd336a7f";
            //string scope = "publish_actions,manage_pages";
            //string scope = "publish_actions";
            string scope = "publish_stream";   //Either publish_stream or public_actions are fine

            var facebookClient = new FacebookClient();
            facebookClient.AppId = appId;
            facebookClient.AppSecret = appSecret;

            if (Request["code"] == null)
            {
                var authUrl = facebookClient.GetLoginUrl(new { 
                    client_id = appId,
                    client_secret = appSecret,
                    scope = scope,
                    redirect_uri = Request.Url.AbsoluteUri
                });
             
                Response.Redirect(authUrl.AbsoluteUri);
            }
            else
            {
                dynamic result = facebookClient.Get("oauth/access_token", new {
                    client_id = appId,
                    client_secret = appSecret,
                    scope = scope,
                    redirect_uri = Request.Url.AbsoluteUri,
                    code = Request["code"]
                });

                facebookClient.AccessToken = result.access_token;

                facebookClient.Post("/me/feed", new { message = "Testing submitting message from eChalk Announcement to Facebook - second approach." + DateTime.Now.ToString() });
            }
        }
    }
}