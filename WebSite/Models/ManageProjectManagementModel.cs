using System.Collections.Generic;
using ETS.Contracts.DataContracts;

namespace WebSite.Models
{
    public class ManageProjectManagementModel
    {
        public int Id { get; set; }

        //public IEnumerable<ProjectEntity> ProjectName { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public IEnumerable<TaskEntity> Task { get; set; }

        public IEnumerable<AccountEntity> TeamMember { get; set; }

        public IEnumerable<RoleEntity> Role { get; set; }
    }
}