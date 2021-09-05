using System;
using Google.Cloud.Firestore;

namespace Business.Core.Models
{
    public abstract class Entity
    {
        [FirestoreProperty] 
        public string Id { get; set; }
    }
}