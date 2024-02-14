using AutoMapper;
using ExerciceJwtApiPizza.Dtos;
using ExerciceJwtApiPizza.Models;

namespace ExerciceJwtApiPizza.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Ingredient, IngredientDTO>().ReverseMap();

            CreateMap<Pizza, PizzaDTO>().ReverseMap();

        }
    }
}
