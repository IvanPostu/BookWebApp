using BookWCFDataService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BookWCFDataService
{
    public class WindowsService
    {
        private ServiceHost _host = new ServiceHost(typeof(BookDataService));

        public void Start()
        {
            _host.Open();
        }

        public void Stop()
        {
            _host.Close();
        }

    }
}
