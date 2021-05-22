using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfColorDal:EfEntityRepositoryBase<Color,CRContext>,IColorDal
    {
    }
}
