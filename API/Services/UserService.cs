using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
            // if one item matches our condition, that item will be returned
            // if no item matches, it'll return null
            // if multiple items match, it will return error
        }



        // adding user logic

        public bool AddUser(CreateAccountDTO userToAdd)
        {
        //    if the user already exist
        // if the do not exist we add an account
        // else throw a false
        }
    }
}