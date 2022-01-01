using curriculum.Data;
using curriculum.Models;
using System;

namespace curriculum.Business
{
    public class ProjectBz : IProjectBz
    {
        private readonly IProjectData projectData;
        public ProjectBz(IProjectData projectData)
        {
            this.projectData = projectData;
        }

        public bool AddProject(ProjectDto project)
        {
            try
            {
                return projectData.AddProject(project);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
