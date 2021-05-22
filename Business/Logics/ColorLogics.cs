using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logics
{
   public class ColorLogics
    {
        public static IResult CheckIfColorAlreadyExist(IColorDal colorDal, Color color)
        {
            var result = colorDal.Get(c => c.ColorName== color.ColorName);

            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

           
        }
    }
}
