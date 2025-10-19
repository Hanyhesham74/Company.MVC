using Demo.BusinessLogic.DTOS.EmployeeDto;
using Demo.BusinessLogic.Services;
using Demo.DataAccess.Models.EmployeeModule;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment env, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _env = env;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var employes=_employeeService.GetAllEmployees();
            return View(employes);
        }

        [HttpGet]
        public IActionResult Create() { 
        return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDto employe)
        {
            if (ModelState.IsValid) {
                try
                {
                  int result=  _employeeService.AddEmployee(employe);
                    if(result>0) return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Can Not Be Created");

                    }
                    
                }
                catch (Exception ex) {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department Can Not Be Created Because:{ex.Message}");

                    }
                    else
                    {
                        _logger.LogError($"Department Can Not Be Created Because:{ex}");
                        return View("ErrorView");
                    }
                }
            }
            return View(employe);
        }
        [HttpGet]
        public IActionResult Details(int? id) { 
         if(!id.HasValue)return BadRequest();
        var employe= _employeeService.GetEmployeeById(id.Value);
            if (employe == null) return NotFound();
            return View(employe);
        }
        [HttpGet]
        public IActionResult Edit(int? id) { 
        if(!id.HasValue) return BadRequest();
        var employe=_employeeService.GetEmployeeById(id.Value);
            if(employe==null)return NotFound();
            var EmployeDto = new UpdatedEmployeeDto()
            {
                Id = employe.Id,
                Name = employe.Name,
                Age = employe.Age,
                Address = employe.Address,
                PhoneNumber = employe.PhoneNumber,
                Email = employe.Email,
                Salary = employe.Salary,
                HiringDate = employe.HiringDate,
                IsActive = employe.IsActive,
                EmployeeType=Enum.Parse<EmployeeType>(employe.EmployeeType),
                Gender=Enum.Parse<Gender>(employe.Gender)
            };
            return View(EmployeDto);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int? id,UpdatedEmployeeDto employeeDto)
        {
            if(!id.HasValue) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                  int num=  _employeeService.UpdateEmployee(employeeDto);
                    if (num > 0)
                    {
                       return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employe Can NOt Be Updated");
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department Can Not Be Created Because:{ex.Message}");

                    }
                    else
                    {
                        _logger.LogError($"Department Can Not Be Created Because:{ex}");
                        return View("ErrorView");
                    }
                }
                
            }
            return View(employeeDto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Isdeleted = _employeeService.DeleteEmployee(id);
                if (Isdeleted) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError(string.Empty, "Employe Can Not Be Deleted");

                }
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Employee Can Not Be Created Because:{ex.Message}");

                }
                else
                {
                    _logger.LogError($"Employee Can Not Be Created Because:{ex}");
                    return View("ErrorView");
                }
            }
            return RedirectToAction("Delete", new { id });
        }
        

    }
}
