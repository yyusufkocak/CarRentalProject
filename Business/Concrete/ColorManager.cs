using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Business.Aspects.Autofac;
using Core.Utilities.Business;
using Business.Logics;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run(
                   ColorLogics.CheckIfColorAlreadyExist(_colorDal, color), CommonLogics.SystemMaintenanceTime());
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);




        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color color)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);

        }
        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {

            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<Color>>(result.Message);
            }
            
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll());

        }
        [CacheAspect(10)]
        public IDataResult<Color> GetById(int id)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<Color>(result.Message);
            }

                return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
            
        }
        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);

        }
    }
}
