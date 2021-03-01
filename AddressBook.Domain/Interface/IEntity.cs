using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookAPI.Domain.Interface
{
    public interface IEntity<Type>
    {
        Type Id { get; set;  }
        DateTime RecordCreateTime { get; set; }

    }
}
