using Domain.Rooms;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class RoomsConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(room => room.Id);
        builder.Property(room => room.Id)
            .HasConversion(id => id.Value, value => new RoomId(value))
            .HasColumnType("uuid")
            .IsRequired();
        builder.Property(room => room.Number).HasColumnType("varchar(20)").IsRequired();
        builder.HasIndex(room => room.Number).IsUnique();
        builder.Property(room => room.Floor).HasColumnType("integer").IsRequired();
        builder.Property(room => room.PricePerNight).HasColumnType("numeric(10,2)").IsRequired();
        builder.Property(room => room.Type).HasConversion<string>().HasColumnType("varchar(30)").IsRequired();
        builder.Property(room => room.IsAvailable).HasColumnType("boolean").IsRequired();
        builder.Property(room => room.CreatedAt)
            .HasConversion(new DateTimeUtcConverter())
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
    }
}
