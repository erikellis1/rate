using Ellis.Rate.Data.Models;
using Ellis.Rate.ViewModels;

namespace Ellis.Rate.Mappers
{
    public class RatedItemMapper
    {
        public static RatedItemViewModel ToViewModel(RatedItem entity)
        {
            return new RatedItemViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Rating = entity.Rating
            };
        }

        public static RatedItem FromViewModel(RatedItemBaseViewModel vm)
        {
            var entity = new RatedItem();
            FromViewModel(vm, entity);
            return entity;
        }

        public static void FromViewModel(RatedItemBaseViewModel vm, RatedItem entity)
        {
            entity.Name = vm.Name;
            entity.Rating = vm.Rating;
        }
    }
}