using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Database.Csv.Converter.Users;
using Klinika.Database.Csv.Stream;
using Klinika.Dto;

namespace Klinika.Dao.Users.CSVImpl
{
    public class AccountDao : IAccountDao
    {
        private readonly ICSVStream<AccountDTO> _stream;

        public AccountDao(ICSVStream<AccountDTO> stream)
        {
            _stream = stream;
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(AccountDTO accountDTO) => DeleteById(accountDTO.Username);

        public void DeleteAll() => _stream.SaveAll(new List<AccountDTO>());

        public void DeleteById(string username)
        {
            List<AccountDTO> accounts = _stream.ReadAll().ToList();
            AccountDTO toRemove = accounts.SingleOrDefault(a => a.Username.CompareTo(username) == 0);
            if (toRemove != null)
            {
                accounts.Remove(toRemove);
                _stream.SaveAll(accounts);
            }
            else
            {
                Console.WriteLine("Nalog nije pronadjen");
            }
        }

        public bool ExistsById(string username) => FindById(username) == null ? false : true;

        public IEnumerable<AccountDTO> FindAll() => _stream.ReadAll().ToList();

        public AccountDTO FindById(string username)
        {
            List<AccountDTO> accounts = _stream.ReadAll().ToList();
            return accounts.SingleOrDefault(a => a.Username.CompareTo(username) == 0);
        }

        public AccountDTO Save(AccountDTO accountDTO)
        {
            AccountDTO oldAccount = FindById(accountDTO.Username);
            if(oldAccount != null)
            {
                Delete(oldAccount);
            }
            _stream.AppendToFile(accountDTO);
            return accountDTO;
        }

        public void SaveAll(IEnumerable<AccountDTO> accounts)
        {
            foreach(AccountDTO account in accounts)
            {
                Save(account);
            }
        }
    }
}
