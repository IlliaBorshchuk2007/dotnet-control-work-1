using Application.Rooms.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Errors;

public static class RoomErrorFactory
{
    public static ObjectResult ToObjectResult(this RoomException error) => new(error.Message)
    {
        StatusCode = error switch
        {
            RoomAlreadyExistsException => StatusCodes.Status409Conflict,
            RoomNotFoundException => StatusCodes.Status404NotFound,
            RoomUnhandledException => StatusCodes.Status500InternalServerError,
            _ => throw new NotImplementedException("Room error handler is not implemented.")
        }
    };
}
