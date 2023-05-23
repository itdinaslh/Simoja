using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Models;
using Simoja.Repository;

namespace Simoja.Services;

public class ClientService : IClient {
    private AppDbContext context;

    public ClientService(AppDbContext ctx) => context = ctx;

    public IQueryable<Client> Clients => context.Clients;

    public IQueryable<IzinAngkut> IzinAngkuts => context.IzinAngkuts;

    public IQueryable<IzinOlah> IzinOlahs => context.IzinOlahs;

    public IQueryable<IzinUsaha> IzinUsahas => context.IzinUsahas;

    public async Task SaveClientAsync(RegisterVM model) {
        #nullable disable
        
        await context.AddAsync(model.Client);

        await context.SaveChangesAsync();
    }

    public async Task UpdateClientAsync(Client client)
    {
        Client cli = await context.Clients.FindAsync(client.ClientID);
        cli.ClientName = client.ClientName;
        cli.Telp = client.Telp;
        cli.Fax = client.Fax;
        cli.KelurahanID = client.KelurahanID;
        cli.Alamat = client.Alamat;
        cli.Latitude = client.Latitude;
        cli.Longitude = client.Longitude;
        cli.PenanggungJawab = client.PenanggungJawab;
        cli.IsVerified = client.IsVerified;
        cli.PIC = client.PIC;
        cli.NoHpPIC = client.NoHpPIC;
        cli.NIB = client.NIB;
        cli.UpdatedAt = DateTime.Now;

        context.Update(cli);

        await context.SaveChangesAsync();
    }

    public async Task VerifyClient(Guid id, bool status)
    {
        Client client = await context.Clients.FindAsync(id);

        if (client is not null)
        {
            client.IsVerified = status;

            context.Update(client);

            await context.SaveChangesAsync();
        }       
    }

    public async Task SaveIzinAngkut(IzinAngkut detail) {
        if (detail.IzinAngkutID == Guid.Empty) {
            await context.AddAsync(detail);
        } else {
            IzinAngkut data = await context.IzinAngkuts.FindAsync(detail.IzinAngkutID);

            if (data is not null) {
                data.JmlAngkutan = detail.JmlAngkutan;
                data.NoIzinUsaha = detail.NoIzinUsaha;
                data.TglTerbitIzin = detail.TglTerbitIzin;
                data.TglAkhirIzin = detail.TglAkhirIzin;                

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }

    public async Task SaveIzinOlah(IzinOlah detail) {
        if (detail.IzinOlahID == Guid.Empty) {
            await context.AddAsync(detail);
        } else {
            IzinAngkut data = await context.IzinAngkuts.FindAsync(detail.IzinOlahID);

            if (data is not null) {                
                data.NoIzinUsaha = detail.NoIzinUsaha;
                data.TglTerbitIzin = detail.TglTerbitIzin;
                data.TglAkhirIzin = detail.TglAkhirIzin;                

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }

    public async Task VerifikasiClient(Client client)
    {
#nullable enable
        Client? data = await context.Clients.FindAsync(client.ClientID);

        if (data is not null)
        {
            data.IsVerified = true;

            context.Update(data);

            await context.SaveChangesAsync();
        }
    }
}