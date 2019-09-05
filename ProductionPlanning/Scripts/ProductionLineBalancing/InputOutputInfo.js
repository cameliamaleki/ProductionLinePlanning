var InputOutputInfoGrid;
function LoadInputOutputInfoGrid() {
    InputOutputInfoGrid = $('#InputOutputInfoTable').DataTable({
        //  "bServerSide": true,
        "processing": true,
        "jQueryUI": false,
        "paging": true,
        "ajax": "/ProductionLineBalancingArea/InputOutputInfo/GetAllBySCIDS?MasterSchid=" + $(".adis").val(),
        "dom": "Bfrtip", "buttons": ['copy', 'csv', 'excel', 'pdf', { text: 'Import Excel', action: function (e, dt, node, config) { $("<input type='file'>").click(); } }],
        "columns": [
           //{
           //    "data": "InputOutputCode",
           //    "title": "کد شناسایی",
           //},
           //{
           //    "data": "InputOutputIndicator",
           //    "title": "ورودی/خروجی",
           //},
            {
                "data": "ScheduleProductionLineID",
                "title": "شماره زمان بندی",
            },
              {
                  "title": "",
              },
                            {
                                "title": "",
                            },
        ],
        "columnDefs": [
    {
        "render": function (data, type, row) {
            var str = "";
            str = "<span class='btnInputOutEdit btn btn-green' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-pencil'></i></span> "
            return str;
        },
        "targets": 1
    },
        {
            "render": function (data, type, row) {
                var str = "";
                str = "<span class='btnInputOutputDelete btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-trash-o'></i></span> "
                return str;
            },
            "targets": 2
        }
        ],
    });
}
$(document).on("click", "#InputOutputInfoTable tbody tr", function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        InputOutputInfoGrid.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
    var data = InputOutputInfoGrid.row('.selected').data();
});
$(document).on("click", ".btnInputOutEdit", function () {
    var tr = $(this).closest('tr');
    // make visible to boxes
    $('#InputOutputCode').val(InputOutputInfoGrid.row(tr).data()['InputOutputCode']);
    $('#InputOutputIndicator').val(InputOutputInfoGrid.row(tr).data()['InputOutputIndicator']);
    $('#InputOutputID').val(InputOutputInfoGrid.row(tr).data()['InputOutputID']);
    setValueDropDownList("ScheduleProductionLineID", InputOutputInfoGrid.row(tr).data()['ScheduleProductionLineID']);
    var parentIID = InputOutputInfoGrid.row(tr).data().InputOutputID;
    var Masterid = InputOutputInfoGrid.row(tr).data().ScheduleProductionLineID;
    LoadCanbanInfoDetail(parentIID);
    LoadWasteCanbanInfoDetail(parentIID);
    LoadFacilityStopInfoGridtab(Masterid)
});
$(document).on("click", ".btnInputOutputDelete", function () {
    var tr = $(this).closest('tr');
    //delete now
    $.post("/ProductionLineBalancingArea/InputOutputInfo/Delete", InputOutputInfoGrid.row(tr).data(), function (data) {
        InputOutputInfoGrid.ajax.reload();
        empty_AllInputOutputInfo();
    });
});
function empty_AllInputOutputInfo() {
    $('#InputOutputCode').val("");
    $('#InputOutputIndicator').val("");
    setValueDropDownList("ScheduleProductionLineID", "0");
    $('#InputOutputID').val("");
    LoadCanbanInfoDetail(0);
    LoadWasteCanbanInfoDetail(0);
    LoadFacilityStopInfoGridtab(0);
}
$(document).on("click", "#btnnewInputOutput", function (e) {
    e.preventDefault();
    if ($("#InputOutputID").val() == "") {
        $("#InputOutputID").val("0");
    }
    $("#frmInputOutputInfo").submit();
});
$(document).on("submit", "#frmInputOutputInfo", function (e) {
    //e.preventDefault();
    //$.post("/ProductionLineBalancingArea/InputOutputInfo/Create", $("#frmInputOutputInfo").serialize(), function (data) {
    //    alert("ثبت شد");
    //    empty_AllInputOutputInfo();
    //    InputOutputInfoGrid.ajax.reload();
    //});
    e.preventDefault();
    if (CanbanInfoDetailGrid.rows().count() < 1) {
        alert("لطفامقدارتولید شده راوارد نمایید");
        return false;
    }
    if (CanbanInfoDetailGrid.rows().count()>=1) {
        var oTable = $('#CanbanInfoDetailTable').dataTable();
        var DetailData = oTable.fnGetData();
        var oTable2 = $('#WasteCanbanInfoDetailTable').dataTable();
        var DetailData2 = oTable2.fnGetData();
        var oTable3 = $('#FacilityStopInfoTabletab').dataTable();
        var DetailData3 = oTable3.fnGetData();
        $.post("/ProductionLineBalancingArea/InputOutputInfo/Create?SchID=" + $(".adis").val(), $("#frmInputOutputInfo").serialize(), function (result) {
            var inputoutpotid = result.Parameters[0].Item2;
            if (DetailData.length > 0) {
                $.post("/ProductionLineBalancingArea/InputOutputInfo/CreateDetailCanban?inputoutpotid=" + inputoutpotid, { data: JSON.stringify(DetailData) }, function (rdata) {
                });
            }
            if (DetailData2.length > 0) {
                $.post("/ProductionLineBalancingArea/InputOutputInfo/CreateDetailWasteCanban?inputoutpotid=" + inputoutpotid, { data: JSON.stringify(DetailData2) }, function (rdata) {
                });
            }
            if (DetailData3.length > 0) {
                $.post("/ProductionLineBalancingArea/FacilityStopInfo/Create?SchID=" + $(".adis").val(), { data: JSON.stringify(DetailData3) }, function (rdata) {
                });
            }
            alert("ثبت شد");
            empty_AllInputOutputInfo();
            InputOutputInfoGrid.ajax.reload();
        });
    }
});
//$(document).on("click", "#btnSaveNewInputOutput", function () {
//    e.preventDefault();
//    $("#InputOutputID").val("0");
//    $("#frmInputOutputInfo").submit();
//});
$(document).on("click", "#btnCleanInputOutput", function () {
    e.preventDefault();
    empty_AllInputOutputInfo();
    InputOutputInfoGrid.ajax.reload();
});
/////////////////canban ////////////////////
var CanbanInfoDetailGrid;
function LoadCanbanInfoDetail(parentIID) {
    var Address = "/ProductionLineBalancingArea/InputOutputInfo/GetAllDetailCanban?parentIID=" + parentIID;
    var ex = document.getElementById('CanbanInfoDetailTable');
    if (!$.fn.DataTable.fnIsDataTable(ex)) {
        CanbanInfoDetailGrid = undefined;
    }
    if (CanbanInfoDetailGrid == undefined) {
        CanbanInfoDetailGrid = $('#CanbanInfoDetailTable').DataTable({
            "processing": true,
            "jQueryUI": false,
            "paging": true,
            "ajax": Address,
            "dom": "Bfrtip", "buttons": ['copy', 'csv', 'excel', 'pdf', { text: 'Import Excel', action: function (e, dt, node, config) { $("<input type='file'>").click(); } }], "columns": [
               {
                   "data": "RowNumber",
                   "title": "ردیف",
               },
               // {
               //     "data": "IOTrackingCodeName",
               //     "title": "کد رهگیری",
               // },
               //{
               //    "data": "IOPackageCodeName",
               //    "title": "کد بسته بندی",
               //},
               {
                   "data": "IOInventoryCodeName",
                   "title": "کد انبار ",
               },
               {
                   "data": "CanbanPartIDName",
                   "title": "کد قطعه",
               },
                {
                    "data": "WorkerName",
                    "title": "نام پرسنل",
                },
               //{
               //    "data": "TechnicalCodeName",
               //    "title": "کد فنی",
               //},
                {
                    "data": "Quantity",
                    "title": "مقدار",
                },
                 {
                     "data": "IOPackageCode",
                     "title": "برنامه تولید ",
                 },
//{
//    "data": "RegisteredDate",
//    "title": "تاریخ ثبت ",
//    }, 
            ],
            "columnDefs": [
                     {
                         "render": function (data, type, row) {
                             var str = "";
                             str = "<span class='btnCanbanDeleteDetail btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-trash-o'></i></span> "
                             return str;
                         },
                         "targets": 6
                     },
                       {
                           "render": function (data, type, row) {
                               var str = "";
                               str = "<span class='btnCanbanEditDetail btn btn-green' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-pencil'></i></span> "
                               return str;
                           },
                           "targets": 7
                       }
            ],
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                $("td:first", nRow).html(iDisplayIndex + 1);
                return nRow;
            },
        });
    }
    else {
        CanbanInfoDetailGrid.ajax.url(Address).load(function () {
        });
    }
}
var IsConbanEdit = false;
var PostEditValues;
$(document).on("click", ".btnCanbanEditDetail", function (e) {
    IsConbanEdit = true;
    var tr = $(this).closest('tr');
    PostEditValues = tr;
    //mydialoge("/ProductionLineBalancingArea/InputOutputInfo/Canban", "ثبت کانبان", "ثبت ضایعات", 1200, 700);
    var row = CanbanInfoDetailGrid.row(PostEditValues);
    var rowdata = row.data();
    $("#Quantity").val(rowdata.Quantity);
    $("#CanbanID").val(rowdata.CanbanID);
    $("#InputOutputID").val(rowdata.InputOutputID);
    setValueDropDownList("CWorkerID", rowdata.CWorkerID);
    setValueDropDownList("UnitID", rowdata.UnitID);
    setValueDropDownList("CanbanPartID", rowdata.CanbanPartID);
    setValueDropDownList("IOTrackingCode", rowdata.IOTrackingCode);
    setValueDropDownList("IOInventoryCode", rowdata.IOInventoryCode);
    setValueDropDownList("IOPackageCode", rowdata.IOPackageCode);
    setValueDropDownList("TechnicalCode", rowdata.CanbanPartID);
    setValueDropDownList("CProcessStageID", rowdata.CProcessStageID);
});
//$(document).on("click", "#btnnewInputOutputCanban", function (e) {
//    mydialoge("/ProductionLineBalancingArea/InputOutputInfo/Canban", "ثبت کانبان", "ثبت ضایعات", 1200, 700);
//});
$(document).on("click", "#btnnewCanbanDetail", function (e) {
    e.preventDefault();
    if (checkvalid4() == false) {
        return false;
    }
    if (IsConbanEdit) {
        var row = CanbanInfoDetailGrid.row(PostEditValues);
        var record = row.data();
        record.IOTrackingCode = $("#IOTrackingCode").val();
        record.IOPackageCode = $("#IOPackageCode").val();
        record.IOInventoryCode = $("#IOInventoryCode").val();
        record.CanbanPartID = $("#CanbanPartID").val();
        record.TechnicalCode = $("#TechnicalCode").val();
        record.UnitID = $("#UnitID").val();
        record.Quantity = $("#Quantity").val();
        record.CanbanID = $("#CanbanID").val();
        record.InputOutputID = $("#InputOutputID").val();
        record.CProcessStageID = $("#CProcessStageID").val();
        record.CWorkerID = $("#CWorkerID").val();
        record.WorkerName = $("#CWorkerID option:selected").text();
        record.IOTrackingCodeName = $("#IOTrackingCode option:selected").text();
        record.IOPackageCodeName = $("#IOPackageCode option:selected").text();
        record.IOInventoryCodeName = ($("#IOInventoryCode option:selected").text() == "انتخاب کنید") ? "-" : $("#IOInventoryCode option:selected").text();
        record.CanbanPartIDName = $("#CanbanPartID option:selected").text();
        record.TechnicalCodeName = $("#TechnicalCode option:selected").text();
        record.UnitIDName = $("#UnitID option:selected").text();
        record.InputOutputIDName = $("#InputOutputID option:selected").text();
        record.CProcessStageIDName = $("#CProcessStageID option:selected").text();
        row.data(record);
        CanbanInfoDetailGrid.draw();
        emptyAllCanban();
        alert(" ثبت شد", 1);
        IsConbanEdit = false;
    }
    else {
        var record = {
            IOTrackingCode: $("#IOTrackingCode").val(),
            IOPackageCode: $("#IOPackageCode").val(),
            IOInventoryCode: $("#IOInventoryCode").val(),
            CWorkerID: $("#CWorkerID").val(),
            CanbanPartID: $("#CanbanPartID").val(),
            TechnicalCode: $("#TechnicalCode option:selected").text(),
            UnitID: $("#UnitID").val(),
            Quantity: $("#Quantity").val(),
            CanbanID: 0,
            InputOutputID: $("#InputOutputID").val(),
            CProcessStageID: $("#CProcessStageID").val(),
            WorkerName: $("#CWorkerID option:selected").text(),
            IOTrackingCodeName: $("#IOTrackingCode option:selected").text(),
            IOPackageCodeName: $("#IOPackageCode option:selected").text(),
            IOInventoryCodeName: $("#IOInventoryCode option:selected").text(),
            CanbanPartIDName: $("#CanbanPartID option:selected").text(),
            TechnicalCodeName: $("#TechnicalCode option:selected").text(),
            UnitIDName: $("#UnitID option:selected").text(),
            InputOutputIDName: $("#InputOutputID option:selected").text(),
            CProcessStageIDName: $("#CProcessStageID option:selected").text(),
        };
        if (record.CProcessStageID == 4 && record.CWorkerID == 0) {
            alert("لطفا پرسنل را انتخاب نمایید");
        }
        else {
            CanbanInfoDetailGrid.row.add(record);
            CanbanInfoDetailGrid.draw();
        }
    }
    emptyAllCanban();
    alert(" ثبت شد", 1);
});
$(document).on("click", ".btnCanbanDeleteDetail", function () {
    var tr = $(this).closest('tr');
    var ss = CanbanInfoDetailGrid.row(tr).data().CanbanID;
    if (ss == undefined || ss == 0) {
        CanbanInfoDetailGrid.row('.selected').remove().draw();
        CanbanInfoDetailGrid.ajax.reload();
    }
    else {
        $.post("/ProductionLineBalancingArea/InputOutputInfo/DeleteCanban?Schedulid=" + ss, function (data) {
            CanbanInfoDetailGrid.ajax.reload();
        });
    }
    //CanbanInfoDetailGrid();
});
$(document).on("click", "#CanbanInfoDetailTable tbody tr", function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        CanbanInfoDetailGrid.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
    var data = CanbanInfoDetailGrid.row('.selected').data();
});
function emptyAllCanban() {
    $("#Quantity").val("");
    $("#CanbanID").val("");
    setValueDropDownList("UnitID", "0");
    setValueDropDownList("CanbanPartID", "0");
    setValueDropDownList("CWorkerID", "0");
    setValueDropDownList("IOTrackingCode", "0");
    setValueDropDownList("IOInventoryCode", "0");
    setValueDropDownList("IOPackageCode", "0");
    setValueDropDownList("TechnicalCode", "0");
    setValueDropDownList("CProcessStageID", "0");
    IsConbanEdit = false;
}
/////////////////wastecanban////////////////
var WasteCanbanInfoDetailGrid;
function LoadWasteCanbanInfoDetail(WasteparentIID) {
    var Address = "/ProductionLineBalancingArea/InputOutputInfo/GetAllDetailWaste?WasteMasterID=" + WasteparentIID;
    var ex = document.getElementById('WasteCanbanInfoDetailTable');
    if (!$.fn.DataTable.fnIsDataTable(ex)) {
        WasteCanbanInfoDetailGrid = undefined;
    }
    if (WasteCanbanInfoDetailGrid == undefined) {
        WasteCanbanInfoDetailGrid = $('#WasteCanbanInfoDetailTable').DataTable({
            "processing": true,
            "jQueryUI": false,
            "paging": true,
            "ajax": Address,
            "dom": "Bfrtip", "buttons": ['copy', 'csv', 'excel', 'pdf', { text: 'Import Excel', action: function (e, dt, node, config) { $("<input type='file'>").click(); } }],
            "columns": [
               {
                   "data": "RowNumber",
                   "title": "ردیف",
               },
               {
                   "data": "WastePartIDName",
                   "title": "نام قطعه/کالا",
               },
                {
                    "data": "FacilityIDName",
                    "title": "نام ایستگاه",
                },
               {
                   "data": "WorkerIDName",
                   "title": "نام کارمند",
               },
               {
                   "data": "WasteSourceIDName",
                   "title": "منشا خطا ",
               },
                {
                    "data": "FaultIDName",
                    "title": "عیب ",
                },
               {
                   "data": "TaminName",
                   "title": "واحد تامین",
               },
               //{
               //    "data": "WPackageCodeName",
               //    "title": "کد بسته بندی",
               //},
                {
                    "data": "WInventoryCodeName",
                    "title": "کد انبار",
                },
                 {
                     "data": "WastageQuantity",
                     "title": "مقدار ضایعات/دوباره کار/تعمیرات",
                 },
                  {
                      "data": "ActionIDName",
                      "title": "نوع برخورد",
                  },
                  {
                      "data": "ReworkTime",
                      "title": "زمان دوباره کاری",
                  },
{
    "data": "WasteDesc",
    "title": "توضیح ضایعات ",
},
{
    "data": "OvercomeDesc",
    "title": "توضیح بازخورد ",
},
            ],
            "columnDefs": [
                     {
                         "render": function (data, type, row) {
                             var str = "";
                             str = "<span class='btnWasteCanbanDeleteDetail btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-trash-o'></i></span> "
                             return str;
                         },
                         "targets": 14
                     },
                       {
                           "render": function (data, type, row) {
                               var str = "";
                               str = "<span class='btnWasteCanbanEditDetail btn btn-green' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-pencil'></i></span> "
                               return str;
                           },
                           "targets": 13
                       }
            ],
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                $("td:first", nRow).html(iDisplayIndex + 1);
                return nRow;
            },
        });
    }
    else {
        WasteCanbanInfoDetailGrid.ajax.url(Address).load(function () {
        });
    }
}
var IsWasteConbanEdit = false;
var PostWasteEditValues;
$(document).on("click", "#btnnewInputOutputWasteCanban", function (e) {
    mydialoge("/ProductionLineBalancingArea/InputOutputInfo/WasteCanban", "ثبت کانبان", "ثبت ضایعات", 1200, 700);
});
$(document).on("click", ".btnWasteCanbanEditDetail", function (e) {
    IsWasteConbanEdit = true;
    var tr = $(this).closest('tr');
    PostWasteEditValues = tr;
    //mydialoge("/ProductionLineBalancingArea/InputOutputInfo/WasteCanban", "ثبت کانبان", "ثبت ضایعات", 1200, 700);
    var row = WasteCanbanInfoDetailGrid.row(PostWasteEditValues);
    var rowdata = row.data();
    $("#WasteCanbanID").val(rowdata.WasteCanbanID);
    $("#InputOutputID").val(rowdata.InputOutputID);
    //$("#IOInventoryCode").val(rowdata.IOInventoryCode);
    $("#WastageQuantity").val(rowdata.WastageQuantity);
    $("#WasteSupplierID").val(rowdata.WasteSupplierID);
    $("#WasteDesc").val(rowdata.WasteDesc);
    $("#OvercomeDesc").val(rowdata.OvercomeDesc);
    $("#ReworkTime").val(rowdata.ReworkTime);
    setValueDropDownList("WastePartID", rowdata.WastePartID);
    setValueDropDownList("ActionID", rowdata.ActionID);
    setValueDropDownList("FaultID", rowdata.FaultID);
    setValueDropDownList("WTrackingCode", rowdata.WTrackingCode);
    setValueDropDownList("WInventoryCode", rowdata.WInventoryCode);
    setValueDropDownList("WPackageCode", rowdata.WPackageCode);
    setValueDropDownList("WastePartID", rowdata.WastePartID);
    setValueDropDownList("WasteSourceID", rowdata.WasteSourceID);
    setValueDropDownList("WorkerID", rowdata.WorkerID);
    setValueDropDownList("FacilityID", rowdata.FacilityID);
    setValueDropDownList("TaminID", rowdata.TaminID);
    setValueDropDownList("WCProcessStageID", rowdata.WCProcessStageID);
});
$(document).on("click", "#btnnewWasteCanbanDetail", function (e) {
    e.preventDefault();
    if ($("#ActionID").val() == 16) {
        if (checkvalid3() == false || $("#WasteSupplierID").val() == 0) {
            alert("لطفا برگه ارسال را وارد کنید");
            return false;
        }
        if (checkvalid3() == false || $("#TaminID").val() == 0) {
            alert("لطفا واحد تامین را وارد کنید");
            return false;
        }
    }
   else {
        if (checkvalid3() == false) {
            return false;
        }
    }
    if (IsWasteConbanEdit) {
        var row = WasteCanbanInfoDetailGrid.row(PostWasteEditValues);
        var record = row.data();
        record.OvercomeDesc = $("#OvercomeDesc").val();
        record.WasteDesc = $("#WasteDesc").val();
        record.WastageQuantity = $("#WastageQuantity").val();
        record.WasteSupplierID = $("#WasteSupplierID").val();
        record.WInventoryCode = $("#WInventoryCode").val();
        record.WPackageCode = $("#WPackageCode").val();
        record.WTrackingCode = $("#WTrackingCode").val();
        record.WasteSourceID = $("#WasteSourceID").val();
        record.WorkerID = $("#WorkerID").val();
        record.FacilityID = $("#FacilityIDz").val();
        record.FaultID = $("#WasteFaultID").val();
        record.ActionID = $("#ActionID").val();
        record.WasteCanbanID = $("#WasteCanbanID").val();
        record.InputOutputID = $("#InputOutputID").val();
        record.WastePartID = $("#WastePartID").val();
        record.WCProcessStageID = $("#WCProcessStageID").val();
        record.ReworkTime = $("#ReworkTime").val();
        record.TaminID = $("#TaminID").val();
        record.BOM = $("#WasteSupplierID option:selected").text();
        record.WInventoryCodeName = $("#WInventoryCode option:selected").text();
        record.WPackageCodeName = $("#WPackageCode option:selected").text();
        record.WTrackingCodeName = $("#WTrackingCode option:selected").text();
        record.WasteSourceIDName = $("#WasteSourceID option:selected").text();
        record.WorkerIDName = $("#WorkerID option:selected").text();
        record.FacilityIDName = $("#FacilityIDz option:selected").text();
        record.FaultIDName = $("#WasteFaultID option:selected").text();
        record.ActionIDName = $("#ActionID option:selected").text();
        record.WasteCanbanIDName = $("#WasteCanbanID option:selected").text();
        record.InputOutputIDName = $("#InputOutputID option:selected").text();
        record.WastePartIDName = $("#WastePartID option:selected").text();
        record.WCProcessStageIDName = $("#WCProcessStageID option:selected").text();
        record.TaminName = $("#TaminID option:selected").text();
        row.data(record);
        WasteCanbanInfoDetailGrid.draw();
        IsWasteConbanEdit = false;
    }
    else {
        var record = {
            OvercomeDesc: $("#OvercomeDesc").val(),
            WasteDesc: $("#WasteDesc").val(),
            WasteSupplierID: $("#WasteSupplierID").val(),
            WastageQuantity: $("#WastageQuantity").val(),
            WInventoryCode: $("#WInventoryCode").val(),
            WPackageCode: $("#WPackageCode").val(),
            WTrackingCode: $("#WTrackingCode").val(),
            WasteSourceID: $("#WasteSourceID").val(),
            WorkerID: $("#WorkerID").val(),
            FacilityID: $("#FacilityIDz").val(),
            FaultID: $("#WasteFaultID").val(),
            ActionID: $("#ActionID").val(),
            WasteCanbanID: 0,
            InputOutputID: $("#InputOutputID").val(),
            WastePartID: $("#WastePartID").val(),
            WCProcessStageID: $("#WCProcessStageID").val(),
            ReworkTime: $("#ReworkTime").val(),
            TaminID: $("#TaminID").val(),
            BOM: $("#WasteSupplierID option:selected").text(),
           TaminName: $("#TaminID option:selected").text(),
            WInventoryCodeName: $("#WInventoryCode option:selected").text(),
            WPackageCodeName: $("#WPackageCode option:selected").text(),
            WTrackingCodeName: $("#WTrackingCode option:selected").text(),
            WasteSourceIDName: $("#WasteSourceID option:selected").text(),
            WorkerIDName: $("#WorkerID option:selected").text(),
            FacilityIDName: $("#FacilityIDz option:selected").text(),
            FaultIDName: $("#WasteFaultID option:selected").text(),
            ActionIDName: $("#ActionID option:selected").text(),
            WasteCanbanIDName: $("#WasteCanbanID option:selected").text(),
            InputOutputIDName: $("#InputOutputID option:selected").text(),
            WastePartIDName: $("#WastePartID option:selected").text(),
            WCProcessStageIDName: $("#WCProcessStageID option:selected").text(),
        };
        //if (record.CProcessStageID == 4 && record.CWorkerID == 0) {
        //    alert("لطفا پرسنل را انتخاب نمایید");
        //}
        //else {
            WasteCanbanInfoDetailGrid.row.add(record);
            WasteCanbanInfoDetailGrid.draw();
    }
    emptyAllWasteCanban();
    alert(" ثبت شد", 1);
});
$(document).on("click", ".btnWasteCanbanDeleteDetail", function () {
    // var tr = $(this).closest('tr');
    //WasteCanbanInfoDetailGrid.row('.selected').remove().draw();
    //WasteCanbanInfoDetailGrid.ajax.reload();
     var tr = $(this).closest('tr');
     var ss = WasteCanbanInfoDetailGrid.row(tr).data().WasteCanbanID;
    $('<div style="direction:rtl">آیا از حذف مطمین هستید ؟</div>').dialog({
        resizable: false,
        height: 200,
        modal: true,
        buttons: {
            "بله": function () {
                if (ss == undefined || ss == 0) {
                    WasteCanbanInfoDetailGrid.row('.selected').remove().draw();
                   // ScheduleProductionLineGrid.ajax.reload();
                }
                else {
                    $.post("/ProductionLineBalancingArea/InputOutputInfo//Deletewaste?wasteid=" + ss, function (data) {
                        WasteCanbanInfoDetailGrid.ajax.reload();
                    });
                }
                // ScheduleProductionLineGrid();
                $(this).dialog("close");
            },
            "خیر": function () {
                $(this).dialog("close");
            }
        }
    });
});
$(document).on("click", "#WasteCanbanInfoDetailTable tbody tr", function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        WasteCanbanInfoDetailGrid.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
    var data = WasteCanbanInfoDetailGrid.row('.selected').data();
});
function emptyAllWasteCanban() {
    $("#OvercomeDesc").val("");
    $("#WasteDesc").val("");
    $("#WastageQuantity").val("");
    $("#WasteCanbanID").val("");
    setValueDropDownList("ActionID", "0");
    setValueDropDownList("FaultID", "0");
    setValueDropDownList("WTrackingCode", "0");
    setValueDropDownList("WInventoryCode", "0");
    setValueDropDownList("WPackageCode", "0");
    setValueDropDownList("WastePartID", "0");
    setValueDropDownList("WasteSourceID", "0");
    setValueDropDownList("WorkerID", "0");
    setValueDropDownList("FacilityID", "0");
    setValueDropDownList("WCProcessStageID", "0");
    IsWasteConbanEdit = false;
}