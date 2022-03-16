using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Responses
{
    public class Response
    {
        public Current_Balance Current_Balance { get; set; }
        public List<Business_Error> Bussines_Errors { get; set; }
        

    }
}
