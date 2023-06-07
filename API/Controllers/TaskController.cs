using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;

        public TaskController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet]
        [Route("GetTask")]

        public async Task<IEnumerable<TaskManage>> GetTask()
        {
            return await _appDbContext.TaskManage.ToArrayAsync();
        }

        [HttpPost]
        [Route("AddTasks")]

        public async Task<TaskManage> AddTasks(TaskManage objTask)
        {
            _appDbContext.TaskManage.Add(objTask);
            await _appDbContext.SaveChangesAsync();
            return objTask;

        }


        [HttpPatch]
        [Route("(UpdateTask/{id}")]

        public async Task<TaskManage> UpdateTask(TaskManage objTask)
        {

            _appDbContext.Entry(objTask).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return objTask;

        }

        [HttpDelete]
        [Route("DeleteTask")]

        public bool DeleteTask(int id)
        {
            bool a = false;
            var Taskmanage = _appDbContext.TaskManage.Find(id);
            if (Taskmanage != null)
            {
                a = true;
                _appDbContext.Entry(Taskmanage).State = EntityState.Deleted;
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