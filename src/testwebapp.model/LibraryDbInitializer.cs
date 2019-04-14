using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testwebapp.model
{
    public class LibraryDbInitializer : MigrateDatabaseToLatestVersion<LibraryContext, testwebapp.model.Migrations.Configuration>
    {
    }
}
