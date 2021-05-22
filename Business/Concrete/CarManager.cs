using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Logics;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(
                CarLogics.CheckIfCarExists(_carDal, car),
                CarLogics.CheckIfCarCountOfBrandCorrect(_carDal, car.BrandId),
                CommonLogics.SystemMaintenanceTime());
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

       
        [SecuredOperation("car.delete")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }
        [PerformanceAspect(5)]
        [SecuredOperation("car.list")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<Car>>(result.Message);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll());

        }
        [PerformanceAspect(5)]
        [CacheAspect(10)]
        public IDataResult<Car> GetById(int id)
        {

            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<Car>(result.Message);
            }

            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));


        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<CarDetailDto>>(result.Message);
            }


            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());




        }
        [CacheAspect(5)]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<Car>>(result.Message);
            }


            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));


        }
        [CacheAspect(5)]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<Car>>(result.Message);
            }


            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));



        }

        
        [SecuredOperation("car.update")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }



    }
}
