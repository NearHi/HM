using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HMQuota.Model;
using HMQuota.Model.DTO;
using HMQuota.Utils;

namespace HMQuota.Services{
    public interface IQuotaHeaderService
    {
        Task<int> addQuotaHeader(QuotaHeader quotaHeader);

        Task<int> delQuotaHeader(int id);

        QuotaHeader getQuotaHeader(int id);

        Task<int> modQuotaHeader(QuotaHeader quotaHeader);

       Page<QuotaHeader> pageList(int pageIndex, int pageSize,int category);

       QuotaBody getQuotaBody(int headerId); 

       int saveHeaderAndBody(SaveDTO saveDTO);


       Task<int> modQuotaBody(QuotaBody quotaBody);
        
    }
}