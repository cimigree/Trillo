using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Trello.Models
{
   // Talks to SQL and declares the variable type and column name
    public class Trillo
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string Notes { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:-MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        public int SortOrder { get; set; }
    }

    // connects the model to the database

    public class TrelloDbContext : DbContext
    {
        public DbSet<Trillo> Trillos { get; set; }
    }
}