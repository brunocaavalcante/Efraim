using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class PermissaoViewModel : EntityViewModel
    {
        public string IdUser { get; set; }

        [Required]
        public string Perfil { get; set; }

        [Required]
        public string Funcionalidade { get; set; }

        [Required]
        [DisplayName("Permissões")]
        public string Permissoes { get; set; }
    }
}
