using Application.Common.Interfaces.Repositories;
using Application.Rooms.Exceptions;
using Domain.Rooms;
using LanguageExt;
using MediatR;

namespace Application.Rooms.Commands;

public sealed record CreateRoomCommand(string Number, int Floor, decimal PricePerNight,
    RoomType Type, bool IsAvailable) : IRequest<Either<RoomException, Room>>;

public sealed class CreateRoomCommandHandler(IRoomRepository repository)
    : IRequestHandler<CreateRoomCommand, Either<RoomException, Room>>
{
    public async Task<Either<RoomException, Room>> Handle(CreateRoomCommand request,
        CancellationToken cancellationToken)
    {
        var existing = await repository.GetByNumber(request.Number, cancellationToken);
        return await existing.Match(
            room => Task.FromResult<Either<RoomException, Room>>(
                new RoomAlreadyExistsException(room.Id, request.Number)),
            async () =>
            {
                var room = Room.New(RoomId.New(), request.Number, request.Floor,
                    request.PricePerNight, request.Type, request.IsAvailable);
                try { return await repository.Add(room, cancellationToken); }
                catch (Exception exception) { return new RoomUnhandledException(room.Id, exception); }
            });
    }
}
