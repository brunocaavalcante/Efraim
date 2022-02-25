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

        public static bool ExibirAcoesListaMembro(this RazorPage page, string action, string controller)
        {
            var actions = string.Empty;
            return true;

            if (controller.Contains("Membro")) actions = "Edit;Details;Delete";

            if (controller.Contains("Departamento") && action == "Membro") actions = "Details;RemoveMembro;";

            if (controller.Contains("Departamento") && action == "Lider") actions = "Details;RemoveLider;";

            bool permitir = actions.Contains(action);
            return permitir;
        }
    }
}