using EclipseWorks.Core.Models;
using EclipseWorks.Helper;

namespace EclipseWorks.Test.MockData
{
    public class UserMockData
    {
        public static List<UserModel> GetUsers()
        {
            var password = PasswordHasher.GenerateSalt();
            var hashPassword = PasswordHasher.HashPassword("12345678", password);

            return [
                 new UserModel
                {
                    Name = "Ivan Liebana",
                    Email = "ivan@mail.com",
                    Password = password,
                    Hash = hashPassword,
                    RegistrationDate = DateTime.Now,
                    IsManager = true,
                    Active = true
                },
                new UserModel
                {
                    Name = "Aline Paula",
                    Email = "aline@mail.com",
                    Password = password,
                    Hash = hashPassword,
                    RegistrationDate = DateTime.Now,
                    IsManager = false,
                    Active = true
                },
                new UserModel
                {
                    Name = "Maria Laura",
                    Email = "marialaura@mail.com",
                    Password = password,
                    Hash = hashPassword,
                    RegistrationDate = DateTime.Now,
                    IsManager = false,
                    Active = true
                },
                 new UserModel
                {
                    Name = "Henry",
                    Email = "henry@mail.com",
                    Password = password,
                    Hash = hashPassword,
                    RegistrationDate = DateTime.Now,
                    IsManager = false,
                    Active = true
                }
             ];
        }

        public static List<UserModel> GetEmptyUsers()
        {
            return [];
        }
    }
}
