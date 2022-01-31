#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wizard.ScoreSheet.Models;

namespace Wizard.ScoreSheet.Data
{
    public class WizardScoreSheetContext : DbContext
    {
        public WizardScoreSheetContext (DbContextOptions<WizardScoreSheetContext> options)
            : base(options)
        {
        }

        public DbSet<Wizard.ScoreSheet.Models.PlayerModel> PlayerModel { get; set; }
    }
}
