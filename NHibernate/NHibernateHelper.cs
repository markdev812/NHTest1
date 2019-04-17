using System;
using NHibernate;
using NHibernate.Cache;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace NHTest
{
    public class NHibernateHelper
    {
        private static readonly ISessionFactory _sessionFactory;
        static NHibernateHelper()
        {
            _sessionFactory = FluentConfigure();
        }
        public static ISession GetCurrentSession()
        {
            return _sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            _sessionFactory.Close();
        }
        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }
        private static ISessionFactory FluentConfigure()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("db")))
                .Cache(c => c.UseQueryCache()
                    .UseSecondLevelCache()
                    .ProviderClass<HashtableCacheProvider>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
              .BuildSessionFactory();
        }
    }
}
