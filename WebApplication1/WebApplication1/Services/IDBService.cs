using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
   public interface IDBService
    {
        public Task<DTOTeam> GetTeam(int TeamID);
        public Task<int> AddMember(int MemberID, int TeamID);
        public Task InTeam(int TeamID);
    }
}
