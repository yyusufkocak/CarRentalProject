using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Business.Logics;
using Core.Utilities.Business;
using Business.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
       

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
           
        }

       
        [SecuredOperation("admin,rental.add")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(
               RentalLogics.CheckIfCarAlreadyRented(_rentalDal, rental),
               CommonLogics.SystemMaintenanceTime());
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
       
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            

        }
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
           
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<Rental>>(result.Message);
            }


            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            

        }
        [CacheAspect(5)]
        public IDataResult<Rental> GetById(int id)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<Rental>(result.Message);
            }

            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
            

        }

        [SecuredOperation("admin,rental.add")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);

        }
    }
}
