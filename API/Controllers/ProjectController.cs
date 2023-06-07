using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;

        public ProjectController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    

        [HttpGet]
        [Route("GetProject")]

        public async Task<IEnumerable<Projects>> GetProjects()
        {
            return await _appDbContext.Projects.ToArrayAsync();
        }

        [HttpPost]
        [Route("AddProjects")]

        public async Task<Projects> AddProjects(Projects objProject)
        {
        _appDbContext.Projects.Add(objProject);
            await _appDbContext.SaveChangesAsync();
            return objProject;

        }


        [HttpPatch]
        [Route("(UpdateProjects/{id}")]

        public async Task<Projects> UpdateProjects(Projects objproject)
        {

            _appDbContext.Entry(objproject).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return objproject;

        }

        [HttpDelete]
        [Route("DeleteProjects/{id}")]

        public bool DeleteProjects(int id) 
        {
            bool a = false;
            var project = _appDbContext.Projects.Find(id);
            if (project != null) 
            {
                a= true;
                _appDbContext.Entry(project).State = EntityState.Deleted;
                _appDbContext.SaveChanges();

            }

            else
            {
                a = false;
            }
            return a;
        
        }

    }
}
