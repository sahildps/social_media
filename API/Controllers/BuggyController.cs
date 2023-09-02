using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace API.Controllers;

public class BuggyController : BaseApiController
{
    private readonly DataContext _context;
    public BuggyController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("auth")]
    public ActionResult<string> GetSecret(){
        return Unauthorized();
    }

    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound(){
        var thing =_context.Users.Find(-1);
        
        if(thing == null) return NotFound();

        return thing;
    }



    [HttpGet("server-error")]
    public ActionResult<string> GetServerEror(){
        var thing =_context.Users.Find(-1);

         var thingtoReturn = thing.ToString();

        return thingtoReturn;
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest(){
        return BadRequest("This was not a good request");
    }

}
