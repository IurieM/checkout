using Basket.Api.Commands;
using Basket.Api.Infrastructure;
using FluentValidation;

namespace Identity.Api.Validators
{
    public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
    {
        public AddBasketItemCommandValidator()
        {
            RuleFor(command => command.Item.Units).GreaterThan(0).WithErrorCode(Constants.ErrorCodes.BasketItems.InvalidUnits);
        }
    }
}
