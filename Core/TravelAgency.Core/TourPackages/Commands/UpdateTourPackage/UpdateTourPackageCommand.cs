using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.Core.Common.Exceptions;
using TravelAgency.Core.Data;
using TravelAgency.Core.Entities;

namespace Travel.Application.TourPackages.Commands.UpdateTourPackage
{
    public partial class UpdateTourPackageCommand : IRequest
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  public class UpdateTourPackageCommandHandler : IRequestHandler<UpdateTourPackageCommand>
  {
    private readonly IApplicationDbContext _context;

    public UpdateTourPackageCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task Handle(UpdateTourPackageCommand request, CancellationToken cancellationToken)
    {
      var entity = await _context.TourPackages.FindAsync(request.Id);
      if (entity == null)
      {
        throw new NotFoundException(nameof(TourPackage), request.Id);
      }
      entity.Name = request.Name;
      await _context.SaveChangesAsync(cancellationToken);

    }
  }
}