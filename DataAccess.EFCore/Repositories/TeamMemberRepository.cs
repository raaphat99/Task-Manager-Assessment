using DataAccess.EFCore.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class TeamMemberRepository : GenericRepository<TeamMember>, ITeamMemberRepository
    {
        public TeamMemberRepository(ApplicationContext context) : base(context)
        { }

        public async Task<TeamMember> GetByIdWithJobsAsync(int id)
        {
            var memberWithJobs = await _context.TeamMembers
                .Include(member => member.Jobs)
                .FirstOrDefaultAsync(member => member.Id == id);
            return memberWithJobs;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.TeamMembers.AnyAsync(member => member.Email == email);
        }
        public async Task<bool> EmailExistsAsync(string email, int excludedUserId)
        {
            return await _context.TeamMembers
                .AnyAsync(member => member.Email == email && member.Id != excludedUserId);
        }
    }
}
