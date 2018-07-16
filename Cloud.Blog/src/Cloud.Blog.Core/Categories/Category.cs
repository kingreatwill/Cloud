using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Cloud.Blog;

namespace Cloud.Blog.Categories
{
    [Table(BlogConsts.DbTablePrefix + "Categories")]
    public class Category : Entity<long>, IExtendableObject, IFullAudited
    {
        #region const

        public const int MaxNameLength = 128;

        #endregion const

        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        #region impl

        public virtual long? CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual long? LastModifierUserId { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual long? DeleterUserId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string ExtensionData { get; set; }

        #endregion impl
    }
}