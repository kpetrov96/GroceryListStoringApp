using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryListStoringApp
{
    public class NHibernateHelper
    {
        private const string ConnectionString = "Server=127.0.0.1 ; Port=5432 ; User Id=postgres; Password=root; Database=GroceryListStoringDB;";
        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        private static ISessionFactory _sessionFactory = Fluently.Configure()
            .Database(PostgreSQLConfiguration.PostgreSQL82
            .ConnectionString(ConnectionString)
            .ShowSql())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg)
            .Create(false, false))
            .BuildSessionFactory();
    }
}
