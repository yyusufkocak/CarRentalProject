using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using Business.Logics;
using Business.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [SecuredOperation("customer.add")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {

            IResult result = BusinessRules.Run(CustomerLogics.CheckIfCustomerAlreadyExist(_customerDal, customer), CommonLogics.SystemMaintenanceTime());
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);



        }
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);


        }
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<List<Customer>>(result.Message);
            }

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());




        }
        [CacheAspect(10)]
        public IDataResult<Customer> GetById(int id)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorDataResult<Customer>(result.Message);
            }

            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));

        }

        [SecuredOperation("customer.add")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            var result = BusinessRules.Run(CommonLogics.SystemMaintenanceTime());

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);

        }
    }
}
