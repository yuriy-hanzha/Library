using Library.Ninject.Core;
using Library.Ninject.Modules;

namespace Library.Server
{
    public static class NinjectConfig
    {
        public static void Start()
        {
            NinjectWebCommon.Start(new DataModule());
        }

        public static void Stop()
        {
            NinjectWebCommon.Stop();
        }
    }
}
