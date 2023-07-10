using System.Collections.Generic;
using Domain.Identity;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<ShopApplicationUser> GetAll();
        ShopApplicationUser Get(string id);
        void Insert(ShopApplicationUser entity);
        void Update(ShopApplicationUser entity);
        void Delete(ShopApplicationUser entity);
    }
}