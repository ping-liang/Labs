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
    public class SitesController : ApiController
    {
        /// <summary>
        /// Get a list of available sites
        /// </summary>
        /// <returns>An ISite instance</returns>
        [HttpGet]
        public IEnumerable<ISite> GetAllSites()
        {
            return SiteManager.List();
        }

        /// <summary>
        /// Get site by site Id
        /// </summary>
        /// <param name="id">Site Id</param>
        /// <returns>An ISite instance</returns>
        [HttpGet]
        public ISite GetSiteById(string id)
        {
            return SiteManager.Get(id); 
        }

        /// <summary>
        /// Search site by site name
        /// </summary>
        /// <param name="name">Site Name</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ISite> SearchSiteByName(string name)
        {
            return SiteManager.Search(name);
        }

        /*
        public IEnumerable<IClass> GetClassesBySite(string id)
        {
            var site = SiteManager.Get(id);
            if (site != null)
            {
                return ClassManager.List(site);
            }

            return null;

        }
         */

    }
}