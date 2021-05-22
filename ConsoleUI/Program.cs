using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using DataAccess.EntityFramework;
using Entities;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());


            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CarID = 1, CustomerId = 3, RentDate = DateTime.Now, });

            //UserManager userManager = new UserManager(new EfUserDal());
            //User user1 = new User();
            //user1.FirstName = "Batuhan";
            //user1.LastName = "Cömert";
            //user1.Email = "batuhancömert@hotmail.com";
            //user1.Password = "123456 ";
            //userManager.Add(user1);

            //Customer customer1 = new Customer();
            //customer1.UserId = 1;
            //customer1.CompanyName = "Google";

            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(customer1);




        }
    }
}
