using Microsoft.Extensions.Hosting;

namespace SwashbuckleIssue
{
    public class SwaggerHostFactory
    {
        public static IHost CreateHost()
        {
            return Program.CreateHostBuilder(new string[0]).Build();
        }
    }
}