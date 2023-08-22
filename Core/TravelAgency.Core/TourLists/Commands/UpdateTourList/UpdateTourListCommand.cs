using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.Core.Common.Exceptions;
using TravelAgency.Core.Data;
using TravelAgency.Core.Entities;

namespace Travel.Application.TourLists.Commands.UpdateTourList
{
    public class UpdateTourListCommand : IRequest
  {
    public int Id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string About { get; set; }
  }

  public class UpdateTourListCommandHandler : IRequestHandler<UpdateTourListCommand>
  {
    private readonly IApplicationDbContext _context;

    public UpdateTourListCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task Handle(UpdateTourListCommand request, CancellationToken cancellationToken)
    {
      var entity = await _context.TourLists.FindAsync(request.Id);
      if (entity == null)
      {
        throw new NotFoundException(nameof(TourList), request.Id);
      }
      entity.City = request.City;
      await _context.SaveChangesAsync(cancellationToken);

  
    }
  }
}