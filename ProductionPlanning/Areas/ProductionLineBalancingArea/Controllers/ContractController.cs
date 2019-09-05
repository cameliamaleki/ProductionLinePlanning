using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Automation;
using Core.Core.Types;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Base;
namespace AmicoIntegratedSystem.Controllers
{
    public class ContractController : Controller
    {
        public ActionResult WizardCreate()
        {
            return View();
        }
        public ActionResult WizardContractOption()
        {
            return View();
        }
        public ActionResult WizardInsurance()
        {
            return View();
        }
        public ActionResult WizardContractAttach()
        {
            return View();
        }
        public ActionResult WizardPayment()
        {
            return View();
        }
        public ActionResult CreateContractWizard()
        {
            Session["ContractAttachList"] = null;
            return View();
        }
        public ActionResult SelectColor()
        {
            return View();
        }
        [HttpPost]
        public JsonResult searchAgents(FormCollection frm)
        {
            Sell.Agents.Agents agentRepo = new Sell.Agents.Agents();
            var Result = agentRepo.GetAllList(frm[0]).ToComboBoxListItem(p => p.Agent_AGNDesc, p => p.Agent_AGNID, "");
            var data = Result.Select(p => new { id = p.Value, text = p.Text });
            return Json(new { q = frm[0], results = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchContractByCustomerId(int CustomerId)
        {
            Sell.Contract.Contract ContractRepo = new Sell.Contract.Contract();
            //var Result = customerRepo.GetAll().Where(p => p.CMName.Contains(Name) && p.AgentId == AgentId).ToComboBoxListItem(p => p.CMName, p => p.CMID, "");
            var data = new List<SelectListItem>();
            data.Add(new SelectListItem
            {
                Selected = true,
                Text = "انتخاب کنید",
                Value = "0"
            });
            data.AddRange(ContractRepo.GetAllContractByCustomerIDListCombo(CustomerId));
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckStatus(int CNTID)
        {
            Sell.Contract.ContractDetail ContractRepo = new Sell.Contract.ContractDetail();
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var data = context.ExecuteQuery<Sell.Report.ContractRegisterReportDetailViewModel>("execute  sale.STP_T00050030;63 " + CNTID);
            if (data.Count() >= 1)
                return Content("1");
            else
                return Content("0");
        }
        public JsonResult SearchContractDetailByContractID(int ContractId)
        {
            Sell.Contract.ContractDetail ContractRepo = new Sell.Contract.ContractDetail();
            //var Result = customerRepo.GetAll().Where(p => p.CMName.Contains(Name) && p.AgentId == AgentId).ToComboBoxListItem(p => p.CMName, p => p.CMID, "");
            var data = new List<SelectListItem>();
            data.Add(new SelectListItem
            {
                Selected = true,
                Text = "انتخاب کنید",
                Value = "0"
            });
            data.AddRange(ContractRepo.GetContractDetailByContractIdCombo(ContractId));
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult searchCustomers(FormCollection frm)
        {
            var AgentId = Convert.ToInt32(frm.Get("AgentId"));
            var Name = frm.Get("data[q]");
            Name = Name.Replace("ی", "ي");
            Sell.ContractCustomer.ContractCustomer customerRepo = new Sell.ContractCustomer.ContractCustomer();
            //var Result = customerRepo.GetAll().Where(p => p.CMName.Contains(Name) && p.AgentId == AgentId).ToComboBoxListItem(p => p.CMName, p => p.CMID, "");
            if (AgentId != null && AgentId != 0)
            {
                var data = customerRepo.GetAllListCombo(Name, AgentId).Select(p => new { id = p.Value, text = p.Text });
                return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = customerRepo.GetAllListCombo(Name).Select(p => new { id = p.Value, text = p.Text });
                return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult searchCustomersByCmCode(FormCollection frm)
        {
            var AgentId = Convert.ToInt32(frm.Get("AgentId"));
            var Name = frm.Get("data[q]");
            Name = Name.Replace("ی", "ي");
            Sell.ContractCustomer.ContractCustomer customerRepo = new Sell.ContractCustomer.ContractCustomer();
            if (AgentId == 0)
            {
                //var data = customerRepo.GetAll().Where(p => p.CMName.Contains(Name) && p.AgentId == AgentId).ToComboBoxListItem(p => p.CMName, p => p.CMID, "");
                var data = customerRepo.GetAllListComboByCmCode(Name).Select(p => new { id = p.Value, text = p.Text });
                return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = customerRepo.GetAllListComboByCmCode(Name).Select(p => new { id = p.Value, text = p.Text });
                return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult searchContractlist(FormCollection frm)
        {
            var Name = frm.Get("data[q]");
            var CustomerId = frm.Get("CustomerId");
            Sell.Contract.Contract contract = new Sell.Contract.Contract();
            //if (CustomerId != null && CustomerId != "0")
            //{
            //    var _CustomerId = Convert.ToInt32(CustomerId);
            //    var data = contract.GetAllContractListCombo(_CustomerId, 0).Where(p => p.Text.Contains(Name)).Take(10).Select(p => new { id = p.Value, text = p.Text });
            //    return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            var data = contract.GetAllContractListCombo().Where(p => p.Text.Contains(Name)).Take(10).Select(p => new { id = p.Value, text = p.Text });
            return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
            //}
        }
        public JsonResult searchContractlistByCustomerID(int CustomerId)
        {
            Sell.Contract.Contract contract = new Sell.Contract.Contract();
            var _CustomerId = Convert.ToInt32(CustomerId);
            var data = contract.GetAllContractListCombo(_CustomerId, 0).Take(10).Select(p => new { id = p.Value, text = p.Text });
            var model = new List<SelectListItem>();
            model.Add(new SelectListItem
            {
                Value = "0",
                Text = "انتخاب کنید"
            });
            model.AddRange(data.Select(p => new SelectListItem
             {
                 Text = p.text,
                 Value = p.id
             }));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchFactors(FormCollection frm)
        {
            var Name = frm.Get("data[q]");
            Sell.Contract.Contract contract = new Sell.Contract.Contract();
            var data = contract.GetAllContractListAll().Where(p => p.CNTSerial.Contains(Name)).Select(p => new { id = p.CNTID, text = p.CNTSerial });
            return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchDocNo(FormCollection frm)
        {
            var Name = frm.Get("data[q]");
            Sell.Contract.Contract contract = new Sell.Contract.Contract();
            var data = contract.GetAllContractListAll().Where(p => p.CNTSerial.Contains(Name)).Select(p => new { id = p.CNTID, text = p.CNTSerial });
            return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchContractForm(FormCollection frm)
        {
            var Name = frm.Get("data[q]");
            Sell.Contract.Contract contract = new Sell.Contract.Contract();
            var data = contract.GetAllContractListAll().Where(p => p.CNTSerial.Contains(Name)).Select(p => new { id = p.CNTID, text = p.CNTSerial });
            return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
        }
        //SearchDocNo
        //    
        //   
        //    
        public JsonResult GetContractHeader(int id)
        {
            Sell.Contract.Contract contract = new Sell.Contract.Contract();
            var data = contract.GetAllContractListCombo().Where(p => p.Value == id.ToString());
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetAgent(int id)
        {
            Sell.Agents.Agents agent = new Sell.Agents.Agents();
            var model = agent.GetByID(id);
            model.Agent_AGNDesc = model.Agent_AGNCode + " - " + model.Agent_AGNDesc;
            List<Sell.Agents.AgentsModel> list = new List<Sell.Agents.AgentsModel>();
            list.Add(model);
            return Json(list.ToComboBoxListItemNonDefault(p => p.Agent_AGNDesc, p => p.Agent_AGNID, false, ""), JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetCustomer(int id)
        {
            Sell.ContractCustomer.ContractCustomer customer = new Sell.ContractCustomer.ContractCustomer();
            var model = customer.GetAllListCombo(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetConteractById(int ContractId)
        {
            Sell.Contract.Contract contract = new Sell.Contract.Contract();
            var model = contract.GetByID(ContractId);
            var Con = contract.GetAllContractList().Where(p => p.CNTID == ContractId);
            try
            {
                model.ContractStatusDesc = Con.FirstOrDefault().STATUSDESC;
            }
            catch (Exception ex)
            {
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractMasterSearch()
        {
            Sell.Contract.Contract contract = new Sell.Contract.Contract();
            var data = contract.GetAllContractList().OrderByDescending(p => p.CNTID);
            int startRec = 0;
            int.TryParse(Request["start"], out startRec);
            int pageSize = 10;
            int.TryParse(Request["length"], out pageSize);
            var search = Request["search[value]"];
            var order = Request["order[0][column]"];
            var direction = Request["order[0][dir]"];
            if (search != "")
            {
                data = data.Where(p => p.CNTSerial.Contains(search) || p.CustomerName.Contains(search) || p.AgencyDesc.Contains(search) || p.CNTID.ToString().Contains(search) || p.CNTDate.Contains(search)).OrderByDescending(p => p.CNTID);
            }
            var model = data.Skip(startRec).Take(pageSize).ToList();
            return Json(new
            {
                sEcho = "",
                iTotalRecords = data.Count(),
                iTotalDisplayRecords = data.Count(),
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractColor(int SalesRowID, int ContractId)
        {
            Sell.Contract.ContractDetail contract = new Sell.Contract.ContractDetail();
            var data = contract.GetColorPriority(SalesRowID, ContractId);
            return Json(new
            {
                sEcho = "",
                iTotalRecords = data.Count(),
                iTotalDisplayRecords = data.Count(),
                aaData = data
            }, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractDetailProductType(int GroupId)
        {
            Sell.Products.Products product = new Sell.Products.Products();
            var model = product.GetProductTypeByGroupId(GroupId);
            return Json(model.ToComboBoxListItem(p => p.Name, p => p.Id, false, ""), JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractDetailSalesRow(int ProductType)
        {
            Sell.Products.Products product = new Sell.Products.Products();
            var model = product.GetSaleRowByProductTypeId(ProductType);
            return Json(model.ToComboBoxListItem(p => p.Name, p => p.Id, false, ""), JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractDetailSalesRowDetail(int SalesRowId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var query = from t in context.T00050009s
                        where t.SaleRowID == SalesRowId
                        select t;
            return Json(new { Date = query.First().DelFromDate, saletype = query.First().F_SaleTypeID, Discount = query.FirstOrDefault().Discount }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomerType(int CustomerID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var query = from t in context.T00050001s
                        where t.CMID == CustomerID
                        select t;
            return Content(query.FirstOrDefault().CMType.ToString());
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult CheckContractDetailPercent(int Value, int SalesRowId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var query = (from t in context.T00050009s
                         where t.SaleRowID == SalesRowId
                         select t).FirstOrDefault();
            //if (query.Discount != 0)
            //{
            if (Value > query.Discount)
                return Content("err");
            else
                return Content("ok");
            //  }
            //else if (query.DiscountPrcnt != 0)
            //{
            //    if (Value >= query.Discount)
            //        return Content("err");
            //    else
            //        return Content("ok");
            //}
            //else
            // {
            //     return Content("ok");
            // }
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractDetailProductUsage(int ProductType)
        {
            Sell.Products.Products product = new Sell.Products.Products();
            var model = product.GetProductUsageByProductTypeId(ProductType);
            return Json(model.ToComboBoxListItem(p => p.pt_desc, p => p.F_pyprmtflID, false, ""), JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractAttachment(int ContractRowId)
        {
            Sell.ContractAttach.ContractAttach contractattach = new Sell.ContractAttach.ContractAttach();
            var model = contractattach.GetContractAttachDetailByContractRowId(ContractRowId);
            return Json(new
            {
                sEcho = "",
                iTotalRecords = model.Count(),
                iTotalDisplayRecords = 3,
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAttachment(int attachId)
        {
            //get recieveid
            byte[] fileData;
            string fileName;
            DataLayer.MailDBDataContext context = new DataLayer.MailDBDataContext();
            Sell.ContractAttach.ContractAttach contractattach = new Sell.ContractAttach.ContractAttach();
            var attach = contractattach.GetById(attachId);
            //only one record will be returned from database as expression uses condtion on primary field
            //so get first record from returned values and retrive file content (binary) and filename 
            fileData = (byte[])attach.ContractAttach_FileContent;
            fileName = DateTime.Now.ToString().Replace("/", "");
            fileName = fileName + ".jpg";
            fileName = fileName.Replace(":", "");
            fileName = fileName.Replace(" ", "");
            //return file and provide byte file content and file name
            string Path = "\\UserFiles\\" + BAL.StaticData.User.User_UserId + "\\" + attach.ContractAttach_FileId + "\\";
            string PhysicalPath = Server.MapPath("\\UserFiles\\" + BAL.StaticData.User.User_UserId + "\\" + attach.ContractAttach_FileId + "\\");
            if (!System.IO.Directory.Exists(PhysicalPath))
            {
                System.IO.Directory.CreateDirectory(PhysicalPath);
            }
            Path = Path + (fileName);
            PhysicalPath = PhysicalPath + (fileName.Replace("%", ""));
            System.IO.StreamWriter writer = new System.IO.StreamWriter(PhysicalPath, false, System.Text.Encoding.GetEncoding(1256));
            var data = GetString(attach.ContractAttach_FileContent);
            writer.Write(data);
            writer.Close();
            Path = "/UserFiles/" + BAL.StaticData.User.User_UserId + "/" + attach.ContractAttach_FileId + "/" + fileName.Replace("%", "");
            return Content(Path);
        }
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        [HttpPost]
        public JsonResult CreateAttachment(string data, HttpPostedFileBase file)
        {
            Sell.ContractAttach.ContractAttach contractattach = new Sell.ContractAttach.ContractAttach();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var model = serializer.Deserialize<Sell.ContractAttach.ContractAttachModel>(data);
            if (model.ContractAttach_FileId == 0)
            {
                if (model.ContractAttach_FileType == 0)
                    model.ContractAttach_FileType = null;
                var TempData = new byte[file.ContentLength];
                file.InputStream.Read(TempData, 0, file.ContentLength);
                var Encoding = System.Text.Encoding.GetEncoding(1256);
                string ReadedData = Encoding.GetString(TempData);
                var content = new byte[ReadedData.ToCharArray().Length * 2];
                System.Buffer.BlockCopy(ReadedData.ToCharArray(), 0, content, 0, ReadedData.ToCharArray().Length * 2);
                model.ContractAttach_FileContent = content;
                contractattach.Insert(model);
                ResultType result = new ResultType();
                result.Status = 0;
                result.ReturnType = 1;
                result.Message = "پیوست ذخیره شد";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (model.ContractAttach_FileType == 0)
                    model.ContractAttach_FileType = null;
                contractattach.Edit(model);
                ResultType result = new ResultType();
                result.Status = 0;
                result.ReturnType = 1;
                result.Message = "پیوست ویرایش شد";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        public Boolean CheckContractStatusForDelete(int FileID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var query = (from t in context.T00050036s
                         where t.FileId == FileID
                         select t).FirstOrDefault();
            var querya = (from t in context.T00050015s
                          where t.CNTRowID == query.F_CntRowId
                          select t).FirstOrDefault();
            var queryb = (from t in context.T00050014s
                          where t.CNTID == querya.F_CNTID
                          select t).FirstOrDefault();
            if (queryb.FlgOkContract == 0)
                return false;
            else return true;
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        [HttpPost]
        public JsonResult DeleteAttachment(int id)
        {
            try
            {
                if (CheckContractStatusForDelete(id))
                {
                    ResultType result = new ResultType();
                    result.Status = -1;
                    result.ReturnType = 0;
                    result.Message = "قرارداد تایید شده و قادر به حذف نمی باشد";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                Sell.ContractAttach.ContractAttach contract = new Sell.ContractAttach.ContractAttach();
                if (contract.Delete(id))
                {
                    ResultType result = new ResultType();
                    result.Status = 0;
                    result.ReturnType = 1;
                    result.Message = "پیوست حذف  شد";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ResultType result = new ResultType();
                    result.Status = -1;
                    result.ReturnType = 0;
                    result.Message = "خطا در حذف";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ResultType result = new ResultType();
                result.Status = -1;
                result.ReturnType = 0;
                result.Message = ex.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractDetailColor(int SaleRowId)
        {
            Sell.Products.Products products = new Sell.Products.Products();
            var model = products.GetProductColor(SaleRowId).ToComboBoxListItem(p => p.ColorDesc, p => p.F_ColorID, false, "");
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractDetail(int ContractId)
        {
            Sell.Contract.ContractDetail contractdetail = new Sell.Contract.ContractDetail();
            var model = contractdetail.GetContractDetailByContractId(ContractId);
            return Json(new
            {
                sEcho = "",
                iTotalRecords = model.Count(),
                iTotalDisplayRecords = 3,
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractDetailItemCreate(Sell.Contract.ContractDetailModel model)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Delivery = new Sell.Agents.Agents().GetByID((int)model.ContractDetail_F_DeliveryAddressID);
            var result = new Sell.Contract.ContractDetailViewModel
            {
                AssignAble = (byte?)model.ContractDetail_AssignAble,
                CarCode = 0,
                CNTPercent = model.ContractDetail_CNTPercent,
                CNTQuantity = model.ContractDetail_CNTQuantity,
                CNTRowID = model.ContractDetail_CNTRowID,
                CntRowNo = (byte?)model.ContractDetail_CntRowNo,
                CNTRowStatus = 0,
                Color = new Sell.Products.Products().GetProductColor().Where(p => p.F_ColorID == model.ContractDetail_F_ColorID).FirstOrDefault().ColorDesc,
                Decoration = new Sell.Products.Products().GetProductDecoration().Where(p => p.pyprmtflID == model.ContractDetail_F_DecorationID).FirstOrDefault().pt_desc,
                DeliveryAddress = Delivery.Agent_AGNCode + "-" + Delivery.Agent_AGNDesc,
                DocumentBy = (byte?)model.ContractDetail_DocumentBy,
                F_ColorID = model.ContractDetail_F_ColorID,
                F_DecorationID = model.ContractDetail_F_DecorationID,
                F_DeliveryAddressID = model.ContractDetail_F_DeliveryAddressID,
                F_EsghatyID = model.ContractDetail_F_EsghatyID,
                F_SaleRowID = model.ContractDetail_F_SaleRowID,
                F_UsageType = model.ContractDetail_F_UsageType,
                FactorBy = (byte?)model.ContractDetail_FactorBy,
                HavaleBy = (byte?)model.ContractDetail_HavaleBy,
                Mosharekat = (byte?)model.ContractDetail_Mosharekat, 
                SaleRowDesc = context.T00050009s.Where(p => p.SaleRowID == model.ContractDetail_F_SaleRowID).FirstOrDefault().SaleRowDesc,
                SayerHazSh = model.ContractDetail_SayerHazSh,
                ShomarehGozari = model.ContractDetail_ShomarehGozari,
                StatusDesc = "",
                tax = model.ContractDetail_Tax,
                PelakOwner= model.PlackOwnerText
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractDetailComboBox(int ContractId)
        {
            Sell.Contract.ContractDetail contractdetail = new Sell.Contract.ContractDetail();
            var model = contractdetail.GetContractDetailByContractIdCombo(ContractId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractOption(int SelectedContractDetailId)
        {
            Sell.CarsOption.CarsOption option = new Sell.CarsOption.CarsOption();
            var model = option.GetByContractId(SelectedContractDetailId);
            return Json(new
            {
                sEcho = "",
                iTotalRecords = model.Count(),
                iTotalDisplayRecords = 3,
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractInsurance(int CarTypeID, int CntRowID)
        {
            Sell.Insurance.Insurance insurance = new Sell.Insurance.Insurance();
            var model = insurance.GetByContractId(CarTypeID, CntRowID);
            return Json(new
            {
                sEcho = "",
                iTotalRecords = model.Count(),
                iTotalDisplayRecords = 3,
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        [HttpPost]
        public JsonResult InsertInsurance(int InstId, int CntRowID, int Free)
        {
            Sell.Insurance.Insurance insurance = new Sell.Insurance.Insurance();
            insurance.Insert(InstId, CntRowID, (Free == 1) ? true : false);
            return Json("بیمه ذخیره شد");
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        [HttpPost]
        public JsonResult DeleteInsurance(int CntRowID)
        {
            Sell.Insurance.Insurance insurance = new Sell.Insurance.Insurance();
            insurance.Delete(CntRowID);
            return Json("بیمه حذف شد");
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        [HttpPost]
        public JsonResult ReqDeleteContract(int ContractId)
        {
            try
            {
                Sell.Contract.Contract contract = new Sell.Contract.Contract();
                if (contract.Delete(ContractId))
                {
                    ResultType result = new ResultType();
                    result.Status = 0;
                    result.ReturnType = 1;
                    result.Message = "درخواست انصراف ثبت شد";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ResultType result = new ResultType();
                    result.Status = -1;
                    result.ReturnType = 0;
                    result.Message = "خطا در انصراف قرارداد";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ResultType result = new ResultType();
                result.Status = -1;
                result.ReturnType = 0;
                result.Message = ex.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        [HttpPost]
        public JsonResult DeleteContract(int ContractId)
        {
            try
            {
                Sell.Contract.Contract contract = new Sell.Contract.Contract();
                if (contract.Delete(ContractId))
                {
                    ResultType result = new ResultType();
                    result.Status = 0;
                    result.ReturnType = 1;
                    result.Message = "قرارداد ابطال  شد";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ResultType result = new ResultType();
                    result.Status = -1;
                    result.ReturnType = 0;
                    result.Message = "خطا در ابطال قرارداد";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ResultType result = new ResultType();
                result.Status = -1;
                result.ReturnType = 0;
                result.Message = ex.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        [HttpPost]
        public ActionResult CheckContractStateForDelete(int ContractId)
        {
            try
            {
                Sell.Contract.Contract contract = new Sell.Contract.Contract();
                var Con = contract.GetByID(ContractId);
                return Content(Con.Contract_CntStatus.ToString());
            }
            catch (Exception ex)
            {
                ResultType result = new ResultType();
                result.Status = -1;
                result.ReturnType = 0;
                result.Message = ex.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult CheckContractStateForEdit(int ContractId)
        {
            try
            {
                Sell.Contract.Contract contract = new Sell.Contract.Contract();
                var Con = contract.GetByID(ContractId);
                return Content((Con.Contract_CntStatus == 48) ? "true" : "false");
            }
            catch (Exception ex)
            {
                ResultType result = new ResultType();
                result.Status = -1;
                result.ReturnType = 0;
                result.Message = ex.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult ContractCycle(int? SelectedContractId)
        {
            return View();
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult ContractOption()
        {
            return View();
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult ContractAttach(int? SelectedContractId)
        {
            return View();
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult ContractTermOfSales(int? id)
        {
            ViewBag.ContractTermOfSalesRowId = id;
            return View();
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult ContractPrint(int? SelectedContractId)
        {
            return View();
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult ContractDetail(int? SelectedContractId, int? SelectedContractDetailId)
        {
            if (SelectedContractDetailId != null)
            {
                Sell.Contract.ContractDetail contractDetail = new Sell.Contract.ContractDetail();
                var model = contractDetail.GetByID((int)SelectedContractDetailId);
                return View(model);
            }
            else
                return View();
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult ContractDetailNewEdit(Sell.Contract.ContractDetailModel model)
        {
            return View(model);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult ContractDetailFillCombosNotSaved(string DetailItem)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            Sell.Contract.ContractDetail contractDetail = new Sell.Contract.ContractDetail();
            var model = serializer.Deserialize<Sell.Contract.ContractDetailEditModel>(DetailItem);
            var SalesRow = context.T00050009s.Where(p => p.SaleRowID == model.ContractDetail_F_SaleRowID).FirstOrDefault();
            var ProductUsage = new Sell.Products.Products().GetProductUsageByProductTypeId(SalesRow.CarCode).Where(p => p.F_pyprmtflID == model.ContractDetail_F_UsageType).FirstOrDefault();
            var ProductType = context.T00050016s.Where(p => p.CarId == SalesRow.CarCode).FirstOrDefault();
            var Decoration = new Sell.Products.Products().GetProductDecoration().Where(p => p.pyprmtflID == model.ContractDetail_F_DecorationID).FirstOrDefault();
            var Color = new Sell.Products.Products().GetProductColor().Where(p => p.F_ColorID == model.ContractDetail_F_ColorID).FirstOrDefault();
            var Delivery = new Sell.Agents.Agents().GetByID((int)model.ContractDetail_F_DeliveryAddressID);
            var ProductGroup = context.T00020002s.Where(p => p.pyprmtflID == ProductType.CarGroup).FirstOrDefault();
            return Json(new
            {
                ProductGroup = ProductGroup.pt_desc,
                ProductType = ProductType.CarName,
                ProductUsage = (ProductUsage == null) ? "انتخاب کنید" : ProductUsage.pt_desc,
                SalesRow = SalesRow.SaleRowDesc,
                Decoration = Decoration.pt_desc,
                Color = Color.ColorDesc,
                DeliveryAddress = Delivery.Agent_AGNCode + "-" + Delivery.Agent_AGNDesc,
                ProductGroupId = ProductType.CarGroup,
                ProductTypeId = ProductType.CarId,
                ProductUsageId = (ProductUsage == null) ? 0 : model.ContractDetail_F_UsageType,
                SalesRowId = model.ContractDetail_F_SaleRowID,
                DecorationId = model.ContractDetail_F_DecorationID,
                ColorId = model.ContractDetail_F_ColorID,
                DeliveryAddressId = model.ContractDetail_F_DeliveryAddressID,
                AssignAble = model.ContractDetail_AssignAble,
                ShomarehGozari = model.ContractDetail_ShomarehGozari,
                SayerHazSh = model.ContractDetail_SayerHazSh,
                PelakOwner = model.PlackOwnerText
            }, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult ContractDetailFillCombos(int SelectedContractDetailId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            Sell.Contract.ContractDetail contractDetail = new Sell.Contract.ContractDetail();
            var model = contractDetail.GetByID((int)SelectedContractDetailId);
            var SalesRow = context.T00050009s.Where(p => p.SaleRowID == model.ContractDetail_F_SaleRowID).FirstOrDefault();
            var ProductUsage = new Sell.Products.Products().GetProductUsageByProductTypeId(SalesRow.CarCode).Where(p => p.F_pyprmtflID == model.ContractDetail_F_UsageType).FirstOrDefault();
            var ProductType = context.T00050016s.Where(p => p.CarId == SalesRow.CarCode).FirstOrDefault();
            var Decoration = new Sell.Products.Products().GetProductDecoration().Where(p => p.pyprmtflID == model.ContractDetail_F_DecorationID).FirstOrDefault();
            var Color = new Sell.Products.Products().GetProductColor().Where(p => p.F_ColorID == model.ContractDetail_F_ColorID).FirstOrDefault();
            var Delivery = new Sell.Agents.Agents().GetByID((int)model.ContractDetail_F_DeliveryAddressID);
            var ProductGroup = context.T00020002s.Where(p => p.pyprmtflID == ProductType.CarGroup).FirstOrDefault();
            return Json(new
            {
                ProductGroup = ProductGroup.pt_desc,
                ProductType = ProductType.CarName,
                ProductUsage = (ProductUsage == null) ? "انتخاب کنید" : ProductUsage.pt_desc,
                SalesRow = SalesRow.SaleRowDesc,
                Decoration = Decoration.pt_desc,
                Color = Color.ColorDesc,
                DeliveryAddress = Delivery.Agent_AGNCode + "-" + Delivery.Agent_AGNDesc,
                ProductGroupId = ProductType.CarGroup,
                ProductTypeId = ProductType.CarId,
                ProductUsageId = (ProductUsage == null) ? 0 : model.ContractDetail_F_UsageType,
                SalesRowId = model.ContractDetail_F_SaleRowID,
                DecorationId = model.ContractDetail_F_DecorationID,
                ColorId = model.ContractDetail_F_ColorID,
                DeliveryAddressId = model.ContractDetail_F_DeliveryAddressID,
                AssignAble = model.ContractDetail_AssignAble,
                ShomarehGozari = model.ContractDetail_ShomarehGozari,
                SayerHazSh = model.ContractDetail_SayerHazSh
            }, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult ContractRecipt(int? SelectedContractId)
        {
            if (SelectedContractId != null)
                ViewBag.SelectedContractId = SelectedContractId;
            else
                ViewBag.SelectedContractId = 0;
            return View();
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult SearchContract()
        {
            return View();
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult Insurance(int? SelectedContractId)
        {
            return View();
        }
        //
        // GET: /Contract/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        [HttpPost]
        public ActionResult Create(ContractCreateModel model)
        {
            try
            {
                Sell.Contract.Contract contract = new Sell.Contract.Contract();
                DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
                if (model.contractMaster.Contract_CNTID == 0)
                {
                    int CarCode = new DataLayer.AtsTotalNewDataContext().T00050009s.Where(p => p.SaleRowID == model.ContractDetail.FirstOrDefault().ContractDetail_F_SaleRowID).FirstOrDefault().CarCode;
                    var AgnCode = (from t in context.T00050002s where t.AGNID == model.contractMaster.Contract_F_AgencyID select t).FirstOrDefault().AGNCode;
                    //model.contractMaster.Contract_F_AgencyID = Convert.ToInt32(AgnCode);
                    model.contractMaster.Contract_CNTSerial = "";
                    int CNTID = contract.Insert(model.contractMaster);
                    //change serial
                    //edit serial
                    var query = (from t in context.T00050014s
                                 where t.CNTID == CNTID
                                 select t).FirstOrDefault();
                    var Year = (BAL.StaticData.DateNow.Date.Split('/')[0]).Substring(2, 2);
                    var SerialID = contract.GetContractSerial((int)model.contractMaster.Contract_F_AgencyID, CarCode, Year);
                    if (SerialID == "1")
                        query.CNTSerial = (Year + AgnCode.PadLeft(4, '0') + CarCode.ToString().PadLeft(2, '0') + SerialID.PadLeft(3, '0'));
                    else query.CNTSerial = SerialID;
                    context.SubmitChanges();
                    Sell.Contract.ContractDetail contractdetail = new Sell.Contract.ContractDetail();
                    int i = 1;
                    var CntRowID = 0;
                    foreach (var detail in model.ContractDetail)
                    {
                        detail.ContractDetail_F_CNTID = CNTID;
                        detail.ContractDetail_CntRowNo = i++;
                        CntRowID = contractdetail.Insert(detail);
                    }
                    ResultType result = new ResultType();
                    result.Status = 0;
                    result.ReturnType = 1;
                    result.Message = "قرارداد ثبت شد";
                    result.Parameters = new List<Tuple<string, string>>();
                    result.Parameters.Add(new Tuple<string, string>("Id", CNTID.ToString()));
                    result.Parameters.Add(new Tuple<string, string>("Code", SerialID));
                    result.Parameters.Add(new Tuple<string, string>("RowId", CntRowID.ToString()));
                    try
                    {
                        Sell.ContractAttach.ContractAttach attach = new Sell.ContractAttach.ContractAttach();
                        var ListData = (List<Sell.ContractAttach.ContractAttachViewModel>)Session["ContractAttachList"];
                        foreach (var record in ListData)
                        {
                            attach.Insert(new Sell.ContractAttach.ContractAttachModel
                            {
                                ContractAttach_F_CntRowId = CntRowID,
                                ContractAttach_FileCaption = record.ContractAttach_FileCaption,
                                ContractAttach_FileContent = record.ContractAttach_FileContent,
                                ContractAttach_FileId = 0,
                                ContractAttach_FileType = record.ContractAttach_FileType
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    Session["ContractAttachList"] = null;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    contract.Update(model.contractMaster);
                    Sell.Contract.ContractDetail contractdetail = new Sell.Contract.ContractDetail();
                    int i = 1;
                    foreach (var detail in model.ContractDetail)
                    {
                        contractdetail.Update(detail);
                    }
                    //edit contract
                    ResultType result = new ResultType();
                    result.Status = 0;
                    result.ReturnType = 1;
                    result.Parameters = new List<Tuple<string, string>>();
                    result.Parameters.Add(new Tuple<string, string>("Id", model.contractMaster.Contract_CNTID.ToString()));
                    result.Parameters.Add(new Tuple<string, string>("Code", model.contractMaster.Contract_CNTSerial));
                    result.Message = "قرارداد ویرایش شد";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ResultType result = new ResultType();
                result.Status = -1;
                result.ReturnType = 2;
                result.Message = ex.ToString();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetFileTypes(int SelectedRowSalesType, int CustomerType)
        {
            //customertype
            // 1 haghighi
            //2 hoghoghi
            //saleros
            //16 naghdi
            // lizingi
            var type = 0;
            if (CustomerType == 1 && SelectedRowSalesType == 16)
            {
                //haghighi naghdi
                type = 3;
            }
            if (CustomerType == 2 && SelectedRowSalesType == 16)
            {
                //hoghoghi naghdi
                type = 4;
            }
            if (CustomerType == 1 && SelectedRowSalesType != 16)
            {
                //haghighi lizing
                type = 5;
            }
            if (CustomerType == 2 && SelectedRowSalesType != 16)
            {
                //hoghoghi lizing
                type = 6;
            }
            var query = new DataLayer.AtsTotalNewDataContext().TblMadareks.Where(p => p.Type == type);
            var result = query.Select(p => new SelectListItem
            {
                Text = p.Dsc,
                Selected = false,
                Value = p.MID.ToString()
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int id)
        {
            ViewBag.ContractId = id;
            return View();
        }
        public ActionResult ContractReport(int? SelectedContractId)
        {
            if (SelectedContractId != null)
                ViewBag.SelectedContractId = SelectedContractId;
            else
                ViewBag.SelectedContractId = 0;
            return View();
        }
        public ActionResult RegistryPrint()
        {
            return View();
        }
        public ActionResult Viewer()
        {
            Session["CR_ContractNoFrom"] = Request.QueryString["CR_ContractNoFrom"];
            Session["CR_ContractNoTo"] = Request.QueryString["CR_ContractNoTo"];
            Session["CR_ContractDateTo"] = Request.QueryString["CR_ContractDateTo"];
            Session["CR_ContractDateFrom"] = Request.QueryString["CR_ContractDateFrom"];
            Session["CR_Customer"] = Request.QueryString["CR_Customer"];
            return View();
        }
        public ActionResult Viewerr()
        {
            Session["Contract_CNTID"] = Request.QueryString["Contract_CNTID"];
            Session["ContractRowId"] = Request.QueryString["ContractRowId"];
            Session["customerid"] = Request.QueryString["customerid"];
            return View();
        }
        public ActionResult getsnapshotviwerr()
        {
            var context = new DataLayer.AtsTotalNewDataContext();
            var stireport1 = new StiReport();
            Sell.Contract.Report repo = new Sell.Contract.Report();
            Sell.Contract.ContractPrintModel repoo = new Sell.Contract.ContractPrintModel();
            if (Convert.ToInt32(Session["Contract_CNTID"]) == 0 && Convert.ToInt32(Session["customerid"]) != 0)
            {
                var model3 = repo.GetContractPrint(new Sell.Contract.Contract()
                    .GetByIDCustomer(Convert.ToInt32(Session["customerid"]))
                    .Contract_CNTID, new Sell.Contract.Contract()
                    .GetByIDCustomer(Convert.ToInt32(Session["customerid"]))
                    .Contract_CNTID);
                stireport1.RegBusinessObject("Cantract", model3);
                stireport1.Load(Server.MapPath("/Content/report/Cantractt.mrt"));
                return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport1);
            }
            else
            {
                var CNTID = Convert.ToInt32(Session["Contract_CNTID"]);
                var result = context.ExecuteQuery<Models.CarGroups>($"[sale].[STP_T00050014];172 @CNTID={CNTID}");
                if (result.Any(p => !p.CarGroup.Equals(1507))) {
                    var model3 = repo.GetContractPrint(Convert.ToInt32(Session["Contract_CNTID"]), Convert.ToInt32(Session["ContractRowId"]));
                    stireport1.RegBusinessObject("Cantract", model3);
                    stireport1.Load(Server.MapPath("/Content/report/Cantractt.mrt"));
                    return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport1);
                }
                else
                {
                    var query = context.ExecuteQuery<Models.PickupContract>($"[sale].[STP_T00050014];171 @CNTID={CNTID}");
                    var row = query.Take(1).ToList();
                    stireport1.Load(Server.MapPath("/Content/report/RequestPrepayment.mrt"));
                    stireport1.Compile();
                    stireport1["Name"]=row[0].CMFLName;
                    stireport1["Parent"]=row[0].CMFatherName;
                    stireport1["NationalCode"] = row[0].CMNationalCode;
                    stireport1["BirthCertificateId"] = row[0].CMIDNo;
                    stireport1["BirthDate"] = row[0].CMBirthDate;
                    stireport1["HomeTown"] = row[0].MahalTavalod;
                    stireport1["PlaceOfIssue"] = row[0].MahalSodor;
                    stireport1["DateOfIssus"] = row[0].CMIssueDate;
                    stireport1["MobileNo"] = row[0].MobileNo;
                    stireport1["Email"] = row[0].EmailAddress;
                    stireport1["HomeTel"] = row[0].TelNo;
                    stireport1["PostalCode"] = row[0].CMPostCode;
                    stireport1["Address"] = row[0].CMAddress;
                    stireport1["Model"] = row[0].CarName;
                    stireport1["CarType"] = row[0].CarTipDsc;
                    stireport1["ModelYear"] = DateTime.Parse(row[0].CNTDate).Year.ToString() ;
                    stireport1["CarColor"] = row[0].Color;
                    stireport1["ContractDate"] = row[0].CNTDate;
                    stireport1["ContractNo"] = row[0].CNTSerial;
                    stireport1.Render();
                    return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport1);
                }
            }
        }
        public ActionResult getsnapshotviwer()
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            Sell.Contract.Report repo = new Sell.Contract.Report();
            var model = repo.GetSaleFlowChartReport(Session["CR_ContractNoFrom"].ToString(), Session["CR_ContractNoTo"].ToString(), Session["CR_ContractDateFrom"].ToString(), Session["CR_ContractDateTo"].ToString(), Convert.ToInt32(Session["CR_Customer"]));
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ContractFlow", model);
            stireport2.Load(Server.MapPath("/Content/report/ContractFlow.mrt"));
            stireport2.Dictionary.Variables["FRomDate"].Value = BAL.StaticData.DateNow.Date;
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerEvent()
        {
            //Automation.Reciever.Reciever reciv = new Automation.Reciever.Reciever();
            //var reciv2 = reciv.GetAllList();
            //StiReport stireport2 = new StiReport();
            //stireport2.RegBusinessObject("RecieverModel", reciv2);
            //stireport2.Load("Content\report\bReport.mrt");
            return StiMvcViewer.ViewerEventResult(HttpContext);
        }
        public ActionResult PrintReport()
        {
            return StiMvcViewer.PrintReportResult(HttpContext);
        }
        public ActionResult ExportReport()
        {
            return StiMvcViewer.ExportReportResult(HttpContext);
        }
        public ActionResult Interactiom()
        {
            return StiMvcViewer.InteractionResult(HttpContext);
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult GetContractWizardAttachment()
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            Sell.ContractAttach.ContractAttach contractattach = new Sell.ContractAttach.ContractAttach();
            var query = (List<Sell.ContractAttach.ContractAttachViewModel>)Session["ContractAttachList"];
            var result = new List<Sell.ContractAttach.ContractAttachViewModel>();
            if (query != null)
            {
                foreach (var a in query)
                {
                    if (a.ContractAttach_FileType != 0 && a.ContractAttach_FileType != null)
                    {
                        var aa = from t in context.TblMadareks
                                 where
                                 t.MID == a.ContractAttach_FileType
                                 select t;
                        a.ContractAttach_FileTypeName = aa.FirstOrDefault().Dsc;
                    }
                    result.Add(new Sell.ContractAttach.ContractAttachViewModel
                    {
                        ContractAttach_FileTypeName = a.ContractAttach_FileTypeName,
                        ContractAttach_FileType = a.ContractAttach_FileType,
                        ContractAttach_FileId = a.ContractAttach_FileId,
                        ContractAttach_FileCaption = a.ContractAttach_FileCaption,
                        ContractAttach_F_CntRowId = a.ContractAttach_F_CntRowId
                    });
                }
            }
            return Json(new
            {
                sEcho = "",
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        [Framework.Security.LogsRequests]
        [Framework.Security.CoreAuthorize]
        public ActionResult AddContractWizardFile(HttpPostedFileBase file, string data)
        {
            List<Sell.ContractAttach.ContractAttachViewModel> ListData = null;
            if (Session["ContractAttachList"] == null)
                ListData = new List<Sell.ContractAttach.ContractAttachViewModel>();
            else
                ListData = (List<Sell.ContractAttach.ContractAttachViewModel>)Session["ContractAttachList"];
            var id = 0;
            foreach (var record in ListData)
                if (record.ContractAttach_FileId > id)
                    id = record.ContractAttach_FileId;
            id++;
            Sell.ContractAttach.ContractAttachViewModel model = new Sell.ContractAttach.ContractAttachViewModel();
            var TempData = new byte[file.ContentLength];
            file.InputStream.Read(TempData, 0, file.ContentLength);
            var Encoding = System.Text.Encoding.GetEncoding(1256);
            string ReadedData = Encoding.GetString(TempData);
            var content = new byte[ReadedData.ToCharArray().Length * 2];
            System.Buffer.BlockCopy(ReadedData.ToCharArray(), 0, content, 0, ReadedData.ToCharArray().Length * 2);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var Data = serializer.Deserialize<Sell.ContractAttach.ContractAttachViewModel>(data);
            model.ContractAttach_FileId = id;
            model.ContractAttach_FileCaption = Data.ContractAttach_FileCaption;
            model.ContractAttach_FileType = Data.ContractAttach_FileType;
            model.ContractAttach_FileTypeName = (new DataLayer.AtsTotalNewDataContext()).TblMadareks.Where(p => p.MID == model.ContractAttach_FileType).FirstOrDefault().Dsc;
            model.ContractAttach_FileContent = content;
            ListData.Add(model);
            Session["ContractAttachList"] = ListData;
            return Content(id.ToString());
        }
    }
    public class ContractCreateModel
    {
        public Sell.Contract.ContractModel contractMaster { get; set; }
        public List<Sell.Contract.ContractDetailModel> ContractDetail { get; set; }
    }
}
