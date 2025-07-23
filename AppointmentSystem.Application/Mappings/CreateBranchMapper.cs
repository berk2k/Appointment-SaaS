using AppointmentSystem.Application.DTOs.Branch;
using AppointmentSystem.Common.Mappings;
using AppointmentSystem.Common.Multitenancy;
using AppointmentSystem.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace AppointmentSystem.Application.Mappings
{
    public class CreateBranchMapper : BaseMapper<CreateBranchRequest, Branch>, IMapper<CreateBranchRequest, Branch>
    {
        public CreateBranchMapper(ITenantContext tenantContext, ILogger<CreateBranchMapper> logger) : base(tenantContext, logger)
        {
        }
        public override Branch Map(CreateBranchRequest source)
        {
            if (source == null) return null;

            return new Branch
            {
                BranchId = Guid.NewGuid(),
                TenantId = _tenantContext.TenantId, 
                Name = source.Name,
                Address = source.Address,
                PhoneNumber = source.PhoneNumber,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
