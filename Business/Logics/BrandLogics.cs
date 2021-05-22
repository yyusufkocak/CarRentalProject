using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logics
{
   public class BrandLogics
    {
        public static IResult CheckIfBrandAlreadyExist(IBrandDal brandDal, Brand brand)
        {
            var result = brandDal.Get(b => b.BrandName == brand.BrandName);

            if (result != null)
            {
                return new SuccessResult();
            }

            return new ErrorResult();

           
        }
    }
}
