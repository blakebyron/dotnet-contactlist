using System;
using Contacts.Domain.Aggregates.ContactAggregate;
using Contacts.Infrastructure.Data.EntityConfiguration;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure.Data
{
    public class ContactContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        private readonly IMediator _mediator;

        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public ContactContext(DbContextOptions<ContactContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ContactEntityTypeConfig("Contacts"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
