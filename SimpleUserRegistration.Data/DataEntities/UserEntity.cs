
namespace SimpleUserRegistration.Data.DataEntities
{
    public class UserEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string Postcode { get; set; }       
    }
}
