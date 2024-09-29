namespace OokamiJJ.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase(Guid? id)
        {
            Id = id;
        }

        public Guid? Id { get; set; }
    }
}
