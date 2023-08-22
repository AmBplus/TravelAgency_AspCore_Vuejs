using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.Core.Entities;

namespace TravelAgency.Core.Data
{
    public interface IApplicationDbContext : Base.Core.IEfDbContext
    {
        DbSet<TourList> TourLists { get; set; }
        DbSet<TourPackage> TourPackages { get; set; }
    }
}