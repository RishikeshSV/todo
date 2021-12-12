using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetTodoModel()
        {
            return await _context.TodoModel
                .OrderBy(o=>o.status)
                .ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> GetTodoModel(int id)
        {
            var todoModel = await _context.TodoModel.FindAsync(id);

            if (todoModel == null)
            {
                return NotFound();
            }

            return todoModel;
        }

        // PUT: api/Todo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoModel(int id, TodoModel todoModel)
        {
            if (id != todoModel.id)
            {
                return BadRequest();
            }

            _context.Entry(todoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Todo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoModel>> PostTodoModel(TodoModel todoModel)
        {
            _context.TodoModel.Add(todoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoModel", new { id = todoModel.id }, todoModel);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoModel(int id)
        {
            var todoModel = await _context.TodoModel.FindAsync(id);
            if (todoModel == null)
            {
                return NotFound();
            }

            _context.TodoModel.Remove(todoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //GET: api/Todo/done
        [Route("done")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetCompletedTodo()
        {
            return await _context.TodoModel
                .Where(task => task.status == true)
                .ToListAsync();
        }
        //GET: api/Todo/notdone
        [Route("notdone")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetNotCompletedTodo()
        {
            return await _context.TodoModel
                .Where(task => task.status == false)
                .ToListAsync();
        }

        private bool TodoModelExists(int id)
        {
            return _context.TodoModel.Any(e => e.id == id);
        }
    }
}
