var ProductionLineInfoGrid;
var WstationID = 0;
var hspid = 0;
var hpid = 0;
var WorkerSaved = false;
//$(document).on("click", "#btnAddProductionLine", function () {
//    WstationID = $("#WorkStationID").val();
//    $("#RoutID").ajaxChosen({
//        dataType: 'json',
//        type: 'POST',
//        url: "/ProductionLineBalancingArea/ProductionLineInfo/GetAllRoutByWorkStation?WorkStationID=" + WstationID,
//        data: {}
//    }, {
//        processItems: function (data) {
//            console.log(data);
//            return data.results;
//        },
//        minLength: 1
//    });
//})
$("#btnScheduleInputOutputInfo").prop("disabled", true);
function LoadProductionLineInfoGrid() {
    ProductionLineInfoGrid = $('#ProductionLineInfoTable').DataTable({
        //  "bServerSide": true,
        "processing": true,
        "jQueryUI": false,
        "paging": true,
        "ajax": "/ProductionLineBalancingArea/ProductionLineInfo/GetAll",
        "dom": "Bfrtip", "buttons": ['copy', 'csv', 'excel', 'pdf', { text: 'Import Excel', action: function (e, dt, node, config) { $("<input type='file'>").click(); } }], "columns": [
           {
               "data": "WorkStationName",
               "title": "نام ایستگاه",
           },
           {
               "data": "RegisteredDate",
               "title": "تاریخ ثبت",
           },
            {
                "data": "ResponsibleName",
                "title": "مدیر خط",
            },
             {
                 "data": "ShiftName",
                 "title": "شیفت",
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
            str = "<span class='btnProductionLineEdit btn btn-green' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-pencil'></i></span> "
            return str;
        },
        "targets": 4
    },
        {
            "render": function (data, type, row) {
                var str = "";
                str = "<span class='btnProductionLineDelete btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-trash-o'></i></span> "
                return str;
            },
            "targets": 5
        },
         {
             "render": function (data, type, row) {
                 var str = "";
                 str = "<span class='btnProductionLineselect btn btn-primary' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-hand-o-up'></i></span> "
                 return str;
             },
             "targets": 6
         }
        ],
    });
}
$(document).on("click", "#ProductionLineInfoTable tbody tr", function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
       // $(".btnProductionLineEdit").css("background-color", "");
    }
    else {
        ProductionLineInfoGrid.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
       // $(".selected .btnProductionLineEdit").css("background-color", "red");
    }
    var data = ProductionLineInfoGrid.row('.selected').data();
});
$(document).on("click", ".btnProductionLineEdit", function () {
    $(".btnProductionLineEdit").css("background-color", "green");
    var tr = $(this).closest('tr');
    $(this).css("background-color", "darkorange");
    // make visible to boxes
    $('#ProductionLineName').val(ProductionLineInfoGrid.row(tr).data()['ProductionLineName']);
    $('#ProductionLineID').val(ProductionLineInfoGrid.row(tr).data()['ProductionLineID']);
    setValueDropDownList("WorkStationID", ProductionLineInfoGrid.row(tr).data()['WorkStationID']);
    setValueDropDownList("ResponsibleID", ProductionLineInfoGrid.row(tr).data()['ResponsibleID']);
    $.get("/ProductionLineBalancingArea/ProductionLineInfo/GetAllRoutByWorkStation?WorkStationID=" + ProductionLineInfoGrid.row(tr).data()['WorkStationID'], function (dataA) {
        var i = 0;
        $("#RoutID").empty();
        var options = '';
        for (var i = 0; i < dataA.length; i++) {
            options += '<option value="' + dataA[i].RoutID + '">' + dataA[i].RoutName + '</option>';
        }
        $("#RoutID").html(options);
        $("#RoutID").trigger("chosen:updated");
    });
    // setValueDropDownList("RoutID", ProductionLineInfoGrid.row(tr).data()['RoutID']);
    $('#WorkersAssociationID').val(ProductionLineInfoGrid.row(tr).data()['WorkersAssociationID']);
    $('#CleanTimeMin').val(ProductionLineInfoGrid.row(tr).data()['CleanTimeMin']);
    $('#FixedCost').val(ProductionLineInfoGrid.row(tr).data()['FixedCost']);
    $('#VarCostPerMin').val(ProductionLineInfoGrid.row(tr).data()['VarCostPerMin']);
    $('#MaxCapacityPerDayMin').val(ProductionLineInfoGrid.row(tr).data()['MaxCapacityPerDayMin']);
    $('#MaintenanceProgramID').val(ProductionLineInfoGrid.row(tr).data()['MaintenanceProgramID']);
});
$(document).on("click", ".btnProductionLineDelete", function () {
    var tr = $(this).closest('tr');
    $('<div style="direction:rtl">آیا از حذف مطمین هستید ؟</div>').dialog({
        resizable: false,
        height: 200,
        modal: true,
        buttons: {
            "بله": function () {
                $.post("/ProductionLineBalancingArea/ProductionLineInfo/Delete", ProductionLineInfoGrid.row(tr).data(), function (data) {
                    ProductionLineInfoGrid.ajax.reload();
                    empty_AllProductionLineInfo();
                });
                $(this).dialog("close");
            },
            "خیر": function () {
                $(this).dialog("close");
            }
        }
    });
});
function empty_AllProductionLineInfo() {
    $('#ProductionLineName').val("");
   // $('#WorkStationID').val("");
    $('#CleanTimeMin').val("");
    $('#FixedCost').val("");
    $('#VarCostPerMin').val("");
    $('#MaxCapacityPerDayMin').val("");
    $('#MaintenanceProgramID').val("");
    setValueDropDownList("WorkStationID", "");
    $("#DurationTime").val("");
    setValueDropDownList("ResponsibleID", "");
}
$(document).on("click", "#btnnewProductionLine", function (e) {
    e.preventDefault();
    if ($("#ProductionLineID").val() == "") {
        $("#ProductionLineID").val("0");
    }
    if($("#WorkStationID").val()>0){
        $("#frmProductionLineInfo").submit();
    }
    else {
        alert("لطفا فرایند را از مرحله اول انجام دهید ");
        return false;
}
});
$(document).on("submit", "#frmProductionLineInfo", function (e) {
    e.preventDefault();
    if (checkvalid() == false) {
        return false;
    }
    var oTable = $('#ScheduleProductionLineTable').dataTable();
    var DetailData = oTable.fnGetData();
    $.post("/ProductionLineBalancingArea/ProductionLineInfo/Create", $("#frmProductionLineInfo").serialize(), function (result) {
        var MasterID = result.Parameters[0].Item2;
        if (DetailData.length > 0) {
            $.post("/ProductionLineBalancingArea/ProductionLineInfo/CreateSchedule?MasterID=" + MasterID, { data: JSON.stringify(DetailData) }, function (rdata) {
                alert(rdata);
            });
        }
        alert("ثبت شد");
       WstationID = $("#WorkStationID").val();
        ScheduleProductionLineGrid.clear().draw();
      LoadScheduleProductionLineGrid(MasterID);
        //alert("a");
        empty_AllProductionLineInfo();
       // alert("af");
        ProductionLineInfoGrid.ajax.reload();
    });
});
//////////////////////////////////////////////////////////////// schaduale///////////////////////////////
var ScheduleProductionLineGrid = undefined;
function LoadScheduleProductionLineGrid(MasterID) {
    var Address = "/ProductionLineBalancingArea/ProductionLineInfo/GetAllSchedule?MasterID=" + MasterID;
    var ex = document.getElementById('ScheduleProductionLineTable');
    if (!$.fn.DataTable.fnIsDataTable(ex)) {
        ScheduleProductionLineGrid = undefined;
    }
    if (ScheduleProductionLineGrid == undefined) {
        ScheduleProductionLineGrid = $('#ScheduleProductionLineTable').DataTable({
            //  "bServerSide": true,
            "processing": true,
            "jQueryUI": false,
            "paging": true,
            "ajax": Address,
            "columns": [
                 {
                     "title": "",
                 },
                                                           {
                                                               "data": "RoutName",
                                                               "title": "رویه تولید قطعه",
                                                           },
                                 {
                                     "data": "DurationTime",
                                     "title": "زمان به دقیقه",
                                 },
                //{
                //    "data": "ScheduleStartTime",
                //    "title": "زمان شروع زمان بندی",
                //},
                //{
                //    "data": "ScheduleFinishTime",
                //    "title": "زمان پایان زمان بندی",
                //},
                //{
                //    "data": "InputID",
                //    "title": "ورودی",
                //},
                 {
                     "data": "Date",
                     "title": "تاریخ",
                 },
            ],
            "columnDefs": [
                 {
                     "render": function (data, type, row) {
                         var str = "";
                         str = "<span class='btnAddPersonel btn btn-purple ' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-user-plus'></i></span> "
                         return str;
                     },
                     "targets": 4
                 },
                  {
                      "render": function (data, type, row) {
                          var str = "";
                          str = "<span class='btnScheduleInputOutputInfo btn btn-yellow' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-data'></i></span> "
                          return str;
                      },
                      "targets": 5
                  },
           {
               "render": function (data, type, row) {
                   var str = "";
                   str = "<span class='btnScheduleDeleteDetail btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-trash-o'></i></span> "
                   return str;
               },
               "targets": 6
           },
             {
                 "render": function (data, type, row) {
                     var str = "";
                     str = "<span class='btnScheduleEditDetail btn btn-green' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-pencil'></i></span> "
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
        ScheduleProductionLineGrid.ajax.url(Address).load(function () {
        });
    }
}
$(document).on("click", "#ScheduleProductionLineTable tbody tr", function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        ScheduleProductionLineGrid.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
    var data = ScheduleProductionLineGrid.row('.selected').data();
});
var IsScheduleEdit = false;
var PostEditValues;
$(document).on("click", ".btnScheduleEditDetail", function (e) {
    IsScheduleEdit = true;
    var tr = $(this).closest('tr');
    PostEditValues = tr;
    var row = ScheduleProductionLineGrid.row(PostEditValues);
    var rowdata = row.data();
    setValueDropDownList("RoutID", rowdata.RoutID);
    $("#ScheduleProductionLineID").val(rowdata.ScheduleProductionLineID);
    $("#DurationTime").val(rowdata.DurationTime);
    $("#Date").val(rowdata.Date);
    $("#CycleTime").val(rowdata.CycleTime);
});
function emptyAllSchedule() {
    $("#ScheduleProductionLineID").val("");
    $("#ScheduleID").val("");
    $("#CycleTime").val("");
    $("#ScheduleStartTime").val("");
    $("#ScheduleFinishTime").val("");
    $("#InputID").val("");
    $("#Date").val("");
    IsScheduleEdit = false;
}
$(document).on("click", "#btnSaveNewProductionLine", function (e) {
    e.preventDefault();
    if ($("#WorkStationID").val() > 0) {
        if (checkvalid2() == false) {
            return false;
        }
        if (IsScheduleEdit) {
            var row = ScheduleProductionLineGrid.row(PostEditValues);
            var record = row.data();
            record.ScheduleProductionLineID = $("#ScheduleProductionLineID").val();
            record.ScheduleID = $("#ScheduleID").val();
            record.CycleTime = $("#CycleTime").val();
            record.ScheduleStartTime = $("#ScheduleStartTime").val();
            record.DurationTime = $("#DurationTime").val();
            record.ScheduleFinishTime = $("#ScheduleFinishTime").val();
            record.InputID = $("#InputID").val();
            record.Date = $("#Date").val();
            record.RoutID = $("#RoutID").val();
            record.RoutName = $("#RoutID_chosen span").text();
            row.data(record);
            ScheduleProductionLineGrid.draw();
            IsScheduleEdit = false;
        }
        else {
            var record = {
                ScheduleProductionLineID: $("#ScheduleProductionLineID").val(),
                ScheduleID: $("#ScheduleID").val(),
                DurationTime: $("#DurationTime").val(),
                CycleTime: $("#CycleTime").val(),
                RoutID: $("#RoutID").val(),
                RoutName: $("#RoutID_chosen span").text(),
                ScheduleStartTime: $("#ScheduleStartTime").val(),
                ScheduleFinishTime: $("#ScheduleFinishTime").val(),
                InputID: $("#InputID").val(),
                Date: $("#Date").val(),
            };
            ScheduleProductionLineGrid.row.add(record);
           ScheduleProductionLineGrid.draw();
        }
        emptyAllSchedule();
        alert(" ثبت شد", 1);
    }
    else {
        alert("لطفا فرایند را از مرحله اول انجام دهید ");
        return false;
    }
});
$(document).on("click", ".btnScheduleDeleteDetail", function () {
    // var tr = $(this).closest('tr');
    var tr = $(this).closest('tr');
    var ss = ScheduleProductionLineGrid.row(tr).data().ScheduleProductionLineID;
    $('<div style="direction:rtl">آیا از حذف مطمین هستید ؟</div>').dialog({
        resizable: false,
        height: 200,
        modal: true,
        buttons: {
            "بله": function () {
                if (ss == undefined || ss == 0) {
                    ScheduleProductionLineGrid.row('.selected').remove().draw();
                   // ScheduleProductionLineGrid.ajax.reload();
                }
                else {
                    $.post("/ProductionLineBalancingArea/ProductionLineInfo/DeleteSchedule?Schedulid=" + ss, function (data) {
                        ScheduleProductionLineGrid.ajax.reload();
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
$(document).on("click", ".btnScheduleInputOutputInfo", function (e) {
    //if (WorkerSaved || AddPersonelGrid.rows().count() > 0) {
    $(".btnScheduleInputOutputInfo").css("background-color", "orange");
    var tr = $(this).closest('tr');
    $(this).css("background-color", "deeppink");
    var SPID = ScheduleProductionLineGrid.row(tr).data().ScheduleProductionLineID;
    $.post("/ProductionLineBalancingArea/ProductionLineInfo/checkpersonel", { spid: SPID }, function (result) {
        if (result == 1) {
            mydialoge("/ProductionLineBalancingArea/ProductionLineInfo/AddInputOutPut?SPID=" + SPID, "ثبت ورودی/خروجی", "ثبت ثبت ورودی/خروجی", 1200, 1200);
        };
    });
    //  }
    // else {
    //  alert("ابتدا پرسنل را تعریف کنید");
    //  return false;
    // }
});
$(document).on("click", ".btnAddPersonel", function (e) {
    var tr = $(this).closest('tr');
    hspid = ScheduleProductionLineGrid.row(tr).data().ScheduleProductionLineID;
    var WorkStationID = WstationID;
    mydialoge("/ProductionLineBalancingArea/ProductionLineInfo/AddPersonel?SPID=" + hspid + "&WorkStationID=" + WorkStationID, "ثبت پرسنل", "ثبت  پرسنل", 700, 700);
});
////////////////////////////////addPersonel//////////
$(document).on("click", "#btnSavenewPersonel", function (e) {
    WorkerSaved = true;
    e.preventDefault();
    if ($("#WorkersAssociationID").val() == "") {
        $("#WorkersAssociationID").val("0");
    }
    $("#frmAddPersonelInfo").submit();
});
$(document).on("submit", "#frmAddPersonelInfo", function (e) {
    e.preventDefault();
    var oTable = $('#AddPersonelTable').dataTable();
    var DetailData = oTable.fnGetData();
    if (DetailData.length > 0) {
        $.post("/ProductionLineBalancingArea/ProductionLineInfo/CreatePersonel", { data: JSON.stringify(DetailData) }, function (result) {
            var SchedulePID = $("#ScheduleProductionLineID2").val();
        });
    }
    alert("ثبت شد");
});
var AddPersonelGrid = undefined;
function LoadAddPersonelGrid(SchedulePID) {
    var Address = "/ProductionLineBalancingArea/ProductionLineInfo/GetAllPersonel?SchedulePID=" + SchedulePID;
    var ex = document.getElementById('AddPersonelTable');
    if (!$.fn.DataTable.fnIsDataTable(ex)) {
        AddPersonelGrid = undefined;
    }
    if (AddPersonelGrid == undefined) {
        AddPersonelGrid = $('#AddPersonelTable').DataTable({
            //  "bServerSide": true,
            "processing": true,
            "jQueryUI": false,
            "paging": true,
            "ajax": Address,
            "dom": "Bfrtip", "buttons": ['copy', 'csv', 'excel', 'pdf', { text: 'Import Excel', action: function (e, dt, node, config) { $("<input type='file'>").click(); } }], "columns": [
                                {
                                    "title": "",
                                },
               {
                   "data": "FacilityName",
                   "title": "نام تسهیل",
               },
               //{
               //    "data": "WorkersAssociationName",
               //    "title": "وضعیت همکاری",
               //},
                {
                    "data": "WorkersName",
                    "title": "نام پرسنل",
                },
                {
                    "data": "W_WorkersID",
                    "title": "",
                    "visible": false
                },
                 {
                     "data": "ScheduleProductionLineID2",
                     "title": "",
                     "visible": false
                 },
                  {
                      "data": "ProductionLineID2",
                      "title": "",
                      "visible": false
                  },
                   {
                       "data": "WorkersScheduleID",
                       "title": "",
                       "visible": false
                   },
            ],
            "columnDefs": [
              {
                  "render": function (data, type, row) {
                      var str = "";
                      str = "<span class='btnPersonelDeleteDetail btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-trash-o'></i></span> "
                      return str;
                  },
                  "targets": 7
              },
                {
                    "render": function (data, type, row) {
                        var str = "";
                        str = "<span class='btnPersonelEditDetail btn btn-green' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-pencil'></i></span> "
                        return str;
                    },
                    "targets": 8
                }
            ],
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                $("td:first", nRow).html(iDisplayIndex + 1);
                return nRow;
            },
        });
    }
    else {
        AddPersonelGrid.ajax.url(Address).load(function () {
        });
    }
}
$(document).on("click", "#AddPersonelTable tbody tr", function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        AddPersonelGrid.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
    var data = AddPersonelGrid.row('.selected').data();
});
function empty_AllAddPersonel() {
    $('#ScheduleProductionLineID').val("");
    $('#WorkersAssociationID').val("");
    $('#ProductionLineID').val("");
    $('#WorkerID').val("");
    $('#WorkersScheduleID').val("");
}
var IsPersonelEdit = false;
var PostPErsonelEditValues;
$(document).on("click", ".btnScheduleEditDetail", function (e) {
    IsPersonelEdit = true;
    var tr = $(this).closest('tr');
    PostPErsonelEditValues = tr;
});
$(document).on("click", "#btnnewAddPersonel", function (e) {
    if ($('#W_WorkersID').val() > 0) {
        if (IsPersonelEdit) {
            var row = AddPersonelGrid.row(PostPErsonelEditValues);
            var record = row.data();
            record.ScheduleProductionLineID2 = $("#ScheduleProductionLineID2").val();
            record.WorkersAssociationID = $("#WorkersAssociationID").val();
            record.ProductionLineID2 = $("#ProductionLineID2").val();
            record.W_WorkersID = $("#W_WorkersID").val();
            record.WorkersName = $("#W_WorkersID option:selected").text();
            record.WorkersScheduleID = 0;
            record.FacilityName = $("#W_FacilityID option:selected").text();
            record.WorkersAssociationName = $("#WorkersAssociationID_chosen span").text();
            record.W_FacilityID = $("#W_FacilityID").val();
            row.data(record);
            AddPersonelGrid.draw();
            IsPersonelEdit = false;
        }
        else {
            var record = {
                ScheduleProductionLineID2: $("#ScheduleProductionLineID2").val(),
                WorkersAssociationID: $("#WorkersAssociationID").val(),
                ProductionLineID2: $("#ProductionLineID2").val(),
                W_WorkersID: $("#W_WorkersID").val(),
                WorkersName: $("#W_WorkersID option:selected").text(),
                WorkersScheduleID: 0,
                FacilityName: $("#W_FacilityID option:selected").text(),
                WorkersAssociationName: $("#WorkersAssociationID_chosen span").text(),
                W_FacilityID: $("#W_FacilityID").val(),
            };
            AddPersonelGrid.row.add(record);
            AddPersonelGrid.draw();
        }
        emptyAllSchedule();
        alert(" ثبت شد", 1);
    }
    else {
        alert("لطفانام پرسنل را انتخاب کنید ");
}
});
$(document).on("click", ".btnPersonelDeleteDetail", function () {
    var tr = $(this).closest('tr');
    var ss = AddPersonelGrid.row(tr).data().WorkersScheduleID;
    if (ss == undefined || ss == 0) {
        AddPersonelGrid.row(tr).remove().draw();
    }
    else {
        $('<div style="direction:rtl">آیا از حذف مطمین هستید ؟</div>').dialog({
            resizable: false,
            height: 200,
            modal: true,
            buttons: {
                "بله": function () {
                    $.post("/ProductionLineBalancingArea/ProductionLineInfo/DeletePersonel", AddPersonelGrid.row(tr).data(), function (data) {
                        AddPersonelGrid.ajax.reload();
                    });
                    $(this).dialog("close");
                },
                "خیر": function () {
                    $(this).dialog("close");
                }
            }
        });
    }
});
///////////////facilitystop////////////
//$(document).on("click", "#btnnewFacilityStoptab", function (e) {
//    e.preventDefault();
//    if ($("#FacilityStopID").val() == "") {
//        $("#FacilityStopID").val("0");
//    }
//    $("#frmInputOutputInfo").submit();
//});
//$(document).on("submit", "#frmInputOutputInfo", function (e) {
//    e.preventDefault();
//    //if (checkvalid() == false) {
//    //    return false;
//    //}
//    if (CanbanInfoDetailGrid.rows().count() >= 1) {
//        $.post("/ProductionLineBalancingArea/FacilityStopInfo/Create", $("#frmInputOutputInfo").serialize(), function (data) {
//            alert("ثبت شد");
//            FacilityStopInfoGridtab.ajax.reload();
//        });
//        empty_AllFacilityStopInfo();
//        FacilityStopInfoGridtab.ajax.reload();
//    }
//});
var FacilityStopInfoGridtab;
function LoadFacilityStopInfoGridtab(Masterid) {
    FacilityStopInfoGridtab = $('#FacilityStopInfoTabletab').DataTable({
        //  "bServerSide": true,
        "processing": true,
        "jQueryUI": false,
        "paging": true,
        "ajax": "/ProductionLineBalancingArea/FacilityStopInfo/GetAllwithMaster?Masterid=" + $(".adis").val(),
        "dom": "Bfrtip", "buttons": ['copy', 'csv', 'excel', 'pdf', { text: 'Import Excel', action: function (e, dt, node, config) { $("<input type='file'>").click(); } }], "columns": [
           {
               "data": "FacilityName",
               "title": "نام ایستگاه",
           },
           {
               "data": "WorkerName",
               "title": "نام پرسنل",
           },
           {
               "data": "StopName",
               "title": "نوع توقف",
           },
            {
                "data": "StopReasonName",
                "title": "علت توقف",
            },
             {
                 "data": "FacilityStopDuration",
                 "title": "مدت زمان توقف",
             },
               {
                   "data": "FacilityStopDesc",
                   "title": "توضیحات",
               },
                //{
                //    "data": "RoutDown",
                //    "title": "توقف کل خط",
                //},
                 {
                     "title": "",
                 },
                            {
                                "title": "",
                            },
        ],
        "columnDefs": [
             //{
             //    "render": function (data, type, row) {
             //        var str = "";
             //        if (data == true) {
             //            str = "بله";
             //        }
             //        if (data == false) {
             //            str = "خیر";
             //        }
             //        return str;
             //    },
             //    "targets": 6
             //},
     {
         "render": function (data, type, row) {
             var str = "";
             str = "<span class='btnFacilityStopInfoEdittab btn btn-green' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-pencil'></i></span> "
             return str;
         },
         "targets": 6
     },
        {
            "render": function (data, type, row) {
                var str = "";
                str = "<span class='btnFacilityStopInfoDeletetab btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-trash-o'></i></span> "
                return str;
            },
            "targets": 7
        }
        ],
    });
}
$(document).on("click", "#FacilityStopInfoTabletab tbody tr", function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        FacilityStopInfoGridtab.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
    var data = FacilityStopInfoGridtab.row('.selected').data();
});
var IsStopEdit = false;
var PostEditStopValues;
$(document).on("click", ".btnFacilityStopInfoEdittab", function () {
    //var tr = $(this).closest('tr');
    //// make visible to boxes
    //$('#FacilityStopID').val(FacilityStopInfoGridtab.row(tr).data()['FacilityStopID']);
    //$('#FacilityStopDuration').val(FacilityStopInfoGridtab.row(tr).data()['FacilityStopDuration']);
    //$('#FacilityStopDesc').val(FacilityStopInfoGridtab.row(tr).data()['FacilityStopDesc']);
    //$('#OEE').val(FacilityStopInfoGridtab.row(tr).data()['OEE']);
    ////$('#FacilityStopStartTime').val(FacilityStopInfoGrid.row(tr).data()['FacilityStopStartTime']);
    //setValueDropDownList("FacilityID", FacilityStopInfoGridtab.row(tr).data()['FacilityID']);
    //setValueDropDownList("ScheduleProductionLineID", FacilityStopInfoGridtab.row(tr).data()['ScheduleProductionLineID']);
    //setValueDropDownList("WorkerID", FacilityStopInfoGridtab.row(tr).data()['WorkerID']);
    //setValueDropDownList("StopID", FacilityStopInfoGridtab.row(tr).data()['StopID']);
    //var parentIID = FacilityStopInfoGridtab.row(tr).data().ScheduleProductionLineID;
    //LoadFacilityStopInfoGridtab(parentIID);
    IsStopEdit = true;
    var tr = $(this).closest('tr');
    PostEditStopValues = tr;
    //mydialoge("/ProductionLineBalancingArea/InputOutputInfo/Canban", "ثبت کانبان", "ثبت ضایعات", 1200, 700);
    var row = FacilityStopInfoGridtab.row(PostEditStopValues);
    var rowdata = row.data();
    $("#FacilityStopID").val(rowdata.FacilityStopID);
    $("#FacilityIDStop").val(rowdata.FacilityIDStop);
    $("#WorkerIDStop").val(rowdata.WorkerIDStop);
    $("#FacilityStopDuration").val(rowdata.FacilityStopDuration);
    $("#FacilityStopDesc").val(rowdata.FacilityStopDesc);
    $("#OEE").val(rowdata.OEE);
    $("#FacilityStopStartTime").val(rowdata.FacilityStopStartTime);
    setValueDropDownList("FacilityID", rowdata.FacilityID);
    setValueDropDownList("ScheduleProductionLineID", rowdata.ScheduleProductionLineID);
    setValueDropDownList("WorkerID", rowdata.WorkerID);
    setValueDropDownList("StopID", rowdata.StopID);
    setValueDropDownList("StopReasonID", rowdata.StopReasonID);
});
$(document).on("click", ".btnFacilityStopInfoDeletetab", function () {
    var tr = $(this).closest('tr');
    $('<div style="direction:rtl">آیا از حذف مطمین هستید ؟</div>').dialog({
        resizable: false,
        height: 200,
        modal: true,
        buttons: {
            "بله": function () {
                $.post("/ProductionLineBalancingArea/FacilityStopInfo/Delete", FacilityStopInfoGridtab.row(tr).data(), function (data) {
                    FacilityStopInfoGridtab.ajax.reload();
                    empty_AllFacilityStopInfo();
                });
                $(this).dialog("close");
            },
            "خیر": function () {
                $(this).dialog("close");
            }
        }
    });
});
function empty_AllFacilityStopInfo() {
    LoadFacilityStopInfoGridtab(0);
   // $('#FacilityStopID').val("");
    $('#FacilityStopDuration').val("");
    $('#FacilityStopDesc').val("");
    $("#DepartmentID").val("");
    $('#FacilityStopStartTime').val("");
    setValueDropDownList("FacilityID", "0");
    setValueDropDownList("ScheduleProductionLineID", "0");
    setValueDropDownList("WorkerID", "0");
    setValueDropDownList("StopID", "0");
    setValueDropDownList("StopReasonID", "0");
    IsStopEdit = false;
}
$(document).on("click", "#btnnewFacilityStopDetail", function (e) {
    e.preventDefault();
   if (checkvalid() == false) {
       return false;
    }
    if (IsStopEdit) {
        var row = FacilityStopInfoGridtab.row(PostEditStopValues);
        var record = row.data();
        record.FacilityStopID = $("#FacilityStopID").val();
        record.FacilityIDStop = $("#FacilityIDStop").val();
        record.WorkerIDStop = $("#WorkerIDStop").val();
        record.StopReasonID = $("#StopReasonID").val();
        record.FacilityStopDuration = $("#FacilityStopDuration").val();
        record.FacilityStopDesc = $("#FacilityStopDesc").val();
        record.OEE = $("#OEE").val();
        record.FacilityStopStartTime = $("#FacilityStopStartTime").val();
        record.ScheduleProductionLineID = $("#ScheduleProductionLineID").val();
        record.FacilityName = $("#FacilityIDStop option:selected").text();
        record.WorkerName = $("#WorkerIDStop option:selected").text();
        record.StopName = $("#StopID option:selected").text();
        record.StopReasonName = $("#StopReasonID option:selected").text();
        record.FacilityID = $("#FacilityID").val();
        record.WorkerID = $("#WorkerID").val();
        record.StopID = $("#StopID").val();
        record.DepartmentID = $("#DepartmentID").val();
        record.RoutDown = $("#RoutDown").val();
        row.data(record);
        FacilityStopInfoGridtab.draw();
        IsStopEdit = false;
    }
    else {
        var record = {
            FacilityID: $("#FacilityID").val(),
            FacilityIDStop: $("#FacilityIDStop").val(),
            WorkerIDStop: $("#WorkerIDStop").val(),
        WorkerID: $("#WorkerID").val(),
        StopReasonID: $("#StopReasonID").val(),
        StopID : $("#StopID").val(),
           FacilityStopID : 0,
        FacilityStopDuration : $("#FacilityStopDuration").val(),
        FacilityStopDesc: $("#FacilityStopDesc").val(),
        DepartmentID: $("#DepartmentID").val(),
        OEE : $("#OEE").val(),
        FacilityStopStartTime : $("#FacilityStopStartTime").val(),
        ScheduleProductionLineID: $("#ScheduleProductionLineID").val(),
        StopReasonName : $("#StopReasonID option:selected").text(),
        FacilityName: $("#FacilityIDStop option:selected").text(),
        WorkerName: $("#WorkerIDStop option:selected").text(),
        StopName: $("#StopID option:selected").text(),
        RoutDown: $("#RoutDown").val(),
        };
        FacilityStopInfoGridtab.row.add(record);
        FacilityStopInfoGridtab.draw();
    }
    empty_AllFacilityStopInfo();
    alert(" ثبت شد", 1);
});