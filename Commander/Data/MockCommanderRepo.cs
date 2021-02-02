using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command> {
                new Command { Id = 1, HowTo = "Boil an Egg", Line = "Boil Water", Platform = "Kettle and Pan" },
                new Command { Id = 2, HowTo = "Fry Chips", Line = "Fry Oil", Platform = "Kettle and Collander" },
                new Command { Id = 3, HowTo = "Clean Pot", Line = "Wash with water", Platform = "Pot and Sponge" },
                new Command { Id = 4, HowTo = "Make Eba", Line = "Boil Water", Platform = "Pot and spatula" }
            };
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 1, HowTo = "Boil an Egg", Line = "Boil Water", Platform = "Kettle and Pan" };

        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
