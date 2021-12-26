using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace PeakyBarbers.Data.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }

    /// <summary>
    /// All entities must have an entity builder configuration implemented.
    /// </summary>
    public abstract class EntityBase<TEntity> : EntityBase, IEntityTypeConfiguration<TEntity> where TEntity : class
    {

        public virtual void Configure(EntityTypeBuilder<TEntity> builder) { }
    }

}
