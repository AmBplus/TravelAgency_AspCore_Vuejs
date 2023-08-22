using System.Threading.Tasks;
using TravelAgency.Core.Dtos.Email;

namespace TravelAgency.Core.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailDto emailRequest);
    }
}