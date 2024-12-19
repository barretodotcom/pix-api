using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PixApi.DTOs;
using PixApi.Services;

namespace PixApi.Controllers
{
    [Route("[controller]")]
    public class PixController : ControllerBase
    {
        private readonly IPixService _pixService;

        public PixController(IPixService pixService)
        {
            _pixService = pixService;
        }
 
        [HttpGet("[action]")]
        public IActionResult GenerateQRCode([FromQuery] QrCodeInput input)
        {
            return File(_pixService.GenerateQRCode(input), "image/png");
        }
    }
}