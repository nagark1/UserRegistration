using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/*
 * 
 * 
 * YOU MAY NOT CHANGE THIS FILE
 * 
 * 
 */ 
namespace UserDataAccessLayer
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public bool HasCreditLimit { get; set; }
        public int CreditLimit { get; set; }
    }

    public static class UserDataAccess
    {
        private const string DATA_FILE_TEMPLATE = "daily_new_users_{0}.json";

        public static void AddUser(UserDto user)
        {
            string dataFile = string.Format(DATA_FILE_TEMPLATE, DateTime.Now.ToString("yyyyMMdd"));
            if (!File.Exists(dataFile))
            {
                using var file = File.Create(dataFile);

                file.Write(Encoding.UTF8.GetBytes("[]"));
                file.Close();
            }

            string fileContents = File.ReadAllText(dataFile);

            var data = JsonConvert.DeserializeObject<List<UserDto>>(fileContents);

            data.Add(user);

            using var writer = File.OpenWrite(dataFile);
            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

            writer.Write(bytes, 0, bytes.Length);
        }
    }
}
