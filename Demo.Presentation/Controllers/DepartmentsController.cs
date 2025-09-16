using Demo.BusinessLogic.DataTransferObjects.Departments;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.Presentation.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Demo.Presentation.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IWebHostEnvironment _env;

        public DepartmentsController(IDepartmentServices departmentServices,ILogger<DepartmentsController>logger,IWebHostEnvironment env)
        {
            _departmentServices = departmentServices;
            _logger = logger;
           _env = env;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartments();
            return View(departments);
        }

        #region Create
        [HttpGet]
        public IActionResult Create() 
        { 
        return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if(!ModelState.IsValid)
            {
           return View(departmentDto);
            }
            var message = string.Empty;
            try
            {
                var result = _departmentServices.AddDepartment(departmentDto);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                 message = "Department Cannot be Created ";
                    ModelState.AddModelError(string.Empty, message);
                    return View(departmentDto);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, message);
                if(_env.IsDevelopment())
                {
                    message = ex.Message;
                    return View(departmentDto);
                }
                else
                {
                    message = "Department Cannot be Created ";
                    return View("Error",message);
                }
            }
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id is null || id <= 0)
            {
                return BadRequest();//400
            }   
            var department = _departmentServices.GetDepartmentById(id.Value);
            if(department is null)
            {
                return NotFound();//404
            }
            return View(department);

        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest(); // 400
            }

            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound(); // 404
            }

            return View(new DepartmentViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateOfCreation = department.DateOfCreation,
            });
        }
        
        [HttpPost]
        public IActionResult Edit([FromRoute]int id,DepartmentViewModel departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }

            var message = string.Empty;

            try
            {
                var result = _departmentServices.UpdateDepartment(new UpdateDepartmentDto()
                {
                    Id = id,
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    DateofCreation = departmentVM.DateOfCreation
                });

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Department Cannot be Updated";
                 
                    return View(departmentVM);
                }
            }
            catch (Exception ex)
            {
               message=_env.IsDevelopment()?ex.Message: "Department Cannot be Updated";

            }
            return View(departmentVM);
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest(); // 400
            }

            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound(); // 404
            }

            return View(department); 
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;

            try
            {
                var result = _departmentServices.DeleteDepartment(id);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "An error happened when deleting the department";
                    var department = _departmentServices.GetDepartmentById(id); 
                    if (department != null)
                    {
                        return View(department); 
                    }
                    return View(); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                message = _env.IsDevelopment() ? ex.Message : "An error happened when deleting the department";
                var department = _departmentServices.GetDepartmentById(id); 
                if (department != null)
                {
                    ViewData["ErrorMessage"] = message; 
                    return View(department);
                }
                return View(); 
            }
        }
        #endregion
    }
}