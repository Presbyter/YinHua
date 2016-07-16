using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using YinHua.Data;

namespace YinHua.Services
{
    public class UserService : BaseService<User>
    {
        private YinHuaContext _db;
        public override int Create(params User[] entities)
        {
            int resultCount = 0;
            using (_db = new YinHuaContext())
            {
                SHA256 sha256 = SHA256.Create();

                foreach (var item in entities)
                {
                    byte[] source = System.Text.Encoding.UTF8.GetBytes(item.Password);
                    byte[] crypto = sha256.ComputeHash(source);
                    item.Password = Convert.ToBase64String(crypto);
                    item.CreateTime = DateTime.Now;
                    item.ModifyTime = DateTime.Now;
                    // _db.Entry(item).State = EntityState.Added;
                    _db.Set<User>().Add((User)item);
                }
                resultCount = _db.SaveChanges();
            }
            return resultCount;
        }

        public bool Login(string mobileNumber, string passWord)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] source = System.Text.Encoding.UTF8.GetBytes(passWord);
            byte[] crypto = sha256.ComputeHash(source);
            string password = Convert.ToBase64String(crypto);

            User user = null;

            using (_db = new YinHuaContext())
            {
                var dbQuery = _db.Set<User>().Where(m => m.MobileNumber == mobileNumber
                    && m.Password == password);
                user = dbQuery.FirstOrDefault();
            }

            return null != user;
        }
    }
}