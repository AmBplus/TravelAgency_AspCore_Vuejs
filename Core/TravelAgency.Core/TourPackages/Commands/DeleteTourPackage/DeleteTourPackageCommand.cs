using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.Core.Common.Exceptions;
using TravelAgency.Core.Data;
using TravelAgency.Core.Entities;

namespace Travel.Application.TourPackages.Commands.DeleteTourPackage
{
    public class DeleteTourPackageCommand : IRequest
  {
    public int Id { get; set; }
  }

  public class DeleteTourPackageCommandHandler : IRequestHandler<DeleteTourPackageCommand>
  {
    private readonly IApplicationDbContext _context;

    public DeleteTourPackageCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task Handle(DeleteTourPackageCommand request, CancellationToken cancellationToken)
    {
      var entity = await _context.TourPackages.FindAsync(request.Id);
      if (entity == null)
      {
        throw new NotFoundException(nameof(TourPackage), request.Id);
      }
      _context.TourPackages.Remove(entity);
      await _context.SaveChangesAsync(cancellationToken);

     
    }
  }
}