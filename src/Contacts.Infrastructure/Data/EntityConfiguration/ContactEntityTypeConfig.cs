using System;
using Contacts.Domain.Aggregates.ContactAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Infrastructure.Data.EntityConfiguration
{
    public class ContactEntityTypeConfig: IEntityTypeConfiguration<Contact>
    {
        private Int32 FullNameFieldLength = 200;

        private readonly string SchemaName;

        public ContactEntityTypeConfig(string schemaName)
        {
            this.SchemaName = schemaName;
        }

        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact", this.SchemaName);
            builder.HasKey(x => x.ID);
            builder.Property(b => b.FullName)
                .HasMaxLength(FullNameFieldLength)
                .IsRequired();
        }
    }
}
