using curriculum.Models;

namespace curriculum.Business
{
    public interface IProjectBz
    {
        public bool AddProject(ProjectDto project);
        public bool UpdateProject(ProjectDto project, int projectId);
        public bool DeleteProject(int projectId);
    }
}
