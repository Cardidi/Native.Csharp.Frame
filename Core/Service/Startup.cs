using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class Startup
    {
        public class NancyBootstrapper : DefaultNancyBootstrapper
        {
            protected override void ConfigureApplicationContainer(TinyIoCContainer container)
            {
                base.ConfigureApplicationContainer(container);
            }

            protected override void ConfigureConventions(NancyConventions nancyConventions)
            {
                base.ConfigureConventions(nancyConventions);
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "data", "web"));
                nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("images", Path.Combine(Environment.CurrentDirectory, "data","web")));
            }
        }

        public class NancyWebHttpBinding : WebHttpBinding
        {

        }
    }
}
