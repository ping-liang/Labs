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
        private FacebookClient _faceBookClient;

        //eChalkApp Id and Secret  
        //const string appId = "288890157955347";
        //const string appSecret = "807cddd3baa680891e68433fcc784106";

        //eChalkApp-Test1 Id and Secret 
        const string  appId = "289263874584642";
        const  string appSecret = "ab67e6bfe1bb983799ec3703fd336a7f";

        //const string scope = "publish_actions,manage_pages";
        //const string scope = "publish_actions";
        const string scope = "publish_stream";   //Either publish_stream or public_actions are fine


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request["fbMsg"] == null)
            //{
            //    Response.Write("Please enter text.");
            //    Response.Redirect("index.html");
            //}

            //string msg = Request["fbMsg"].ToString();
            string msg = "Testing submitting message from eChalk Announcement to Facebook. Time Submitted:" + DateTime.Now.ToString();

            var _faceBookClient = new FacebookClient();
            _faceBookClient.AppId = appId;
            _faceBookClient.AppSecret = appSecret;

            //TODO: add error handling
            FacebookCheckAuthorization();

            PublishContentToFB(msg);
        }

        //This is the approach I prefer
        private void FacebookCheckAuthorization()
        {
            if (Request["code"] == null)
            {
                var authUrl = _faceBookClient.GetLoginUrl(new
                { 
                    client_id = appId,
                    client_secret = appSecret,
                    scope = scope,
                    redirect_uri = Request.Url.AbsoluteUri
                });
             
                Response.Redirect(authUrl.AbsoluteUri);
            }
            else
            {
                dynamic result = _faceBookClient.Get("oauth/access_token", new
                {
                    client_id = appId,
                    client_secret = appSecret,
                    scope = scope,
                    redirect_uri = Request.Url.AbsoluteUri,
                    code = Request["code"]
                });

                _faceBookClient.AccessToken = result.access_token; 
            }
        }

        private void PublishContentToFB(string msg)
        {
            _faceBookClient.Post("/me/feed", new { message = msg });
        }
    }
}