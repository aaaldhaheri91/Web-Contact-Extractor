using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Web_Contact_Extractor.Controllers
{
    public class BaseApiController : ControllerBase
    {
        ///<summary>
        /// Provide 204 response
        ///</summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult OKNoContent()
        {
            return base.StatusCode(StatusCodes.Status204NoContent);
        }

        ///<summary>
        /// Provide 403 response
        ///</summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Forbidden(string msg) 
        {
            return base.StatusCode(StatusCodes.Status403Forbidden, msg);
        }

        ///<summary>
        /// Provide 403 response
        ///</summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult NotFound(string msg)
        {
            return base.StatusCode(StatusCodes.Status404NotFound, msg);
        }        

        ///<summary>
        /// Provide 500 response
        ///</summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult InternalServerError(string msg) 
        {
            return base.StatusCode(StatusCodes.Status500InternalServerError, msg);
        }

        ///<summary>
        /// Provide 500 response
        ///</summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult InternalServerError(Exception ex) 
        {
            return base.StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
        
        ///<summary>
        /// Provide 401 response
        ///</summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Unauthorized(string msg) 
        {
            return base.StatusCode(StatusCodes.Status401Unauthorized, msg);
        }
    }
}