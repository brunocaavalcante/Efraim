using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Models
{
    public class UsuarioPerfilViewModel
    {
        public UsuarioViewModel Usuario { get; set; }
        public List<UsuarioViewModel> Usuarios { get; set; }
        public List<PerfilViewModel> ListaPerfil { get; set; }
        
        public string PossuiPerfil(UsuarioViewModel usuario, string perfil)
        {
            if(usuario.ListaPerfil == null) return "";
            return usuario.ListaPerfil.Any(x => x.Descricao == perfil) ? "checked" : "";
        }
    }
}
