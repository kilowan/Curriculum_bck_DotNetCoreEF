using curriculum.Models;

namespace curriculum.Data
{
    public interface IProjectData
    {
        public bool AddProject(ProjectDto project);
        public bool UpdateProject(ProjectDto project, int projectId);
        public bool DeleteProject(int projectId);
    }
}
