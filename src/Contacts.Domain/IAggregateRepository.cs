using System;
namespace Contacts.Domain
{
    public interface IAggregateRepository<T> where T : IAggregateRoot
    {
    }
}
