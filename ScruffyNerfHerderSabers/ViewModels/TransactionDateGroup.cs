using System;
using System.ComponentModel.DataAnnotations;
using ScruffyNerfHerderSabers.DAL;
using ScruffyNerfHerderSabers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScruffyNerfHerderSabers.ViewModels
{
    public class TransactionDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? TransactionDate { get; set; }

        public int CustomerCount { get; set; }
    }
}