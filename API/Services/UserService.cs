using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API.Models;
using API.Models.DTO;
using API.Services.Context;

namespace API.Services
{
    public class UserService
    {
        private readonly DataContext _context; 

        public UserService(DataContext context)
        {
            _context = context;
        }


        // helper functions to help us check if the user exist
        // DoesUserExist
        public bool DoesUserExist(string username)
        {
            // check our tables to see if the user name exist

         return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
          
            // if one item matches our condition, that item will be returned
            // if no item matches, it'll return null
            // if multiple items match, it will return error
        }



        // adding user logic

        public bool AddUser(CreateAccountDTO userToAdd)
        {
            bool result = false;
        //    if the user already exist
        if(!DoesUserExist(userToAdd.Username))
        {
            UserModel User = new UserModel();

            UserModel newUser = new UserModel();

            var newHashedPassword = HashPassword(userToAdd.Password);

            newUser.Id = userToAdd.Id;
            newUser.Username = userToAdd.Username;
            newUser.Salt = newHashedPassword.Salt;
            newUser.Hash = newHashedPassword.Hash;

            _context.Add(newUser);

            result = _context.SaveChanges() != 0;



        }
        // if the do not exist we add an account
            return result;
        // else throw a false
        }

        public PasswordDTO HashPassword(string password)
        {
            // create a password DTO this is what will return
            PasswordDTO newHashedPassword = new PasswordDTO();
            // New instance or byte 64 array and save it to Saltbytes
            byte[] SaltBytes = new byte[64];
            // RNGCryptoServiceProvider creates random number
            var provider = new RNGCryptoServiceProvider();
            // now here we are going to get rid of the zeroes
            provider.GetNonZeroBytes(SaltBytes);
            // create a variable for our Salt. this will take our 64 string and encrypt it for us
            var Salt = Convert.ToBase64String(SaltBytes);
            // Now lets create our Hash. first arg is password, bytes, iterations
            var Rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);
            var Hash = Convert.ToBase64String(Rfc2898DeriveBytes.GetBytes(256));


            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
            
        }

        // function to verify user password
        public bool VerifyUserPassword(string? Password, string?StoredHash, string?StoredSalt)
        {
            var SaltBytes = Convert.FromBase64String(StoredSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return newHash == StoredHash;
        }


    }
}