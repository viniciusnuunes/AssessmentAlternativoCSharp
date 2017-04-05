using System;

public class EntityContextDb : DbContext
{
    public DbSet<Aluno> aluno { get; set; }
}
