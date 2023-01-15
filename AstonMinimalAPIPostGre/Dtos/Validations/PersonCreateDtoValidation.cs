using FluentValidation;

namespace AstonMinimalAPIPostGre.Dtos.Validations
{
    public class PersonCreateDtoValidation : AbstractValidator<PersonDto>
    {

        public PersonCreateDtoValidation()
        {

            RuleFor(x => x.ItemId).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Homeworld).NotNull();
            RuleFor(x => x.FilmNameWithPerson).NotNull();
            RuleFor(x => x.vehicle).NotNull();
        }
    }
}