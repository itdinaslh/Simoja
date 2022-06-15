using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class ClientService : IClient {
    private AppDbContext context;

    public ClientService(AppDbContext ctx) => context = ctx;

    public IQueryable<Client> Clients => context.Clients;
}