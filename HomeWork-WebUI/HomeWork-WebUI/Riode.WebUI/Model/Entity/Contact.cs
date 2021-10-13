using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Model.Entity
{
    public class Contact:BaseEntity
    {
        [EmailAddress]
        [Required (ErrorMessage = "Can't be empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email formata uygun deyil")]
        public string Comment { get; set; }

        public string Answer { get; set; }
        public DateTime? AnswerDate { get; set; }
        public int? AnswerdByUserId { get; set; }

    }
}

