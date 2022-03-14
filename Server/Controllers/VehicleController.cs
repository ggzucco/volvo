using Microsoft.AspNetCore.Mvc;
using volvo.Shared;
using volvo.BLL;

namespace volvo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(ILogger<VehicleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<VehicleShared> Get()
        {
            VehicleBLL vehicleS = new VehicleBLL();
            return vehicleS.GetAll();
        }

        [HttpGet("{id}")]
        public VehicleShared Get(Int64 id)
        {
            VehicleBLL vehicle = new VehicleBLL();
            return vehicle.Get(id);
        }

        [HttpPost]
        public ActionResult Save(VehicleShared vehicle)
        {
            VehicleBLL vehicleBLL = new VehicleBLL();
            vehicleBLL.Save(vehicle);
            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Int64 id)
        {

            VehicleBLL vehicleBLL = new VehicleBLL();
            vehicleBLL.Remove(id);
            return Ok();
        }

    }
}