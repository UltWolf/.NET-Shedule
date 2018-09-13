using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SharedSTANDARTLogic.Models
{
    class ExtenWebClient : WebClient
        {
            public string ContentType;

            protected override WebResponse GetWebResponse(WebRequest request)
            {
                var response = base.GetWebResponse(request);
                if (response != null)
                {
                    this.ContentType = response.Headers["Content-Type"];
                }
                return response;
            }
        }
    }
 
