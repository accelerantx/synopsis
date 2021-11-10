namespace Synopsis.Domain.Common
{
    public interface IEntity
    {
        long Id { get; }
        bool? IsDeleted { get; }
    }
}
