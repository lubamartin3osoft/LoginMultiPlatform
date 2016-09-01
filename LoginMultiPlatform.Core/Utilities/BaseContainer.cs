using System;
using LoginMultiPlatform.Core.Abstracts;
using LoginMultiPlatform.Core.Repository;
using SimpleInjector;
using SimpleInjector.Advanced;
using SQLite.Net.Async;

namespace LoginMultiPlatform.Core.Utilities
{
   public class BaseContainer
   {
      private static BaseContainer _instance;
      private readonly Container _container;

      public BaseContainer()
      {
         _container = new Container();
         _container.Options.AllowOverridingRegistrations = true;
      }

      public static BaseContainer Instance =>
         _instance ?? (_instance = new BaseContainer());

      public void InitializeDependencies(SQLiteAsyncConnection connection, Func<IApplicationSessionContext> appFunc)
      {
         if (!_container.IsLocked())
         {
            _container.Register(() => connection);
            _container.Register(typeof(IApplicationSessionContext), appFunc);
            _container.Register<IUserRepository, UserRepository>();
         }
      }

      public T GetInstance<T>() where T : class
      {
         T instance = _container.GetInstance<T>();
         return instance;
      }
   }
}
