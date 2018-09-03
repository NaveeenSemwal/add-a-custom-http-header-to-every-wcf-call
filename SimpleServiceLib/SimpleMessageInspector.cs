using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServiceLib
{
    // Client message inspector  
    public class SimpleMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            // Implement this method to inspect/modify messages after a message  
            // is received but prior to passing it back to the client   
            Console.WriteLine("AfterReceiveReply called");
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
        {

            HttpRequestMessageProperty httpRequestMessage;
            object httpRequestMessageObject;
            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
            {
                httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
                if (string.IsNullOrEmpty(httpRequestMessage.Headers["Authorization"]))
                {
                    httpRequestMessage.Headers["Authorization"] = "Naveen";
                }
            }
            else
            {
                httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers.Add("Authorization", "Naveen");
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }

            return null;

        }
    }
}
