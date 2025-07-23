using AppointmentSystem.Application.DTOs.Branch;
using AppointmentSystem.Common.Mappings;
using AppointmentSystem.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace AppointmentSystem.Application.Mappings
{
    public class BranchResponseMapper : BaseMapper<Branch, BranchResponse>, IMapper<Branch, BranchResponse>
    {
        public BranchResponseMapper(ILogger<BranchResponseMapper> logger)
            : base(null, logger)
        {
        }

        public override BranchResponse Map(Branch source)
        {
            if (source == null) return null;

            return new BranchResponse
            {
                BranchId = source.BranchId,
                Name = source.Name,
                Address = source.Address,
                PhoneNumber = source.PhoneNumber
            };
        }
    }
}
