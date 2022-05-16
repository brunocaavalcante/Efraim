using Business.Core.Models;
using Google.Cloud.Firestore;

namespace Business.Models
{
    [FirestoreData]
    public class Perfil : Entity
    {
        [FirestoreProperty]
        public string Descricao { get; set; }

        [FirestoreProperty]
        public string Funcionalidade { get; set; }

        [FirestoreProperty]
        public string Permissoes { get; set; }
    }

}
