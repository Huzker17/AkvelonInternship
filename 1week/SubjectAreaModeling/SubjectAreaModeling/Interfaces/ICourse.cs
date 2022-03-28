using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Interfaces
{
    public interface ICourse
    {
        /// <summary>
        /// Method for creating Course
        /// </summary>
        /// <param name="TeacherId">Only one teacher can handle one course</param>
        /// <param name="Name">The name of the course</param>
        public void Create(int TeacherId, string Name);
    }
}
