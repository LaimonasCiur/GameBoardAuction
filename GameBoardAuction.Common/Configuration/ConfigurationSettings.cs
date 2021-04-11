namespace GameBoardAuction.Common.Configuration
{
    public class ConfigurationSettings
    {
        public IdentityServerConfig IdentityServer { get; set; }

        public class IdentityServerConfig 
        {
            public string IdIdentifier { get; set; }
        }
    }
}
