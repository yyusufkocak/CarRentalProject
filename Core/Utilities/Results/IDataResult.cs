using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
   public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
