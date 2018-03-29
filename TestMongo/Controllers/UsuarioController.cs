using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestMongo.Data;
using TestMongo.Models;

namespace TestMongo.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET api/<controller>
        public List<Usuario> Get()
        {
            UsuarioData uData = new UsuarioData();
            List<Usuario> usuarios = uData.GetAllUsuario();
            return usuarios;
        }

        // GET api/<controller>/5
        public Usuario Get(string name)
        {
            UsuarioData uData = new UsuarioData();
            Usuario usuario = uData.GetUsuario(new Usuario { name = name });
            return usuario;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            UsuarioData uData = new UsuarioData();
            uData.createUsuario(new Models.Usuario { name = "Usuario Test", age = 20, company_name = "Microsoft", oClass = "Esp", knowledge_base = new List<string> { "Python", "AngularJs" } });
            if (uData.hasError)
            {
                string errordesc = uData.errorDescription;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public bool Delete(string name)
        {
            UsuarioData uData = new UsuarioData();
            return uData.DeleteUsuario(new Usuario { name = name });
        }
    }
}