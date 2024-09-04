using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {

        private readonly BlogItemService _data;

        public BlogController(BlogItemService dataFromService)
        {
            _data = dataFromService;
        }
    
    [HttpPost("AddBlogItems")]

    public bool AddBlogItems(BlogItemModel newBlogItem)
    {
        return _data.AddBlogItems(newBlogItem);
    }


// GetAllBlog Items
    [HttpGet("GetBlogItems")]
    
    public IEnumerable<BlogItemModel> GetAllBlogItems()
    {
        return _data.GetAllBlogItems();
    }


// GetBlogItemsbyCategory

    [HttpGet("GetBlogItemsByCategory/{Category}")]

      public IEnumerable<BlogItemModel> GetItemByCategory(string Category)
      {
        return _data.GetItemByCategory(Category);
      }

// GetItemsByTags

[HttpGet("GetItemsByTag/{Tag}")]

    public List<BlogItemModel> GetItemsByTag(string Tag)
    {
        return _data.GetItemByTag();
    }



// GetBlogItemsByDate

[HttpGet("GetItemsByDate/{Date}")]

public IEnumerable<BlogItemModel> GetItemsByDate(string Date)
{
    return _data.GetItemByDate();
}

// UpdateBlogItems
[HttpPost("UpdateBlogItems")]

public bool UpdateBlogItems(BlogItemModel BlogUpdate)
{
    return _data.UpdateBlogItems(BlogUpdate);
}

// DeleteBlogItems

[HttpPost("DeleteBlogItems/{BlogDelete}")]

public bool DeleteBlogItems(BlogItemModel BlogDelete)
{
    return _data.DeleteBlogItems(BlogDelete);
}

// GetPublishedBlogItems

[HttpGet("GetPublishedItems")]

public IEnumerable<BlogItemModel> GetPublishedItems()
{
    return _data.GetPublishedItems();
}

// WE need a GetItemsByUserId

[HttpGet("GetItemsByUserId/{UserId}")]

public IEnumerable<BlogItemModel> GetItemsByUserId (int UserId)
{
    return _data.GetItemsByUserId(UserId);
}
 


    }
}


