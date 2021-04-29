using BookWCFService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BookWCFService
{
    public class WindowsService
    {
        private ServiceHost _host = new ServiceHost(typeof(BookService));

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
