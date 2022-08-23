using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionerDetailModule.Models;
using PensionerDetailModule.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PensionerDetailModule.Controllers
{
    [Route("api/PensionerDetails")]
    [ApiController]
    [Authorize]
    public class PensionerDetailsController : ControllerBase
    {
        private readonly IPensionerDetailsRepository _pensionerDetailRepo;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PensionerDetailsController));

        public PensionerDetailsController(IPensionerDetailsRepository pensionerDetailRepo)
        {
            _pensionerDetailRepo = pensionerDetailRepo;
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetailsAsync()
        {
            //Console.WriteLine("Start CSV File Reading...");
            var path = @"C:\Users\912839\OneDrive - Cognizant\Desktop\PensionerDetails.csv";

            //Here We are calling function to read CSV file
            _log4net.Info(" Http Get Request From GetDetailsAsync method of: " + nameof(PensionerDetailsController));
            var resultData = await _pensionerDetailRepo.ReadCSVFile(path);

            _log4net.Info(" Return OK result From GetDetailsAsync method of: " + nameof(PensionerDetailsController));
            return Ok(resultData);
        }

        [HttpGet("[action]/{aadharNumber}")]
        public async Task<IActionResult> GetPensionerDetailAsync(string aadharNumber)
        {
            var path = @"C:\Users\912839\OneDrive - Cognizant\Desktop\PensionerDetails.csv";

            //Here We are calling function to read CSV file
            var resultData = await _pensionerDetailRepo.ReadCSVFile(path);

            _log4net.Info(" Http Get Pensioner Detail From GetPensionerDetailAsync method of: " + nameof(PensionerDetailsController));
            var pensionerDetail = resultData.FirstOrDefault(item => item.AadharNumber == aadharNumber);
            if (pensionerDetail != null && resultData.Any())
            {
                _log4net.Info(" Return OK result From GetPensionerDetailsAsync method of: " + nameof(PensionerDetailsController));
                return Ok(pensionerDetail);
            }
            _log4net.Warn(" Badrequest returned from Http GET Request From GetPensionerDetaiAsync method of: " + nameof(PensionerDetailsController));
            return BadRequest(new { message = "Aaadhar number is invalid" });
        }
    }
}
