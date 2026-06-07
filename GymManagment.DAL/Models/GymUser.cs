using GymManagment.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.DAL.Models
{
    // for members and trainers
    public class GymUser : BaseEntitiy 
    {
        public string Name { get; set; } = default;
        public string Email { get; set; } = default;
        public string Phone { get; set; } = default;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
    }

    // Address
    [Owned]
    public class Address
    {
        public string BuildingNUmber { get; set; } = default;
        public string Street { get; set; } = default;
        public string City { get; set; } = default;
    }
}
