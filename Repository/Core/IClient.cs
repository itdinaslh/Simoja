using Simoja.Entity;

namespace Simoja.Repository;

public interface IClient {
    IQueryable<Client> Clients { get; }
}