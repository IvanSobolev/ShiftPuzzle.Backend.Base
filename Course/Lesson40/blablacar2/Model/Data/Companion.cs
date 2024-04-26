using System.ComponentModel.DataAnnotations;

public class Companion
{
    public int Id {get; set;}
    public string Name {get; set;}
    public DateTime TripDate {get; set;}
    public float Reward {get; set;}
    public string From {get; set;}
    public string To {get; set;}
}