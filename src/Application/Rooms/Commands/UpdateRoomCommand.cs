using Application.Common.Interfaces.Repositories;
using Application.Rooms.Exceptions;
using Domain.Rooms;
using LanguageExt;
using MediatR;

namespace Application.Rooms.Commands;

public sealed record UpdateRoomCommand(Guid Id, string Number, int Floor, decimal PricePerNight,
    RoomType Type, bool IsAvailable) : IRequest<Either<RoomException, Room>>;

public sealed class UpdateRoomCommandHandler(IRoomRepository repository)
    : IRequestHandler<UpdateRoomCommand, Either<RoomException, Room>>
{
    public async Task<Either<RoomException, Room>> Handle(UpdateRoomCommand request,
        CancellationToken cancellationToken)
    {
        var id = new RoomId(request.Id);
        var found = await repository.GetById(id, cancellationToken);
        return await found.Match(
            async room =>
            {
                var duplicate = await repository.GetByNumber(request.Number, cancellationToken);
                return await duplicate.Match(
                    other => other.Id != room.Id
                        ? Task.FromResult<Either<RoomException, Room>>(
                            new RoomAlreadyExistsException(other.Id, request.Number))
                        : Save(room),
                    () => Save(room));

                async Task<Either<RoomException, Room>> Save(Room entity)
                {
                    entity.UpdateDetails(request.Number, request.Floor, request.PricePerNight,
                        request.Type, request.IsAvailable);
                    try { return await repository.Update(entity, cancellationToken); }
                    catch (Exception exception) { return new RoomUnhandledException(entity.Id, exception); }
                }
            },
            () => Task.FromResult<Either<RoomException, Room>>(new RoomNotFoundException(id)));
    }
}
