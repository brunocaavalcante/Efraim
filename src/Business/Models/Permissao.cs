using Business.Core.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    [FirestoreData]
    public class Permissao : Entity
    {
        [FirestoreProperty]
        public string Perfil { get; set; }

        [FirestoreProperty]
        public string Funcionalidade { get; set; }

        [FirestoreProperty]
        public string Permissoes { get; set; }
    }
}
