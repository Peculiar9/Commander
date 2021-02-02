﻿using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) 
            : base(options)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}
