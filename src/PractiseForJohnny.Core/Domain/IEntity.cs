namespace PractiseForJohnny.Core.Domain;

public interface IEntity
{
}

public interface IEntityTId<TId> : IEntity
{
    public TId Id { get; set; }
}