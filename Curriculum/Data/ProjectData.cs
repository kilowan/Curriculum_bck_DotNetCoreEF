using curriculum.Models;
using System;
using System.Linq;

namespace curriculum.Data
{
    public class ProjectData : IProjectData
    {
        private readonly CurriculumContext _context;
        public ProjectData(CurriculumContext context)
        {
            _context = context;
        }

        public bool AddProject(ProjectDto project)
        {
            try
            {
                bool result = false;
                int lastId = _context.Projects
                    .OrderBy(sub => sub.id)
                    .Select(sub => sub.id)
                    .LastOrDefault() + 1;

                _context.Projects.Add(new Models.Project() 
                { 
                    id = lastId,
                    contractId = project.contractId,
                    name = project.name
                });
                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool UpdateProject(ProjectDto project, int projectId)
        {
            try
            {
                bool result = false;
                Models.Project pr = _context.Projects
                    .Where(pr => pr.id == projectId)
                    .FirstOrDefault();
                pr.name = project.name;
                _context.Projects.Update(pr);
                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeleteProject(int projectId)
        {
            try
            {
                bool result = false;
                Models.Project pr = _context.Projects
                    .Where(pr => pr.id == projectId)
                    .FirstOrDefault();
                _context.Projects.Remove(pr);
                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
