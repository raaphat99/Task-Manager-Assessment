using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITeamMemberRepository : IGenericRepository<TeamMember>
    {
        Task<TeamMember> GetByIdWithJobsAsync(int id);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> EmailExistsAsync(string email, int excludedUserId);
    }
}
