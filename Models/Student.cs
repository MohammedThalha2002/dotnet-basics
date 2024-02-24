using System.ComponentModel.DataAnnotations;

namespace FirstWebAppMVC.Models;

public class Student
{
    [Key]
    public Guid id { get; set; }
    public string? Name { get; set; }
    public int RollNo { get; set; }
    public int Age { get; set; }
}