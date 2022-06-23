using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.DTO
{
    public class DTOTeam
    {
        public string TeamName { get; set; }
        public string OrganizationName { get; set; }
        public string TeamDescription { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }
}
