using FluentNHibernate.Mapping;

namespace NHTest
{
    public class AppInstance
    {
        public virtual int Id { get; protected set; }
        public virtual string AppName { get; protected set; }
        public virtual string AppVersion { get; protected set; }
    }

    public class AppInstanceMap : ClassMap<AppInstance>
    {
        public AppInstanceMap()
        {
            Id(x => x.Id);
            Map(x => x.AppName);
            Map(x => x.AppVersion);
        }
    }
}
