using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AlifJobTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Host h = HostFactory.New(x =>
            {
                x.Service<Service>(s =>
                {
                    s.ConstructUsing(name => new Service());
                    s.WhenStarted(wd => wd.Start());
                    s.WhenStopped(wd => wd.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("AlifTest");
                x.SetDisplayName("AlifTest");
                x.SetServiceName("AlifTest");
            });

            h.Run();
        }
    }
}
