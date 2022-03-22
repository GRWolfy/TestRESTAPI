using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestRESTAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class Test1Controller : ControllerBase
   {
      private static List<Test1> heroes = new List<Test1> {
            new Test1 { Id = 1,
            Name ="Spider Man",
            Firstname = "Peter",
            Lastname = "Parker",
            Place = "NY"
         },
            new Test1 { 
            Id = 2,
            Name ="Ironman",
            Firstname = "Tony",
            Lastname = "Stark",
            Place = "Somewhere Island"
         }
      };


      [HttpGet]
      public async Task<ActionResult<List<Test1>>> Get() {
         return Ok(heroes);
      }

      //Search method. The Route has a parameter ID.
      [HttpGet("{id}")]
      public async Task<ActionResult<Test1>> Get(int id)
      {
         var hero = heroes.Find(h => h.Id == id);
         if (hero == null)
            return BadRequest("Hero not found.");
         return Ok(hero);
      }

      [HttpPost]
      public async Task<ActionResult<List<Test1>>> AddHero(Test1 hero) {
         heroes.Add(hero);
         return Ok(heroes);
      }

      [HttpPut]
      public async Task<ActionResult<List<Test1>>> UpdateHero(Test1 request)
      {
         var hero = heroes.Find(h => h.Id == request.Id);
         if (hero == null)
            return BadRequest("Hero not found.");

         hero.Name = request.Name;
         hero.Firstname = request.Firstname;
         hero.Lastname = request.Lastname;
         hero.Place = request.Place;

         return Ok(heroes);
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult<Test1>> Delete(int id)
      {
         var hero = heroes.Find(h => h.Id == id);
         if (hero == null)
            return BadRequest("Hero not found.");
         heroes.Remove(hero);
         return Ok(heroes);
      }
   }
}
