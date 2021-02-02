using Commander.Models;
using System.Collections.Generic;
using System.Linq;

namespace Commander.Data
{


    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
           if(cmd == null)
            {
                throw new System.ArgumentNullException();
            }
            _context.Commands.Add(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            var commands = _context.Commands.FirstOrDefault(p => p.Id == id);
            return commands;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
