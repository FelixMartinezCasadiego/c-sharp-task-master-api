using Microsoft.AspNetCore.Mvc; // Importing necessary ASP.NET Core MVC functionalities
using TaskMasterAPI.Services; // Importing the namespace where TaskDataStore is defined

namespace TaskMasterAPI.Controllers;

[ApiController] // This attribute indicates that the class is an API controller
[Route("api/[controller]")] // This sets the base route for the controller to "api/task"
public class TaskController : ControllerBase // Inheriting from ControllerBase to gain access to controller functionalities no view support
{
    [HttpGet]
    public ActionResult<IEnumerable<Models.Task>> GetAllTasks()
    {
        // Logic to retrieve all tasks would go here
        return Ok(TaskDataStore.Current.Tasks); // Returning a 200 OK response with the list of tasks
    }

    [HttpGet("{id}")] // This attribute maps GET requests with an "id" parameter to this method
    public ActionResult<Models.Task> GetTask(int id)
    {
        var task = TaskDataStore.Current.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound("La tarea no ha sido encontrada."); // Returning a 404 Not Found response if the task does not exist
        }
        return Ok(task); // Returning a 200 OK response with the requested task
    }
}
