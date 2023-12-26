using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Exceptions.CategoryException
{
    public class CategoryImageException:Exception
    {
        public CategoryImageException() : base("Enter right image format")
        {

        }
    }

    public class CategoryImageLengthException : Exception
    {
        public CategoryImageLengthException() : base("Can be added maxsimum 3 mb")
        {

        }
    }
}
