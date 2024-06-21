﻿using ActionMethods.BusinessLogic;
using ActionMethods.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ActionMethods.Controllers
{
    /// <summary>
    /// Controller for handling novel-related HTTP requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLNovelController : ControllerBase
    {
        #region Private Member

        /// <summary>
        /// Declare instance of BLNovel class
        /// </summary>
        private BLNovel _objNovel;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize instance of BLNovel class
        /// </summary>
        public CLNovelController()
        {
            _objNovel = new BLNovel();
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves novels asynchronously after a delay of 5 seconds.
        /// </summary>
        [HttpGet]
        [Route("GetAsyncData")]
        public async Task<IActionResult> GetAsyncData()
        {
            // Simulating asynchronous operation
            await Task.Delay(5000);

            return Ok(_objNovel.GetNovels());
        }

        /// <summary>
        /// Returns a HttpResponseMessage with JSON content representing novels.
        /// </summary>
        [HttpGet]
        [Route("GetHttpResponse")]
        public HttpResponseMessage GetHttpResponse()
        {
            string jsonContent = JsonSerializer.Serialize(_objNovel.GetNovels());

            // Create a HttpResponseMessage with the JSON content
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json")
            };

            return response;
        }

        /// <summary>
        /// Retrieves data as an ObjectResult.
        /// </summary>
        [HttpGet]
        [Route("GetObjectResult")]
        public ObjectResult GetObjectResult()
        {
            // Return the list of novels as an ObjectResult with HTTP status code 200 (OK)
            return new ObjectResult(_objNovel.GetNovels()) { StatusCode = StatusCodes.Status200OK };
        }

        /// <summary>
        /// Retrieves data as a ContentResult containing JSON.
        /// </summary>
        [HttpGet]
        [Route("GetContentResult")]
        public ContentResult GetContentResult()
        {
            // Serialize the list of novels to JSON format
            string jsonContent = JsonSerializer.Serialize(_objNovel.GetNovels());

            // Return the content with JSON format
            return Content(jsonContent, "application/json");

            // Note: the commented code below returns the type of list only, not the list's content
            // return Content(_objNovel.GetNovels().ToString(), "text/plain");
        }

        /// <summary>
        /// Redirects to the endpoint for retrieving novels.
        /// </summary>
        [HttpGet]
        [Route("GetRedirectResult")]
        public RedirectResult GetRedirectResult()
        {
            // Redirect to the endpoint for retrieving novels
            return Redirect("/api/CLNovel/GetNovels");
        }

        /// <summary>
        /// Retrieves data as a JsonResult.
        /// </summary>
        [HttpGet]
        [Route("GetJsonResult")]
        public JsonResult GetJsonResult()
        {
            // Return the data as a JsonResult
            return new JsonResult(_objNovel.GetNovelById(1));
        }

        /// <summary>
        /// Returns an Excel file containing the list of novels.
        /// </summary>
        [HttpGet]
        [Route("GetNovelsExcel")]
        public IActionResult GetNovelsExcel()
        {
            var stream = _objNovel.GenerateNovelsExcel();
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "Novels.xlsx";
            return File(stream, contentType, fileName);
        }

        /// <summary>
        /// Returns a JavaScript file containing novel-related functions.
        /// </summary>
        [HttpGet]
        [Route("GetJavaScriptFile")]
        public IActionResult GetJavaScriptFile()
        {
            try
            {
                var fileContent = _objNovel.GetJavaScriptFileContent();
                var contentType = "application/javascript";
                var fileName = "novels.js";
                return File(fileContent, contentType, fileName);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the content of the "novels.js" script file and returns it as a JavaScript result.
        /// </summary>
        /// <returns>A JavaScriptResult containing the content of the "novels.js" script file.</returns>
        [HttpGet]
        [Route("GetNovelScript")]
        public JavaScriptResult GetNovelScript()
        {
            string scriptPath = Path.Combine(Directory.GetCurrentDirectory(), "File", "novels.js");
            string scriptContent = System.IO.File.ReadAllText(scriptPath);
            return new JavaScriptResult(scriptContent);
        }

        /// <summary>
        /// Retrieves a list of novels.
        /// </summary>
        [HttpGet]
        [Route("GetNovels")]
        public IActionResult GetNovels()
        {
            return Ok(_objNovel.GetNovels());
        }

        [HttpGet]
        [Route("GetNovelById")]
        public IActionResult GetNovelsById(int id)
        {
            return Ok(_objNovel.GetNovelById(id));
        }

        /// <summary>
        /// Adds a new novel to the List.
        /// </summary>
        /// <param name="objNVL01">The novel object to add.</param>
        [HttpPost]
        [Route("AddNovel")]
        public IActionResult AddNovel([FromBody] NVL01 objNVL01)
        {
            if (_objNovel.Validation(objNVL01))
            {
                return Ok(_objNovel.AddNovel(objNVL01));
            }
            return BadRequest("Invalid data");
        }

        /// <summary>
        /// Updates an existing novel's data.
        /// </summary>
        /// <param name="objNVL01">The updated novel object.</param>
        [HttpPut]
        [Route("UpdateNovelData")]
        public IActionResult UpdateNovel([FromBody] NVL01 objNVL01)
        {
            if (_objNovel.Validation(objNVL01))
            {
                var result = _objNovel.UpdateNovel(objNVL01);
                if (result == null)
                {
                    return NotFound("Object with given id is not found");
                }
                else
                {
                    return Ok(result);
                }
            }
            return BadRequest("Invalid data");
        }

        /// <summary>
        /// Deletes a novel from the List.
        /// </summary>
        /// <param name="id">The ID of the novel to delete.</param>
        [HttpDelete]
        [Route("DeleteNovel")]
        public IActionResult DeleteNovel(int id)
        {
            var result = _objNovel.DeleteNovel(id);
            if (result == null)
            {
                return NotFound("Object with given id is not found");
            }
            else
            {
                return Ok(result);
            }
        }

        #endregion
    }
}
