using WebApp.Model;

namespace WebApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext db;

        public UserRepository(AppDBContext db)
        {
            this.db = db;
        }

        public User Create(User user)
        {
            db.Users.Add(user);
            user.Id = db.SaveChanges();
            return user;
        }

        public User GetByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(long id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
