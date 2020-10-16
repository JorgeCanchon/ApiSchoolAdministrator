using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Infraestructure.Data.EntityFrameworkSqlServer
{
    public class RepositoryContextSqlServer : DbContext
    {
        public RepositoryContextSqlServer()
        {

        }
        public RepositoryContextSqlServer(DbContextOptions options)
            : base(options)
        {

        }
    }
}
