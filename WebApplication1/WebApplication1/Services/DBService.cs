using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public class DBService : IDBService
    {

        private readonly MainDbContext dbContext;
        
        public DBService(MainDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddMember(int MemberID, int TeamID)
        {
            var Membership = new Membership { MemberID = MemberID, TeamID = TeamID };
            var entity = dbContext.Attach(Membership);
            if(dbContext.Teams.Find(TeamID).OrganizationID != dbContext.Members.Find(MemberID).OrganizationID)
            {
                return 2;
            }
            await dbContext.SaveChangesAsync();
            return 0;
        }

        public async Task<DTOTeam> GetTeam(int TeamID)
        {
            var teams = await dbContext.Teams.FindAsync(TeamID);

            var team = await dbContext.Organizations.FindAsync(teams.OrganizationID);

            IEnumerable<Member> members = await dbContext.Members.Where(e => dbContext.Memberships.Where(e => e.MemberID == e.MemberID).Select(e => e.MemberID).Contains(e.MemberID)).ToListAsync();
            return new DTOTeam
            {
                TeamName = teams.TeamName,
                TeamDescription = teams.TeamDescription,
                OrganizationName = team.OrganizationName,
                Members = members.ToList()
            };
        }

        public async Task InTeam(int TeamID)
        {
            await dbContext.Teams.Where(e => e.TeamID == TeamID).AnyAsync();
        }
    }
}
