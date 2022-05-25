using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public interface IDepartmentRepository
    {
        //Saying we need a method called GetAllDepartments that returns a collection
        //That conforms to IEnumerable<T>
        IEnumerable<Department> GetAllDepartments();

        void InsertDepartment(string newDepartmentName);
    }
}
