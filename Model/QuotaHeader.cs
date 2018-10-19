using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMQuota.Model
{
    public class QuotaHeader
    {

        public int Id { get; set; }
        public DateTime createDate { get; set; }
        public String quotaName { get; set; }

        public DateTime lastUpdate { get; set; }

        public int index { get; set; }

        public int category { get; set; }

        [NotMapped]
        public QuotaBody quotaBody { get; set; }
    }
}