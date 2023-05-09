using EMS.data.Abstract;
using EMS.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.data.Concrete.EFCore
{
    public class EfCoreDemartmentRepository :
       EfCoreGenericRepository<Department, EMSDemoContext>, IDepartmentRepository
    {
     
    }
}
