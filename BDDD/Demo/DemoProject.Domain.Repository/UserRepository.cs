using BDDD.Repository;
using BDDD.Repository.NHibernate;
using DemoProject.Domain.Model;
using DemoProject.Domain.Repositories;

namespace DemoProject.Domain.Repository
{
    public class UserRepository : NHibernateRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context)
        {
        }

        public bool UserNameExists(string userName)
        {
            return Exists(user => user.UserName == userName);
        }

        public bool EmailExists(string email)
        {
            return Exists(user => user.Email == email);
        }

        public bool CheckPassword(string userName, string password)
        {
            return Exists(user => user.UserName == userName && user.Password == password);
        }

        public User GetUserByName(string userName)
        {
            return GetSignal(user => user.UserName == userName);
        }

        public User GetUserByEmail(string email)
        {
            return GetSignal(user => user.Email == email);
        }
    }
}
