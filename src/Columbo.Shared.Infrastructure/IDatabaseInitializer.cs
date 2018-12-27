using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Infrastructure
{
    public interface IDatabaseInitializer
    {
        void InitializeDatabase(IDatabaseContext context);
        void Seed(IDatabaseContext context);
    }
}
