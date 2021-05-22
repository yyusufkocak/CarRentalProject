using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logics
{
    public class CommonLogics
    {

        public static IResult SystemMaintenanceTime()
        { 

       if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
     
                return new SuccessResult();
            
        }
    }
}
