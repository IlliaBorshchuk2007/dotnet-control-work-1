namespace Domain.Rooms;

public sealed class Room
{
    public RoomId Id { get; private set; } = RoomId.Empty();
    public string Number { get; private set; } = string.Empty;
    public int Floor { get; private set; }
    public decimal PricePerNight { get; private set; }
    public RoomType Type { get; private set; }
    public bool IsAvailable { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Room() { }

    private Room(RoomId id, string number, int floor, decimal pricePerNight,
        RoomType type, bool isAvailable, DateTime createdAt)
    {
        Id = id;
        Number = number;
        Floor = floor;
        PricePerNight = pricePerNight;
        Type = type;
        IsAvailable = isAvailable;
        CreatedAt = createdAt;
    }

    public static Room New(RoomId id, string number, int floor, decimal pricePerNight,
        RoomType type, bool isAvailable) =>
        new(id, number, floor, pricePerNight, type, isAvailable, DateTime.UtcNow);

    public void UpdateDetails(string number, int floor, decimal pricePerNight,
        RoomType type, bool isAvailable)
    {
        Number = number;
        Floor = floor;
        PricePerNight = pricePerNight;
        Type = type;
        IsAvailable = isAvailable;
    }
}
