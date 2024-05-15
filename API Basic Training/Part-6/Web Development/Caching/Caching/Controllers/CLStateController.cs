using Caching.Data;
using Caching.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Caching;
using System.Web.Http;

namespace Caching.Controllers
{
    /// <summary>
    /// Controller for state which is handle method calling
    /// </summary>
    public class CLStateController : ApiController
    {
        #region Private Member

        /// <summary>
        /// Private Instance of Cache class.
        /// </summary>
        private Cache _objCache = new Cache();

        /// <summary>
        /// Create instance of Stopwatch.
        /// </summary>
        private static Stopwatch _stopwatch;

        /// <summary>
        /// Instance of BLStateData Class.
        /// </summary>
        private BLStateData _objBlStateData = new BLStateData();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for initialize stopwatch object.
        /// </summary>
        public CLStateController()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Give list of State from cache if its already store otherwise store it in cache and retrive.
        /// </summary>
        /// <returns>list of State.</returns>
        [HttpGet]
        [Route("api/State/FetchStateData")]
        public IHttpActionResult FetchStateData()
        {
            List<State> statedata;

            if (_objCache["Cached data"] != null)
            {
                //retive data from cache.
                 statedata = (List<State>)_objCache.Get("Cached data");
            }
            else
            {
                // Retrieves state data from the data source.
                statedata = _objBlStateData.RetriveState();

                _objCache.Insert("Cached data", statedata, null, DateTime.Now.AddMinutes(20), TimeSpan.Zero);
            }
            _stopwatch.Stop();
            long responseTime = _stopwatch.ElapsedTicks;
            HttpContext.Current.Response.AddHeader("Response-time", responseTime.ToString());
            //HttpContext.Current.Response.AddHeader("Cache-control",);

            // Returns an HTTP response with the retrieved state data.
            return Ok(statedata);
        }

        #endregion
    }
}