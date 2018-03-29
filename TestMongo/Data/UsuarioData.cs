using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using TestMongo.Models;

namespace TestMongo.Data
{
    public class UsuarioData: Common.Error
    {
        public void createUsuario(Usuario usuario)
        {
            try
            {
                var settings = new MongoClientSettings
                {
                    Server = new MongoServerAddress("localhost", 27017),
                    UseSsl = false
                };

                var client = new MongoClient(settings);
                IMongoDatabase db = client.GetDatabase("ABCTest");
                var collection = db.GetCollection<BsonDocument>("Usuario");

                var newUser = new BsonDocument
                {
                  {"name", usuario.name},
                  {"company_name", usuario.company_name},
                  {"knowledge_base", new BsonArray(usuario.knowledge_base)},
                  {"class", usuario.oClass},
                  {"age", usuario.age}
                };

                collection.InsertOneAsync(newUser);

            }
            catch(Exception ex)
            {
                this.hasError = true;
                this.errorNumber = ex.HResult.ToString();
                this.errorDescription = ex.Message;
            }


        }

        public List<Usuario> GetAllUsuario()
        {
            try {
                var client = new MongoClient();

                IMongoDatabase db = client.GetDatabase("ABCTest");

                var collection = db.GetCollection<Usuario>("Usuario");

                List<Usuario> usuarios = collection.Find(new BsonDocument()).ToList();

                return usuarios;

            }
            catch(Exception ex)
            {
                this.hasError = true;
                this.errorNumber = ex.HResult.ToString();
                this.errorDescription = ex.Message;
                return new List<Usuario>();
            }
           
        }

        public Usuario GetUsuario(Usuario filter) {

            try
            {
                var client = new MongoClient();

                IMongoDatabase db = client.GetDatabase("ABCTest");

                var collection = db.GetCollection<Usuario>("Usuario");

                Usuario usuario = collection.Find(new BsonDocument("name",filter.name)).First();

                return usuario;

            }
            catch (Exception ex)
            {
                this.hasError = true;
                this.errorNumber = ex.HResult.ToString();
                this.errorDescription = ex.Message;
                return new Usuario();
            }

        }

        public bool DeleteUsuario(Usuario usuario)
        {
            try {
                var client = new MongoClient();
                IMongoDatabase db = client.GetDatabase("ABCTest");
                var collection = db.GetCollection<Usuario>("Usuario");
                collection.DeleteOne(a => a.name == usuario.name);

                return true;
            }
            catch(Exception ex)
            {
                this.hasError = true;
                this.errorNumber = ex.HResult.ToString();
                this.errorDescription = ex.Message;
                return false;
            }
        }

    }
}