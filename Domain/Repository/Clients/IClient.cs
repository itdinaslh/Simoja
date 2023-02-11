using Simoja.Entity;

namespace Simoja.Repository;

public interface IClient {
    IQueryable<Client> Clients { get; }

    Task VerifyClient(Guid id, bool status);

    IQueryable<IzinAngkut> IzinAngkuts { get; }

    IQueryable<IzinOlah> IzinOlahs { get; }

    IQueryable<IzinlKawasan> IzinKawasans { get; }

    Task SaveClientAsync(Client client);

    Task SaveIzinAngkut(IzinAngkut detail);

    Task SaveIzinOlah(IzinOlah olah);
}