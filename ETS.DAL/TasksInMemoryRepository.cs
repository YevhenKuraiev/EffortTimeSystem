using System.Collections.Generic;
using System.Linq;
using ETS.Contracts.DataContracts;
using ETS.Contracts.Interfaces;

namespace ETS.DAL
{
    public class TasksInMemoryRepository : ITasksRepository
    {
        private static readonly List<TaskEntity> TasksStorage = new List<TaskEntity>
        {
            new TaskEntity
            {
                Id = 12,
                Title = "Bug fixing",
                Description = "This task is related to all activities regarding fixing of customer issues",
                Project = new ProjectEntity
                {
                    Id = 3,
                    Name = "W3D3"
                }
            },
            new TaskEntity
            {
                Id = 17,
                Title = "Development",
                Description = "This task is related to all activities regarding fixing of customer issues",
                Project = new ProjectEntity
                {
                    Id = 5,
                    Name = "LTA"
                }
            }
        };

        public IEnumerable<TaskEntity> GetAll()
        {
            return TasksStorage;
        }

        public TaskEntity GetById(int id)
        {
            return TasksStorage.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TaskEntity report)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TaskEntity reportWithChanges)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
