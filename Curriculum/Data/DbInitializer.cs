using curriculum.Data;
using System.Linq;

namespace Incidences.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CurriculumContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Credentials.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }
        }
    }
}
