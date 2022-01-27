using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using perpustakaan.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perpustakaan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenisController : ControllerBase
    {
        private readonly JenisRepository jenis;
        private readonly string conn;
        private readonly ResponseRepository res;
        public JenisController(JenisRepository _jenis, ConnectionString connection, ResponseRepository _res)
        {
            jenis = _jenis;
            conn = connection.Value;
            res = _res;
        }
        [HttpGet("GetJenis")]
        public IActionResult GetAllJenis()
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
                var result = jenis.GetAllJenis();
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
        [HttpGet("GetDropJenis")]
        public IActionResult GetDropJenis()
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
                var result = jenis.GetAllJenis();
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
    }
}
