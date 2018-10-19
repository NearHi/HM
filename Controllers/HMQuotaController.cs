using HMQuota.Model;
using HMQuota.Model.DTO;
using HMQuota.Services;
using HMQuota.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HMQuota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("quota")]
    public class HMQuotaController : ControllerBase
    {
        private IQuotaHeaderService quotaHeaderService;
        public HMQuotaController(IQuotaHeaderService quotaHeaderService) => this.quotaHeaderService = quotaHeaderService;
        [HttpGet]
        [EnableCors("quota")]
        [Route("GetList")]
        public ActionResult<Page<QuotaHeader>> GetList(int pageIndex, int category) => Ok(this.quotaHeaderService.pageList(pageIndex, 2, category));

        [HttpGet]
        [EnableCors("quota")]
        public ActionResult<QuotaHeader> Get(int id) => Ok(this.quotaHeaderService.getQuotaHeader(id));

        [HttpGet]
        [EnableCors("quota")]
        [Route("Delete")]
        public ActionResult<string> Delete(int id) => this.quotaHeaderService.delQuotaHeader(id).Equals(-1) ? "删除失败！" : "删除成功！";


        [HttpPost]
        public ActionResult<string> Add([FromBody] QuotaHeader quotaHeader) => this.quotaHeaderService.addQuotaHeader(quotaHeader).Equals(-1) ? "新增失败！" : "新增成功！";

        [HttpPost]
        [Route("saveHeaderAndBody")]
        [EnableCors("quota")]
        public ActionResult<string> saveHeaderAndBody([FromForm]SaveDTO SaveDTO) => this.quotaHeaderService.saveHeaderAndBody(SaveDTO).Equals(-1) ? "新增失败！" : "新增成功！";
        [HttpPost]
        [Route("modQuotaHeader")]
        [EnableCors("quota")]
        public ActionResult<string> modQuotaHeader([FromForm] QuotaHeader quotaHeader) => this.quotaHeaderService.modQuotaHeader(quotaHeader).Equals(-1) ? "修改失败！" : "修改成功！";
        [HttpGet]
        [Route("GetQuotaBody")]
        [EnableCors("quota")]
        public ActionResult<QuotaBody> GetQuotaBody(int headerId) => this.quotaHeaderService.getQuotaBody(headerId);

        [HttpPost]
        [Route("modQuotaBody")]
        [EnableCors("quota")]
        public ActionResult<string> modQuotaBody([FromForm] QuotaBody quotaBody) => this.quotaHeaderService.modQuotaBody(quotaBody).Equals(-1) ? "修改失败！" : "修改成功！";

    }
}