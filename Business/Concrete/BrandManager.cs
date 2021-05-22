using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Business.Aspects.Autofac;
using Core.Utilities.Business;
using Business.Logics;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            var result = BusinessRules.Run(BrandLogics.CheckIfBrandAlreadyExist(_brandDal, brand),CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);


        }

        [CacheRemoveAspect("IBrandService.Get")]

        public IResult Delete(Brand brand)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);

        }
        
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<Brand>>(result.Message);
            }
            

                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
            


        }
        
        [PerformanceAspect(5)]
        [CacheAspect(5)]
        public IDataResult<Brand> GetById(int id)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<Brand>(result.Message);
            }
            

                return new SuccessDataResult<Brand>(_brandDal.Get(c => c.BrandId == id));
            



        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
 
        }
    }
}
