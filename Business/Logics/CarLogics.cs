using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logics
{
    public class CarLogics
    {
        

        public static IResult CheckIfCarExists(ICarDal carDal, Car car)
        {
            var result = carDal.Get(c => c.BrandId == car.BrandId
           && c.ColorId == car.ColorId
           && c.ModelYear == car.ModelYear
           && c.CarName == car.CarName);

            if (result!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }

        public static IResult CheckIfCarCountOfBrandCorrect(ICarDal carDal, int brandId)
        {
            var result = carDal.GetAll(c => c.BrandId == brandId);

            if (result.Count <= 3)
            {
                return new SuccessResult();
            }

            return new ErrorResult();

        }

       
    }
}
