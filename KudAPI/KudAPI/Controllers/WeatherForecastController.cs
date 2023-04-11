using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace KudAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]

        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            for (int i = 0; i < Summaries.Count; i++)
            {
                if (string.Equals(name, Summaries[i]))
                { break; }
                else if (i + 1 == Summaries.Count && !string.Equals(name, Summaries[i]))
                {
                    Summaries.Add(name);
                }
                
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            Summaries.RemoveAt(index);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0|| index>= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!");
            }
            else
            {
                for (int i = 0; i < Summaries.Count; i++)
                {
                    if (string.Equals (name, Summaries[i]))
                    {
                        break;
                    }
                    else if (i + 1 == Summaries.Count && !string.Equals(name, Summaries[1]))
                    {
                        Summaries[index] = name;
                    }
                }
                return Ok();
            }
        }
       
        [HttpGet("{index}")]
       public string GetIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "Введенный текст неверный";
            }
            return Summaries[index];
        }

        [HttpGet ("find-by-name")]
        public int GetName(string name)
        {
            int a = 0;
            for (int i = 0; i < Summaries.Count; i++)
            {
                if (Summaries[i] == name)
                    a++;
            }
            return a;
        }
        [HttpGet("GetAll")]
        public List<string> GetAll(int Strategy)
        {
            if (Strategy == null)
                return Summaries;

            if (Summaries .Count == 1)
			{
                Summaries.Sort();
                return Summaries;
			}

            if (Strategy == -1)
			{
                Summaries.Sort();
                Summaries.Reverse();
                return Summaries;
			}
            return Summaries;
        }
    }
}
