using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TriFy.Car.Downloader.Dtos;

namespace TriFy.Car.Downloader.Controllers
{

    [Route("api/repuve")]
    public class RepuveController : CarDownloaderController
    {
        private readonly IRepuveAppService _repuveService;

        public RepuveController(IRepuveAppService repuveService)
        {
            _repuveService = repuveService;
        }

        /// <summary>
        /// Create a PDF file with HTML content
        /// </summary>
        /// <param name="content">Html content</param>
        /// <param name="filename">Filename</param>
        /// <returns>File</returns>
        [HttpPost("export")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK, MediaTypeNames.Application.Octet)]
        public async Task<IActionResult> Export([FromBody] RepuveFileInput input)
        {
            try
            {
 
                var outpùt = await _repuveService.ExportAsync(input, new CancellationToken());
                return File(outpùt.Buffer, MediaTypeNames.Application.Octet, outpùt.Filename);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
