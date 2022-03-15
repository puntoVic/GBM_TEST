using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Responses
{
    public class Response
    {
        Current_Balance Current_Balance { get; set; }
        List<Business_Error> Bussines_Errors { get; set; }
        

    }
}
