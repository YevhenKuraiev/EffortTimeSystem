using System.Collections.Generic;
using System.Linq;
using ETS.Contracts.DataContracts;
using ETS.Contracts.Interfaces;

namespace ETS.DAL
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private static readonly List<RoleEntity> RolesStorage = new List<RoleEntity>
        {
            new RoleEntity
            {
                Id = 1,
                Name = "Project manager"
            },
            new RoleEntity
            {
                Id = 2,
                Name = "Team lead"
            },
                        new RoleEntity
            {
                Id = 3,
                Name = "Engineer"
            }
        };

        public IEnumerable<RoleEntity> GetAll()
        {
            return RolesStorage;
        }

        public RoleEntity GetById(int id)
        {
            return RolesStorage.FirstOrDefault(t => t.Id == id);
        }

        public void Add(RoleEntity role)
        {
            throw new System.NotImplementedException();
        }

        public void Update(RoleEntity roleWithChanges)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
