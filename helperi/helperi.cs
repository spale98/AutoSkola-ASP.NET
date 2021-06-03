using System;
using System.Text;
using System.Web.Mvc;

namespace Pokusaj3.helperi
{
    public static class helperi
    {
       
        public static MvcHtmlString OdgHelper(string src)
        {
            StringBuilder path = new StringBuilder();
            string serverUrl = String.Format("{0}://{1}{2}", System.Web.HttpContext.Current.Request.Url.Scheme, System.Web.HttpContext.Current.Request.Url.Authority, System.Web.HttpContext.Current.Request.ApplicationPath);
            string function = "Content/slike/tuzan.jpg"; //https://localhost:44341/Content/slike/smesan.jpg
            path.Append(serverUrl).Append(string.Format("/{0}", function));
            var tagBuilder = new TagBuilder("div");
            string p1 = path.ToString();
            tagBuilder.InnerHtml = "<img src =" +p1+">"; 
            tagBuilder.AddCssClass("Odg");
            return new MvcHtmlString(tagBuilder.ToString());
        }
    }
}

