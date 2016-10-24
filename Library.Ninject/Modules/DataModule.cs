using AutoMapper;
using Library.Data;
using Library.Data.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Library.Ninject.Modules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            var mapperConfig = new AutoMapperConfiguration().SetupMappings();
            var mapper = mapperConfig.CreateMapper();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();

            Bind<LibraryDbContext>().ToSelf().InRequestScope();
            Bind<IBookRepository>().To<BookRepository>().InRequestScope();
        }
    }
}
