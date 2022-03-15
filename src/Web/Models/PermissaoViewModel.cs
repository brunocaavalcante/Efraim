using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class PermissaoViewModel : EntityViewModel
    {
        public string IdUser { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Perfil { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Funcionalidade { get; set; }
       
        [DisplayName("Permissões")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Permissoes { get; set; }
    }
}
