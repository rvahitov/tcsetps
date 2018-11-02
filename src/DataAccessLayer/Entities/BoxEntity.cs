using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Correct.Storage.DataAccessLayer.Entities
{
    public class BoxEntity
    {
        public int Id { get; set; }
        public string AggregateId { get; set; }
        public string Barcode { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }

    internal class BoxEntityConfiguration : IEntityTypeConfiguration<BoxEntity>
    {
        public void Configure(EntityTypeBuilder<BoxEntity> builder)
        {
            builder.ToTable("Box");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Modified).IsConcurrencyToken();
        }
    }
}