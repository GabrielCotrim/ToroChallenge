using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Infrastructure.Data.Interfaces;

namespace ToroChallenge.Infrastructure.Data
{
    public class DbSeed : IDbSeed
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbSeed(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }
        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    if (!context.Usuarios.Any())
                    {
                        var usuarioMock = new Usuario
                        {
                            Apelido = "Usuário Mock"
                        };
                        context.Usuarios.Add(usuarioMock);
                    }

                    if (!context.Ativos.Any())
                    {
                        var ativos = new List<Ativo>
                        {
                            new Ativo{ Symbol = "PETR4", CurrentPrice = 28.44 },
                            new Ativo{ Symbol = "MGLU3", CurrentPrice = 25.91 },
                            new Ativo{ Symbol = "VVAR3", CurrentPrice = 25.91 },
                            new Ativo{ Symbol = "SANB11", CurrentPrice = 40.77 },
                            new Ativo{ Symbol = "TORO4", CurrentPrice = 115.98 },
                            new Ativo{ Symbol = "OIBR3", CurrentPrice = 0.90 }
                        };
                        context.Ativos.AddRange(ativos);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
