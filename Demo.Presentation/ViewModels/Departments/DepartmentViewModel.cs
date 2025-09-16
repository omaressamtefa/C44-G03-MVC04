namespace Demo.Presentation.ViewModels.Departments
{
    public class DepartmentViewModel
    {

        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; } = string.Empty;
        public DateOnly DateOfCreation { get; set; }
    }
}
