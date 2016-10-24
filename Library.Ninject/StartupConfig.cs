using System.Web.Http;

namespace Library.Ninject
{
    public class StartupConfig
    {
        private static HttpConfiguration _config;

        public static HttpConfiguration Config => _config ?? (_config = new HttpConfiguration());
    }
}
