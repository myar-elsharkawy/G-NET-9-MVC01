using GymManagment.DAL.Models;

namespace WebApp_MVC01.Models
{
    public class Plan : BaseEntitiy
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public bool IsActive { get; set; }

    }
}
