using LXP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXP.Data.IRepository
{
    public interface ICourseRepository
    {
        Course GetCourseDetailsByCourseId(Guid courseId);
        Task AddCourse(Course course);
        bool AnyCourseByCourseTitle(string courseTitle);
        Course GetCourseDetailsByCourseName(string courseName);
    }
}
