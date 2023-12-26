using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Exceptions.CategoryException
{
    public class CategoryNullException:Exception
    {
        public CategoryNullException() : base("Category can't be null")
        {

        }
        public CategoryNullException(string message) : base(message)
        {
        }
    
}
}
