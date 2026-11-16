using Domain.Rooms;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories;

public interface IRoomRepository
{
    Task<Option<Room>> GetById(RoomId id, CancellationToken cancellationToken);
    Task<Option<Room>> GetByNumber(string number, CancellationToken cancellationToken);
    Task<Room> Add(Room room, CancellationToken cancellationToken);
    Task<Room> Update(Room room, CancellationToken cancellationToken);
}
