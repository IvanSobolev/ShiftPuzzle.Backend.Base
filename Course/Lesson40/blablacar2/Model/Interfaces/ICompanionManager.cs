public interface ICompanionManager
{
    public List<Companion> FindSuitableCompanions(string from, string to);
    public string AddNewCompanion(Companion companion);
    public string RemoveCompanion(int Id);
}