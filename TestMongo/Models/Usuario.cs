using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TestMongo.Models
{
    [BsonIgnoreExtraElements]
    public class Usuario
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string company_name { get; set; }
        public string oClass{ get;set;}
        public int age { get; set; }
        public List<string> knowledge_base { get; set; }
    }
}