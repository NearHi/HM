using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMQuota.Model;
using HMQuota.Model.DTO;
using HMQuota.Services;
using HMQuota.Utils;
using Microsoft.EntityFrameworkCore;
namespace HMQuota.Services
{
    public class QuotaHeaderService : IQuotaHeaderService
    {
        private HMQuotaDBContext dBContext;
        public QuotaHeaderService(HMQuotaDBContext dbContext) => this.dBContext = dbContext;
        public async Task<int> addQuotaHeader(QuotaHeader quotaHeader)
        {


            await dBContext.AddAsync(quotaHeader);
            return dBContext.SaveChanges();

        }

        public async Task<int> delQuotaHeader(int id)
        {

            QuotaHeader obj = await dBContext.quotaHeaders.FindAsync(id);
            if (null == obj)
            {
                return -1;
            }
            else
            {
                obj.category = 0;//
                return dBContext.SaveChanges();
            }

        }

        public QuotaBody getQuotaBody(int headerId)
        {

            return this.dBContext.quotaBody.Where(a => a.headerId == headerId).First();

        }

        public QuotaHeader getQuotaHeader(int id)
        {
            var header = this.dBContext.quotaHeaders.Find(id);
            header.quotaBody = dBContext.quotaBody.Single(a => a.headerId == id);
            return header;
        }

        public async Task<int> modQuotaBody(QuotaBody quotaBody)
        {
            QuotaBody quota = await dBContext.quotaBody.FindAsync(quotaBody.Id);
            if (null == quota)
            {
                return -1;
            }
            else
            {
                quota.lastUpdate = DateTime.Now;
                if (!string.IsNullOrEmpty(quotaBody.quotaString))
                {
                    quota.quotaString = quotaBody.quotaString;
                }
                if (!string.IsNullOrEmpty(quotaBody.quotaString1))
                {
                    quota.quotaString1 = quotaBody.quotaString1;
                }
                if (!string.IsNullOrEmpty(quotaBody.quotaString2))
                {
                    quota.quotaString2 = quotaBody.quotaString2;
                }
                if (!string.IsNullOrEmpty(quotaBody.quotaString3))
                {
                    quota.quotaString3 = quotaBody.quotaString3;
                }
                if (!string.IsNullOrEmpty(quotaBody.quotaString4))
                {
                    quota.quotaString4 = quotaBody.quotaString4;
                }
                if (!string.IsNullOrEmpty(quotaBody.quotaString5))
                {
                    quota.quotaString5 = quotaBody.quotaString5;
                }
                if (!string.IsNullOrEmpty(quotaBody.quotaString6))
                {
                    quota.quotaString6 = quotaBody.quotaString6;
                }
                if (!string.IsNullOrEmpty(quotaBody.quotaString7))
                {
                    quota.quotaString7 = quotaBody.quotaString7;
                }
                return dBContext.SaveChanges();
            }

        }

        public async Task<int> modQuotaHeader(QuotaHeader quotaHeader)
        {

            QuotaHeader quota = await dBContext.quotaHeaders.FindAsync(quotaHeader.Id);
            if (null == quota)
            {
                return -1;
            }
            else
            {
                quota.quotaName = quotaHeader.quotaName;
                quota.lastUpdate = DateTime.Now;
                quota.category = quotaHeader.category;
                return dBContext.SaveChanges();
            }

        }

        public Page<QuotaHeader> pageList(int pageIndex, int pageSize, int category)
        {


            Page<QuotaHeader> page = new Page<QuotaHeader>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            int skip = (pageIndex - 1) * pageSize;
            page.TotalItems = dBContext.quotaHeaders.Where(a => a.category == category).Count();
            page.Items = dBContext.quotaHeaders.OrderBy(a => a.index).Where(a => a.category == category).Skip(skip).Take(pageSize).ToList();
            page.TotalPages = page.TotalItems % pageSize == 0 ? page.TotalItems / pageSize : page.TotalItems / pageSize + 1;
            return page;


        }

        public int saveHeaderAndBody(SaveDTO saveDTO)
        {
            int flag = 0;
            using (var trans = this.dBContext.Database.BeginTransaction())
            {


                try
                {
                    QuotaHeader header = new QuotaHeader();
                    header.category = saveDTO.category;
                    header.quotaName = saveDTO.quotaName;
                    header.index = 1;
                    header.createDate = DateTime.Now;
                    header.lastUpdate = DateTime.Now;
                    this.dBContext.quotaHeaders.Add(header);
                    flag += this.dBContext.SaveChanges();
                    QuotaBody body = new QuotaBody();
                    body.headerId = header.Id;
                    body.createDate = DateTime.Now;
                    body.lastUpdate = DateTime.Now;
                    if (!string.IsNullOrEmpty(saveDTO.quotaString))
                    {
                        body.quotaString = saveDTO.quotaString;
                    }
                    if (!string.IsNullOrEmpty(saveDTO.quotaString1))
                    {
                        body.quotaString1 = saveDTO.quotaString1;
                    }
                    if (!string.IsNullOrEmpty(saveDTO.quotaString2))
                    {
                        body.quotaString2 = saveDTO.quotaString2;
                    }
                    if (!string.IsNullOrEmpty(saveDTO.quotaString3))
                    {
                        body.quotaString3 = saveDTO.quotaString3;
                    }
                    if (!string.IsNullOrEmpty(saveDTO.quotaString4))
                    {
                        body.quotaString4 = saveDTO.quotaString4;
                    }
                    if (!string.IsNullOrEmpty(saveDTO.quotaString5))
                    {
                        body.quotaString5 = saveDTO.quotaString5;
                    }
                    if (!string.IsNullOrEmpty(saveDTO.quotaString6))
                    {
                        body.quotaString6 = saveDTO.quotaString6;
                    }
                    if (!string.IsNullOrEmpty(saveDTO.quotaString7))
                    {
                        body.quotaString7 = saveDTO.quotaString7;
                    }
                    this.dBContext.quotaBody.Add(body);
                    flag += dBContext.SaveChanges();

                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return -1;
                }

            }
            return flag == 0 ? -1 : flag;
        }
    }
}