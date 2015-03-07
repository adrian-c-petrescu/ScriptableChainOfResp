using Autofac.Core;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiImplementation.Services;

namespace DiImplementation.Utils
{
    public class IoC
    {
        private static IContainer _container;

        static IoC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LocalDataGetter>().As<ILocalDataGetter>().InstancePerDependency();
            builder.RegisterType<RemoteDataGetter>().As<IRemoteDataGetter>().InstancePerDependency();
            builder.RegisterType<DataMergeService>().As<IDataMergeService>().InstancePerDependency();

            _container = builder.Build();
        }


        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public static object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
