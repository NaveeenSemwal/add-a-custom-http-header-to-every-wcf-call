using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOktaClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://stackoverflow.com/questions/964433/how-to-add-a-custom-http-header-to-every-wcf-call

            OktaServiceReference.OktaServiceClient clientOkta = new OktaServiceReference.OktaServiceClient();

            var result = clientOkta.DoWorkAsync();

            Console.Read();


        }
    }
}
