using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BogusData.Health
{
    public class AppHealthCheck : IHealthCheck
    {
        private readonly int DATABASE_CAN_CONNECT = 1;

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (DATABASE_CAN_CONNECT == 1)
                {
                    return HealthCheckResult.Healthy();
                }
                else
                {
                    return HealthCheckResult.Unhealthy("Database is offline.");
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Degraded(exception: ex);
            }
        }
    }
}
