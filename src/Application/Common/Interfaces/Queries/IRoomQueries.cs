using Domain.Rooms;
using LanguageExt;

namespace Application.Common.Interfaces.Queries;

public interface IRoomQueries
{
    Task<IReadOnlyList<Room>> GetAll(CancellationToken cancellationToken);
    Task<Option<Room>> GetById(RoomId id, CancellationToken cancellationToken);
}
