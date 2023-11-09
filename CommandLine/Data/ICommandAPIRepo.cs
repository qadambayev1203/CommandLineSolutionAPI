using CommandLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandLine.Data
{
    public interface ICommandAPIRepo
    {
        Task<IEnumerable<Command>> GetAllCommands();

        Task<Command> GetCommandById(int id);

        Task CreateCommand(Command command);

        Task UpdateCommand(Command command);

        void DeleteCommand(Command command);

        Task<bool> SaveChangesAsync();
    }
}
