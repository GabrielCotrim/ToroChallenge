using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroChallenge.Domain.Models
{
    public class UserPositionModel
    {
        public double CheckingAccountAmount { get; set; }
        public List<PositionModel> Positions { get; set; } = new List<PositionModel>();
        public double Consolidated { get; set; }
    }
}
