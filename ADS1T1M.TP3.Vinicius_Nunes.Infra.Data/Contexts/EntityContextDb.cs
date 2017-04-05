using ADS1T1M.TP3.Vinicius_Nunes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS1T1M.TP3.Vinicius_Nunes.Infra.Data.Contexts
{
    class EntityContextDb : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
    }
}
