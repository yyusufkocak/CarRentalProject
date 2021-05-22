using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
           _cars=new List<Car> {
                new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 140,ModelYear=2016,CarName= "Deneme1" },
                new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 153,ModelYear=2019,CarName= "Deneme2" },
                new Car { Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 146,ModelYear=2017,CarName= "Deneme3" },
                new Car { Id = 4, BrandId = 4, ColorId = 3, DailyPrice = 149,ModelYear=2017,CarName= "Deneme4" },
                new Car { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 151,ModelYear=2018,CarName= "Deneme5" },
                new Car { Id = 6, BrandId = 2, ColorId = 1, DailyPrice = 150,ModelYear=2019,CarName= "Deneme6" },
                new Car { Id = 7, BrandId = 1, ColorId = 1, DailyPrice = 141,ModelYear=2017,CarName= "Deneme7" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars.ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int Id)
        {
            return _cars.SingleOrDefault(c=>c.Id==Id);
        }

        public List<Car> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(c=>c.Id==car.Id);
            CarToUpdate.Id = car.Id;
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.CarName= car.CarName;




        }

        List<CarDetailDto> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
