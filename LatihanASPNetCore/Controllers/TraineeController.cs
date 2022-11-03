using LatihanASPNetCore.BusinessLogic;
using LatihanASPNetCore.Core;
using LatihanASPNetCore.Model;
using LatihanASPNetCore.Model.BodyRequest;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LatihanASPNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly TraineeBusinessLogic traineeBusineesLogic;

        public TraineeController(IConfiguration configuration)
        {
            traineeBusineesLogic = new TraineeBusinessLogic(configuration);
        }

        // GET: api/<TraineeController>
        [HttpGet]
        public ActionResult<ApiResponse<List<Trainee>>> Get()
        {
            ApiResponse<List<Trainee>> response = new ApiResponse<List<Trainee>>();

            try
            {
                List<Trainee> trainees = traineeBusineesLogic.GetTrainees();

                response.Message = "Success";
                response.StatusCode = StatusCodes.Status200OK;
                response.Data = trainees;
            }
            catch (InternalServerErrorException e)
            {
                response.Message = e.Message;
                response.StatusCode = StatusCodes.Status500InternalServerError;
            } 
            catch (NotFoundException e)
            {
                response.Message = e.Message;
                response.StatusCode = StatusCodes.Status404NotFound;
            } 
            catch (Exception e)
            {
                response.Message = e.Message;
                response.StatusCode = StatusCodes.Status400BadRequest;
            }

            return StatusCode((int)response.StatusCode, response);
        }

        // GET api/<TraineeController>/5
        [HttpGet("{traineeId}")]
        public ActionResult<ApiResponse<Trainee>> Get(int traineeId)
        {
            ApiResponse<Trainee> response = new ApiResponse<Trainee>();

            try
            {
                Trainee trainee = traineeBusineesLogic.GetTraineeById(traineeId);

                response.Message = "Success";
                response.StatusCode = StatusCodes.Status200OK;
                response.Data = trainee;
            }
            catch (InternalServerErrorException e)
            {
                response.Message = e.Message;
                response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            catch (NotFoundException e)
            {
                response.Message = e.Message;
                response.StatusCode = StatusCodes.Status404NotFound;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.StatusCode = StatusCodes.Status400BadRequest;
            }

            return StatusCode((int)response.StatusCode, response);
        }

        // POST api/<TraineeController>
        [HttpPost]
        public ActionResult<ApiResponse<string>> Post([FromBody] TraineeBodyRequest bodyRequest)
        {
            ApiResponse<string> response = new ApiResponse<string>();

            try
            {
                traineeBusineesLogic.PostTrainee(bodyRequest);

                response.Message = "Success";
                response.StatusCode = StatusCodes.Status201Created;
                response.Data = "Berhasil menambah data trainee";
            }
            catch (InternalServerErrorException e)
            {
                response.Message = e.Message;
                response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            catch (NotFoundException e)
            {
                response.Message = e.Message;
                response.StatusCode = StatusCodes.Status404NotFound;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.StatusCode = StatusCodes.Status400BadRequest;
            }

            return StatusCode((int)response.StatusCode, response);
        }

        // PUT api/<TraineeController>/5
        [HttpPut("{traineeId}")]
        public ActionResult<ApiResponse<string>> Put(int traineeId, [FromBody] TraineeBodyRequest bodyRequest)
        {
            return StatusCode(StatusCodes.Status202Accepted);
        }

        // DELETE api/<TraineeController>/5
        [HttpDelete("{traineeId}")]
        public ActionResult<ApiResponse<string>> Delete(int id)
        {
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
