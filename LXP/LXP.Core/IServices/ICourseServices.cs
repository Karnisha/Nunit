using LXP.Common.ViewModels;
using LXP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXP.Core.IServices
{
    public interface ICourseServices
    {
        Course GetCourseDetailsByCourseId(string courseId);
        Course GetCourseDetailsByCourseName(string courseName);
        bool AddCourse(CourseViewModel course);
    }
}
