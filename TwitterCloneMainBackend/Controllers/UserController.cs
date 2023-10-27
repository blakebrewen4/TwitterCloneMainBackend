using Microsoft.AspNetCore.Mvc;
using TwitterCloneMainBackend.Data;

public class UserController : Controller
{
    private readonly TwitterDbContext _context;

    public UserController(TwitterDbContext context)
    {
        _context = context;
    }

    // Use _context to interact with the database
}

