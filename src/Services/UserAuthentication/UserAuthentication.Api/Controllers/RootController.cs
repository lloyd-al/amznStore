using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace amznStore.Services.UserAuthentication.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RootController : ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        //public ApplicationUser applicationUser => (ApplicationUser)HttpContext.Items["ApplicationUser"];
        protected readonly ILogger _logger;
        public RootController(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
