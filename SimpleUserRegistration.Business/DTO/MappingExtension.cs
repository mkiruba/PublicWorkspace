using AutoMapper;
using SimpleUserRegistration.Data.DataEntities;

namespace SimpleUserRegistration.Business.DTO
{
    public static class MappingExtension
    {
        public static User ToDTO(this UserEntity entity)
        {
            return Mapper.Map<UserEntity, User>(entity);        
        }

        public static UserEntity ToEntity(this User data)
        {
            return Mapper.Map<User, UserEntity>(data);
        }
    }
}
