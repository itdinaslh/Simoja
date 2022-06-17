using Simoja.Entity;

namespace Simoja.Repository;

public interface IClient {
    IQueryable<Client> Clients { get; }

    IQueryable<DetailAngkut> DetailAngkuts { get; }

    IQueryable<DetailOlah> DetailOlahs { get; }

    IQueryable<DetailKawasan> DetailKawasans { get; }

    Task SaveClientAsync(Client client);
}