using Sat.Recruitment.Api.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Repositories
{
    public class UserRepository
    {
        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        public async Task<IEnumerable<User>> LoadUsersAsync()
        {          
            var users = new List<User>();
            using (var readerUser = ReadUsersFromFile())
            {
                string line;
                while ((line = await readerUser.ReadLineAsync()) != null)
                {
                    var aUser = line.Split(',');
                    users.Add(new User() { Name = aUser[0], Email = aUser[1], Phone = aUser[2], Address = aUser[3], UserType = aUser[4], Money = decimal.Parse(aUser[5])});                  
                }
                readerUser.Close();
            }
            return users;
        }
    }
}
