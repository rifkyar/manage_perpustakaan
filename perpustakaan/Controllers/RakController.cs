using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using perpustakaan.Repositories;
using perpustakaan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perpustakaan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RakController : ControllerBase
    {
        private readonly RakRepository rak;
        private readonly string conn;
        private readonly ResponseRepository res;
        public RakController(RakRepository _rak, ConnectionString connection, ResponseRepository _res)
        {
            rak = _rak;
            conn = connection.Value;
            res = _res;
        }
        [HttpGet("GetAllRak")]
        public IActionResult GetAllRak()
        {
            SqlConnection konek = new SqlConnection(conn);
            try
            {
                konek.Open();
            }
            catch 
            {
                return StatusCode(500, res.ResponseMessage("500", "False", "There is no connection. Please contact your system Administrator!", null));
            }
            try
            {
                var result = rak.GetAllRak();
                if (result.Count > 0)
                {
                    return Ok(new { Code = "200", Status = "True", Message = "Berhasil tampil Data", Data = result });
                }
                return NotFound(res.ResponseMessage("404", "False", "tampil data gagal ", null));
            }
            catch (Exception e)
            {
                //Log.LogError($"Gagal Update data . Message : {e.Message}");
                return StatusCode(500, res.ResponseMessage("500", "False", e.Message, null));
            }
        }
        [HttpGet("GetRakPakai")]
        public IActionResult GetRakPakai()
        {
            SqlConnection konek = new SqlConnection(conn);
            try
            {
                konek.Open();
            }
            catch
            {
                return StatusCode(500, res.ResponseMessage("500", "False", "There is no connection. Please contact your system Administrator!", null));
            }
            try
            {
                var result = rak.GetRakPakai();
                if (result.Count > 0)
                {
                    return Ok(new { Code = "200", Status = "True", Message = "Berhasil tampil Data", Data = result });
                }
                return NotFound(res.ResponseMessage("404", "False", "tampil data gagal ", null));
            }
            catch (Exception e)
            {
                //Log.LogError($"Gagal Update data . Message : {e.Message}");
                return StatusCode(500, res.ResponseMessage("500", "False", e.Message, null));
            }
        }
        [HttpGet("GetDropRak")]
        public IActionResult GetDropRak()
        {
            SqlConnection konek = new SqlConnection(conn);
            try
            {
                konek.Open();
            }
            catch
            {
                return StatusCode(500, res.ResponseMessage("500", "False", "There is no connection. Please contact your system Administrator!", null));
            }
            try
            {
                var result = rak.GetAllRak();
                if (result.Count > 0)
                {
                    return Ok(result);
                }
                return NotFound(res.ResponseMessage("404", "False", "tampil data gagal ", null));
            }
            catch (Exception e)
            {
                //Log.LogError($"Gagal Update data . Message : {e.Message}");
                return StatusCode(500, res.ResponseMessage("500", "False", e.Message, null));
            }
        }
        [HttpPost("SaveRak")]
        public async Task<IActionResult> SaveRakAsync([FromBody] SaveRak value)
        {
            SqlConnection connection = new SqlConnection(conn);
            try
            {
                connection.Open();
            }
            catch
            {
                //Log.LogError($"Gagal Connect Ke Database.");
                return StatusCode(500, res.ResponseMessage("500", "False", "There is no connection. Please contact your system Administrator!", null));
            }
            try
            {
                
                var result = await rak.SaveRak(value);
                if (result > 0)
                {
                    return Ok(new { Code = "200", Status = "True", Message = "Berhasil Update Data", Data = result });
                }
                return NotFound(res.ResponseMessage("404", "False", "Update data gagal ", new { value.Value }));
            }
            catch (Exception e)
            {
                //Log.LogError($"Gagal Update data . Message : {e.Message}");
                return StatusCode(500, res.ResponseMessage("500", "False", e.Message, null));
            }

        }
    }
}
