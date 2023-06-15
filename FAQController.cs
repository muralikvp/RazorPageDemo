using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPageDemo.Models;

namespace RazorPageDemo
{
    [Route("api/[controller]")]
    public class FAQController : Controller
    {
        private readonly HTContext _context;

        public FAQController(HTContext context)
        {
            _context = context;
        }

        [Route("GetAllFaq")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FAQ>>> GetFAQ()
        {
            if (_context.FAQ == null)
            {
                return NotFound();
            }
            //select * from FAQ
            //Convert into FAQ list of Objects
            return await _context.FAQ.ToListAsync();
        }
        public ActionResult<FAQ> getRecord(int id)
        {
            if (_context.FAQ == null)
            {
                return NotFound();
            }
            //select * from FAQ where id = 12;
            var fAQ = _context.FAQ.Find(id);
            if (fAQ == null)
            {
                return NotFound();
            }
            return fAQ;
        }

        [Route("InsertFAQ")]
        [HttpPost]
        public ActionResult<FAQ> InsertFAQ(FAQ fAQ)
        {
            if (_context.FAQ == null)
            {
                return Problem("Entity set 'HTContext.FAQ'  is null.");
            }
            //insert into FAQ Values('Test','POlo');
            _context.FAQ.Add(fAQ);
            _context.SaveChanges();
            return CreatedAtAction("GetFAQ", new { id = fAQ.id }, fAQ);
        }

       

    }
}
