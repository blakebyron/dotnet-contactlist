using System;
using Contacts.Domain.Aggregates.ContactAggregate;

namespace Contacts.Infrastructure.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public ContactRepository()
        {
        }

        public Contact Create(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact Get(Guid ID)
        {
            throw new NotImplementedException();
        }
    }
}
