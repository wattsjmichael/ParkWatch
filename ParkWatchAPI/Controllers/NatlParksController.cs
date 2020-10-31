using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkWatchApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ParkWatchApi.Helpers;

namespace ParkWatchApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NatlParksController : ControllerBase
  {
    private ParkWatchApiContext _db;
    private readonly IUriService uriService;

    public NatlParksController(ParkWatchApiContext db, IUriService uriService)
    {
      _db = db;
      this.uriService = uriService;
    }

    // GET api/NatlParks
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter, string natlParkState, string natlParkCity, int? natlParkCampingSpots, bool? isOpenNatl)
    {
      var route = Request.Path.Value;
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var query = _db.NatlParks.AsQueryable();
      if (natlParkState != null)
      {
        query = query.Where(entry => entry.NatlParkState == natlParkState);
      }
      if (natlParkCity != null)
      {
        query = query.Where(entry => entry.NatlParkCity == natlParkCity);
      }
      if (natlParkCampingSpots != null)
      {
        query = query.Where(entry => entry.NatlParkCampingSpots == natlParkCampingSpots);
      }
      if (isOpenNatl != null)
      {
        query = query.Where(entry => entry.IsOpenNatl == isOpenNatl);
      }
      query = query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
      .Take(validFilter.PageSize);
      var totalRecords = await _db.NatlParks.CountAsync();
      var pagedResponse = PaginationHelper.CreatePagedReponse<NatlPark>(query.ToList(), validFilter, totalRecords, uriService, route);
      return Ok(pagedResponse);
    }

    // POST api/natlparks
    [HttpPost]
    public void Post([FromBody] NatlPark natlPark)
    {
      _db.NatlParks.Add(natlPark);
      _db.SaveChanges();
    }

    //GET by Id Api/natlparks/2
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var natlPark = await _db.NatlParks.Where(x => x.NatlParkId == id).FirstOrDefaultAsync();
      return Ok(new Response<NatlPark>(natlPark));
    }

    //PUT api/natlparks/3
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] NatlPark natlPark)
    {
      natlPark.NatlParkId = id;
      _db.Entry(natlPark).State = EntityState.Modified;
      _db.SaveChanges();
    }

    //Delete api/natlparks/2
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var natlParkToDelete = _db.NatlParks.FirstOrDefault(entry => entry.NatlParkId == id);
      _db.NatlParks.Remove(natlParkToDelete);
      _db.SaveChanges();
    }

    //Get api/natlparks/random
    [HttpGet("random")]
    public ActionResult<NatlPark> Get()
    {
      int count = _db.NatlParks.Count();
      int index = new Random().Next(count);
      return _db.NatlParks.Skip(index).FirstOrDefault();
    }
  }
}