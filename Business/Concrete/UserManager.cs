using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Entities.Concrete;
using Business.Aspects.Autofac;
using Core.Utilities.Business;
using Business.Logics;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [SecuredOperation("user")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(
                    UserLogics.CheckIfEmailAlreadyExist(_userDal, user.Email),
                    CommonLogics.SystemMaintenanceTime());
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);


        }
        [SecuredOperation("user")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);

        }
       
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<User>>(result.Message);
            }

            return new SuccessDataResult<List<User>>(_userDal.GetAll());

        }
        [PerformanceAspect(5)]
        [CacheAspect(5)]
        public IDataResult<User> GetByMail(string email)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
        [PerformanceAspect(5)]
        [CacheAspect(10)]
        public IDataResult<User> GetById(int id)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));

        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<OperationClaim>>(result.Message);
            }

            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        [SecuredOperation("user")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);

        }
    }
}
