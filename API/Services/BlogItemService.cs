using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Migrations;
using API.Models;
using API.Services.Context;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace API.Services
{
    public class BlogItemService : ControllerBase
    {

        private readonly DataContext _context;

        public BlogItemService(DataContext context)
        {
            _context = context;
        }
        public bool AddBlogItems(BlogItemModel newBlogItem)
        {
            bool result = false;
            _context.Add(newBlogItem);
            result = _context.SaveChanges() != 0;
            return result;
        }

        public bool DeleteBlogItems(BlogItemModel blogDelete)
        {
            _context.Update<BlogItemModel>(blogDelete);
            return _context.SaveChanges() !=0;
        }


        public IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return _context.BLogInfo;
        }

        public IEnumerable<BlogItemModel> GetItemByCategory(string category)
        {
            return _context.BLogInfo.Where(item => item.Category == category);
        }

        public IEnumerable<BlogItemModel> GetItemByDate(string date)
        {
            return _context.BLogInfo.Where(item => item.Date == date);
        }

         public List<BlogItemModel> GetItemByTag(string Tag)
        {
            List<BlogItemModel> AllBlogsWithTag = new List<BlogItemModel>();
            var allItems = GetAllBlogItems().ToList();
            for(int i = 0; i <allItems.Count; i++)
            {
                BlogItemModel Item = allItems[i];
                var itemArr = Item.Tag.Split(',');
                for(int j = 0; j < itemArr.Length; j++){
                    if(itemArr[j].Contains(Tag)){
                        AllBlogsWithTag.Add(Item);
                        break;
                    }
                }
            }
            return AllBlogsWithTag;
        }

        public IEnumerable<BlogItemModel> GetPublishedItems(string isPublished)
        {
            return _context.BLogInfo.Where(item => item.IsPublished);
        }


        public bool UpdateBlogItems(BlogItemModel blogUpdate)
        {
           _context.Update<BlogItemModel>(blogUpdate);
           return _context.SaveChanges() != 0;
        }






// Methods
        internal IEnumerable<BlogItemModel> GetItemByDate()
        {
            throw new NotImplementedException();
        }

        internal List<BlogItemModel> GetItemByTag()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogItemModel> GetItemsByUserId(int userId)
        {
           return _context.BLogInfo.Where(item => item.UserId == userId);
        }

        internal IEnumerable<BlogItemModel> GetPublishedItems()
        {
            throw new NotImplementedException();
        }

    }
}        

