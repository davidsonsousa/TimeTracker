using System;
using System.Diagnostics.CodeAnalysis;

namespace TimeTracker.SharedKernel
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            if (object.Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", nameof(id));
            }

            Id = id;
        }

        // EF requires an empty constructor
        protected Entity()
        {

        }

        public override bool Equals(object otherObject)
        {
            var entity = otherObject as Entity<TId>;
            return entity != null
                   ? Equals(entity)
                   : base.Equals(otherObject);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals([AllowNull] Entity<TId> other)
        {
            return other == null
                   ? false
                   : Id.Equals(other.Id);
        }
    }
}
