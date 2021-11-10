using System.Data.Entity.ModelConfiguration;
using Synopsis.Domain.Entities;

namespace Synopsis.Infrastructure.Data.Configurations
{
    internal class UserProfileConfiguration : ConfigurationBase<UserProfile>
    {
        public override string TableName => "UserProfiles";

        public override void Configure(EntityTypeConfiguration<UserProfile> builder)
        {
            base.Configure(builder);
        }
    }
}
