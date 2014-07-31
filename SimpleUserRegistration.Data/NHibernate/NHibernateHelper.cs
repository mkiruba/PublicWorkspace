using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using SimpleUserRegistration.Data.DataEntities;
using SimpleUserRegistration.Data.NHibernate.Maps;
using System;
using System.IO;
using System.Reflection;

namespace SimpleUserRegistration.Data.NHibernate
{
    public class NHibernateHelper
    {        
        private static string _connectionString = @"Data Source=|DataDirectory|\UsersDB.sdf;Persist Security Info=False;";
        private static ISessionFactory _sessionFactory;
        private readonly Assembly _resourceAssembly;

        public NHibernateHelper(string connectionString, Assembly resourceAssembly)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("connectionString");
            }
            _connectionString = connectionString;

            if (resourceAssembly == null)
            {
                throw new ArgumentNullException("resourceAssembly");
            }
            _resourceAssembly = resourceAssembly;
        }

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard
                .ShowSql()
                .ConnectionString(_connectionString))
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsersMap>());

            return configuration.BuildSessionFactory();         
        }

        
    }
}
