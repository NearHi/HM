using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMQuota.Model
{
    public class QuotaBody
    {
        public int Id { get; set; }
        public DateTime createDate { get; set; }
        public String quotaString { get; set; }
        public String quotaString1 { get; set; }
        public String quotaString2 { get; set; }
        public String quotaString3 { get; set; }
        public String quotaString4 { get; set; }
        public String quotaString5 { get; set; }
        public String quotaString6 { get; set; }
        public String quotaString7 { get; set; }
        public String quotaString8 { get; set; }
        public String quotaString9 { get; set; }
        public DateTime lastUpdate { get; set; }

        public int headerId { get; set; }

        public QuotaBody(){}
        public QuotaBody(int id){
            this.Id=id;
        }
    }
}