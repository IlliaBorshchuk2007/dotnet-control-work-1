using Domain.Rooms;

namespace Application.Rooms.Exceptions;

public abstract class RoomException(RoomId id, string message, Exception? inner = null) : Exception(message, inner)
{
    public RoomId Id { get; } = id;
}

public sealed class RoomAlreadyExistsException(RoomId id, string number)
    : RoomException(id, $"Room with number '{number}' already exists.");

public sealed class RoomNotFoundException(RoomId id)
    : RoomException(id, $"Room not found under id {id}.");

public sealed class RoomUnhandledException(RoomId id, Exception inner)
    : RoomException(id, "Unexpected persistence error.", inner);
