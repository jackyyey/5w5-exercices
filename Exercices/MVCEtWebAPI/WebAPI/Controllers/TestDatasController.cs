using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEtWebAPI.Data;
using Models.Models;
using Microsoft.AspNetCore.Authorization;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDatasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TestDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestData>>> GetTestData()
        {
            return await _context.TestData.ToListAsync();
        }

        // GET: api/TestDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestData>> GetTestData(int id)
        {
            var testData = await _context.TestData.FindAsync(id);

            if (testData == null)
            {
                return NotFound();
            }

            return testData;
        }
        [Authorize]
        [HttpPost("CreateData")]
        public async Task CreateData(CreateTestDataDTO ctd)
        {
            TestData test = new TestData { Name = ctd.Name };
            await _context.AddAsync(test);
            await _context.SaveChangesAsync();
        }
        private bool TestDataExists(int id)
        {
            return _context.TestData.Any(e => e.Id == id);
        }
    }
}
