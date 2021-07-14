using System.ComponentModel.DataAnnotations;

namespace gregslist_cs.Models
{
  public class Car
  {
    public int id { get; set; }

    [Required]
    [Range(1, 9999999)]
    public int price { get; set; }

    [Required]
    public string make { get; set; }

    [Required]
    public string model { get; set; }
    // public int year { get; set; }
    // public string description { get; set; }
    // public string imgUrl { get; set; }
    // public string creatorId { get; set; }
    // public string creator { get; set; }
  }
}