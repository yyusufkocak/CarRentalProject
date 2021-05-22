using Core.Utilities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logics
{
    public class UserLogics
    {
        public static IResult CheckIfEmailAlreadyExist(IUserDal userDal, string email)
        {
            var result = userDal.Get(u => u.Email == email);
            if (result == null)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
            
        }
    }
}
