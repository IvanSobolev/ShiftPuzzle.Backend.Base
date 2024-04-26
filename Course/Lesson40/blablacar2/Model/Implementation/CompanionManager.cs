public class CompanionManager : ICompanionManager
{
    private readonly CompanionContext _context;

    public CompanionManager(CompanionContext context)
    {
        _context = context;
    }
    public List<Companion> FindSuitableCompanions(string from, string to)
    {
        return _context.Companions.Where(c => c.From == from && c.To == to).ToList<Companion>();
    }

    public string AddNewCompanion(Companion companion)
    {
        _context.Companions.Add(companion);
        _context.SaveChanges();
        return "Companion added";
    }

    public string RemoveCompanion(int Id)
    {
        var companion = _context.Companions.FirstOrDefault(c => c.Id == Id);
        if (companion != null)
        {
            _context.Companions.Remove(companion);
            _context.SaveChanges();
            return "Companion removed";
        }
        else 
        {
            return "Companion is not find";
        }
    }
}