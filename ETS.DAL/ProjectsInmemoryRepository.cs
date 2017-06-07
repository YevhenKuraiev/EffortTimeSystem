using System;
using System.Collections.Generic;
using System.Linq;
using ETS.Contracts.DataContracts;
using ETS.Contracts.Interfaces;

namespace ETS.DAL
{
    public class ProjectsInmemoryRepository : IProjectsRepository
    {
        private static readonly List<ProjectEntity> ProjectsStorage = new List<ProjectEntity>
        {
            new ProjectEntity
            {
                Id = 3,
                Name = "W3D3",
                Description = "W3D3_description"
            },
            new ProjectEntity
            {
                Id = 5,
                Name = "LTA",
                Description = "LTA_description"
            }
        };

        public IEnumerable<ProjectEntity> GetAll()
        {
            return ProjectsStorage;
        }

        public ProjectEntity GetById(int id)
        {
            return ProjectsStorage.FirstOrDefault(p => p.Id == id);
        }

        public void Add(ProjectEntity report)
        {
            ProjectsStorage.Add(report);
        }

        public void Update(ProjectEntity projectWithChanges)
        {
            var projectToUpdate = ProjectsStorage.First(rp => rp.Id == projectWithChanges.Id);
            projectToUpdate.Id = projectWithChanges.Id;
            projectToUpdate.Name = projectWithChanges.Name;
            projectToUpdate.Description = projectWithChanges.Description;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
