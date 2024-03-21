﻿using AWS_BusinessObjects.Common;
using AWS_BusinessObjects.Enums;
using AWS_BusinessObjects.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_BusinessObjects.Entities
{
    public class Order : BaseAuditableEntity
    {
        [ForeignKey("ApplicationUser")]
        [Required(ErrorMessage = "UserAccountId is required")]
        public string UserAccountId { get; set; }
        [ForeignKey(nameof(ArtWork))]
        [Required(ErrorMessage = "ArtWordID is required")]
        public Guid ArtWorkID { get; set; }
        [Range(1,9999999999, ErrorMessage = "Price must be between 1 and 9999999999")]
        public float Price { get; set; }
        public OrderStatus Status { get; set; }
        public bool isPreOrder { get; set; }    
        public virtual IList<Rating>? Rating { get; set; }
    }
}
