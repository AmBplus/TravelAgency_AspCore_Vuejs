using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.Core.Common.Exceptions;
using TravelAgency.Core.Data;
using TravelAgency.Core.Entities;
using TravelAgency.Core.Enums;

namespace TravelAgency.Core.TourPackages.Commands.UpdateTourPackageDetail
{
    public class UpdateTourPackageDetailCommand : IRequest
  {
    public int Id { get; set; }
    public int ListId { get; set; }
    public string WhatToExpect { get; set; }
    public string MapLocation { get; set; }
    public float Price { get; set; }
    public int Duration { get; set; }
    public bool InstantConfirmation { get; set; }
    public Currency Currency { get; set; }
  }

  public class UpdateTourPackageDetailCommandHandler : IRequestHandler<UpdateTourPackageDetailCommand>
  {
    private readonly IApplicationDbContext _context;

    public UpdateTourPackageDetailCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task Handle(UpdateTourPackageDetailCommand request, CancellationToken cancellationToken)
    {
      var entity = await _context.TourPackages.FindAsync(request.Id);
      if (entity == null)
      {
        throw new NotFoundException(nameof(TourPackage), request.Id);
      }
      entity.ListId = request.ListId;
      entity.WhatToExpect = request.WhatToExpect;
      entity.MapLocation = request.MapLocation;
      entity.Price = request.Price;
      entity.Duration = request.Duration;
      entity.InstantConfirmation = request.InstantConfirmation;
      entity.Currency = request.Currency;

      await _context.SaveChangesAsync(cancellationToken);

    }
  }
}