using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Logics
{
    public class RentalLogics
    {
       



        public static IResult CheckIfCarAlreadyRented(IRentalDal rentalDal, Rental rental)
        {
            var existRental = rentalDal.GetAll(r => r.CarID == rental.CarID).OrderBy(r => r.RentDate).FirstOrDefault();

            if (existRental == null || (existRental.ReturnDate != null && existRental.ReturnDate < DateTime.Now))
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
