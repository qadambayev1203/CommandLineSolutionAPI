using CommandLine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandLine.Data
{
    public class CommandContex : DbContext
    {
        public CommandContex(DbContextOptions<CommandContex> options) : base(options)
        {    }

        public DbSet<Command> Commands { get; set; }
    }
}
