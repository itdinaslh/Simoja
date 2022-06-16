using Simoja.Entity;

namespace Simoja.Repository;

public interface IClient {
    IQueryable<Client> Clients { get; }

    IQueryable<DetailAngkut> DetailAngkuts { get; }

    Task SaveClientAsync(Client client);
}