var SelectedContractId = 0;
var SelectedContractDetailId = 0;
var SelectedContractDetailItems = [];
var SelectedContractDetailRow = null;
//لیست کردن ارری////
jQuery.fn.serializeAllArray = function () {
    var obj = {};
    $('input', this).each(function () {
        obj[this.name] = $(this).val();
    });
    return $.param(obj);
}
jQuery.fn.serializeObject = function () {
    var arrayData, objectData;
    arrayData = this.serializeArray();
    //arrayData = this.serializeAllArray();
    objectData = {};
    $.each(arrayData, function () {
        var value;
        if (this.value != null) {
            value = this.value;
        } else {
            value = '';
        }
        if (objectData[this.name] != null) {
            if (!objectData[this.name].push) {
                objectData[this.name] = [objectData[this.name]];
            }
            objectData[this.name].push(value);
        } else {
            objectData[this.name] = value;
        }
    });
    return objectData;
};
//***************************************************************detail contract
$(document).on("change", "#ContractDetailProductGroup", function () {
    //public JsonResult GetTermOfSaleProductType(int GroupId)
    var address = "/Contract/GetContractDetailProductType?GroupId=" + $("#ContractDetailProductGroup").val();
    LoadComboBox(address, "ContractDetailProductType", false)
})
$(document).on("change", "#ContractDetailProductType", function () {
    ///public JsonResult GetTermOfSaleSalesRow(int ProductType)
    var address = "/Contract/GetContractDetailSalesRow?ProductType=" + $("#ContractDetailProductType").val();
    LoadComboBox(address, "ContractDetail_F_SaleRowID", false)
    var address = "/Contract/GetContractDetailProductUsage?ProductType=" + $("#ContractDetailProductType").val();
    LoadComboBox(address, "ContractDetail_F_UsageType", false)
})
var SelectedRowSalesType = 0;
$(document).on("change", "#ContractDetail_F_SaleRowID", function () {
    ///public JsonResult GetTermOfSaleSalesRow(int ProductType)
    var address = "/Contract/GetContractDetailColor?SaleRowId=" + $("#ContractDetail_F_SaleRowID").val();
    LoadComboBox(address, "ContractDetail_F_ColorID", false)
    $.get("/Contract/GetContractDetailSalesRowDetail", { SalesRowId: $("#ContractDetail_F_SaleRowID").val() }, function (data) {
        $("#Contract_TahvilDate").val(data.Date);
        SelectedRowSalesType = data.saletype;
        $("#ContractDetail_CNTPercent").val(data.Discount);
        if (SelectedRowSalesType != 16) {
            $("#PlackOwnerText").val("");
            $("#PlackOwnerText").prop("disabled", true);
        }
        else {
            $("#PlackOwnerText").prop("disabled", false);
        }
    })
})
$(document).on("change", "#Contract_PublicSale", function () {
    if ($("#Contract_PublicSale").is(":checked")) {
        $("#btnContractInsurance").prop("disabled", true);
    } else {
        $("#btnContractInsurance").prop("disabled", false);
    }
})
//****************************************************************master contract
var ContractDetaildt;
function LoadContractMaster() {
    $.getJSON("/Contract/GetConteractById", { ContractId: SelectedContractId }, function (data) {
        console.log(data);
        $("#Contract_CNTDate").val(data.Contract_CNTDate);
        $("#Contract_F_AgencyID").val(data.Contract_F_AgencyID);
        LoadComboBox("/Contract/GetAgent/" + data.Contract_F_AgencyID, "Contract_F_AgencyID", true);
        $("#Contract_F_CustomerID").val(data.Contract_F_CustomerID);
        LoadComboBox("/Contract/GetCustomer/" + data.Contract_F_CustomerID, "Contract_F_CustomerID", true);
        $("#Contract_F_SponsorID").val(data.Contract_F_SponsorID);
        $("#Contract_CNTSerial").val(data.Contract_CNTSerial);
        $("#Contract_CNTCommissionPercent").val(data.Contract_CNTCommissionPercent);
        $("#Contract_PublicSale").val(data.Contract_PublicSale);
        if ($("#Contract_PublicSale").is(":checked")) {
            $("#btnContractInsurance").prop("disabled", true);
        } else {
            $("#btnContractInsurance").prop("disabled", false);
        }
        $("#ContractStatusDesc").val(data.ContractStatusDesc);
        $("#Contract_TahvilDate").val(data.Contract_TahvilDate);
        $("#Contract_CNTSerialOld").val(data.Contract_CNTSerialOld);
        $("#Contract_SendSms").prop("checked", data.Contract_SendSms);
        $("#Contract_CNTID").val(data.Contract_CNTID);
        $("#Contract_Alabel").val(data.Contract_CNTID);
        $("#btnContractInsurance").prop("disabled", false);
        $("#btnContractRecipt").prop("disabled", false);
        $("#btnContractCycle").prop("disabled", false);
        $("#btnContractOption").prop("disabled", false);
        $("#btnContractAttach").prop("disabled", false);
        $("#btnContractTermOfSales").prop("disabled", false);
        $("#btnContractSolh").prop("disabled", false);
        $("#btnContractPrintt").prop("disabled", false);
        SearchContractForm();
    });
}
function LoadContractMasterView() {
    $.getJSON("/Contract/GetConteractById", { ContractId: SelectedContractIdView }, function (data) {
        console.log(data);
        $("#Contract_CNTDateView").val(data.Contract_CNTDate);
        $("#Contract_CNTDateView").prop('disabled', true);
        $("#Contract_F_AgencyIDView").val(data.Contract_F_AgencyID);
        LoadComboBox("/Contract/GetAgent/" + data.Contract_F_AgencyID, "Contract_F_AgencyIDView", true, function () {
            ChangeComboState("Contract_F_AgencyIDView", true, true);
        });
        $("#Contract_F_CustomerIDView").val(data.Contract_F_CustomerID);
        LoadComboBox("/Contract/GetCustomer/" + data.Contract_F_CustomerID, "Contract_F_CustomerIDView", true, function () {
            ChangeComboState("Contract_F_CustomerIDView", true, true);
        });
        $("#Contract_F_SponsorIDView").val(data.Contract_F_SponsorID);
        ChangeComboState("Contract_F_SponsorIDView", true, true);
        $("#Contract_CNTSerialView").val(data.Contract_CNTSerial);
        $("#Contract_CNTSerialView").prop('disabled', true);
        $("#Contract_CNTCommissionPercentView").val(data.Contract_CNTCommissionPercent);
        $("#Contract_CNTCommissionPercentView").prop('disabled', true);
        $("#Contract_PublicSaleView").val(data.Contract_PublicSale);
        $("#Contract_PublicSaleView").prop('disabled', true);
        $("#btnContractInsuranceView").prop("disabled", true);
        $("#btnContractInsuranceView").prop('disabled', true);
        $("#ContractStatusDescView").val(data.ContractStatusDesc);
        $("#ContractStatusDescView").prop('disabled', true);
        $("#Contract_TahvilDateView").val(data.Contract_TahvilDate);
        $("#Contract_TahvilDateView").prop('disabled', true);
        $("#Contract_CNTSerialOldView").val(data.Contract_CNTSerialOld);
        $("#Contract_CNTSerialOldView").prop('disabled', true);
        $("#Contract_SendSmsView").prop("checked", data.Contract_SendSms);
        $("#Contract_SendSmsView").prop('disabled', true);
        $("#Contract_CNTIDView").val(data.Contract_CNTID);
        $("#Contract_CNTIDView").prop('disabled', true);
        $("#Contract_AlabelView").val(data.Contract_CNTID);
        $("#Contract_AlabelView").prop('disabled', true);
    });
}


//****************************************************detail contract table
function LoadContractDetail() {
    var address = "/Contract/GetContractDetail?ContractId=" + SelectedContractId;
    index = 0;
    SelectedContractDetailRow = null;
    var ex = document.getElementById('ContractDetailGrid');
    if (!$.fn.DataTable.fnIsDataTable(ex)) {
        ContractDetaildt = undefined;
    }
    if (ContractDetaildt == undefined) {
        ContractDetaildt = $('#ContractDetailGrid').DataTable({
            "processing": true,
            "jQueryUI": false,
            "scrollCollapse": true,
            "paging": false,
            "bAutoWidth": false,
            "bSort": false,
            "bFilter": false,
            "responsive": (IsMobileDevice) ? true : false,
            "fnInitComplete": function (oSettings, json) {
                setTimeout(function (e) {
                    $("#btnAddContractDetail").prop("disabled", true)
                }, 100);
            },
            "ajax": address,
            "columns": [
                {
                    "data": "IDt",
                    "title": "ردیف",
                    "width": "150px"
                },
        {
            "data": "SaleRowDesc",
            "title": "ردیف پیش فروش",
            "width": "150px"
        },
        {
            "data": "DeliveryAddress",
            "title": "محل تحویل",
            "width": "150px"
        },
         {
             "data": "Color",
             "title": "رنگ",
             "width": "150px"
         },
                        {
                            "data": "Decoration",
                            "title": "تو دوزی",
                            "width": "150px"
                        },
        {
            "data": "CNTQuantity",
            "title": "تعداد",
            "width": "150px"
        },
          {
              "data": "AssignAble",
              "title": "قابل واگذار",
              "width": "150px"
          },
          {
              "data": "StatusDesc",
              "title": "وضعیت ردیف قرارداد",
              "width": "150px"
          },
          {
              "data": "PelakOwner",
              "title": "صاحب پلاک",
              "width": "150px"
          },
            {
                "data": "Command",
                "title": "",
                "width": "150px"
            }],
            "columnDefs": [
             {
                 "render": function (data, type, row) {
                     //row.Mail_Subject
                     console.log(row);
                     console.log("aaa");
                     if (row.AssignAble == true) {
                         return "<input type='checkbox' data-value='' checked disabled />";
                     }
                     else {
                         return "<input type='checkbox' data-value='' disabled  />";
                     }
                 },
                 "targets": 6
             },
                 {
                     "render": function (data, type, row) {
                         var str = "";
                         console.log("bbb");
                         str = "<span class='EditContractDetail btn btn-warning' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' data-ContractDetailId='" + row.CNTRowID + "'>ویرایش</span>   <span class='DeleteContractDetail btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' data-ContractDetailId='" + row.CNTRowID + "'>حذف</span> "
                         return str;
                     },
                     "targets": 9
                 }
            ],
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                $("td:first", nRow).html(iDisplayIndex + 1);
                return nRow;
            },
            "fnDrawCallback": function () {
                $("#ContractDetailGrid_info").css({ 'width': '104.5%' });
                $("#ContractDetailGrid_info").html("<div class='PageNumbersInfo'>" + $("#ContractDetailGrid_info").html() + "</div>")
                $("#ContractDetailGrid_info").prepend("<input class='btnAddContractDetail btn btn-large btn-info' id='btnAddContractDetail' type='button' style='height:30px;padding:3px;font-family: yekan;font-size:10px' value='اضافه ردیف' >");
            },
            "createdRow": function (row, data, index) {
                //if (data.isRead == false) {
                //    $('td', row).addClass('highlight');
                //}
                //else {
                //    $('td', row).addClass('readed');
                //}
            }
        });
        var detailRows = [];
        $('#ContractDetailGrid tbody').on('click', 'tr', function () {
            //Select Row
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                ContractDetaildt.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                var row = ContractDetaildt.row($(this));
                SelectedContractDetailRow = row.data();
            }
        });
    }
    else {
        ContractDetaildt.ajax.url(address).load(function () {
            HideLoading();
            setTimeout(function (e) {
                $("#btnAddContractDetail").prop("disabled", true)
            }, 100);
        });
    }
}

//******************************just view detail
var ContractDetaildtView = undefined;
function LoadContractDetailView() {
    var address = "/Contract/GetContractDetail?ContractId=" + SelectedContractIdView;
    index = 0;
    SelectedContractDetailRowView = null;
    var ex = document.getElementById('ContractDetailGridView');
    if (!$.fn.DataTable.fnIsDataTable(ex)) {
        ContractDetaildtView = undefined;
    }
    if (ContractDetaildtView == undefined) {
        ContractDetaildtView = $('#ContractDetailGridView').DataTable({
            "processing": true,
            "jQueryUI": false,
            "scrollCollapse": true,
            "paging": false,
            "bAutoWidth": false,
            "bSort": false,
            "bFilter": false,
            "responsive": (IsMobileDevice) ? true : false,
            "fnInitComplete": function (oSettings, json) {
                setTimeout(function (e) {
                }, 100);
            },
            "ajax": address,
            "columns": [
                {
                    "data": "IDt",
                    "title": "ردیف",
                    "width": "150px"
                },
        {
            "data": "SaleRowDesc",
            "title": "ردیف پیش فروش",
            "width": "150px"
        },
        {
            "data": "DeliveryAddress",
            "title": "محل تحویل",
            "width": "150px"
        },
         {
             "data": "Color",
             "title": "رنگ",
             "width": "150px"
         },
          {
              "data": "Decoration",
              "title": "تو دوزی",
              "width": "150px"
          },
        {
            "data": "CNTQuantity",
            "title": "تعداد",
            "width": "150px"
        },
          {
              "data": "AssignAble",
              "title": "قابل واگذار",
              "width": "150px"
          },
          {
              "data": "StatusDesc",
              "title": "وضعیت ردیف قرارداد",
              "width": "150px"
          },
          {
              "data": "PelakOwner",
              "title": "صاحب پلاک",
              "width": "150px"
          },
            {
                "data": "Command",
                "title": "",
                "width": "150px"
            }],
            "columnDefs": [
             {
                 "render": function (data, type, row) {
                     //row.Mail_Subject
                     console.log(row);
                     console.log("aaa");
                     if (row.AssignAble == true) {
                         return "<input type='checkbox' data-value='' checked disabled />";
                     }
                     else {
                         return "<input type='checkbox' data-value='' disabled  />";
                     }
                 },
                 "targets": 6
             },
                 {
                     "render": function (data, type, row) {
                         var str = "";
                         console.log("bbb");
                         str = "<span class='EditContractDetail btn btn-warning' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' data-ContractDetailId='" + row.CNTRowID + "'>ویرایش</span>   <span class='DeleteContractDetail btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' data-ContractDetailId='" + row.CNTRowID + "'>حذف</span> "
                         return "";
                     },
                     "targets": 9
                 }
            ],
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                $("td:first", nRow).html(iDisplayIndex + 1);
                return nRow;
            },
            "fnDrawCallback": function () {
                // $("#ContractDetailGrid_info").css({ 'width': '104.5%' });
                // $("#ContractDetailGrid_info").html("<div class='PageNumbersInfo'>" + $("#ContractDetailGrid_info").html() + "</div>")
                // $("#ContractDetailGrid_info").prepend("<input class='btnAddContractDetail btn btn-large btn-info' id='btnAddContractDetail' type='button' style='height:30px;padding:3px;font-family: yekan;font-size:10px' value='اضافه ردیف' >");
            },
            "createdRow": function (row, data, index) {
                //if (data.isRead == false) {
                //    $('td', row).addClass('highlight');
                //}
                //else {
                //    $('td', row).addClass('readed');
                //}
            }
        });
        var detailRows = [];
        $('#ContractDetailGrid tbody').on('click', 'tr', function () {
            //Select Row
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                ContractDetaildtView.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                var row = ContractDetaildtView.row($(this));
                SelectedContractDetailRowView = row.data();
            }
        });
    }
    else {
        ContractDetaildtView.ajax.url(address).load(function () {
            HideLoading();
            setTimeout(function (e) {
                //   $("#btnAddContractDetail").prop("disabled", true)
            }, 100);
        });
    }
}
var IsContractDetailItemEdit = 0;
var IsContractDetailItemEdit = 0;
$(document).on("click", ".EditContractDetail", function (e) {
    var ContractDetailId = $(this).attr("data-ContractDetailId");
    e.preventDefault();
    if (ContractDetailId == 0) {
        //edit from List
        IsContractDetailItemEdit = 1;
        var row = $(this).closest("tr");
        OpenWindow("/Contract/ContractDetail", "انتخاب ردیف قرارداد", 1000, 500, {});
    }
    else {
        //edit from db
        OpenWindow("/Contract/ContractDetail?SelectedContractId" + SelectedContractId + "&SelectedContractDetailId=" + ContractDetailId, "انتخاب ردیف قرارداد", 1000, 500, {});
    }
})
$(document).on("click", ".DeleteContractDetail", function (e) {
    var ContractDetailId = $(this).attr("data-ContractDetailId");
    var Content = "<div>مایل به حذف ردیف قرارداد هستید ؟</div><div><input type='button' class=' btn btn-large btn-block btn-primary' id='DeleteContractDetailConfirm' style='width:100px !important;' value='تایید' /></div>";
    ShowPrompt(Content, "حذف ردیف قرارداد", 300, 300);
})
$(document).on("click", "#DeleteContractDetailConfirm", function (e) {
    ShowAlert("خطا در حذف");
    if (SelectedContractId == 0) {
        SelectedContractDetailItems = [];
        LoadContractDetail();
    }
    HidePrompt();
});

//****************************************شرایط فروش به مشتریان

var ContractTemrOfSaledt;
function LoadTermOfSaleGrid() {
    //GetTermOfSales(int CarGroup, int CarID, int SaleRowId) 
    var All = $('input:radio[name=All]:checked').val()
    var address = "/TermOfSales/GetTermOfSales?All=" + All + "&CarGroup=" + $("#TermOfSaleProductGroup").val() + "&CarID=" + $("#TermOfSaleProductType").val() + "&SaleRowId=" + $("#TermOfSaleSaleRecord").val();
    index = 0;
    var ex = document.getElementById('TermOfSaleGrid');
    if (!$.fn.DataTable.fnIsDataTable(ex)) {
        ContractTemrOfSaledt = undefined;
    }
    if (ContractTemrOfSaledt == undefined) {
        ContractTemrOfSaledt = $('#TermOfSaleGrid').DataTable({
            "processing": true,
            "jQueryUI": false,
            "scrollCollapse": true,
            "paging": true,
            "bAutoWidth": false,
            "bSort": false,
            "responsive": (IsMobileDevice) ? true : false,
            "ajax": address,
            "columns": [
                {
                    "data": "SaleRowId",
                    "title": "کد ردیف فروش",
                    "width": "150px"
                },
        {
            "data": "SaleRowDesc",
            "title": "ردیف فروش",
            "width": "150px"
        },
         {
             "data": "SaleFromDate",
             "title": "تاریخ اعتبار از",
             "width": "150px"
         },
                        {
                            "data": "SaleToDate",
                            "title": "تاریخ اعتبار تا",
                            "width": "150px"
                        },
        {
            "data": "DelFromDate",
            "title": "تاریخ تحویل از",
            "width": "150px"
        },
          {
              "data": "DelToDate",
              "title": "تاریخ تحویل تا",
              "width": "150px",
          },
          {
              "data": "SaleQty",
              "title": "حد اکثر مجاز",
              "width": "150px"
          },
          {
              "data": "StatusName",
              "title": "وضعیت",
              "width": "150px"
          },
          {
              "data": "Discount",
              "title": "مبلغ تخفیف",
              "width": "150px"
          }, {
              "data": "DiscountPrcnt",
              "title": "سود مشارکت",
              "width": "150px"
          }, {
              "data": "RejectPrcnt",
              "title": "درصد انصراف",
              "width": "150px"
          }, {
              "data": "FacDesc",
              "title": "شرح روی فاکتور",
              "width": "150px"
          }, {
              "data": "DocDesc",
              "title": "شرح روی سند",
              "width": "150px"
          }, {
              "data": "GaranDesc",
              "title": "شرح برگ گارانتی",
              "width": "150px"
          }],
            "columnDefs": [{
                "render": function (data, type, row) {
                    //row.Mail_Subject
                    return ++index;
                },
                "targets": 0,
            }],
            "createdRow": function (row, data, index) {
                console.log(data);
                //if (data.isRead == false) {
                //    $('td', row).addClass('highlight');
                //}
                //else {
                //    $('td', row).addClass('readed');
                //}
            }
        });
        var detailRows = [];
        $('#TermOfSaleGrid tbody').on('click', 'tr', function () {
            //Select Row
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
                $("#TermOfSaleDetail").html("");
            }
            else {
                ContractTemrOfSaledt.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                var row = (ContractTemrOfSaledt.row($(this))).data();
                ShowLoading();
                $.get("/TermOfSales/Detail/" + row.SaleRowId, {}, function (data) {
                    $("#TermOfSaleDetail").html(data);
                    if ($('#Status1').val() == "1") {
                        $("input[name=status][value=1]").attr('checked', 'checked');
                    }
                    else {
                        $("input[name=status][value=2]").attr('checked', 'checked');
                    }
                    if ($('#F_EsghatyID').val() == "1") {
                        $("input[name=FalgEsghat][value=1]").attr('checked', 'checked');
                    }
                    if ($('#AssignBypr').val() == "1") {
                        $("input[name=FlgAssignByPriority][value=1]").attr('checked', 'checked');
                    }
                    if ($('#TypeTahvil1').val() == "2") {
                        $("input[name=type1][value=2]").attr('checked', 'checked');
                    }
                });
            }
        });
    }
    else {
        ContractTemrOfSaledt.ajax.url(address).load(function () {
            HideLoading();
        });
    }
}

///******************** فانکشن کامای بین اعداد
function numberWithCommas(x) {
    var parts = x.toString().split(".");
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
}
var ContractPaymentdt;
function LoadContractPaymentGrid() {
    ChangeContractPaymentState(true);
    var address = "/ContractPayment/GetContractPayment?ContractId=" + $("#ContractPaymentContract").val() + "&ContractRowId=" + $("#ContractPayment_F_CNTRowID").val();
    index = 0;
    var ex = document.getElementById('ContractPaymentGrid');
    if (!$.fn.DataTable.fnIsDataTable(ex)) {
        ContractPaymentdt = undefined;
    }
    if (ContractPaymentdt == undefined) {
        ContractPaymentdt = $('#ContractPaymentGrid').DataTable({
            "processing": true,
            "jQueryUI": false,
            "scrollCollapse": true,
            "paging": false,
            "bAutoWidth": false,
            "bSort": false,
            "responsive": (IsMobileDevice) ? true : false,
            "fnInitComplete": function (oSettings, json) {
                var totalSUM = 0;
                try {
                    $("#ContractPaymentGrid tbody tr").each(function () {
                        var getValue = $(this).find("td:eq(6)").html().replace("$", "");
                        getValue = getValue.replace("ریال", "");
                        var filteresValue = getValue.replace(/\,/g, '');
                        totalSUM += Number(filteresValue)
                        console.log(filteresValue);
                    });
                }
                catch (e) {
                }
                $("#ContractPaymentD").html("<span>جمع وجوه دریافتی : " + numberWithCommas(totalSUM) + "</span>");
                $.get("/ContractPayment/GetTotalAmount", { CNTID: $("#ContractPaymentContract").val() }, function (data) {
                    $("#ContractPaymentP").html("<span>جمع کل : " + numberWithCommas(data.TotalAmount) + "</span>");
                });
                $("#btnNewContractPayment").prop("disabled", false);
            },
            "ajax": address,
            "columns": [
                {
                    "data": "IDt",
                    "title": "ردیف",
                    "width": "150px"
                },
        {
            "data": "CrCode",
            "title": "کد",
            "width": "150px"
        },
        {
            "data": "CrDate",
            "title": "تاریخ ثبت سند",
            "width": "150px"
        },
         {
             "data": "DocNo",
             "title": "شماره مدرک",
             "width": "150px"
         },
                        {
                            "data": "DocDate",
                            "title": "تاریخ مدرک",
                            "width": "150px"
                        },
        {
            "data": "AccountNo",
            "title": "شماره حساب",
            "width": "150px"
        },
          {
              "data": "Money",
              "title": "مبلغ",
              "width": "150px",
              "render": function (data, type, row, meta) {
                  var num = $.fn.dataTable.render.number(',', '.', 0, "").display(data);
                  return num + "ریال"
              },
          },
          {
              "data": "Description",
              "title": "توضیحات",
              "width": "150px"
          }],
            "columnDefs": [{
                "render": function (data, type, row) {
                    //row.Mail_Subject
                    return ++index;
                },
                "targets": 0,
            }],
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                $("td:first", nRow).html(iDisplayIndex + 1);
                return nRow;
            },
            "createdRow": function (row, data, index) {
                console.log(data);
                //if (data.isRead == false) {
                //    $('td', row).addClass('highlight');
                //}
                //else {
                //    $('td', row).addClass('readed');
                //}
            }
        });
        var detailRows = [];
        $('#ContractPaymentGrid tbody').on('click', 'tr', function () {
            //Select Row
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
                ContractPaymentLoadClearRow();
            }
            else {
                ContractPaymentdt.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                var row = ContractPaymentdt.row($(this)).data();
                ContractPaymentLoadRow(row.CrID);
            }
        });
    }
    else {
        ContractPaymentdt.ajax.url(address).load(function () {
            HideLoading();
            var totalSUM = 0;
            $("#btnNewContractPayment").prop("disabled", false);
            try {
                $("#ContractPaymentGrid tbody tr").each(function () {
                    var getValue = $(this).find("td:eq(6)").html().replace("$", "");
                    getValue = getValue.replace("ریال", "");
                    var filteresValue = getValue.replace(/\,/g, '');
                    totalSUM += Number(filteresValue)
                    console.log(filteresValue);
                });
            } catch (e) {
            }
            $("#ContractPaymentD").html("<span>جمع وجوه دریافتی : " + numberWithCommas(totalSUM) + "</span>");
            $.get("/ContractPayment/GetTotalAmount", { CNTID: $("#ContractPaymentContract").val() }, function (data) {
                $("#ContractPaymentP").html("<span>جمع کل : " + numberWithCommas(data.TotalAmount) + "</span>");
            });
        });
    }
}
function ContractPaymentLoadClearRow() {
    //clear textBoxes
}
function ContractPaymentLoadRow(id) {
    $.get("/ContractPayment/GetContractPaymentById", { id: id }, function (data) {
        //fill textbox
        $.get("/Home/GetDateNow", {}, function (Date) {
            $("#btnNewContractPayment").prop("disabled", false)
            $("#btnEditContractPayment").prop("disabled", false)
            $("#btnRejectContractPayment").prop("disabled", false)
            $("#btnConfirmPayment").prop("disabled", true)
            //if (data.CrDate < Date) {
            //    $("#ContractPayment_CrDate").val(data.CrDate);
            //}
            //else {
            //    $("#ContractPayment_CrDate").val(data.CrDate);
            //    $("#MotamamDate").css({ "display": "none" });
            //}
            $("#MotamamDate").val(data.CrDate);
            $("#MotamamDate").css({ "display": "" });
            $("#ContractPayment_CrCode").val(data.CrCode);
            console.log(data);
            //ContractPayment_RecidORPay
            //ContractPayment_RecidORPay
            //ContractPayment_F_TypeOfDoc
            $("#ContractPayment_F_TypeOfDoc").val(data.F_TypeOfDoc);
            $("#ContractPayment_F_TypeOfDoc").selectpicker('refresh');
            var address = "/ContractPayment/GetContractPaymentArticles?DocumentType=" + $("#ContractPayment_F_TypeOfDoc").val();
            LoadComboBox(address, "ContractPayment_RecidORPayRe", false, function () {
                $("#ContractPayment_RecidORPayRe").val(data.F_TypeOfDP);
                $("#ContractPayment_RecidORPayRe").selectpicker('refresh');
            });
            var RecidOrPayVal = 0;
            if (data.RecidORPay)
                RecidOrPayVal = 1;
            $("input[name=ContractPayment_RecidORPaySelector][value=" + RecidOrPayVal + "]").attr('checked', 'checked');
            //$("#MotamamDate").css({ "display": "none" });
            $("#MotamamDate").val(data.CrDate);
            $("#ContractPayment_CrID").val(data.CrID);
            $("#ContractPayment_DocDate").val(data.DocDate);
            $("#ContractPayment_F_BranchID").val(data.F_BranchID);
            $("#ContractPayment_DocNo").val(data.DocNo);
            $("#ContractPayment_AccountNo").val(data.AccountNo);
            $("#ContractPayment_Money").val(data.Money);
            $("#ContractPayment_Description").val(data.Description);
            $("#ContractPayment_F_BankID").val(data.F_BankID);
            $("#ContractPayment_F_BankID").selectpicker('refresh');
            $("#ContractPayment_F_Mpardakht").val(data.F_Mpardakht);
            $("#ContractPayment_F_Mpardakht").selectpicker('refresh');
            $("#ContractPayment_F_TypeOfAcc").val(data.F_TypeOfAcc);
            $("#ContractPayment_F_TypeOfAcc").selectpicker('refresh');
            ChangeContractPaymentState(true);
        });
        //ContractPayment_F_TypeOfAcc
        //ContractPayment_F_Mpardakht
    });
}
$(document).on("click", ".SelectSearchContract", function (e) {
    //SelectedContractId =$() selectedrow 
    SelectedContractId = $(this).attr("data-id");
    LoadContractMaster();
    LoadContractDetail();
    CloseWindow();
})
function disableBtn() {
    document.getElementById("btnEditContract").disabled = true;
}
var SelectInsurance = 0;
function ClearContractForm() {
    SelectedContractId = 0;
    $("#btnEditContract").prop("disabled", true)
    $("#btnRejectContract").prop("disabled", true)
    $("#btnConfirm").prop("disabled", true)
    $("#btnAddContractDetail").prop("disabled", true)
    $("#btnCancel").prop("disabled", true)
    $("#btnNewContract").prop("disabled", false)
    LoadContractDetail();
    $("#ContractStatusDesc").val("");
    $("#btnContractInsurance").prop("disabled", true);
    $("#btnContractRecipt").prop("disabled", true);
    $("#btnContractCycle").prop("disabled", false);
    $("#btnContractOption").prop("disabled", true);
    $("#btnContractAttach").prop("disabled", true);
    $("#btnContractTermOfSales").prop("disabled", true);
    $("#btnContractSolh").prop("disabled", true);
    $("#btnContractPrintt").prop("disabled", true);
}
function NewContractForm() {
    SelectedContractId = 0;
    SelectedContractDetailItems = [];
    $("#Contract_CNTID").val("0");
    $("#Contract_CNTDate").val("");
    $("#Contract_Alabel").val("");
    InsuranceInsId = 0;
    if (IsAgent) {
    }
    else {
        ClearCombo("Contract_F_AgencyID", true);
    }
    ClearCombo("Contract_F_CustomerID", true);
    ClearCombo("Contract_F_SponsorID", true);
    $("#Contract_CNTSerial").val("");
    $("#Contract_CNTCommissionPercent").val("");
    $("#Contract_PublicSale").val("");
    $("#Contract_TahvilDate").val("");
    $("#Contract_CNTSerialOld").val("");
    $("#Contract_SendSms").prop("checked", true);
    $("#ContractStatusDesc").val("");
    $("#btnEditContract").prop("disabled", true)
    $("#btnRejectContract").prop("disabled", true)
    $("#btnConfirm").prop("disabled", false)
    $("#btnAddContractDetail").prop("disabled", false)
    $("#btnCancel").prop("disabled", false)
    $("#btnNewContract").prop("disabled", true)
    $("#btnAddContractDetail").prop("disabled", false);
    $("#btnContractInsurance").prop("disabled", false);
    if ($.fn.DataTable.fnIsDataTable($("#ContractDetailGrid"))) {
        $('#ContractDetailGrid').DataTable().clear().draw();
    }
}
function CancelContractForm() {
    $("#btnEditContract").prop("disabled", true)
    $("#btnRejectContract").prop("disabled", true)
    $("#btnConfirm").prop("disabled", true)
    $("#btnAddContractDetail").prop("disabled", true)
    $("#btnCancel").prop("disabled", true)
    $("#btnNewContract").prop("disabled", false)
    $("#btnContractSearch").prop("disabled", false);
    $("#ContractStatusDesc").val("");
}
function EditContractForm() {
    $("#btnEditContract").prop("disabled", true)
    $("#btnRejectContract").prop("disabled", true)
    $("#btnConfirm").prop("disabled", false)
    $("#btnAddContractDetail").prop("disabled", false)
    $("#btnCancel").prop("disabled", false)
    $("#btnNewContract").prop("disabled", true)
}
function SearchContractForm() {
    $("#btnEditContract").prop("disabled", false)
    $("#btnRejectContract").prop("disabled", false)
    $("#btnConfirm").prop("disabled", true)
    $("#btnAddContractDetail").prop("disabled", true)
    $("#btnCancel").prop("disabled", false)
    $("#btnNewContract").prop("disabled", false)
}
$(document).on("click", "#btnNewContract", function (e) {
    $("#Contract_CNTID").val("0");
    NewContractForm();
    IsDeleteContract = 0;
    SelectInsurance = 0;
    $("#ContractStatusDesc").val("");
    $.get("/Home/GetDateNowAdd", { Count: 45 }, function (data) {
        $("#Contract_TahvilDate").val(data);
    })
    $.get("/Home/GetDateNow", {}, function (data) {
        $("#Contract_CNTDate").val(data);
    })
    $("#btnContractInsurance").prop("disabled", false);
    $("#btnContractSearch").prop("disabled", true);
})
$(document).on("click", "#btnEditContract", function (e) {
    $("#Contract_CNTID").val();
    $.get("/Contract/CheckContractStateForEdit", { ContractId: $("#Contract_CNTID").val() }, function (data) {
        if (data == "false") {
            EditContractForm();
        }
        else {
            ShowAlert("تخصیص خودرو به اتمام رسیده و امکان ویرایش نیست", 2)
        }
    });
    //
})
var IsDeleteContract = 0;
$(document).on("click", "#btnRejectContract", function (e) {
    $.post("/Contract/CheckContractStateForDelete", { ContractId: $("#Contract_CNTID").val() }, function (data) {
        //check other option
        if (data == "220" || data == "1") {
            $("#Contract_CNTID").val();
            IsDeleteContract = 1;
            $("#btnEditContract").prop("disabled", true)
            $("#btnRejectContract").prop("disabled", true)
            $("#btnConfirm").prop("disabled", false)
            $("#btnAddContractDetail").prop("disabled", true)
            $("#btnCancel").prop("disabled", false)
            $("#btnNewContract").prop("disabled", false)
        }
        else if (data == "48") {
            ShowAlert("تخصیص خودرو به اتمام رسیده و امکان ابطال نیست", 2);
        }
        else {
            $("#ContractRejectDeleteDialog").css({ "display": "" });
            //check Contract State
            $("#ContractRejectDeleteDialog").html("برای ابطال ابتدا نیاز به ثبت درخواست انصراف است ، آیا مایل به ثبت درخواست هستید ؟");
            $("#ContractRejectDeleteDialog").dialog({
                resizable: false,
                height: 140,
                modal: true,
                buttons: {
                    "انصراف": function () {
                        $(this).dialog("close");
                    },
                    "ابطال": function () {
                        $.post("/Contract/ReqDeleteContract", { ContractId: $("#Contract_CNTID").val() }, function (result) {
                            $("#ContractRejectDeleteDialog").dialog("close");
                            if (result.Status == 0) {
                                ShowAlert(result.Message, 1);
                                NewContractForm();
                                $("#btnContractRecipt").prop("disabled", true);
                                $("#btnContractCycle").prop("disabled", false);
                                $("#btnContractOption").prop("disabled", true);
                                $("#btnContractAttach").prop("disabled", true);
                                $("#btnContractTermOfSales").prop("disabled", true);
                                $("#btnContractSolh").prop("disabled", true);
                                $("#btnContractPrintt").prop("disabled", true);
                                $("#btnEditContract").prop("disabled", true)
                                $("#btnRejectContract").prop("disabled", true)
                                $("#btnConfirm").prop("disabled", true)
                                $("#btnAddContractDetail").prop("disabled", true)
                                $("#btnCancel").prop("disabled", true)
                                $("#btnNewContract").prop("disabled", false)
                            }
                            else {
                                ShowAlert(result.Message, 2);
                            }
                        });
                    }
                }
            });
        }
    });
})
$(document).on("change", "#Form_ContractDetail_AssignAble", function (e) {
    if ($(this).val()) {
        $("input[name=ContractDetail_HavaleBy][value=1]").attr('checked', 'checked');
        $("input[name=ContractDetail_DocumentBy][value=1]").attr('checked', 'checked');
        $("input[name=ContractDetail_FactorBy][value=1]").attr('checked', 'checked');
    }
})
$(document).on("click", "#btnConfirm", function (e) {
    $("#Contract_CNTID").val();
    e.preventDefault();
    if (IsDeleteContract == 1) {
        $("#ContractRejectDeleteDialog").css({ "display": "" });
        //check Contract State
        $("#ContractRejectDeleteDialog").html("آیا مایل به ابطال قرارداد هستید ؟");
        $("#ContractRejectDeleteDialog").dialog({
            resizable: false,
            height: 140,
            modal: true,
            buttons: {
                "انصراف": function () {
                    $(this).dialog("close");
                },
                "ابطال": function () {
                    $.post("/Contract/DeleteContract", { ContractId: $("#Contract_CNTID").val() }, function (result) {
                        $("#ContractRejectDeleteDialog").dialog("close");
                        if (result.Status == 0) {
                            ShowAlert(result.Message, 1);
                            NewContractForm();
                            $("#btnContractRecipt").prop("disabled", true);
                            $("#btnContractCycle").prop("disabled", false);
                            $("#btnContractOption").prop("disabled", true);
                            $("#btnContractAttach").prop("disabled", true);
                            $("#btnContractTermOfSales").prop("disabled", true);
                            $("#btnContractSolh").prop("disabled", true);
                            $("#btnContractPrintt").prop("disabled", true);
                            $("#btnEditContract").prop("disabled", true)
                            $("#btnRejectContract").prop("disabled", true)
                            $("#btnConfirm").prop("disabled", true)
                            $("#btnAddContractDetail").prop("disabled", true)
                            $("#btnCancel").prop("disabled", true)
                            $("#btnNewContract").prop("disabled", false)
                        }
                        else {
                            ShowAlert(result.Message, 2);
                        }
                    });
                }
            }
        });
    }
    else {
        if (!CheckContract()) {
            return;
        }
        $("#frmCreateContract").submit();
    }
})
$(document).on("click", "#btnCancel", function (e) {
    $("#Contract_CNTID").val();
    IsDeleteContract = 0;
    CancelContractForm();
})
$(document).on("change", "#Form_ContractDetail_AssignAble", function () {
    if ($("#Form_ContractDetail_AssignAble").is(":checked")) {
        $("#ContractDetail_AssignAble").val("1");
    } else {
        $("#ContractDetail_AssignAble").val("0");
    }
});
$(document).on("change", "#Form_ContractDetail_SayerHazSh", function () {
    if ($("#Form_ContractDetail_SayerHazSh").is(":checked")) {
        $("#ContractDetail_SayerHazSh").val("true");
    } else {
        $("#ContractDetail_SayerHazSh").val("false");
    }
});
$(document).on("change", "#Form_ContractDetail_ShomarehGozari", function () {
    if ($("#Form_ContractDetail_ShomarehGozari").is(":checked")) {
        $("#ContractDetail_ShomarehGozari").val("1");
    } else {
        $("#ContractDetail_ShomarehGozari").val("0");
    }
});
function CheckContractDetailItem() {
    if ($("#ContractDetailProductGroup").val() == 0) {
        ShowAlert("گروه محصول را وارد کنید", 2);
        return false;
    }
    if ($("#ContractDetailProductType").val() == 0) {
        ShowAlert("نوع محصول را وارد کنید", 2);
        return false;
    }
    if ($("#ContractDetail_F_UsageType").val() == 0) {
        ShowAlert("کاربری محصول را وارد کنید", 2);
        return false;
    }
    if ($("#ContractDetail_F_SaleRowID").val() == 0) {
        ShowAlert("ردیف فروش محصول را وارد کنید", 2);
        return false;
    }
    if ($("#ContractDetail_F_ColorID").val() == 0) {
        ShowAlert("رنگ  را وارد کنید", 2);
        return false;
    }
    if ($("#ContractDetail_F_DecorationID").val() == 0) {
        ShowAlert("تودوزی را وارد کنید", 2);
        return false;
    }
    if ($("#ContractDetail_F_DeliveryAddressID").val() == 0) {
        ShowAlert("آدرس محل تحوبل را وارد کنید", 2);
        return false;
    }
    return true;
    //ContractDetail_HavaleBy
    //ContractDetail_DocumentBy
    //ContractDetail_HavaleBy
}
function ValidateContractDetail() {
    $(".error").removeClass("error");
    $(".errorPromt").remove();
    $("#Contract_PelakOwner").val($("#PlackOwnerText").val());
    var Flag = true;
    $(".error").removeClass("error");
    if ($("#ContractDetailProductGroup").val() == 0) {
        $("[data-id=ContractDetailProductGroup]").addClass("error");
        Flag = false;
    }
    if ($("#ContractDetailProductType").val() == 0) {
        $("[data-id=ContractDetailProductType]").addClass("error");
        Flag = false;
    }
    if ($("#ContractDetail_F_UsageType").val() == 0) {
        $("[data-id=ContractDetail_F_UsageType]").addClass("error");
        Flag = false;
    }
    if ($("#ContractDetail_F_SaleRowID").val() == 0) {
        $("[data-id=ContractDetail_F_SaleRowID]").addClass("error");
        Flag = false;
    }
    if ($("#ContractDetail_F_ColorID").val() == 0 || $("#ContractDetail_F_ColorID").val() == undefined) {
        $("[data-id=ContractDetail_F_ColorID]").addClass("error");
        Flag = false;
    }
    if ($("#ContractDetail_F_DecorationID").val() == 0) {
        $("[data-id=ContractDetail_F_DecorationID]").addClass("error");
        Flag = false;
    }
    if ($("#ContractDetail_F_DeliveryAddressID").val() == 0) {
        $("#ContractDetail_F_DeliveryAddressID_chosen").addClass("error");
        Flag = false;
    }
    if (SelectedRowSalesType == 16) {
        if ($("#PlackOwnerText").val() == "") {
            $("#PlackOwnerText").addClass("error");
            Flag = false;
        }
    }
    if (Flag == false) {
        ShowAlert("موارد مشخص شده را وارد کنید", 2);
    }
    return Flag;
}
$(document).on("click", "#btnConfirmcontractDetail", function (e) {
    e.preventDefault();
    $("#Contract_CNTID").val();
    if (!ValidateContractDetail())
        return;
    if ($("#Contract_PublicSale").is(":checked")) {
        if (parseInt($("#ContractDetail_CNTQuantity").val()) <= 1) {
            ShowAlert("تعداد باید بیشتر از 1 باشد ", 2);
            return;
        }
    }
    if ($("#Form_ContractDetail_AssignAble").is(":checked")) {
        $("#ContractDetail_AssignAble").val("1");
    } else {
        $("#ContractDetail_AssignAble").val("0");
    }
    if ($("#Form_ContractDetail_SayerHazSh").is(":checked")) {
        $("#ContractDetail_SayerHazSh").val("true");
    } else {
        $("#ContractDetail_SayerHazSh").val("false");
    }
    if ($("#Form_ContractDetail_ShomarehGozari").is(":checked")) {
        $("#ContractDetail_ShomarehGozari").val("1");
    } else {
        $("#ContractDetail_ShomarehGozari").val("0");
    }
    //add to array Or Add Updatearray
    if ($("#frmCreateContractDetailItem").valid() && CheckContractDetailItem()) {
        if ($("#ContractDetail_CNTPercent").val() != "") {
            $.get("/Contract/CheckContractDetailPercent", { Value: $("#ContractDetail_CNTPercent").val(), SalesRowId: $("#ContractDetail_F_SaleRowID").val() }, function (checkData) {
                if (checkData == "err") {
                    ShowAlert("کاربر گرامی، مبلغ تخفیف نمیتواند بیش از تخفیف تعریف شده در شرایط فروش باشد", 2);
                } else {
                    var Data = $("#frmCreateContractDetailItem").serializeObject();
                    SelectedContractDetailItems = [];
                    SelectedContractDetailItems.push(Data);
                    $.getJSON("/Contract/GetContractDetailItemCreate", Data, function (e) {
                        //ContractDetaildt.clear().draw();
                        if (ContractDetaildt == undefined) {
                        }
                        else {
                            ContractDetaildt.row.add(e);
                            ContractDetaildt.draw();
                        }
                    });
                    CloseWindow();
                }
            });
        }
        else {
            var Data = $("#frmCreateContractDetailItem").serializeObject();
            SelectedContractDetailItems = [];
            SelectedContractDetailItems.push(Data);
            $.getJSON("/Contract/GetContractDetailItemCreate", Data, function (e) {
                ContractDetaildt.clear().draw();
                if (ContractDetaildt == undefined) {
                }
                else {
                    ContractDetaildt.row.add(e);
                    ContractDetaildt.draw();
                }
            });
            CloseWindow();
        }
    }
})
function RefreshGrid() {
}
function CheckContract() {
    if (SelectedContractDetailItems.length == 0) {
        ShowAlert("حد اقل  1 ردیف فروش را وارد کنید", 2);
        return false;
    }
    if ($("#Contract_F_AgencyID").val() == 0) {
        ShowAlert("نمایندگی را وارد کنید", 2);
        return false;
    }
    if ($("#Contract_F_CustomerID").val() == 0) {
        ShowAlert("مشتری را وارد کنید", 2);
        return false;
    }
    if (!$("#Contract_PublicSale").is(":checked")) {
        if ($("#Contract_CNTID").val() == "0")
            if (InsuranceInsId == 0) {
                ShowAlert("برای قرار ثبت قرارداد حتما باید بیمه وارد شود", 2);
                return false;
            }
    }
    return true;
}

//************************************************  ثبت قرارداد
$(document).on("submit", "#frmCreateContract", function (e) {
    e.preventDefault();
    $("#Contract_CNTID").val();
    if ($("#Contract_CNTCommissionPercent").val() == "")
        $("#Contract_CNTCommissionPercent").val("0");
    var Parameterdata = { contractMaster: $("#frmCreateContract").serializeObject(), ContractDetail: SelectedContractDetailItems };
    var IsNew = false;
    $.ajax({
        url: "/Contract/Create",
        type: 'post',
        dataType: 'json',
        // It is important to set the content type
        // request header to application/json because
        // that's how the client will send the request
        contentType: 'application/json',
        data: JSON.stringify(Parameterdata),
        cache: false,
        success: function (result) {
            if (result.Status == 0) {
                try {
                    var i = 0;
                    for (i = 0; i < ContractPaymentWizardList.length; i++) {
                        var row = ContractPaymentWizardList[i];
                        row.ContractPayment_F_CNTRowID = result.Parameters[2].Item2;
                        row.ContractPayment_F_CntId = result.Parameters[0].Item2;
                    }
                    $.post("/ContractPayment/CreateList", { data: JSON.stringify(ContractPaymentWizardList) }, function (rdata) {
                        if (rdata.Status == 0) {
                            ShowAlert(rdata.Message, 1);
                        }
                    });
                } catch (e) {
                }
                if (IsNew) {
                    LoadContractDetail();
                    $("#btnContractRecipt").prop("disabled", false);
                    $("#btnContractCycle").prop("disabled", false);
                    $("#btnContractOption").prop("disabled", false);
                    $("#btnContractAttach").prop("disabled", false);
                    $("#btnContractTermOfSales").prop("disabled", false);
                    $("#btnContractSolh").prop("disabled", false);
                    $("#btnContractPrintt").prop("disabled", false);
                    $("#btnEditContract").prop("disabled", false)
                    $("#btnRejectContract").prop("disabled", false)
                    $("#btnConfirm").prop("disabled", true)
                    $("#btnAddContractDetail").prop("disabled", true)
                    $("#btnCancel").prop("disabled", false)
                    $("#btnNewContract").prop("disabled", false)
                }
                else {
                    ShowAlert(result.Message, 1);
                    EditContractForm();
                    if ($("#Contract_PublicSale").is(":checked")) {
                        $("#btnContractInsurance").prop("disabled", true);
                    } else {
                        $("#btnContractInsurance").prop("disabled", false);
                    }
                    try {
                        SelectedContractId = result.Parameters[0].Item2;
                        $("#Contract_CNTSerial").val(result.Parameters[1].Item2)
                        $("#Contract_Alabel").val(SelectedContractId);
                    }
                    catch (e) {
                    }
                    LoadContractDetail();
                    try {
                        var IsFree = InsuranceIsFree;
                        var InsId = InsuranceInsId;
                        var CntRowID = result.Parameters[2].Item2
                        $.post("/Contract/InsertInsurance", { InstId: InsId, CntRowID: CntRowID, Free: IsFree }, function (e) {
                            ShowAlert("بیمه ذخیره شد", 1);
                            InsurState = -1;
                        });
                    }
                    catch (e) {
                    }
                    $("#btnContractRecipt").prop("disabled", false);
                    $("#btnContractCycle").prop("disabled", false);
                    $("#btnContractOption").prop("disabled", false);
                    $("#btnContractAttach").prop("disabled", false);
                    $("#btnContractTermOfSales").prop("disabled", false);
                    $("#btnContractSolh").prop("disabled", false);
                    $("#btnContractPrintt").prop("disabled", false);
                    $("#btnEditContract").prop("disabled", true)
                    $("#btnRejectContract").prop("disabled", true)
                    $("#btnConfirm").prop("disabled", true)
                    $("#btnAddContractDetail").prop("disabled", true)
                    $("#btnCancel").prop("disabled", false)
                    $("#btnNewContract").prop("disabled", false)
                }
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError);
        }
    });
})

//************************* combos of contract form


function RefreshComboClient(ComboBoxId, Text, Value, IsAjax) {
    if ($("#" + ComboBoxId + " option[value='" + Value + "']").val() === undefined) {
        var option = $('<option>').text(Text).val(Value);
        $("#" + ComboBoxId).append(option);
    }
    $("#" + ComboBoxId).val(Value);
    if (IsAjax == true)
        $("#" + ComboBoxId).trigger("chosen:updated");
    else
        $("#" + ComboBoxId).selectpicker('refresh');
}
function RefreshCombo(ComboBoxId, Text, Value, IsAjax) {
    $("#" + ComboBoxId).empty();
    option = $('<option>').text(Text).val(Value);
    $("#" + ComboBoxId).append(option);
    option = $('<option>').text("انتخاب کنید").val(0);
    $("#" + ComboBoxId).append(option);
    if (IsAjax == true)
        $("#" + ComboBoxId).trigger("chosen:updated");
    else
        $("#" + ComboBoxId).selectpicker('refresh');
}
function ClearCombo(ComboBoxId, IsAjax) {
    if ($("#" + ComboBoxId + " option[value='0']").val() === undefined) {
        var option = $('<option>').text("انتخاب کنید").val(0);
        $("#" + ComboBoxId).prepend(option);
        //$("#" + ID).val(0);
        //$("#" + ID).trigger("chosen:updated");
    }
    if (IsAjax) {
        $("#" + ComboBoxId).val("0");
        $("#" + ComboBoxId).trigger("chosen:updated");
    } else {
        //$("#" + ComboBoxId).empty();
        //option = $('<option>').text("انتخاب کنید").val("0");
        //$("#" + ComboBoxId).append(option);
        $("#" + ComboBoxId).val("0");
        $("#" + ComboBoxId).selectpicker('refresh');
    }
}
function LoadComboBox(address, ComboBoxId, isAjax, callback) {
    $.getJSON(address, {}, function (data) {
        var selectList = $("#" + ComboBoxId);
        selectList.empty();
        $.each(data, function (index, optionData) {
            var option = $('<option>').text(optionData.Text).val(optionData.Value);
            selectList.append(option);
        });
        if (isAjax == true)
            $("#" + ComboBoxId).trigger("chosen:updated");
        else
            $("#" + ComboBoxId).selectpicker('refresh');
        if (callback != undefined)
            callback();
    })
}
//function LoadComboBox(address, ComboBoxId, isAjax) {
//    $.getJSON(address, {}, function (data) {
//        var selectList = $("#" + ComboBoxId);
//        selectList.empty();
//        $.each(data, function (index, optionData) {
//            var option = $('<option>').text(optionData.Text).val(optionData.Value);
//            selectList.append(option);
//        });
//        if (isAjax == true)
//            $("#" + ComboBoxId).trigger("chosen:updated");
//        else
//            $("#" + ComboBoxId).selectpicker('refresh');
//    })
//}
var InsurState = -1;
var InsuranceIsFree;
var InsuranceInsId;
$(document).on("click", "#ConfirmInsurance", function (e) {
    if ($("#Contract_CNTID").val() == "0") {
        ShowAlert("بیمه انتخاب شد", 1);
        CloseWindow();
    } else {
        if (InsurState == 1) {
            var IsFree = InsuranceIsFree;
            var InsId = InsuranceInsId;
            var CntRowID = $('#ContractDetailGrid').DataTable().row($('#ContractDetailGrid tbody tr:first')).data().CNTRowID;
            $.post("/Contract/InsertInsurance", { InstId: InsId, CntRowID: CntRowID, Free: IsFree }, function (e) {
                ShowAlert("بیمه ذخیره شد", 1);
                InsurState = -1;
            });
        }
        else if (InsurState == 2) {
            var CntRowID = $('#ContractDetailGrid').DataTable().row($('#ContractDetailGrid tbody tr:first')).data().CNTRowID;
            $.post("/Contract/DeleteInsurance", { CntRowID: CntRowID }, function (e) {
                ShowAlert("بیمه حذف شد", 1);
                InsurState = -1;
            });
        }
    }
});

$(document).on("click", "#btnContractSearch", function (e) {
    e.preventDefault();
    OpenWindow("/Contract/SearchContract", "قرار داد ها", 600, 600, {});
    //lblContractSearch
})

//******************* contract insurance
$(document).on("click", "#btnContractInsurance", function (e) {
    e.preventDefault();
    if ($("#Contract_CNTID").val() == "0") {
        if (SelectedContractDetailItems.length == 0) {
            ShowAlert("حد اقل  1 ردیف فروش را وارد کنید", 2);
            return false;
        }
        else
            OpenWindow("/Contract/Insurance?SelectedContractId=0", "بیمه ها", 600, 400, {});
    }
    else
        OpenWindow("/Contract/Insurance?SelectedContractId=" + SelectedContractId, "بیمه ها", 600, 400, {});
})

$(document).on("click", ".InsuranceContract", function (e) {
    if ($(this).is(':checked')) {
        InsurState = 1;
        var IsFree = $(this).attr("data-IsFree");
        var InsId = $(this).attr("data-value");
        InsuranceIsFree = IsFree;
        InsuranceInsId = InsId;
    }
    else {
        InsurState = 2;
    }
});
$(document).on("click", "#btnContractRecipt", function (e) {
    //resid vajh
    e.preventDefault();
    OpenWindow("/Contractpayment/Create?SelectedContractId=" + SelectedContractId + "&ContractRowId=" + SelectedContractDetailId, "رسید وجه", 900, 600, {});
})
$(document).on("click", "#ContractSelectColor", function (e) {
})
$(document).on("click", "#btnContractCycle", function (e) {
    OpenWindow("/Contract/ContractReport?SelectedContractId=" + SelectedContractId, "گردش", 600, 600, {});
})
$(document).on("click", "#btnContractOption", function (e) {
    e.preventDefault();
    OpenWindow("/Contract/ContractOption", "آپشن", 600, 400, {});
})
$(document).on("click", "#btnContractAttach", function (e) {
    e.preventDefault();
    OpenWindow("/Contract/ContractAttach?SelectedContractId=" + SelectedContractId, "پیوست", 600, 600, {});
})
//چک موارد قرارداد
$(document).on("click", "#btnContractTermOfSales", function (e) {
    e.preventDefault();
    if (SelectedContractDetailRow == null) {
        ShowAlert("ابتدا یک قرارداد انتخاب کنید", 2);
    }
    else {
        var SaleRowId = SelectedContractDetailRow.F_SaleRowID;
        OpenWindow("/Contract/ContractTermOfSales/" + SaleRowId, "شرایط فروش", 1200, 300, {});
    }
})
$(document).on("click", "#btnContractSolh", function (e) {
    //صلح نامه
})
$(document).on("click", "#btnContractPrint", function (e) {
    OpenWindow("/Contract/ContractPrint?SelectedContractId=" + SelectedContractId, "چاپ قرار داد", 600, 600, {});
})

//ثبت قرارداد
$(document).on("click", "#btnAddContractDetail", function (e) {
    e.preventDefault();
    $(".error").removeClass("error");
    if ($("#Contract_F_CustomerID").val() == "0") {
        $("#Contract_F_CustomerID_chosen").addClass("error");
        ShowAlert("مشتری را وارد کنید", 2);
        return;
    }
    if (SelectedContractDetailItems.length == 0)
        //  OpenWindow("/Contract/ContractDetail?SelectedContractId=" + SelectedContractId, "انتخاب ردیف قرارداد", 1000, 500, {});
        OpenWindow("/Contract/CreateContractWizard", "انتخاب ردیف قرارداد", 1100, 700, {});
    else ShowAlert("بیشتر از یک ردیف فروش انتخاب نمی توان کرد", 2);
})
$(document).on("click", ".btnDelContractDetail", function (e) {
    //edit in grid
    OpenWindow("/Contract/ContractDetail?SelectedContractId=" + SelectedContractId + "&SelectedContractDetailId=" + SelectedContractDetailId, "ویرایش ردیف قرارداد", 600, 600, {});
})
$(document).on("click", ".btnEditContractDetail", function (e) {
    //delete from grid
})
function CloseWindow() {
    try {
        $("#dialog").html("");
        $("#dialog").dialog("destroy");
        HideLoading();
    }
    catch (e) { }
}
function CloseWindowSecond() {
    try {
        $("#dialog1").html("");
        $("#dialog1").dialog("destroy");
        HideLoading();
    }
    catch (e) { }
}
function OpenWindowSecond(address, title, width, height, parameter) {
    try {
        $("#dialog1").dialog("destroy");
    }
    catch (e) { }
    ShowLoading();
    $("#PopupContent1").html("<div id='dialog1'><div id='PopupDialogData1' style='width:100%;margin-top:35%'>" + LoadingImageDialogAddress + "</div></data>");
    $("#dialog1").dialog({
        autoOpen: true,
        width: width,
        height: height,
        modal: true,
        title: title,
        beforeClose: function (event, ui) {
            $("#dialog1").html("");
            HideLoading();
        }
    });
    $.get(address, parameter, function (data) {
        $("#PopupDialogData1").css({ "margin-top": "" });
        $("#PopupDialogData1").html(data);
    });
}
function OpenWindow(address, title, width, height, parameter) {
    try {
        $("#dialog").dialog("destroy");
    }
    catch (e) { }
    ShowLoading();
    $("#PopupContent").html("<div id='dialog'><div id='PopupDialogData' style='width:100%;margin-top:35%'>" + LoadingImageDialogAddress + "</div></data>");
    $("#dialog").dialog({
        autoOpen: true,
        width: width,
        height: height,
        modal: true,
        title: title,
        beforeClose: function (event, ui) {
            $("#dialog").html("");
            HideLoading();
        }
    });
    $.get(address, parameter, function (data) {
        $("#PopupDialogData").css({ "margin-top": "" });
        $("#PopupDialogData").html(data);
    });
}
function HidePrompt() {
    try {
        $("#Prompt").html("");
        $("#Prompt").dialog("destroy");
        HideLoading();
    }
    catch (e) { }
}
function ShowPrompt(Content, title, width, height) {
    try {
        $("#Prompt").dialog("destroy");
    }
    catch (e) { }
    ShowLoading();
    $("#PromptContent").html("<div id='Prompt'><div id='PromptContentData' style='width:100%;margin-top:35%'>" + LoadingImageDialogAddress + "</div></data>");
    $("#Prompt").dialog({
        autoOpen: true,
        width: width,
        height: height,
        modal: true,
        title: title,
        beforeClose: function (event, ui) {
            $("#Prompt").html("");
            HideLoading();
        }
    });
    $("#PromptContentData").css({ "margin-top": "" });
    $("#PromptContentData").html(Content);
}
function CheckContractPrtner(callback) {
    if ($("#ContractPartner_F_CNTId").val() == 0) {
        ShowAlert("قرارداد را وارد کنید", 2);
        return false;
    }
    if ($("#ContractPartner_F_shoraka").val() == 0) {
        ShowAlert("شرکا را وارد کنید", 2);
        return false;
    }
    if ($("#ContractPartner_Dong").val() == "" && $("#ContractPartner_PercentNo").val() == "") {
        ShowAlert("درصد و یا دنگ شرکا را وارد کنید", 2);
        return false;
    }
    if ($("#ContractPartner_Dong").val().indexOf('.') >= 0 && $("#ContractPartner_PercentNo").val().indexOf('.') >= 0) {
        ShowAlert("مقدار درصد یا دنگ  را درست وارد کنید", 2);
        return false;
    }
    callback();
    //  return true;
}
$(document).on("click", 'input:radio[name="SearchContractPartnerIsActive"]', function (e) {
    LoadcontractPartnerGrid();
})
//$(document).on("click", 'input:radio[name="ContractPartner_isActiveSelector"]', function (e) {
//    var aval = $('input:radio[name="ContractPartner_isActiveSelector"]:checked').val();
//    $("#ContractPartner_isActive").val(aval);
//});

//***************************table of partners
function LoadcontractPartnerGrid() {
    //ContractPartnerGrid
    // $("input[name=ContractPayment_RecidORPaySelector][value=" + RecidOrPayVal + "]").attr('checked', 'checked');
    var ShowType = 1;
    var aval = $('input:radio[name="SearchContractPartnerIsActive"]:checked').val();
    if (aval != undefined)
        ShowType = aval;
    var address = "/ContractPartner/GetContractPartner?ContractId=" + $("#ContractPartner_F_CNTId").val() + "&ShowType=" + ShowType;
    index = 0;
    if (ContractPartnetdt == undefined) {
        ContractPartnetdt = $('#ContractPartnerGrid').DataTable({
            "processing": true,
            "jQueryUI": false,
            "scrollCollapse": true,
            "paging": false,
            "bAutoWidth": false,
            "bSort": false,
            "responsive": (IsMobileDevice) ? true : false,
            "ajax": address,
            "columns": [
                {
                    "data": "IDt",
                    "title": "ردیف",
                    "width": "150px"
                },
        {
            "data": "F_CNTId",
            "title": "شماره قرارداد",
            "width": "150px"
        },
          {
              "data": "SHCode",
              "title": "کد",
              "width": "150px"
          },
          {
              "data": "Name",
              "title": "نام و نام خانوادگی",
              "width": "150px"
          },
          {
              "data": "Dong",
              "title": "دانگ",
              "width": "150px"
          },
          {
              "data": "PercentNo",
              "title": "درصد سهام",
              "width": "150px"
          },
          {
              "data": "isActiveName",
              "title": "وضعیت",
              "width": "150px"
          }],
            "columnDefs": [{
                "render": function (data, type, row) {
                    //row.Mail_Subject
                    return ++index;
                },
                "targets": 0,
            }],
        });
        var detailRows = [];
        $('#ContractPartnerGrid tbody').on('click', 'tr', function () {
            //Select Row
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                ContractPartnetdt.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                var row = ContractPartnetdt.row($(this)).data();
                var Address = "/ContractPartner/GetShoraka?CntId=" + $("#ContractPartner_F_CNTId").val();
                LoadComboBox(Address, "ContractPartner_F_shoraka", false, function (e) {
                    $("#ContractPartner_F_shoraka").val(row.F_shoraka);
                    $("#ContractPartner_F_shoraka").selectpicker('refresh');
                });
                $("#ContractPartner_PercentNo").val(row.PercentNo);
                $("#ContractPartner_Dong").val(row.Dong);
                $("#btnContractPartnerNew").prop("disabled", false)
                $("#btnContractPartnerEdit").prop("disabled", false)
                $("#btnContractPartnerDelete").prop("disabled", false)
                $("#btnContractPartnerConfirm").prop("disabled", true)
                $("#btnContractPartnerCancel").prop("disabled", true)
                $("#ContractPartner_ID").val(row.ID);
                $("#ContractPartner_isActive").val(row.isActive);
                //var val = 0;
                //if (row.isActive == true)
                //     val = 1;
                // $("input[name=ContractPartner_isActiveSelector][value=" + val + "]").attr('checked', 'checked');
                //ContractPartner_ID
                if (row.isActive == 1) {
                    ContractPartnerDialogText = "غیر فعال";
                }
                else {
                    ContractPartnerDialogText = "فعال";
                }
            }
        });
    }
    else {
        ContractPartnetdt.ajax.url(address).load(function () {
            HideLoading();
        });
    }
}

//******************فرم ثبت شرکا

var ContractPartnerDialogText = "غیر فعال";
$(document).on("submit", "#frmCreateContractPartner", function (e) {
    e.preventDefault();
    $.post("/ContractPartner/Create", $("#frmCreateContractPartner").serializeObject(), function (result) {
        if (result.Status == 0) {
            ShowAlert(result.Message, 1);
            $("#btnContractPartnerNew").prop("disabled", false)
            $("#btnContractPartnerEdit").prop("disabled", true)
            $("#btnContractPartnerDelete").prop("disabled", true)
            $("#btnContractPartnerConfirm").prop("disabled", true)
            $("#btnContractPartnerCancel").prop("disabled", true)
            LoadcontractPartnerGrid();
        }
        else {
            ShowAlert(result.Message, 2);
        }
    });
})
$(document).on("change", "#ContractPartner_F_CNTId", function (e) {
    LoadcontractPartnerGrid();
    var Address = "/ContractPartner/GetShoraka?CntId=" + $("#ContractPartner_F_CNTId").val();
    LoadComboBox(Address, "ContractPartner_F_shoraka", false, function (e) { });
});

//********************** new contract partner
$(document).on("click", "#btnContractPartnerNew", function (e) {
    //$("#ContractPartner_F_CNTId").val(0);
    //$("#ContractPartner_F_CNTId").trigger("chosen:updated");
    //$("#ContractPartner_F_CNTId").trigger("change");
    //  ClearCombo("ContractPartner_F_shoraka", false);
    $("#ContractPartner_PercentNo").val("");
    $("#ContractPartner_Dong").val("");
    $("#btnContractPartnerNew").prop("disabled", true)
    $("#btnContractPartnerEdit").prop("disabled", true)
    $("#btnContractPartnerDelete").prop("disabled", true)
    $("#btnContractPartnerConfirm").prop("disabled", false)
    $("#btnContractPartnerCancel").prop("disabled", false)
    $("#ContractPartner_ID").val("0");
    $("#ContractPartner_isActive").val("1");
})

//************************** edit contract partners
$(document).on("click", "#btnContractPartnerEdit", function (e) {
    $("#btnContractPartnerNew").prop("disabled", true)
    $("#btnContractPartnerEdit").prop("disabled", true)
    $("#btnContractPartnerDelete").prop("disabled", true)
    $("#btnContractPartnerConfirm").prop("disabled", false)
    $("#btnContractPartnerCancel").prop("disabled", false)
})

//******************* delete partner from contract
$(document).on("click", "#btnContractPartnerDelete", function (e) {
    $("#ContractPartnetDeleteDialog").css({ "display": "" });
    $("#ContractPartnetDeleteDialog").dialog({
        resizable: false,
        height: 140,
        modal: true,
        buttons: [{
            text: "انصراف",
            click: function () {
                $("#ContractPartnetDeleteDialog").dialog("close");
            }
        }, {
            text: ContractPartnerDialogText,
            click: function () {
                $.post("/ContractPartner/Delete", { ID: $("#ContractPartner_ID").val() }, function (result) {
                    if (result.Status == 0) {
                        //ShowAlert(result.Message, 1);
                        //$("#btnContractPartnerNew").prop("disabled", true)
                        //$("#btnContractPartnerEdit").prop("disabled", true)
                        //$("#btnContractPartnerDelete").prop("disabled", true)
                        //$("#btnContractPartnerConfirm").prop("disabled", false)
                        //$("#btnContractPartnerCancel").prop("disabled", false)
                        $("#ContractPartnetDeleteDialog").dialog("close");
                        LoadcontractPartnerGrid();
                        ShowAlert("شرکا " + ContractPartnerDialogText + " شد", 1)
                    }
                    else {
                        ShowAlert(result.Message, 2);
                    }
                });
            }
        }]
    });
})

//******************************** check values befor confirm contract
$(document).on("click", "#btnContractPartnerConfirm", function (e) {
    e.preventDefault();
    if (CheckContractPrtner(function () {
        if ($("#ContractPartner_Dong").val() != "") {
            var Val = parseInt($("#ContractPartner_Dong").val());
            if (Val > 6) {
                ShowAlert("مقدار دنگ  را درست وارد کنید", 2);
                return false;
    }
    else {
                $.get("/ContractPartner/checkValue", { Darsad: 0, Dong: Val, ContractId: $("#ContractPartner_F_CNTId").val() }, function (data) {
                    if (data == "false") {
                        ShowAlert("مقدار درصد یا  را درست وارد کنید", 2);
                        return false;
    }
    else {
                        $("#frmCreateContractPartner").submit();
    }
    });
    }
    }
    else if ($("#ContractPartner_PercentNo").val() != "") {
            var Val = parseInt($("#ContractPartner_PercentNo").val());
            if (Val >= 100) {
                ShowAlert("مقدار درصد را درست وارد کنید", 2);
                return false;
    }
    else {
                $.get("/ContractPartner/checkValue", { Darsad: Val, Dong: 0, ContractId: $("#ContractPartner_F_CNTId").val() }, function (data) {
                    if (data == "false") {
                        ShowAlert("مقدار درصد یا  را درست وارد کنید", 2);
                        return false;
    }
    else {
        $("#frmCreateContractPartner").submit();
    }
    });
    }
    }
    })) {
        return;
    }
})

//************************************* not editable things in contract when canceling
$(document).on("click", "#btnContractPartnerCancel", function (e) {
    $("#btnContractPartnerNew").prop("disabled", false)
    $("#btnContractPartnerEdit").prop("disabled", true)
    $("#btnContractPartnerDelete").prop("disabled", true)
    $("#btnContractPartnerConfirm").prop("disabled", true)
    $("#btnContractPartnerCancel").prop("disabled", true)
})
