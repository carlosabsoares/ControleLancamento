using ControleLancamento.Api.Domain.Entities;
using ControleLancamento.Api.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleLancamento.Api.Infra.Mapping
{
    public static class MapLancamentoContext
    {
        public static void MapLancamento(this DataContext context, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LancamentoEntity>().ToTable("Lancamento");

            modelBuilder.Entity<LancamentoEntity>().HasKey(x => x.Id);
        }
    }
}