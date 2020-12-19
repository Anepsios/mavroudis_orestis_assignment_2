namespace mavroudis_orestis_assignment_2.Migrations
{
    using mavroudis_orestis_assignment_2.Data;
    using mavroudis_orestis_assignment_2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var trainers = new List<Trainer>
            {
                new Trainer {FirstName = "Sakis", LastName = "Sakopoulos", Subject = Subject.CSharp },
                new Trainer {FirstName = "Takis", LastName = "Takopoulos", Subject = Subject.CSharp },
                new Trainer {FirstName = "Makis", LastName = "Makopoulos", Subject = Subject.Java },
                new Trainer {FirstName = "Akis", LastName = "Akopoulos", Subject = Subject.Java },
                new Trainer {FirstName = "Lakis", LastName = "Lakopoulos", Subject = Subject.Javascript },
                new Trainer {FirstName = "Pakis", LastName = "Pakopoulos", Subject = Subject.Python }
            };
            trainers.ForEach(x => context.Trainers.AddOrUpdate(y => y.LastName, x));
            context.SaveChanges();
        }
    }
}
