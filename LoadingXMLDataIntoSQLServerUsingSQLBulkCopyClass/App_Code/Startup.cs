using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoadingXMLDataIntoSQLServerUsingSQLBulkCopyClass.Startup))]
namespace LoadingXMLDataIntoSQLServerUsingSQLBulkCopyClass
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
