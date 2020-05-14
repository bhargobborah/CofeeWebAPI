using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CofeeApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CofeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly CofeeDbContext _cofeeDbContext;

        public MenuController(CofeeDbContext cofeeDbContext)
        {
            _cofeeDbContext = cofeeDbContext;
        }

        [HttpGet]
        public IActionResult GetMenus()
        {
            var menus = _cofeeDbContext.Menus.Include("SubMenus");
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenu(int id)
        {
            var menu = _cofeeDbContext.Menus.Include("SubMenus").FirstOrDefault(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }
    }
}