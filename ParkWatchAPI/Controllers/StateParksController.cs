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
  public class StateParksController : ControllerBase
  {
    private ParkWatchApiContext _db;
    private readonly IUriService uriService;

    public StateParksController(ParkWatchApiContext db, IUriService uriService)
    {
      _db = db;
      this.uriService = uriService;
    }

    // GET api/stateparks
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter, string stateParkState, string stateParkCity, int? stateParkCampingSpots, bool? isOpenState)
    {
      var route = Request.Path.Value;
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var query = _db.StateParks.AsQueryable();
      if (stateParkState != null)
      {
        query = query.Where(entry => entry.StateParkState == stateParkState);
      }
      if (stateParkCity != null)
      {
        query = query.Where(entry => entry.StateParkCity == stateParkCity);
      }
      if (stateParkCampingSpots != null)
      {
        query = query.Where(entry => entry.StateParkCampingSpots == stateParkCampingSpots);
      }
      if (isOpenState != null)
      {
        query = query.Where(entry => entry.IsOpenState == isOpenState);
      }
      query = query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
      .Take(validFilter.PageSize);
      var totalRecords = await _db.StateParks.CountAsync();
      var pagedResponse = PaginationHelper.CreatePagedReponse<StatePark>(query.ToList(), validFilter, totalRecords, uriService, route);
      return Ok(pagedResponse);
    }


    // POST api/stateparks
    [HttpPost]
    public void Post([FromBody] StatePark statePark)
    {
      _db.StateParks.Add(statePark);
      _db.SaveChanges();
    }

    //Get Api/stateparks/2
      [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var statePark = await _db.StateParks.Where(x=>x.StateParkId == id).FirstOrDefaultAsync();
      return Ok(new Response<StatePark>(statePark));
    }
    //PUT api/stateparks/2
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] StatePark statePark)
    {
      statePark.StateParkId = id;
      _db.Entry(statePark).State = EntityState.Modified;
      _db.SaveChanges();
    }

    //DELETE api/stateparks/3
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var stateParkToDelete = _db.StateParks.FirstOrDefault(entry=>entry.StateParkId == id);
      _db.StateParks.Remove(stateParkToDelete);
      _db.SaveChanges();
    }
    //Random api/stateparks/Random
    [HttpGet("random")]
    public ActionResult<StatePark> Get()
    {
      int count = _db.StateParks.Count();
      int index = new Random().Next(count);
      return _db.StateParks.Skip(index).FirstOrDefault();
    }
  }
}