using AutoMapper;
using SimpleUserRegistration.Business.DTO;
using SimpleUserRegistration.Data.DataEntities;

namespace SimpleUserRegistration.Business.AutoMapper
{
    public static class AutoMapper
    {
        public static void Initialise()
        {
            CreateMapForModelsToDTO();
        }

        private static void CreateMapForModelsToDTO()
        {
            Mapper.CreateMap<User, UserEntity>();
            Mapper.CreateMap<UserEntity, User>();
        }
    }
}
