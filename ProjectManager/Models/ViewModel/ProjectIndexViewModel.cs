using PetaPoco;

namespace ProjectManager.Models
{
    public class ProjectIndexViewModel
    {
        public Page<ProjectModel> ProjectList { get; set; } 
    }
}