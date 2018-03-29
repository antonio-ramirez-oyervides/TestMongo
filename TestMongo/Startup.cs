using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestMongo.Startup))]
namespace TestMongo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         
        }
    }
}
