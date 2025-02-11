using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Infrastructure.Persistence;

public class BaseDbContext(DbContextOptions<BaseDbContext> options) : DbContext(options)
{
  public DbSet<User> Users { get; set; }
  public DbSet<Tag> Tags { get; set; }
  public DbSet<NewsTag> NewsTags { get; set; }
  public DbSet<News> News { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>(entity =>
    {
      entity.ToTable("Usuario");
      entity.HasKey(u => u.Id);
      entity.Property(u => u.Name).HasColumnName("Nome").HasMaxLength(250).IsRequired();
      entity.Property(u => u.Pass).HasColumnName("Senha").HasMaxLength(50).IsRequired();
      entity.Property(u => u.Email).HasColumnName("Email").HasMaxLength(250).IsRequired();
    });

    modelBuilder.Entity<News>(entity =>
    {
      entity.ToTable("Noticia");
      entity.HasKey(n => n.Id);
      entity.Property(n => n.Title).HasColumnName("Titulo").HasMaxLength(250).IsRequired();
      entity.Property(n => n.Content).HasColumnName("Texto").HasColumnType("TEXT").IsRequired();
      entity.HasOne(n => n.User).WithMany(u => u.News).HasForeignKey(n => n.UserId).OnDelete(DeleteBehavior.Cascade);

      entity.Property(n => n.UserId).HasColumnName("UsuarioId");
    });

    modelBuilder.Entity<Tag>(entity =>
    {
      entity.ToTable("Tags");
      entity.HasKey(t => t.Id);
      entity.Property(t => t.Description).HasColumnName("Descricao").HasMaxLength(100).IsRequired();
    });

    modelBuilder.Entity<NewsTag>(entity =>
    {
      entity.ToTable("NoticiaTag");
      entity.HasKey(nt => nt.Id);
      entity.HasOne(nt => nt.News).WithMany(n => n.NewsTags).HasForeignKey(nt => nt.NewsId).OnDelete(DeleteBehavior.Cascade);
      entity.HasOne(nt => nt.Tag).WithMany(t => t.NewsTags).HasForeignKey(nt => nt.TagId).OnDelete(DeleteBehavior.Cascade);

      entity.Property(nt => nt.NewsId).HasColumnName("NoticiaId");
      entity.Property(nt => nt.TagId).HasColumnName("TagId");
    });

    base.OnModelCreating(modelBuilder);
  }
}