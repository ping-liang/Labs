﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FB
{
    public partial class twitter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var maxlenght = Request.Browser.MaximumHrefLength;
                //Request.Browser.MaximumHrefLength

            string carriageReturn = "\r";
            string lineFeed = "\n";
            
            
            string endcodeCarraigeReturn = HttpUtility.UrlPathEncode(carriageReturn);
            string endcodeLineFeed = HttpUtility.UrlPathEncode(lineFeed);

            string test = @"<a href=""javascript:var twitterWin=window.open('https://twitter.com/intent/tweet?tw_p=tweetbutton&url=http%3A%2F%2Fhs.king.echalk.net%2Fann.aspx%3Fid%3D06a53a35-b266-45e2-a7f8-1f3473f40fbe&text=The%20forces%20of%20political%20nihilism%20not%20only%20remain%20alive%20and%20well%20within%20the%20Republican%20Party%2C%20but%20they%20are%20on%20the%20rise.%20Witness%20the%20way%20they%20shook%20Washington%20on%20Tuesday%20by%20removing%20from%20power%20Eric%20Cantor%2C%20the%20House%20majority%20leader%2C%20who%20had%20been%20one%20of%20the%20most%20implacable%20opponents%20to%20the%20reform%20of%20immigration%2C%20health%20care%20and%20taxation.%20His%20crime%20(in%20addition%20to%20complacent%20campaigning)%3F%20He%20was%20occasionally%20obliged%2C%20as%20a%20leader%2C%20to%20take%20a%20few%20minimalist%20steps%20toward%20governing%2C%20like%20raising%20the%20debt%20ceiling%20and%20ending%20a%20ruinous%20shutdown.%0AContinue%20reading%20the%20main%20story%0ARELATED%20IN%20OPINION%0ATaking%20Note%3A%20So%2C%20Who%2C%20Exactly%2C%20Is%20David%20Brat%2C%20the%20Guy%20Who%20Beat%20Eric%20Cantor%3FJUNE%2011%2C%202014%0AThe%20Conscience%20of%20a%20Liberal%3A%20Fall%20of%20an%20ApparatchikJUNE%2011%2C%202014%0AEvaluations%3A%20After%20Eric%20CantorJUNE%2011%2C%202014%0AFor%20that%20he%20was%20pilloried%20in%20his%20Virginia%20district%20by%20a%20little-known%20resident%20of%20the%20distant%20extremes%2C%20David%20Brat%2C%20whose%20most%20effective%20campaign%20tool%20was%20a%20photo%20showing%20Mr.%20Cantor%20standing%20next%20to%20President%20Obama.%20By%20falsely%20portraying%20the%20seven-term%20incumbent%20as%20just%20another%20compromiser%2C%20just%20another%20accommodationist%20to%20the%20power%20of%20big%20government%2C%20Mr.%20Brat%20managed%20the%20unimaginable%20feat%20of%20bringing%20down%20a%20majority%20leader%20in%20a%20primary%2C%20and%20by%20double%20digits.','TwitterShareButtonWindow','width=600,height=350,location=0,menubar=0,titlebar=0,status=0,toolbar=0,top=200,left=200');twitterWin.focus();"" target=""TwitterShareButtonWindow""><img src=""http://static33dev.echalk.net/images/twitter_share_icon.gif"" alt=""Twitter Share""></a>";


            /*
            test = test.Replace(endcodeCarraigeReturn, "");
            test = test.Replace(endcodeLineFeed, "");
            test = test.Replace(endcodeCarraigeReturn.ToUpper(), "");
            test = test.Replace(endcodeLineFeed.ToUpper(), "");
            test = test;
            */

            string pattern = endcodeCarraigeReturn + "|" + endcodeCarraigeReturn.ToUpper() + "|" + endcodeLineFeed + "|" + endcodeLineFeed.ToUpper();
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(pattern);
            test = reg.Replace(test, "");

            test = test;


            if (!IsClientScriptBlockRegistered("TwitterScript"))
            {
                //Page.RegisterClientScriptBlock("TwitterScrip", "<script language=javascript src='/js/twitter.js'>");
            }
        }
    }
}