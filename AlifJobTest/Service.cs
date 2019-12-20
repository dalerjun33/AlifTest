using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace AlifJobTest
{
    public class Service
    {
        private readonly string _myAddress = ConfigurationManager.AppSettings["MyAddress"].ToString();
        private HttpSelfHostServer _serv;
        private void StartSelfHost()
        {
            var selfHostConfiguraiton = new HttpSelfHostConfiguration(_myAddress);
            Functions functions = new Functions();
            functions.Collector();
            selfHostConfiguraiton.Routes.MapHttpRoute(
                name: "DefaultApiRoute",
                routeTemplate: "{controller}",
                defaults: null
            );
            _serv = new HttpSelfHostServer(selfHostConfiguraiton);

            _serv.OpenAsync();
           
        }
        public void Start()
        {
            StartSelfHost();
            Console.WriteLine("Start Service My Address :" + _myAddress);
        }
        public void Stop()
        {
            _serv.CloseAsync();
        }
    }

}
