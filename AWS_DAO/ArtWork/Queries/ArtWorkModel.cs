﻿using AWS_BusinessObjects.Entities;
using AWS_BusinessObjects.Enums;
using AWS_BusinessObjects.Identity;
using AWS_DAO.Common.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_DAO.ArtWork.Queries
{
    public class ArtWorkModel : IMapFrom<AWS_BusinessObjects.Entities.ArtWork>
    {
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserAccountId { get; set; }
        public string UserOwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public ArtWorkStatus ArtWorkStatus { get; set; }
        public bool IsSold { get; set; }
        public bool IsPreOrder { get; set; }
/*        public virtual IList<Order>? Orders { get; set; }
        public virtual IList<Interact>? Interacts { get; set; }*/
    }
}
