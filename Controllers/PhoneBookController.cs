using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : Controller
    {

        /// <summary>
        /// GET /api/phonebook/all
        /// GET /api/phonebook/name/{name}
        /// GET /api/phonebook/number/{number}
        /// </summary>
        /// <returns></returns>
        /// 

        // List of phonebook entries
        List<PhoneBookEntry> phoneBook; 

        public PhoneBookController()
        {
            phoneBook = new List<PhoneBookEntry>();
            phoneBook.Add(new PhoneBookEntry() { Name = "Anna Mary", Number = "02938392834", Address = "24 Dublin Boulevard" });
            phoneBook.Add(new PhoneBookEntry() { Name = "John Paul", Number = "02938392835", Address = "25 Limerick Boulevard" });
            phoneBook.Add(new PhoneBookEntry() { Name = "George Kelly", Number = "02938392836", Address = "26 Galway Boulevard" });
        }

        // GET api/phonebook/all
        [HttpGet("all")]
        public IEnumerable<PhoneBookEntry> GetAllEntries()
        {
            var entries = phoneBook.OrderBy(e => e.Name);
            return entries;
        }

        // GET /api/phonebook/name/{name}
        [HttpGet("name/{name}")]
        public IEnumerable<PhoneBookEntry> GetEntriesForName(string name)
        {
            var entries = phoneBook.Where(e=>e.Name.ToUpper() == name.ToUpper());
            return entries;
        }

        //GET /api/phonebook/number/{number}
        [HttpGet("number/{number}")]
        public IActionResult GetEntriesForNumber(String number)
        {
            var entry = phoneBook.Where(e => e.Number.ToUpper() == number.ToUpper());
            if(entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }


    
    }
}
