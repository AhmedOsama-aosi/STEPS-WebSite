using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NuGet.Packaging.Signing;
using StepsWebApp.Data;
using StepsWebApp.Models;

namespace StepsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       private readonly StepsContext _context;

        public ValuesController(StepsContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> Get()
        {
            return Ok(await _context.Articles.ToListAsync());
        }

        [HttpGet("test")]
        public async Task<ActionResult> test()
        {
            return Ok(new { message = "ok" });
        }

        [HttpGet("id")]
        
        public async Task<ActionResult<Article>> GetById([FromBody] Article ars)
        {
            Article ar = await _context.Articles.FirstOrDefaultAsync(a => a.Id == ars.Id);
            if (ar == null || ar.Discription == null)
                return BadRequest("not found");
            return Ok(ar);

        }
        [HttpPost]
        public ActionResult Post([FromBody] Article article)
        {
            _context.Articles.Add(article);
            return CreatedAtAction("GetById",new {id = article.Id},article);
        }

        [HttpPut]
        public async Task<ActionResult>Put(Article article)
        {
            Article? ar = await _context.Articles.FirstOrDefaultAsync(a =>a.Id == article.Id);
            ar.Btn = article.Btn;
            ar.Discription = article.Discription;
            ar.PhotoLink = article.PhotoLink;
           await _context.SaveChangesAsync();
            return Ok( ar);
        }



        // ------application ------
        [HttpGet(TheEndpoint.stationStatus )]
        public async Task<ActionResult<StationStatus>> GetUserConsumptionData([FromBody] StationStatus _stationStatus)
        {
            StationStatus stationStatus = null;
           List< StationStatus >listStationStatus = new List<StationStatus>();
            if (_stationStatus.Id != null)
            {
                if (_stationStatus.Date != null)
                {
                    if(_stationStatus.Time != null)
                    {
                         stationStatus = await _context.StationStatuses.FirstOrDefaultAsync(S => S.SystemId == _stationStatus.Id && S.Date == _stationStatus.Date && S.Time == _stationStatus.Time);

                    }
                    else
                    {
                        listStationStatus =  _context.StationStatuses.Where(S => S.SystemId == _stationStatus.Id && S.Date == _stationStatus.Date).ToList();

                    }
                }
                else
                {
                    listStationStatus =  _context.StationStatuses.Where(S => S.SystemId == _stationStatus.Id).ToList();

                }
            }
           
            if (stationStatus == null && listStationStatus.Count ==0)
                return BadRequest("not found");
            if(stationStatus == null)
            {
                return Ok(listStationStatus);

            }
            else 
            {
                return Ok(stationStatus);

            }

        }
        [HttpPost( TheEndpoint.stationStatus )]
        public async Task<ActionResult> PostUserConsumptionData([FromBody] StationStatus _stationStatus)
        {
            _context.StationStatuses.Add(_stationStatus);
            _context.SaveChanges();

            return Ok( _stationStatus);
        }

        [HttpGet(TheEndpoint.solarPanelsOutput)]

        public async Task<ActionResult<SolarPanelsOutput>> GetSolarPanelsOutput([FromBody] SolarPanelsOutput _solarPanelsOutput)
        {
            SolarPanelsOutput solarPanelsOutput = await _context.SolarPanelsOutput.FirstOrDefaultAsync(a => a.Id == _solarPanelsOutput.Id);
            if (solarPanelsOutput == null )
                return BadRequest("not found");
            return Ok(solarPanelsOutput);

        }
        [HttpPost(TheEndpoint.solarPanelsOutput)]
        public async Task<ActionResult> PostSolarPanelsOutput([FromBody] SolarPanelsOutput _solarPanelsOutput)
        {
            _context.SolarPanelsOutput.Add(_solarPanelsOutput);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSolarPanelsOutput", new { id = _solarPanelsOutput.Id }, _solarPanelsOutput);
        }


    }
}
