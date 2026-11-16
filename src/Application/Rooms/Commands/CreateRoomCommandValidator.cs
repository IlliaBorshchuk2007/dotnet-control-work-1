using FluentValidation;

namespace Application.Rooms.Commands;

public sealed class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(x => x.Number).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Floor).InclusiveBetween(0, 200);
        RuleFor(x => x.PricePerNight).GreaterThan(0).LessThanOrEqualTo(1_000_000);
        RuleFor(x => x.Type).IsInEnum();
    }
}
