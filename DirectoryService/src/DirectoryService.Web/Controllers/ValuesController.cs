using CSharpFunctionalExtensions;
using DirectoryService.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult TestPatternResult(string name, string indent)
        //{
        //    Result<Department> departmentResult = Department.Create(name, indent);
        //    if (departmentResult.IsFailure)
        //        return BadRequest(departmentResult.Error);
        //    // or return ValidationProblem(); 

        //    var result = Save(departmentResult.Value);

        //    if (result.IsFailure)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok();

        //}

        //private Result Save(Department department)
        //{
        //    if (true)
        //    {
        //        return Result.Success(department);
        //    }
        //    else
        //    {
        //        return Result.Success(department);

        //    }
        //}

    }
}
