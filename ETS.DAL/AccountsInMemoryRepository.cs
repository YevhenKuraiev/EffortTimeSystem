using System.Collections.Generic;
using System.Linq;
using ETS.Contracts.DataContracts;
using ETS.Contracts.Interfaces;

namespace ETS.DAL
{
    public class AccountsInMemoryRepository : IAccountsRepository
    {
        private static readonly List<AccountEntity> AccountsStorage = new List<AccountEntity>
        {
            new AccountEntity
            {
                Id = 12,
                Name = "John",
                Surname = "Green",
                Email = "JohnGreen@gmail.com",
                Login = "JohnGreen12",
                Password = "JohnGreen12",
                AccessLevel = 1
            },
            new AccountEntity
            {
                Id = 13,
                Name = "Lila",
                Surname = "Brown",
                Email = "LilaBrown@gmail.com",
                Login = "LilaBrown13",
                Password = "LilaBrown13",
                AccessLevel = 2
            }
        };

        public IEnumerable<AccountEntity> GetAll()
        {
            return AccountsStorage;
        }

        public AccountEntity GetById(int id)
        {
            return AccountsStorage.FirstOrDefault(t => t.Id == id);
        }

        public void Add(AccountEntity account)
        {
            throw new System.NotImplementedException();
        }

        public void Update(AccountEntity accountWithChanges)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
