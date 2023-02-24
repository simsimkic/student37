using Dao;
using Klinika.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Dao.Users
{
    public interface IAccountDao : ICRUDDao<AccountDTO, string>
    {
    }
}
