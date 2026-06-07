using GymManagment.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_MVC01.Models;
using WebApp_MVC01.WebAppContexts;

namespace GymManagment.DAL.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {
        // we need first DB Connection
        private readonly AppDbContext dbcontext;

        public PlanRepository(AppDbContext dbcontext)
        {
             this.dbcontext = dbcontext;  // remove the new 
             //dbcontext = new AppDbContext();
        }
        public async Task<int> AddAsync(Plan plan, CancellationToken ct = default)
        {
            dbcontext.Plans.Add(plan);
            return await dbcontext.SaveChangesAsync(ct);
        }

        public async Task<int> DeleteAsync(Plan plan, CancellationToken ct = default)
        {
            dbcontext.Plans.Remove(plan);
            return await dbcontext.SaveChangesAsync(ct);

        }

        public async Task<IEnumerable<Plan>> GetAllAsync(bool tracking = false, CancellationToken ct = default)
        {
            //if (tracking)
            //    return await dbcontext.Plans.ToListAsync(ct);
            //else
            //    return await dbcontext.Plans.AsNoTracking().ToListAsync(ct);

            // OR
            IQueryable<Plan> query = tracking ? dbcontext.Plans : dbcontext.Plans.AsNoTracking();
            return await query.ToListAsync(ct);

        }

        public async Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await dbcontext.Plans.FindAsync(id, ct);
        }

        public Task<int> UpdateAsync(Plan plan, CancellationToken ct = default)
        {
            dbcontext.Plans.Update(plan);
            return dbcontext.SaveChangesAsync(ct);
        }
    }
}
