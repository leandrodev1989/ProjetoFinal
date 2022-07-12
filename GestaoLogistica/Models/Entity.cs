namespace GestaoLogistica.Models
{
    public abstract class Entity
    {
        protected Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
