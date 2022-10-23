using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xarajat.Api.Data;
using Xarajat.Api.Entities;
using Xarajat.Api.Helpers;
using Xarajat.Api.Models;

namespace Xarajat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly XarajatDbContext _context;

    public RoomsController(XarajatDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetRooms()
    {
        var rooms = _context.Rooms.ToList().Select(room => ConvertToGetRoomModel(room)).ToList();

        return Ok(rooms);
    }

    [HttpPost]
    public IActionResult AddRoom(CreateRoomModel createRoomModel)
    {
        var room = new Room
        {
            Name = createRoomModel.Name,
            Status = RoomStatus.Created,
            Key = RandomGenerator.GetRandomString(),
            AdminId = 2 
        };
        _context.Rooms.Add(room);
        _context.SaveChanges();
        return Ok(ConvertToGetRoomModel(room));

    }

    [HttpGet("{id}")]
    public IActionResult GetRoomById(int id)
    {
        var room = _context.Rooms.Include(r => r.Admin).FirstOrDefault(r => r.Id == id);

        if(room == null)
            return NotFound();

        var getRoomModel = ConvertToGetRoomModel(room);
        
        return Ok(getRoomModel);
    }
    
    [HttpPut]
    public IActionResult UpdateRoom(int id, UpdateRoomModel updateRoomModel)
    {
        var room = _context.Rooms.FirstOrDefault(room => room.Id == id);

        if (room == null)
            return NotFound();

        room.Name = updateRoomModel.Name;
        room.Status = updateRoomModel.Status;

        _context.SaveChanges();
        return Ok(ConvertToGetRoomModel(room)); 

    }
    
    [HttpDelete]
    public IActionResult DeleteRoom(int id)
    {
        var room = _context.Rooms.FirstOrDefault(room => room.Id == id);

        if (room == null)
            return NotFound();

        _context.Rooms.Remove(room);

        _context.SaveChanges();
        return Ok();

    }

    private GetRoomModel ConvertToGetRoomModel(Room room)
    {
        return new GetRoomModel
        {
            Id = room.Id,
            Name = room.Name,
            Key = room.Key,
            Status = room.Status,
            Admin = room.Admin == null ? null : ConverToGetUserModel(room.Admin)
        };
    }

    private GetUser ConverToGetUserModel(User user)
    {
        return new GetUser
        {
            Id = user.Id,
            Name = user.Name
        };
    }
}
