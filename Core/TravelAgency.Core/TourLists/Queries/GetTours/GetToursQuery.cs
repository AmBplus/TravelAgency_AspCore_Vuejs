﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Core.Data;
using TravelAgency.Core.Dtos.Tour;

namespace Travel.Application.TourLists.Queries.GetTours
{
    public class GetToursQuery : IRequest<ToursVm> { }

  public class GetToursQueryHandler : IRequestHandler<GetToursQuery, ToursVm>
  {
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetToursQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ToursVm> Handle(GetToursQuery request, CancellationToken cancellationToken)
    {
            return new ToursVm
            {
                Lists = await _context.TourLists
               .ProjectTo<TourListDto>(_mapper.ConfigurationProvider)
               .OrderBy(t => t.City)
               .ToListAsync(cancellationToken)
            };
    }
  }
}