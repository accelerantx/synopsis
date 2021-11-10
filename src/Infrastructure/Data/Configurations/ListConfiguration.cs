using System.Data.Entity.ModelConfiguration;
using Synopsis.Domain.Entities;

namespace Synopsis.Infrastructure.Data.Configurations
{
    internal class ListConfiguration : ConfigurationBase<List>
    {
        public override string TableName => "Lists";

        public override void Configure(EntityTypeConfiguration<List> builder)
        {
            base.Configure(builder);
        }
    }
}
