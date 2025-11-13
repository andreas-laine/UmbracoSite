using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace UmbracoCMS.ViewModels;

public class CallBackFormViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email address")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Phone is required")]
    [Display(Name = "Phone")]
    public string Phone { get; set; } = null!;
    [Required(ErrorMessage = "Please select and option")]
    public string SelectedOption { get; set; } = null!;

    [BindNever]
    public IEnumerable<string> Options { get; set; } = [];
}