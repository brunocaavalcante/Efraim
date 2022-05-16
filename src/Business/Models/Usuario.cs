using Business.Core.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace Business.Models
{
    [FirestoreData]
    public class Usuario : Entity
    {
        [FirestoreProperty]
        public string CPF { get; set; }

        [FirestoreProperty("nome")]
        public string Nome { get; set; }

        [FirestoreProperty("dataNascimento")]
        public DateTime DataNascimento { get; set; }

        [FirestoreProperty("telefone")]
        public string Telefone { get; set; }

        [FirestoreProperty("email")]
        public string Email { get; set; }

        public List<Perfil> ListaPerfil { get; set; }
    }
}