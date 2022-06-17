using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class ClientService : IClient {
    private AppDbContext context;

    public ClientService(AppDbContext ctx) => context = ctx;

    public IQueryable<Client> Clients => context.Clients;

    public IQueryable<DetailAngkut> DetailAngkuts => context.DetailAngkuts;

    public IQueryable<DetailOlah> DetailOlahs => context.DetailOlahs;

    public IQueryable<DetailKawasan> DetailKawasans => context.DetailKawasans;

    public async Task SaveClientAsync(Client client) {
        #nullable disable
        if (client.ClientId == 0) {            
            await context.AddAsync(client);
        } else {
            Client cli = await context.Clients.FindAsync(client.ClientId);
            cli.ClientName = client.ClientName;
            cli.Telp = client.Telp;
            cli.Fax = client.Fax;
            cli.KelurahanID = client.KelurahanID;
            cli.Alamat = client.Alamat;
            cli.Latitude = client.Latitude;
            cli.Longitude = client.Longitude;
            cli.PenanggungJawab = client.PenanggungJawab;
            cli.PIC = client.PIC;
            cli.NoHpPIC = client.NoHpPIC;
            cli.UpdatedAt = DateTime.Now;

            context.Update(cli);
        }

        await context.SaveChangesAsync();
    }
}