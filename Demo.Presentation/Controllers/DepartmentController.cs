using Demo.BusinessLogic.DTOS;
using Demo.BusinessLogic.Services;
using Demo.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NuGet.Packaging.Signing;
using System.Timers;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentService departmentService, IWebHostEnvironment env, ILogger<DepartmentController> logger) {
            _departmentService = departmentService;
            _env = env;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try {
                    int result = _departmentService.AddDepartment(departmentDto);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else {
                        ModelState.AddModelError(string.Empty, "Department Can Not be Created");

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

            return View(departmentDto);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            return View(department);

        }

        public IActionResult Edit(int? id) {
            if (!id.HasValue) return BadRequest();
            var depaetment = _departmentService.GetDepartmentById(id.Value);
            if (depaetment is null) return NotFound();
            var model = new DepartmentEditViewModel()
            {
                Name = depaetment.Name,
                Description = depaetment.Description,
                Code = depaetment.Code,
                CreatedOn = depaetment.CreatedOn.HasValue ? depaetment.CreatedOn.Value : default
            };
            return View(model);
        }   
        


        

        [HttpPost]
        public IActionResult Edit([FromRoute]int?id,DepartmentEditViewModel departmentVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(!id.HasValue) return BadRequest();
                    var UpdateDDeptDto = new UpdatedDepartmentDto()
                    {
                        Id = id.Value,
                        Code = departmentVM.Code,
                        Name = departmentVM.Name,
                        Description = departmentVM.Description,
                        DateOfCreation = departmentVM.CreatedOn

                    };
                    var result = _departmentService.UpdateDepartment(UpdateDDeptDto);
                    if (result > 0) {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can Not Be Updated");

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
            return View(departmentVM);
        }

        public IActionResult Delete(int? id) { 
          if(!id.HasValue)return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            return View(department);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try { 
             bool Isdeleted= _departmentService.DeleteDepartment(id);
                if (Isdeleted)return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Can Not Be Deleted");
                    
                }
            }
            catch(Exception ex)
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
            return RedirectToAction("Delete", new { id });
        }
    }
}
