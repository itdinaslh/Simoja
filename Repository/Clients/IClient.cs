using Simoja.Entity;

namespace Simoja.Repository;

public interface IClient {
    IQueryable<Client> Clients { get; }

    Task VerifyClient(int id, bool status);

    IQueryable<IzinAngkut> IzinAngkuts { get; }

    IQueryable<IzinOlah> IzinOlahs { get; }

    IQueryable<IzinlKawasan> IzinKawasans { get; }

    Task SaveClientAsync(Client client);

    Task SaveDetailAngkut(IzinAngkut detail);

    Task SaveDetailOlah(IzinOlah olah);
}