using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logics
{
    public class CustomerLogics
    {
        public static IResult CheckIfCustomerAlreadyExist(ICustomerDal customerDal, Customer customer)
        {
            var result = customerDal.Get(c => c.CompanyName == customer.CompanyName);

            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

            
        }
    }
}