using Microsoft.AspNetCore.Mvc;

[Route ("/api/carpool")]
public class CompanionController : ControllerBase
{
    private readonly ICompanionManager _companionManager;

    public CompanionController (ICompanionManager companion)
    {
        _companionManager = companion;
    }

    [HttpGet("/search/{from}/{to}")]
    public List<Companion> FindCompanions(string from, string to)
    {
        return _companionManager.FindSuitableCompanions(from, to);
    }

    [HttpPost("/add")]
    public IActionResult AddCompanions([FromBody] Companion companion)
    {
        return Ok(_companionManager.AddNewCompanion(companion));
    }

    [HttpDelete("/del/{id}")]
    public IActionResult DelCompanions(int id)
    {
        return Ok(_companionManager.RemoveCompanion(id));
    }
}