using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Http;
using StubModel.Managers;
using StubModel.Models;

namespace StubWebApis.Controllers
{
    public class StudentsController : ApiController
    {
        /// <summary>
        /// Get a list of studennts in a site
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns>An Istudent instance</returns>
        [HttpGet]
        public IEnumerable<IStudent> GetSiteStudents(string siteId)
        {
            var site = SiteManager.Get(siteId);

            if (site != null)
            {
                return StudentManager.List(site);
            }

            return null;
        }

        /// <summary>
        /// Get a student based on student user id
        /// </summary>
        /// <param name="siteId">Site Id</param>
        /// <param name="id">Student user Id</param>
        /// <returns>An Istudent instanc</returns>
        [HttpGet]
        public IStudent Get(string siteId, string id)
        {
            var site = SiteManager.Get(siteId);

            if (site != null)
            {
                return StudentManager.Get(site, id);
            }

            return null;
        }

        /// <summary>
        /// Search students based on student name
        /// </summary>
        /// <param name="siteId">Site Id</param>
        /// <param name="name">Student name; accept partial name</param>
        /// <returns>A collection of students</returns>
        [HttpGet]
        public IEnumerable<IStudent> SearchStudents(string siteId, string name)
        {
            var site = SiteManager.Get(siteId);

            if (site != null)
            {
                return StudentManager.Search(site, name);
            }

            return null;
        }

        /// <summary>
        /// Get the list of classes of a student
        /// </summary>
        /// <param name="siteId">Site Id</param>
        /// <param name="id">Student Id</param>
        /// <returns>An IClass instance</returns>
        public IEnumerable<IClass> GetClasses(string siteId, string id)
        {
            var student = Get(siteId, id);

            if (student != null)
            {
                return StudentManager.GetClasses(student);
            }

            return null;
        }

        /// <summary>
        /// Create a student in a site
        /// </summary>
        /// <param name="siteId">Site Id</param>
        /// <param name="name">Student name</param>
        [HttpPost]
        public void CreateStudent(string siteId, string name)
        {
            var site = SiteManager.Get(siteId);

            if (site != null)
            {
                StudentManager.CreateStudent(name, site);
            }
        }


        /// <summary>
        /// Add a student to a class
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="classId"></param>
        /// <param name="studentId"></param>
        [HttpPost]
        public void AddStudentToClass(string siteId, string classId, string studentId)
        {
            var classSection = ClassManager.Get(classId);
            var student = default(IStudent);

            if (classSection != null)
            {
                student = Get(siteId, studentId);
            }

            if (classSection != null && student != null)
            {
                StudentManager.AddClass(student, classSection);
            }
        }

        [HttpPut]
        public void SaveStudent(IStudent student)
        {
            if (student != null)
            {
                StudentManager.Save(student);
            } 
        }
 
    }
}
