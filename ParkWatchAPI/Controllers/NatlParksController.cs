using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkWatchApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ParkWatchApi.Controllers
{
[Route("api/[controller]")]
  [ApiController]
  public class NatlParksController : ControllerBase
  {
    private ParkWatchApiContext _db;

    public NatlParksController(ParkWatchApiContext db)
    {
      _db = db;
    }

    // GET api/NatlParks
    [HttpGet]
    public ActionResult<IEnumerable<NatlPark>> Get()
    {
      return _db.NatlParks.ToList();
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
    public ActionResult<NatlPark> Get(int id)
    {
      return _db.NatlParks.FirstOrDefault(entry=>entry.NatlParkId == id);
    }

    //PUT api/natlpark/3
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] NatlPark natlPark )
    {
      natlPark.NatlParkId = id;
      _db.Entry(natlPark).State = EntityState.Modified;
      _db.SaveChanges();
    }
  }
}