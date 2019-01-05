using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Infrastructure
{
    public interface IDatabaseSeeder
    {
        void Seed(IDatabaseContext databaseContext);
    }
}
