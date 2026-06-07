using GymManagment.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.DAL.Models
{
    public class Trainer : GymUser
    {
        // HireDate = = CreatedAt of BaseEntitiy
        public Specialty Specialty { get; set; }
    }
}
