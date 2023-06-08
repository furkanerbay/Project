using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfEntityColorRepository>().As<IColorRepository>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();

            builder.RegisterType<EfEntityCategoryRepository>().As<ICategoryRepository>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();

            builder.RegisterType<EfEntityProvinceRepository>().As<IProvinceRepository>().SingleInstance();
            builder.RegisterType<ProvinceManager>().As<IProvinceService>().SingleInstance();

            builder.RegisterType<EfEntityStoreRepository>().As<IStoreRepository>().SingleInstance();
            builder.RegisterType<StoreManager>().As<IStoreService>().SingleInstance();

            builder.RegisterType<EfEntityBookRepository>().As<IBookRepository>().SingleInstance();
            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //Calisan uygulama icerisinde

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() //Implemente edilmiş interfaceleri bul.
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector() //AspectInterceptorSelector'ı çağır
                }).SingleInstance();
        }
    }
}
