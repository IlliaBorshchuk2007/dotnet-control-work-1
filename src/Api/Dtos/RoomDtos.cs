using Domain.Rooms;

namespace Api.Dtos;

public sealed record RoomDto(Guid Id, string Number, int Floor, decimal PricePerNight,
    RoomType Type, bool IsAvailable, DateTime CreatedAt)
{
    public static RoomDto FromDomainModel(Room room) => new(room.Id.Value, room.Number,
        room.Floor, room.PricePerNight, room.Type, room.IsAvailable, room.CreatedAt);
}

public sealed record CreateRoomDto(string Number, int Floor, decimal PricePerNight,
    RoomType Type, bool IsAvailable);

public sealed record UpdateRoomDto(string Number, int Floor, decimal PricePerNight,
    RoomType Type, bool IsAvailable);
