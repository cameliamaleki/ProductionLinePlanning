var RoutInfoGrid;
var ROUTIDNEW = 0;
var PARTIDNEW = "0";
var WORKSTATIONNEW = 0;
var partfac = 0;
$(document).on("click", ".activeRout", function (e) {
    if ($(this).hasClass("label-yellow")) {
        $(this).removeClass("label-yellow");
        $(this).addClass("label-danger");
        $(this).html("غیر فعال")
    } else {
        $(this).removeClass("label-danger");
        $(this).addClass("label-yellow");
        $(this).html("فعال")
    }
    var aa = RoutInfoGrid.row($(this).closest('tr')).data();
    $.post("/ProductionLineBalancingArea/RoutInfo/RoutActivity?Activity=" + $(this).html() + "&RoutID=" + aa.RoutID, function (data) {
    });
});
function LoadRoutInfoGrid() {
    RoutInfoGrid = $('#RoutInfoTable').DataTable({
        //  "bServerSide": true,
        "processing": true,
        "jQueryUI": false,
        "paging": true,
        "ajax": "/ProductionLineBalancingArea/RoutInfo/GetAll",
        "dom": "Bfrtip", "buttons": ['copy', 'csv', 'excel', 'pdf', { text: 'Import Excel', action: function (e, dt, node, config) { $("<input type='file'>").click(); } }], 
        "columns": [
           {
               "data": "RoutName",
               "title": "نام جریان",
           },
           {
               "data": "WorkStationName",
               "title": "نام ایستگاه",
           },
            {
                "data": "RoutTypeName",
                "title": "نوع",
            },
             {
                 "data": "PartName",
                 "title": "نام قطعه",
             },
              {
                  "data": "IsActived",
                  "title": "",
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
           str = "<span class='btnRoutInfoEdit btn btn-green' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-pencil'></i></span> "
           return str;
       },
       "targets": 5
   },
        {
            "render": function (data, type, row) {
                var str = "";
                str = "<span class='btnRoutInfoDelete btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-trash-o'></i></span> "
                return str;
            },
            "targets": 6
        },
        {
            "render": function (data, type, row) {
                if (data == "0") {
                    data = "غیر فعال";
                    var str = "";
                    str = str + "<div class='col-md-4'><button class='label label-sm label-danger selectt activeRout'> " + data + "</button> </div>";
                }
                else if (data != 0) {
                    data = "فعال";
                    console.log("render 0");
                    var str = "";
                    str = str + "<div class='col-md-4'><button class='label label-sm label-yellow selectt activeRout'> " + data + "</button> </div>";
                }
                return str;
            },
            "targets": 4
        },
        ],
    });
}
$(document).on("click", "#RoutInfoTable tbody tr", function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        RoutInfoGrid.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
    var data = RoutInfoGrid.row('.selected').data();
});
$(document).on("click", ".btnRoutInfoEdit", function () {
    var tr = $(this).closest('tr');
    // make visible to boxes
    $('#RoutName').val(RoutInfoGrid.row(tr).data()['RoutName']);
    $('#RoutID').val(RoutInfoGrid.row(tr).data()['RoutID']);
    setValueDropDownList("PartID", RoutInfoGrid.row(tr).data()['PartID']);
    setValueDropDownList("RoutTypeID", RoutInfoGrid.row(tr).data()['RoutTypeID']);
    setValueDropDownList("WorkStationID", RoutInfoGrid.row(tr).data()['WorkStationID']);
    if ($("#PartID").val() == "0") {
        $('#btnnewRoutFacility').prop('disabled', true);
    }
    else {
        $('#btnnewRoutFacility').prop('disabled', false);
    }
    var parentIID = RoutInfoGrid.row(tr).data().RoutID;
    LoadRoutFacilityInfoDetail(parentIID);
    LoadRoutChildParentInfoDetail(parentIID);
});
$(document).on("click", ".btnRoutInfoDelete", function () {
    var tr = $(this).closest('tr');
    $('<div style="direction:rtl">آیا از حذف مطمین هستید ؟</div>').dialog({
        resizable: false,
        height: 200,
        modal: true,
        buttons: {
            "بله": function () {
                $.post("/ProductionLineBalancingArea/RoutInfo/CheckRoutUsed?RoutID=" + RoutInfoGrid.row(tr).data().RoutID, function (data) {
                    if (data != "0") {
                        alert(data);
                        $(this).dialog("close");
                    }
                    else {
                        $.post("/ProductionLineBalancingArea/RoutInfo/Delete", RoutInfoGrid.row(tr).data(), function (data) {
                            RoutInfoGrid.ajax.reload();
                            empty_AllRoutInfo();
                        });
                    }
                });
                $(this).dialog("close");
            },
            "خیر": function () {
                $(this).dialog("close");
            }
        }
    });
});
function empty_AllRoutInfo() {
    $('#RoutName').val("");
    $('#RoutID').val("");
    $('#WorkStationID').val("");
    $('#RoutTypeID').val("");
    $('#PartID').val("");
    setValueDropDownList("PartID", "0");
    setValueDropDownList("RoutTypeID", "0");
    setValueDropDownList("WorkStationID", "0");
    LoadRoutFacilityInfoDetail(0);
    LoadRoutChildParentInfoDetail(0);
}
$(document).on("click", "#btnCleanRout", function (e) {
    e.preventDefault();
    empty_AllRoutInfo();
    LoadRoutInfoGrid();
});
$(document).on("click", "#btnSaveNewRout", function (e) {
    e.preventDefault();
    $("#RoutID").val("0");
    $("#frmRoutInfo").submit();
});
$(document).on("click", "#btnnewRout", function (e) {
    e.preventDefault();
    if ($("#RoutID").val() == "") {
        $("#RoutID").val("0");
    }
    $("#frmRoutInfo").submit();
});
$(document).on("submit", "#frmRoutInfo", function (e) {
    e.preventDefault();
    if (checkvalid() == false) {
        return false;
    }
    var oTable = $('#RoutFacilityInfoTable').dataTable();
    var DetailData = oTable.fnGetData();
    var oTable2 = $('#RoutChildParentInfoTable').dataTable();
    var DetailData2 = oTable2.fnGetData();
    $.post("/ProductionLineBalancingArea/RoutInfo/Create", $("#frmRoutInfo").serialize(), function (result) {
        var MASTERID = result.Parameters[0].Item2;
        if (DetailData.length > 0) {
            $.post("/ProductionLineBalancingArea/RoutInfo/CreateDetail1?MASTERID=" + MASTERID, { data: JSON.stringify(DetailData) }, function (rdata) {
            });
        }
            if (DetailData2.length > 0) {
                $.post("/ProductionLineBalancingArea/RoutInfo/CreateDetail2?MASTERID=" + MASTERID, { data: JSON.stringify(DetailData2) }, function (rdata) {
                });
        }
        alert("ثبت شد");
        empty_AllRoutInfo();
        RoutInfoGrid.ajax.reload();
    });
    e.preventDefault();
});
/////////////////RoutFacility ////////////////////
var RoutFacilityInfoGrid;
function LoadRoutFacilityInfoDetail(parentIID) {
    var Address = "/ProductionLineBalancingArea/RoutInfo/GetAllDetail1?parentIID=" + parentIID;
    var ex = document.getElementById('RoutFacilityInfoTable');
    if (!$.fn.DataTable.fnIsDataTable(ex)) {
        RoutFacilityInfoGrid = undefined;
    }
    if (RoutFacilityInfoGrid == undefined) {
        RoutFacilityInfoGrid = $('#RoutFacilityInfoTable').DataTable({
            "processing": true,
            "jQueryUI": false,
            "paging": true,
            "ajax": Address,
            "dom": "Bfrtip", "buttons": ['copy', 'csv', 'excel', 'pdf', { text: 'Import Excel', action: function (e, dt, node, config) { $("<input type='file'>").click(); } }], "columns": [
{
    "data": "",
    "title": "ردیف",
},
{
    "data": "PartName",
                    "title": "نام محصول",
                },
               {
                   "data": "FaciltiyName",
                   "title": "نام تسهیل",
               },
               {
                   "data": "TimeDurationMin",
                   "title": "مدت زمان ",
               },
            ],
            "columnDefs": [
                     {
                         "render": function (data, type, row) {
                             var str = "";
                             str = "<span class='btnRoutFacilityDeleteDetail btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-trash-o'></i></span> "
                             return str;
                         },
                         "targets": 5
                     },
                       {
                           "render": function (data, type, row) {
                               var str = "";
                               str = "<span class='btnRoutFacilityEditDetail btn btn-green' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-pencil'></i></span> "
                               return str;
                           },
                           "targets": 4
                       }
            ],
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                $("td:first", nRow).html(iDisplayIndex + 1);
                return nRow;
            },
        });
    }
    else {
        RoutFacilityInfoGrid.ajax.url(Address).load(function () {
        });
    }
}
var IsRoutFacilityEdit = false;
var RoutFacilityPostEditValues;
$(document).on("click", ".btnRoutFacilityEditDetail", function (e) {
    IsRoutFacilityEdit = true;
    var tr = $(this).closest('tr');
    RoutFacilityPostEditValues = tr;
    ROUTIDNEW = $('#RoutID').val();
    PARTIDNEW = $('#PartID option:selected').text();
    WORKSTATIONNEW = $('#WorkStationID').val();
    partfac = $('#PartID').val();
    mydialoge("/ProductionLineBalancingArea/RoutInfo/CreateDetail1", "ثبت مدت زمان ماشین الات", "ثبت مدت زمان ماشین الات", 1200, 700);
});
$(document).on("click", "#btnnewRoutFacility", function (e) {
    ROUTIDNEW = $('#RoutID').val();
    PARTIDNEW = $('#PartID option:selected').text();
    WORKSTATIONNEW = $('#WorkStationID').val();
    mydialoge("/ProductionLineBalancingArea/RoutInfo/CreateDetail1", "ثبت مدت زمان ماشین الات", "ثبت مدت زمان ماشین الات", 1200, 700);
});
$(document).on("click", "#btnnewRoutFacilityDetail", function (e) {
    if (IsRoutFacilityEdit) {
        var row = RoutFacilityInfoGrid.row(RoutFacilityPostEditValues);
        var record = row.data();
        record.RoutID = $("#RoutID").val();
        record.RoutFacilityID = $("#RoutFacilityID").val();
        record.FaciltiyID = $("#FaciltiyID").val();
        record.PartID = $("#fff").val();
        record.TimeDurationMin = $("#TimeDurationMin").val();
        record.FaciltiyName = $("#FaciltiyID option:selected").text();
        record.PartName = $("#PPPAAARRRTTT").val();
        row.data(record);
        RoutFacilityInfoGrid.draw();
        IsRoutFacilityEdit = false;
    }
    else {
        var record = {
            RoutID: $("#RoutID").val(),
            RoutFacilityID : 0,
            FaciltiyName: $("#FaciltiyID option:selected").text(),
            PartName: $("#PartID option:selected").text(),
            FaciltiyID: $("#FaciltiyID").val(),
            PartID: $("#PartID").val(),
            TimeDurationMin : $("#TimeDurationMin").val(),
        };
        RoutFacilityInfoGrid.row.add(record);
        RoutFacilityInfoGrid.draw();
    }
    emptyAllRoutFacility();
    alert(" ثبت شد", 1);
});
$(document).on("click", ".btnRoutFacilityDeleteDetail", function () {
    var tr = $(this).closest('tr');
    //RoutFacilityInfoGrid.row('tr.selected').remove().draw();
    //RoutFacilityInfoGrid.ajax.reload();
    var ss = RoutFacilityInfoGrid.row(tr).data().RoutFacilityID;
    if (ss == undefined || ss == 0) {
        $('<div style="direction:rtl">آیا از حذف مطمین هستید ؟</div>').dialog({
            resizable: false,
            height: 200,
            modal: true,
            buttons: {
                "بله": function () {
                    RoutFacilityInfoGrid.row(tr).remove().draw();
                    $(this).dialog("close");
                },
                "خیر": function () {
                    $(this).dialog("close");
                }
            }
        });
    }
    else {
        $('<div style="direction:rtl">آیا از حذف مطمین هستید ؟</div>').dialog({
            resizable: false,
            height: 200,
            modal: true,
            buttons: {
                "بله": function () {
                    $.post("/ProductionLineBalancingArea/RoutInfo/DeleteDetail1?RoutFacilityID=" + ss, function (data) {
                        RoutFacilityInfoGrid.ajax.reload();
                    });
                    $(this).dialog("close");
                },
                "خیر": function () {
                    $(this).dialog("close");
                }
            }
        });
        //delete now
    }
});
$(document).on("click", "#RoutFacilityInfoTable tbody tr", function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        RoutFacilityInfoGrid.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
    var data = RoutFacilityInfoGrid.row('.selected').data();
});
function emptyAllRoutFacility() {
    $("#RoutFacilityID").val("");
    $("#FaciltiyID").val("");    
    $("#TimeDurationMin").val("");
    IsRoutFacilityEdit = false;
}
/////////////////RoutChildParent ////////////////////
var RoutChildParentInfoGrid;
function LoadRoutChildParentInfoDetail(parentIID) {
    var Address = "/ProductionLineBalancingArea/RoutInfo/GetAllDetail2?parentIID=" + parentIID;
    var ex = document.getElementById('RoutChildParentInfoTable');
    if (!$.fn.DataTable.fnIsDataTable(ex)) {
        RoutChildParentInfoGrid = undefined;
    }
    if (RoutChildParentInfoGrid == undefined) {
        RoutChildParentInfoGrid = $('#RoutChildParentInfoTable').DataTable({
            "processing": true,
            "jQueryUI": false,
            "paging": true,
            "ajax": Address,
            "dom": "Bfrtip", "buttons": ['copy', 'csv', 'excel', 'pdf', { text: 'Import Excel', action: function (e, dt, node, config) { $("<input type='file'>").click(); } }], "columns": [
               {
                   "data": "",
                   "title": "ردیف",
               },
                {
                    "data": "ChildRoutName",
                    "title": "زیرخط",
                },
            ],
            "columnDefs": [
                     {
                         "render": function (data, type, row) {
                             var str = "";
                             str = "<span class='btnRoutChildParentDeleteDetail btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='fa fa-trash-o'></i></span> "
                             return str;
                         },
                         "targets": 3
                     },
                       {
                           "render": function (data, type, row) {
                               var str = "";
                               str = "<span class='btnRoutChildParentEditDetail btn btn-green' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' ><i class='clip-pencil'></i></span> "
                               return str;
                           },
                           "targets": 2
                       }
            ],
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                $("td:first", nRow).html(iDisplayIndex + 1);
                return nRow;
            },
        });
    }
    else {
        RoutChildParentInfoGrid.ajax.url(Address).load(function () {
        });
    }
}
var IsRoutChildParentEdit = false;
var RoutChildParentPostEditValues;
$(document).on("click", ".btnRoutChildParentEditDetail", function (e) {
    IsRoutChildParentEdit = true;
    var tr = $(this).closest('tr');
    RoutChildParentPostEditValues = tr;
    ROUTIDNEW = $('#RoutID').val();
    PARTIDNEW = $('#PartID').val();
    WORKSTATIONNEW = $('#WorkStationID').val();
    mydialoge("/ProductionLineBalancingArea/RoutInfo/CreateDetail2", "ثبت زیرخط", "ثبت زیرخط", 1200, 700);
});
$(document).on("click", "#btnnewRoutChildParent", function (e) {
    ROUTIDNEW = $('#RoutID').val();
    PARTIDNEW = $('#PartID').val();
    WORKSTATIONNEW = $('#WorkStationID').val();
    mydialoge("/ProductionLineBalancingArea/RoutInfo/CreateDetail2", "ثبت زیرخط", "ثبت زیرخط", 1200, 700);
});
$(document).on("click", "#btnnewRoutChildParentDetail", function (e) {
    if (IsRoutChildParentEdit) {
        var row = RoutChildParentInfoGrid.row(RoutChildParentPostEditValues);
        var record = row.data();
        record.RoutID = $("#RoutID").val();
        record.RoutChildParentID = $("#RoutChildParentID").val();
        record.ChildRoutName = $("#ChildRoutID option:selected").text();
        record.ChildRoutID = $("#ChildRoutID").val();
        row.data(record);
        RoutChildParentInfoGrid.draw();
        IsRoutChildParentEdit = false;
    }
    else {
        var record = {
            RoutID: $("#RoutID").val(),
            RoutChildParentID: 0,
            RoutChildParentID: $("#RoutChildParentID").val(),
            ChildRoutName: $("#ChildRoutID option:selected").text(),
            ChildRoutID: $("#ChildRoutID").val()
        };
        RoutChildParentInfoGrid.row.add(record);
        RoutChildParentInfoGrid.draw();
    }
    emptyAllRoutChildParent();
    alert(" ثبت شد", 1);
});
$(document).on("click", ".btnRoutChildParentDeleteDetail", function () {
    // var tr = $(this).closest('tr');
    RoutChildParentInfoGrid.row('.selected').remove().draw();
    RoutChildParentInfoGrid.ajax.reload();
    RoutChildParentInfoGrid();
});
$(document).on("click", "#RoutChildParentInfoTable tbody tr", function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        RoutChildParentInfoGrid.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
    var data = RoutChildParentInfoGrid.row('.selected').data();
});
function emptyAllRoutChildParent() {
    // $("#RoutID").val("");
    $("#RoutChildParentID").val("");
    setValueDropDownList("ChildRoutID", "0");
    IsRoutChildParentEdit = false;
}
