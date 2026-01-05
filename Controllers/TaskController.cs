using Microsoft.AspNetCore.Mvc; // Importing necessary ASP.NET Core MVC functionalities
using TaskMasterAPI.Services; // Importing the namespace where TaskDataStore is defined

namespace TaskMasterAPI.Controllers;

[ApiController] // This attribute indicates that the class is an API controller
[Route("api/[controller]")] // This sets the base route for the controller to "api/task"
public class TaskController : ControllerBase // Inheriting from ControllerBase to gain access to controller functionalities no view support
{
    [HttpGet] // This attribute maps GET requests to this method
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

    [HttpPost] // This attribute maps POST requests to this method
    public ActionResult<Models.Task> CreateTask(Models.TaskInsert taskInsert)
    {
        if(taskInsert.Title == string.Empty  || taskInsert.Title == null)
        {
            return BadRequest("El título de la tarea no puede estar vacío."); // Returning a 400 Bad Request response if the title is empty
        }

        if(taskInsert.Description == string.Empty || taskInsert.Description == null)
        {
            return BadRequest("La descripción de la tarea no puede estar vacía."); // Returning a 400 Bad Request response if the description is empty
        }

        var newTask = new Models.Task
        {
            Id = TaskDataStore.Current.Tasks.Max(t => t.Id) + 1, // Generating a new ID for the task
            CreatedAt = DateTime.Now, // Setting the creation date to the current date and time
            UpdatedAt = DateTime.Now, // Setting the updated date to the current date and time
            IsCompleted = false,    // New tasks are not completed by default           
            Title = taskInsert.Title, // Setting the title from the input model
            Description = taskInsert.Description, // Setting the description from the input model
        };

        try
        {    
            TaskDataStore.Current.Tasks.Add(newTask); // Adding the new task to the data store
            return Ok(newTask); // Returning a 200 OK response with the newly created task
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}"); // Returning a 500 Internal Server Error response in case of an exception
        }
    }
}
