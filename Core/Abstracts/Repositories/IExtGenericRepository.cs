using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.DataTools;

namespace Core.Abstracts.Repositories
{
    public interface IExtGenericRepository<T>:IGenericRepository<T> where T : class
    {

    }
}
