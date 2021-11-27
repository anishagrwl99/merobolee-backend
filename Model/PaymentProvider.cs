using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    public class AppConfig
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Logo { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<AppConfigDetail> ConfigDetails { get; set; }

    }

    public class AppConfigDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AppConfig")]
        public int AppConfigId { get; set; }
        public string ConfigName { get; set; }
        public string ConfigValue { get; set; }

        public virtual AppConfig AppConfig { get; set; }
    }
}
