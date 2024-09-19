using API.Models;

namespace API.Mocks
{
    public class UserStorage
    {
        private static UserStorage instance;
        private List<User> users;

        private UserStorage() 
        {
            users = new List<User> { new User { Id = 1,Name="Майкл Джексон",Email="moonwalk@gmail.com",Password="MJ_moonWalker007"},
                                     new User { Id = 2,Name="",Email="",Password="" },
                                     new User { Id = 3,Name="",Email="",Password="" },
                                     new User { Id = 4,Name="",Email="",Password="" },
                                     new User { Id = 5,Name="",Email="",Password="" }};
        }

        public static UserStorage GetInstance()
        {
            if (instance == null)
                instance = new UserStorage();
            return instance;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }
        public User GetUserById(int id)
        {
            return users.First(user => user.Id == id);
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
        public void DeleteUser(int id)
        {
            users.Remove(users.First(user=>user.Id == id));
        }

    }
}
