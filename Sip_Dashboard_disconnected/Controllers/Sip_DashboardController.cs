using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sip_Dashboard_disconnected.Dtos;
using Sip_Dashboard_disconnected.Interfcaes;

namespace Sip_Dashboard_disconnected.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sip_DashboardController : ControllerBase
    {
       public readonly ISipDashboardServices _sipdashboardservices;
        public Sip_DashboardController(ISipDashboardServices sipdashboardservices)
        {
            this._sipdashboardservices = sipdashboardservices;
        }
        //  [HttpGet]
        // [Route ("AddSip_dashboard")]
        [HttpPost(Name = "AddSip_dashboard")]
        public async Task<IActionResult> Post([FromBody] Sip_DashboardDtos sipdashboarddtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var sipdata = await _sipdashboardservices.AddSip_dashboard(sipdashboarddtoobj);
                return StatusCode(StatusCodes.Status200OK, "record added sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server error");
            }

        }
        [HttpDelete(Name = "DeleteSip_dashboardByPosition/{position}")]
        //        [HttpDelete]
       // [Route("DeleteBookingDetilsById/{id}")]

        public async Task<IActionResult> Delete(int position)
        {
            if (position < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var sipdashdata = await _sipdashboardservices.DeleteSip_dashboard(position);
                if (sipdashdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "position not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, "position is deleted succesfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
       [HttpGet(Name = "GetSip_dashboard")]
        public async Task<IActionResult> GetSip_dashboard()
        {
            try
            {
                var sipdata = await _sipdashboardservices.GetSip_dashboard();
                if (sipdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, sipdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        // [HttpGet(Name = "GetSipdashboardByPosition/{position}")]
        //        [Route("GetBookingDetailsById/{id}")]
        [HttpGet]
        [Route("GetSip_dashboardByPosition/{position}")]

        public async Task<IActionResult> Get(int position)
        {
            if (position < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var getsip = await _sipdashboardservices.GetSip_dashboardByPosition(position);
                if (getsip == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "sip position not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, getsip);
                }
            }
            catch (Exception ex)

            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
       [HttpPut(Name = "UpdateSip_dashboard")]
        public async Task<IActionResult> Put([FromBody] Sip_DashboardDtos sipdashboardobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _sipdashboardservices.UpdateSip_dashboard(sipdashboardobj);
                return StatusCode(StatusCodes.Status201Created, "sipdashboard Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}
