using Microsoft.AspNetCore.Mvc;
using Xarajat.Api.Data;
using Xarajat.Api.Models;
using User = Xarajat.Api.Entities.User;

namespace Xarajat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    public readonly XarajatDbContext _context;

    public UsersController(XarajatDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Entities.User> GetUsers()
    {
        List<Entities.User> users = _context.Users.ToList();
        return users;
    }

    [HttpPost]
    public Entities.User AddUser(CreateUserModel createUserModel)
    {
        var user = new User()
        {
            Name = createUserModel.Name,
            Email = createUserModel.Email,
            Phone = createUserModel.Phone,
            CreateadData = DateTime.Now
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if(user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UpdateUserModel updateUserModel)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id ==id);
        if (user == null)
            return NotFound();

        user.Name = updateUserModel.Name;
        user.Email = updateUserModel.Email;
        user.Phone = updateUserModel.Phone;
        _context.SaveChanges();

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
            return NotFound();

        _context.Users.Remove(user);
        _context.SaveChanges();

        return Ok();
    }


}





//    [HttpGet("{id}")]
//    public User GetUsers(int id) => new User(){Id = id, Name = "name"};

//    [HttpGet("sorted")]
//    public List<User> GetUsersSorted()
//    {
//        return new List<User>()
//        {
//            new User() {Id = 1, Name = "ism1"},
//            new User() {Id = 3, Name = "ism3"}
//        };
//    }


//    [HttpPost]
//    public User AddUser(User user) => user;

//    [HttpPut("{id}")]
//    public User PutUser(int id, User user)
//    {
//        return user;
//    } 

//    [HttpDelete("{id}")]
//    public string DeleteUser(int id)
//    {
//        return id.ToString();
//    }
//
