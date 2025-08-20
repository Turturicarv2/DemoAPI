using DataAccess.Data;
using DataAccess.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{

    public UnitOfWork(IPersonData personData)
    {
        Persons = personData;
    }
}
