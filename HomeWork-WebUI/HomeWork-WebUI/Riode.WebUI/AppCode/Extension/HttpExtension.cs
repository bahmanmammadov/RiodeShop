using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace Riodetask.AppCode.Extension
{
    static public partial class Extension
    {
        static public string GetCurrentLang( this HttpContext ctr)
        {
            Match match = Regex.Match(ctr.Request.Path, @"\/(?<lang>az|en|ru)\/?.*");

            
            if (match.Success)
                return match.Groups["lang"].Value;

            if (ctr.Request.Cookies.TryGetValue("lang", out string lang))
            {
                return lang;
            }
            
                return "az";
        }
    }
}
