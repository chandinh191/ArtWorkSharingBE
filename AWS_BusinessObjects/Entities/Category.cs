﻿using AWS_BusinessObjects.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_BusinessObjects.Entities
{
    public class Category : BaseAuditableEntity
    {
        [ForeignKey("ApplicationUser")]
        [Required(ErrorMessage = "UserAccountId is required")]
        public string UserAccountId { get; set; }
        public string CategoryName { get; set; }
        [Required(AllowEmptyStrings = true, ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description must be at most 500 characters")]
        public string Description { get; set; }
    }
}
