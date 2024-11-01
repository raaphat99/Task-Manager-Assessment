﻿using DataAccess.EFCore.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly ApplicationContext _context;
        private readonly Lazy<IJobRepository> jobs;
        private readonly Lazy<ITeamMemberRepository> teamMembers;
        #endregion

        #region Constructor
        public UnitOfWork(ApplicationContext context)
        {
            // Lazy<T> class is used to defer the creation of the repositories until they are accessed.
            _context = context;
            jobs = new Lazy<IJobRepository>(() => new JobRepository(_context));
            teamMembers = new Lazy<ITeamMemberRepository>(() => new TeamMemberRepository(_context));
        }
        #endregion

        #region Getters
        //The Value property of Lazy<T> ensures that the repository is instantiated only once and then reused. (Singleton object)
        public IJobRepository Jobs => jobs.Value;
        public ITeamMemberRepository TeamMembers => teamMembers.Value;

        #endregion

        #region Methods
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion  

    }
}
