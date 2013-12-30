using System;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Engine;
using NHibernate.Mapping.ByCode;


using BadCompositeMapping.DomainMapping;


namespace BadCompositeMapping.SessionMapper
{
    public static class Mapper
    {
        static NHibernate.ISessionFactory _sessionFactory = Mapper.GetSessionFactory();


        public static NHibernate.ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        static NHibernate.ISessionFactory GetSessionFactory()
        {
            var mapper = new NHibernate.Mapping.ByCode.ModelMapper();

            mapper.AddMappings(
                new[] { 
                    typeof(ProductMapping)
                    , typeof(CategoryMapping)
                    , typeof(ProductCategoryMapping)
                    , typeof(ModelMapping)
                });


            var cfg = new NHibernate.Cfg.Configuration();

            cfg.DataBaseIntegration(c =>
            {
                c.Driver<NHibernate.Driver.Sql2008ClientDriver>();
                c.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                c.ConnectionString = "Server=localhost;Database=zTestComposite;Trusted_Connection=True;";

                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });



            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            cfg.AddMapping(domainMapping);



            _sessionFactory = cfg.BuildSessionFactory();

            return _sessionFactory;
        }
    }
}