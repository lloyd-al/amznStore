using Microsoft.AspNetCore.Mvc;
using System;
using Serilog;

namespace amznStore.Services.Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RootController : ControllerBase
    {
        protected readonly ILogger _logger;

        public RootController(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
