using System;

namespace EmergingBooking.Infrastructure.Cqrs.Domain
{
    public class Entity
    {
        public Entity(Guid? identifier)
        {
            Identifier = identifier ?? Guid.NewGuid();
        }

        public Guid Identifier { get; }

        public override bool Equals(object entity)
        {
            if (!(entity is Entity entityToBeCompared))
                return false;

            if (ReferenceEquals(this, entityToBeCompared))
                return true;

            if (GetType() != entityToBeCompared.GetType())
                return false;

            return Identifier == entityToBeCompared.Identifier;
        }

        public static bool operator ==(Entity entityA, Entity entityB)
        {
            if (ReferenceEquals(entityA, null) && ReferenceEquals(entityB, null))
                return true;

            if (ReferenceEquals(entityA, null) || ReferenceEquals(entityB, null))
                return false;

            return entityA.Equals(entityB);
        }

        public static bool operator !=(Entity entityA, Entity entityB)
        {
            return !(entityA == entityB);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Identifier).GetHashCode();
        }
    }
}
