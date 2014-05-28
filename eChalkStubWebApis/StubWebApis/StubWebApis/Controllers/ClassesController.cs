using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Http;
using StubModel.Managers;
using StubModel.Models;

namespace StubWebApis.Controllers
{
    public class ClassesController : ApiController
    {
        /// <summary>
        ///Get all classes of a site
        /// </summary>
        /// <param name="siteId">Site ID</param>
        /// <returns>IClass instance</returns>
        [HttpGet]
        [ActionName("SiteClasses")]
        public IEnumerable<IClass> GetSiteClasses(string siteId)
        {
            var site = SiteManager.Get(siteId);

            if (site != null)
            {
                return ClassManager.List(site);
            }

            return null;
        }
      
        /// <summary>
        /// Get a class by Id
        /// </summary>
        /// <param name="id">Class Id</param>
        /// <returns>IClass instance</returns>
        [HttpGet]
        [ActionName("GetClass")]
        public IClass Get(string id)
        {
            return ClassManager.Get(id);
        }

        /// <summary>
        /// Search classes in a particular site based on class name
        /// </summary>
        /// <param name="siteId">Site Id</param>
        /// <param name="className">Class Name. Accept partical class name</param>
        /// <returns>IClass instance</returns>
        [HttpGet]
        public IEnumerable<IClass> Search(string siteId, string className)
        {
            var site = SiteManager.Get(siteId);

            if (site != null)
            {
                return ClassManager.Search(site, className);
            }

            return null;
        }

        /// <summary>
        /// Add a student to a class
        /// </summary>
        /// <param name="siteId">Site Id</param>
        /// <param name="classId">Class Id</param>
        /// <param name="studentId">Student User Id</param>
        [HttpPost]
        public void AddStudentToClass(string siteId, string classId, string studentId)
        {
            var site = SiteManager.Get(siteId);
            IStudent student = default(IStudent);
            IClass classSection = default(IClass);

            if (site != null)
            {
                student = StudentManager.Get(site, studentId);
            }

            if (site != null && student != null)
            {
                classSection = ClassManager.Get(classId);
            }

            if (student != null && classSection != null)
            {
                ClassManager.AddStudent(classSection, student);
            }
        }
        
    }
}