using System;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Web.Extensions
{
    public static class RazorExtensions 
    {
        public static string FormatarCpf(this RazorPage page, string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
    }
}