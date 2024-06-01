using System.ComponentModel.DataAnnotations;

namespace ASP.HOTELS.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Rooms { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public string ImgURL { get; set; }
    }
}