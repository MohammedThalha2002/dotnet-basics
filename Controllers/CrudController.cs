using FirstWebAppMVC.Context;
using FirstWebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAppMVC.Controllers;

public class CrudController : Controller
{
    public readonly ApplicationDbContext dbContext;

    public CrudController(ApplicationDbContext _context)
    {
        dbContext = _context;
    }

    // GET ALL STUDENTS
    public async Task<IActionResult> Index()
    {
        List<Student> students = await dbContext.Students.ToListAsync();
        return View(students);
    }

    // GET A STUDENT BY ID
    public async Task<IActionResult> Index(int id)
    {
        var student = await dbContext.Students.FindAsync(id);
        if (student != null)
        {
            return View("Views/Crud/Single.cshtml", student);
        }
        return RedirectToAction("Index");
    }


    // ADD A NEW STUDENT
    [HttpPost]
    public async Task<IActionResult> AddStudent(Student student)
    {
        Student _student = new Student()
        {
            id = Guid.NewGuid(),
            Name = student.Name,
            Age = student.Age,
            RollNo = student.RollNo
        };
        await dbContext.Students.AddAsync(_student);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    // UPDATE A STUDENT
    public async Task<IActionResult> UpdateStudent(Student _student)
    {
        var student = await dbContext.Students.FindAsync(_student.id);
        if (student != null)
        {
            dbContext.Students.Update(student);
            await dbContext.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }

    // DELETE A STUDENT
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await dbContext.Students.FindAsync(id);
        if (student != null)
        {
            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }

}