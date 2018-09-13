
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedSTANDARTLogic.Models.Resource
{

    public class SheduleRequest
    {

        public string query { get; set; }
        public string[] suggestions { get; set; }

        public override bool Equals(object obj)
        {
            SheduleRequest SG = obj as SheduleRequest;
            if (SG != null)
            {
                if (SG.query == this.query)
                {
                    for (int i = 0; i < suggestions.Length; i++)
                    {
                        if (SG.suggestions[0].Equals(suggestions[0]))
                        {

                            return false;
                          
                        }
                     
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
