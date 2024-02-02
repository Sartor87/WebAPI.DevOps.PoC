using Microsoft.AspNetCore.Mvc;
using WebAPI.DevOps.PoC.Repos;

namespace WebAPI.DevOps.PoC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneColorController : ControllerBase
    {
        private readonly ILogger<PhoneColorController> _logger;

        public PhoneColorController(ILogger<PhoneColorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMupPhoneColors")]
        public MupColorPhoneModel GetPhoneModel()
        {
            IList<IList<object>> rows = new List<IList<object>>
            {
                new List<object> { "Model", "White", "White 2", "Black", "Gray", "Silver", "Gold", "Yellow", "Red", "Green", "Blue 1" },
                new List<object> { "Samsung Galaxy A20", "", "", "Black", "", "", "", "", "Red", "", "Deep Blue" },
                new List<object> { "UlePhone Armor 8", "", "", "Black", "", "", "", "", "", "", "" }
            };
            _logger.Log(LogLevel.Information, "Number of rows to be processed for GetPhoneModel: " + rows.Count);
            return new MupColorPhoneRepo().MupColorsModelsAndModelColors(rows);
        }
    }
}
