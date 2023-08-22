using System.Collections.Generic;
using Travel.Application.TourLists.Queries.ExportTours;

namespace TravelAgency.Core.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTourPackagesFile(IEnumerable<TourPackageRecord> records);
    }
}