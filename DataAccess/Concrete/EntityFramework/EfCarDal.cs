using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess;
using Core.Utilities;

namespace DataAccess.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CRContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CRContext context = new CRContext())
            {
                var result = from cr in context.Cars
                             join b in context.Brands
                           on cr.BrandId equals b.BrandId
                             join c in context.Colors
                             on cr.ColorId equals c.ColorId
                             select new CarDetailDto {CarName=cr.CarName,BrandName=b.BrandName,ColorName=c.ColorName,DailyPrice=cr.DailyPrice};

                return result.ToList();

            }



        }
    }
}
