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
    /// Controller for state which is handel method calling
    /// </summary>
    public class StateController : ApiController
    {
        private Cache _objCache = new Cache();
        private static Stopwatch _stopwatch;

        public StateController()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        [HttpGet]
        [Route("api/State/FetchStateData")]
        public IHttpActionResult FetchStateData()
        {
            
            List<State> statedata;
            if (_objCache["Cached data"] != null)
            {
                 statedata = (List<State>)_objCache.Get("Cached data");
            }
            else
            {
                // Retrieves state data from the data source.
                statedata = StateData.RetriveState();

                _objCache.Insert("Cached data", statedata, null, DateTime.Now.AddMinutes(20), TimeSpan.Zero);
            }
            _stopwatch.Stop();
            long responseTime = _stopwatch.ElapsedTicks;
            HttpContext.Current.Response.AddHeader("Response-time", responseTime.ToString());
            //HttpContext.Current.Response.AddHeader("Cache-control",);

            // Returns an HTTP response with the retrieved state data.
            return Ok(statedata);
        }
    }
}
