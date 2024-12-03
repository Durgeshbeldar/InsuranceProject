using DsInsurance.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            var roles = Enum.GetValues(typeof(RoleType))
                            .Cast<RoleType>()
                            .Select(role => new
                            {
                                Id = (int)role,
                                Name = role.ToString()
                            })
                            .ToList();

            return Ok(roles);
        }
        [HttpGet("policy-status")]
        public IActionResult GetPolicyStatuses()
        {
            var statuses = Enum.GetValues(typeof(PolicyStatus))
                               .Cast<PolicyStatus>()
                               .Select(status => new
                               {
                                   Id = (int)status,
                                   Name = status.ToString()
                               })
                               .ToList();

            return Ok(statuses);
        }
        [HttpGet("claim-status")]
        public IActionResult GetClaimStatuses()
        {
            var statuses = Enum.GetValues(typeof(ClaimStatus))
                               .Cast<ClaimStatus>()
                               .Select(status => new
                               {
                                   Id = (int)status,
                                   Name = status.ToString()
                               })
                               .ToList();

            return Ok(statuses);
        }
        [HttpGet("transaction-types")]
        public IActionResult GetTransactionTypes()
        {
            var types = Enum.GetValues(typeof(TransactionType))
                            .Cast<TransactionType>()
                            .Select(type => new
                            {
                                Id = (int)type,
                                Name = type.ToString()
                            })
                            .ToList();

            return Ok(types);
        }
        [HttpGet("premium-types")]
        public IActionResult GetPremiumTypes()
        {
            var types = Enum.GetValues(typeof(PremiumType))
                            .Cast<PremiumType>()
                            .Select(type => new
                            {
                                Id = (int)type,
                                Name = type.ToString()
                            })
                            .ToList();

            return Ok(types);
        }

        [HttpGet("installment-status")]
        public IActionResult GetInstallmentStatuses()
        {
            var statuses = Enum.GetValues(typeof(InstallmentStatus))
                               .Cast<InstallmentStatus>()
                               .Select(status => new
                               {
                                   Id = (int)status,
                                   Name = status.ToString()
                               })
                               .ToList();

            return Ok(statuses);
        }

        [HttpGet("refund-status")]
        public IActionResult GetRefundStatuses()
        {
            var statuses = Enum.GetValues(typeof(RefundStatus))
                               .Cast<RefundStatus>()
                               .Select(status => new
                               {
                                   Id = (int)status,
                                   Name = status.ToString()
                               })
                               .ToList();

            return Ok(statuses);
        }

        [HttpGet("notification-types")]
        public IActionResult GetNotificationTypes()
        {
            var types = Enum.GetValues(typeof(NotificationType))
                            .Cast<NotificationType>()
                            .Select(type => new
                            {
                                Id = (int)type,
                                Name = type.ToString()
                            })
                            .ToList();

            return Ok(types);
        }

        [HttpGet("department-types")]
        public IActionResult GetDepartmentTypes()
        {
            var departments = Enum.GetValues(typeof(DepartmentType))
                                  .Cast<DepartmentType>()
                                  .Select(department => new
                                  {
                                      Id = (int)department,
                                      Name = department.ToString()
                                  })
                                  .ToList();

            return Ok(departments);
        }

        [HttpGet("rider-types")]
        public IActionResult GetRiderTypes()
        {
            var riders = Enum.GetValues(typeof(RiderType))
                             .Cast<RiderType>()
                             .Select(rider => new
                             {
                                 Id = (int)rider,
                                 Name = rider.ToString()
                             })
                             .ToList();

            return Ok(riders);
        }

        [HttpGet("earning-types")]
        public IActionResult GetEarningTypes()
        {
            var types = Enum.GetValues(typeof(EarningType))
                            .Cast<EarningType>()
                            .Select(type => new
                            {
                                Id = (int)type,
                                Name = type.ToString()
                            })
                            .ToList();

            return Ok(types);
        }

        [HttpGet("payment-status-types")]
        public IActionResult GetPaymentStatusesTypes()
        {
            var types = Enum.GetValues(typeof(PaymentStatus))
                            .Cast<EarningType>()
                            .Select(type => new
                            {
                                Id = (int)type,
                                Name = type.ToString()
                            })
                            .ToList();

            return Ok(types);
        }
    }
}
