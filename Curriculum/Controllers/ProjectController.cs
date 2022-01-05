using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace curriculum.Controllers
{
    [Route("api/Project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectBz projectBz;
        public ProjectController(IProjectBz projectBz)
        {
            this.projectBz = projectBz;
        }

        [HttpPost]
        [Authorize]
        public bool AddProject(ProjectDto project)
        {
            try
            {
                return projectBz.AddProject(project);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{projectId}")]
        [Authorize]
        public bool UpdateProject(ProjectDto project, int projectId)
        {
            try
            {
                return projectBz.UpdateProject(project, projectId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
