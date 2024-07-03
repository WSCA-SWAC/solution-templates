namespace WscaBaseSolution.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (Entity)obj;

            return Id == item.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
