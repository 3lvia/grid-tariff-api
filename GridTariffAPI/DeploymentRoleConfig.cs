using GridTariffApi.Exceptions;

namespace GridTariffApi
{
    public class DeploymentRoleConfig
    {
        public enum RoleType
        {
            Api,
            Synchronizer
        }


        public RoleType Role { get; }

        public DeploymentRoleConfig(string roleType)
        {
            Role = roleType.ToLower() switch
            {
                "synchronizer" => RoleType.Synchronizer,
                _ => RoleType.Api // Default to Api
            };
        }
    }
}
