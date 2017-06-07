using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ETS.Contracts.DataContracts;
using ETS.Contracts.Interfaces;
using ETS.DAL;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ProjectManagementController : Controller
    {
        private readonly IProjectsRepository projectsRepository = new ProjectsInmemoryRepository();
        private readonly IRolesRepository rolesRepository = new RolesInMemoryRepository();
        private readonly IAccountsRepository accountsRepository = new AccountsInMemoryRepository();
        private readonly IAccountInProjectsRepository accountInProjectsRepository = new AccountInProjectsInMemoryRepository();
        private readonly ITasksRepository tasksRepository = new TasksInMemoryRepository();

        // GET: ProjectManagement
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ProjectEntity> allProjects = this.projectsRepository.GetAll();
            IEnumerable<RoleEntity> roleByProject = this.rolesRepository.GetAll();
            IEnumerable<AccountInProjectEntity> accountByProject = this.accountInProjectsRepository.GetAll();

            IEnumerable<ProjectManagementModel> projectsModel = accountByProject.Select(projectEntity => new ProjectManagementModel
            {
                Id = projectEntity.Project.Id,
                ProjectName = projectEntity.Project.Name,
                ProjectManager = projectEntity.Account.Name,
                Description = projectEntity.Project.Description
            });

            return View(projectsModel);
        }

        //Формирование страницы EditProject
        [HttpGet]
        public ActionResult EditProject(int id)
        {
            if(accountInProjectsRepository.GetById(id) != null)
            {
                AccountInProjectEntity projectEntity = this.accountInProjectsRepository.GetById(id);
                IEnumerable<AccountEntity> allAccountEntity = this.accountsRepository.GetAll();
                IEnumerable<TaskEntity> allTaskEntity = this.tasksRepository.GetAll();
                IEnumerable<RoleEntity> roleByProjectEntity = this.rolesRepository.GetAll();

                var model = new ManageProjectManagementModel
                {
                    Id = projectEntity.Project.Id,
                    ProjectName = projectEntity.Project.Name,
                    Description = projectEntity.Project.Description,
                    Task = allTaskEntity.Select(taskEntity => new TaskEntity
                    {
                        Id = taskEntity.Id,
                        Title = taskEntity.Title,
                        Description = taskEntity.Description,
                        Project = taskEntity.Project
                    }),
                    TeamMember = allAccountEntity.Select(accountEntity => new AccountEntity
                    {
                        Id = accountEntity.Id,
                        Name = accountEntity.Name,
                        MiddleName = accountEntity.MiddleName,
                        Surname = accountEntity.Surname,
                        Email = accountEntity.Email,
                        Login = accountEntity.Login,
                        Password = accountEntity.Password,
                        AccessLevel = accountEntity.AccessLevel
                    }),
                    Role = roleByProjectEntity.Select(roleEntity => new RoleEntity
                    {
                        Id = roleEntity.Id,
                        Name = roleEntity.Name,
                    })
                };
                return View("EditProject", model);
            }
            else
            { //если это новый ид (добавление нового проекта)
                AccountInProjectEntity projectEntity = this.accountInProjectsRepository.GetById(id);
                IEnumerable<AccountEntity> allAccountEntity = this.accountsRepository.GetAll();
                IEnumerable<TaskEntity> allTaskEntity = this.tasksRepository.GetAll();
                IEnumerable<RoleEntity> roleByProjectEntity = this.rolesRepository.GetAll();

                var newProjectModel = new ManageProjectManagementModel
                {
                    Id = id,
                    ProjectName = "",
                    Description = "",
                    Task = allTaskEntity.Select(taskEntity => new TaskEntity
                    {
                        Id = taskEntity.Id,
                        Title = taskEntity.Title,
                        Description = taskEntity.Description,
                        Project = taskEntity.Project
                    }),
                    TeamMember = allAccountEntity.Select(accountEntity => new AccountEntity
                    {
                        Id = accountEntity.Id,
                        Name = accountEntity.Name,
                        MiddleName = accountEntity.MiddleName,
                        Surname = accountEntity.Surname,
                        Email = accountEntity.Email,
                        Login = accountEntity.Login,
                        Password = accountEntity.Password,
                        AccessLevel = accountEntity.AccessLevel
                    }),
                    Role = roleByProjectEntity.Select(roleEntity => new RoleEntity
                    {
                        Id = roleEntity.Id,
                        Name = roleEntity.Name,
                    })
                };
                return View("EditProject", newProjectModel);
            }
        }

        [HttpPost]
        public RedirectToRouteResult UpdateProject(ManageProjectManagementModel model)
        {
            
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult UpdateProject()
        //{

        //    return View("Index");
        //}
    }
}