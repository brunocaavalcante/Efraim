using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Linq;
using Web.Models;

namespace Web.Extensions
{
    public static class RazorExtensions
    {
        public static string FormatarCpf(this RazorPage page, string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        public static bool VerificaPermissao(this RazorPage page, UsuarioViewModel user, string funcionalidade, string permissao)
        {
            /*foreach (var item in user.ListaPerfil.Where(p => p.Funcionalidade.Equals(funcionalidade)))
            {
                if (item.Permissoes.Contains(permissao)) return true;
            }*/

            return false;
        }

        public static bool VerificaPerfil(this RazorPage page, UsuarioViewModel user, string perfil)
        {
            return user.ListaPerfil.Any(p => p.Descricao == perfil);            
        }
    }
}