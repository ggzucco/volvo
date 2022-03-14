using Microsoft.AspNetCore.Mvc;
using volvo.Shared;
using volvo.BLL;

namespace volvo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelVehicleController : ControllerBase
    {
       
        private readonly ILogger<ModelVehicleController> _logger;

        public ModelVehicleController(ILogger<ModelVehicleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ModelVehicleShared> Get()
        {
            ModelVehicleBLL models = new ModelVehicleBLL();
            return models.GetAll();
        }
    }
}