//$(document).on("click", "#btnLendingCarsNew", function (e) {
//    $("#btnLendingCarsCancel").prop("disabled", false)
//    $("#btnLendingCarsConfirm").prop("disabled", false)
//    $("#btnLendingCarsReject").prop("disabled", true)
//    $("#btnLendingCarsEdit").prop("disabled", true)
//    $("#btnLendingCarsNew").prop("disabled", true)
//    ClearCombo("IDrequstAmani", true);
//    ClearCombo("F_AgnID", true);
//    $("#DateA").val("");
//    //$("#F_AgnID = query.F_AgnID;
//    $("#FlgTaahod").prop("checked", false);
//    //$("#TrackID = (int?)query.TrackID;
//    $("#code").val("");
//    $("#LendigCarsSelectDetail").prop("disabled", false)
//    LendingCarsDetailList = [];
//    LoadLendingCarsDetail(0, function () { });
//});
//$(document).on("click", "#btnLendingCarsEdit", function (e) {
//    $("#btnLendingCarsCancel").prop("disabled", false)
//    $("#btnLendingCarsConfirm").prop("disabled", false)
//    $("#btnLendingCarsReject").prop("disabled", false)
//    $("#btnLendingCarsEdit").prop("disabled", true)
//    $("#btnLendingCarsNew").prop("disabled", true)
//    $("#LendigCarsSelectDetail").prop("disabled", false)
//});
//$(document).on("click", "#btnLendingCarsReject", function (e) {
//});
//$(document).on("click", "#btnLendingCarsConfirm", function (e) {
//    $("#frmLendingCars").submit();
//});
//function ValidateLendingCars() {
//    var Flag = true;
//    $(".error").removeClass("error");
//    if ($("#F_AgnID").val() == 0) {
//        $("[data-id=F_AgnID]").parent().addClass("error");
//        Flag = false;
//    }
//    if ($("#DateA").val() == "") {
//        $("#DateA").addClass("error");
//        Flag = false;
//    }
//    if (LendingCarsDetailList.length == 0) {
//        ShowAlert("یک ردیف را انتخاب کنید", 2);
//    }
//    return Flag;
//}
//$(document).on("submit", "#frmLendingCars", function (e) {
//    e.preventDefault();
//    if (!ValidateLendingCars()) {
//        return;
//    }
//    $.post("/LendingCars/Create", $("#frmLendingCars").serializeObject(), function (result) {
//        console.log(result);
//        if (result.Status == 0) {
//            var idMaster = result.Parameters[0].Item2;
//            $("#code").val(result.Parameters[1].Item2)
//            $.post("/LendingCars/CreateDetail", { model: JSON.stringify(LendingCarsDetailList), IdMaster: idMaster }, function (e) {
//                ShowAlert(result.Message, 1);
//                LendingCarsDetailList = [];
//                $("#btnLendingCarsCancel").prop("disabled", true)
//                $("#btnLendingCarsConfirm").prop("disabled", true)
//                $("#btnLendingCarsReject").prop("disabled", true)
//                $("#btnLendingCarsEdit").prop("disabled", true)
//                $("#btnLendingCarsNew").prop("disabled", false)
//                $("#LendigCarsSelectDetail").prop("disabled", true)
//            });
//        }
//        else {
//            ShowAlert(result.Message, 2);
//        }
//    });
//});
//$(document).on("click", "#btnLendingCarsCancel", function (e) {
//    $("#btnLendingCarsCancel").prop("disabled", true)
//    $("#btnLendingCarsConfirm").prop("disabled", true)
//    $("#btnLendingCarsReject").prop("disabled", true)
//    $("#btnLendingCarsEdit").prop("disabled", true)
//    $("#btnLendingCarsNew").prop("disabled", false)
//    $("#LendigCarsSelectDetail").prop("disabled", true)
//});
//$(document).on("click", "#LendigCarsSelectDetail", function (e) {
//    //edit from db
//    if ($("#F_AgnID").val() = "0") {
//        ShowAlert("نمایندکی را انتخاب کنید", 2);
//    } else {
//        OpenWindow("/LendingCars/LendingCarsDetail", "انتخاب ردیف درخواست امانی", 800, 600, {});
//    }
//});
//$(document).on("change", "#IDrequstAmani", function (e) {
//    var Id = $(this).val();
//    $.get("/LendingCars/GetLendingCarsMasterById", { LEndingCarsId: Id }, function (data) {
//        $("#DateA").val(data.DateA);
//        //$("#F_AgnID = query.F_AgnID;
//        $("#F_AgnID").val(data.F_AgnID);
//        LoadComboBox("/Contract/GetAgent/" + data.F_AgnID, "F_AgnID", true);
//        $("#FlgTaahod").prop("checked", data.FlgTaahod);
//        //$("#TrackID = (int?)query.TrackID;
//        $("#code").val(data.code);
//        $("#btnLendingCarsCancel").prop("disabled", false)
//        $("#btnLendingCarsConfirm").prop("disabled", true)
//        $("#btnLendingCarsReject").prop("disabled", false)
//        $("#btnLendingCarsEdit").prop("disabled", false)
//        $("#btnLendingCarsNew").prop("disabled", false)
//        LoadLendingCarsDetail($("#IDrequstAmani").val(), function () { });
//        $.get("/LendingCars/GetLendingCarsDetail", { LEndingCarsId: Id }, function (e) { });
//    });
//});
//$(document).on("click", "#EditLendingDetail", function (e) {
//    var IDRequestAmani = $(this).attr("data-LendingCarsDetailId");
//    var RowNumber = $(this).attr("data-LendingCarsDetailRowNumber")
//    if (IDRequestAmani == 0) {
//        //newRecord
//        OpenWindow("/LendingCars/LendingCarsDetail?RowId=" + RowNumber, "انتخاب ردیف درخواست امانی", 800, 600, {});
//    }
//    else {
//        //edit
//        OpenWindow("/LendingCars/LendingCarsDetail?RowId=" + IDRequestAmani, "انتخاب ردیف درخواست امانی", 800, 600, {});
//    }
//});
//var LendigCarsDetailGriddt;
//function LoadLendingCarsDetail(IdRequestAmani, callbak) {
//    if (IdRequestAmani != 0) {
//        LendingCarsDetailList = [];
//    }
//    var address = "/LendingCars/GetLendingCarsDetailByRequestId?IdRequest=" + IdRequestAmani;
//    index = 0;
//    SelectedContractDetailRow = null;
//    var ex = document.getElementById('LendigCarsDetailGrid');
//    if (!$.fn.DataTable.fnIsDataTable(ex)) {
//        LendigCarsDetailGriddt = undefined;
//    }
//    if (LendigCarsDetailGriddt == undefined) {
//        LendigCarsDetailGriddt = $('#LendigCarsDetailGrid').DataTable({
//            "processing": true,
//            "jQueryUI": false,
//            "scrollCollapse": true,
//            "paging": false,
//            "bAutoWidth": false,
//            "bSort": false,
//            "responsive": (IsMobileDevice) ? true : false,
//            "ajax": address,
//            "columns": [
//                {
//                    "data": "radif",
//                    "title": "ردیف",
//                    "width": "150px"
//                },
//        {
//            "data": "CarName",
//            "title": "خودرو",
//            "width": "150px"
//        },
//         {
//             "data": "num",
//             "title": "تعداد",
//             "width": "150px"
//         },
//                        {
//                            "data": "Days",
//                            "title": "مدت",
//                            "width": "150px"
//                        },
//        {
//            "data": "typeDliv",
//            "title": "نوع تحویل گیرنده",
//            "width": "150px"
//        },
//          {
//              "data": "nameDliv",
//              "title": "تحویل گیرنده",
//              "width": "150px"
//          },
//          {
//              "data": "StatusDesc",
//              "title": "وضعیت",
//              "width": "150px"
//          },
//          {
//              "data": "pt_desc",
//              "title": " کاربری",
//              "width": "150px"
//          },
//            {
//                "data": "Command",
//                "title": "",
//                "width": "150px"
//            },
//            ],
//            "columnDefs": [
//             {
//                 "render": function (data, type, row) {
//                     //row.Mail_Subject
//                     str = "<span class='EditLendingDetail' data-LendingCarsDetailRowNumber='" + row.radif + "' data-LendingCarsDetailId='" + row.IDDetailReqAmani + "'>ویرایش</span>   <span class='DeleteLendingDetail' data-LendingCarsDetaiId='" + row.IDDetailReqAmani + "'>حذف</span> "
//                     return str;
//                 },
//                 "targets": 8,
//             }],
//            "createdRow": function (row, data, index) {
//                //if (data.isRead == false) {
//                //    $('td', row).addClass('highlight');
//                //}
//                //else {
//                //    $('td', row).addClass('readed');
//                //}
//                //LendingCarsDetailList.push({
//                //    IDDetailReqAmani: row.IDDetailReqAmani,
//                //    entekhab: row.entekhab,
//                //    radif: row.radif,
//                //    CarName: row.CarName,
//                //    pt_desc: row.pt_desc,
//                //    num: row.num,
//                //    num_ok: row.num_ok,
//                //    Days: row.Days,
//                //    typeDliv: row.typeDliv,
//                //    nameDliv: row.nameDliv,
//                //    StatusDesc: row.StatusDesc,
//                //    F_color: row.F_color,
//                //    F_IDCar: row.F_IDCar,
//                //    AcceptanceType: row.AcceptanceType,
//                //    status: row.status,
//                //    F_Deliver: row.F_Deliver,
//                //    DelivType: row.DelivType,
//                //    F_UsageType: row.F_UsageType,
//                //    F_IdCar: row.F_IdCar,
//                //    ShasiNO: row.ShasiNO
//                // });
//            }
//        });
//        var detailRows = [];
//        $('#LendigCarsDetailGrid tbody').on('click', 'tr', function () {
//            //Select Row
//            if ($(this).hasClass('selected')) {
//                $(this).removeClass('selected');
//            }
//            else {
//                LendigCarsDetailGriddt.$('tr.selected').removeClass('selected');
//                $(this).addClass('selected');
//                var row = LendigCarsDetailGriddt.row($(this));
//            }
//        });
//    }
//    else {
//        LendigCarsDetailGriddt.ajax.url(address).load(function () {
//            HideLoading();
//            callbak();
//        });
//    }
//}
//$(document).on("change", "#LendingCarsProductGroup", function () {
//    //public JsonResult GetTermOfSaleProductType(int GroupId)
//    var address = "/Contract/GetContractDetailProductType?GroupId=" + $("#LendingCarsProductGroup").val();
//    LoadComboBox(address, "F_IDCar", false)
//})
//$(document).on("change", "#F_IDCar", function () {
//    var address = "/Contract/GetContractDetailProductUsage?ProductType=" + $("#F_IDCar").val();
//    LoadComboBox(address, "F_UsageType", false)
//})
//var LendingCarsDetailList = [];
//$(document).on("click", "#btnLendingCarsDetailConfirm", function (e) {
//    $.post("/LendingCars/GenerateDetailListView", { DetailStr: JSON.stringify(LendingCarsDetailList) }, function (data) {
//        LendigCarsDetailGriddt.clear();
//        var i = 0;
//        for (i = 0; i < data.length; i++) {
//            if (LendigCarsDetailGriddt == undefined) {
//                //init grid
//                LoadLendingCarsDetail(0, function () { });
//            }
//            LendigCarsDetailGriddt.row.add(data[i]).draw();;
//        }
//        CloseWindow();
//    });
//});
//$(document).on("click", "input:radio[name=DelivType]", function () {
//    var val = $('input:radio[name=DelivType]:checked').val();
//    if (val == "4") {
//        $("#F_DeliverArea").css({ "visibility": "hidden" });
//        $("#F_DeliverText").css({ "visibility": "visible" });
//    }
//    else {
//        $("#F_DeliverArea").css({ "visibility": "visible" });
//        $("#F_DeliverText").css({ "visibility": "hidden" });
//    }
//});
//$(document).on("click", "#btnlendingcarsRemove", function () {
//    CloseWindow();
//});
//function CheckLendingCarsDetail() {
//    var Flag = true;
//    $(".error").removeClass("error");
//    if ($("#LendingCarsProductGroup").val() == 0) {
//        $("[data-id=LendingCarsProductGroup]").parent().addClass("error");
//        Flag = false;
//    }
//    if ($("#F_IDCar").val() == 0 || $("#F_IDCar").val() == null) {
//        $("[data-id=F_IDCar]").parent().addClass("error");
//        Flag = false;
//    }
//    if ($("#F_UsageType").val() == 0 || $("#F_IDCar").val() == null) {
//        $("[data-id=F_UsageType]").parent().addClass("error");
//        Flag = false;
//    }
//    if ($('input:radio[name=DelivType]:checked').val() == undefined) {
//        $('input:radio[name=DelivType]').parent().addClass("error");
//        Flag = false;
//    }
//    if ($('input:radio[name=DelivType]:checked').val() == 1) {
//        if ($("#F_Deliver").val() == 0) {
//            $('#F_Deliver_chosen').addClass("error");
//            Flag = false;
//        }
//    }
//    if ($('#Days').val() == "") {
//        $('#Days').addClass("error");
//        Flag = false;
//    }
//    if ($('#num').val() == "") {
//        $('#num').addClass("error");
//        Flag = false;
//    }
//    return Flag;
//}
//$(document).on("click", "#btnLendingCarsDetailAdd", function (e) {
//    if (CheckLendingCarsDetail()) {
//        var MaxRadif = 0;
//        var i = 0;
//        for (i = 0; i < LendingCarsDetailList.length; i++) {
//            MaxRadif = LendingCarsDetailList[i].radif;
//        }
//        MaxRadif = MaxRadif + 1;
//        var F_Deliver = $("#F_Deliver").val();
//        var DelivType = $('input:radio[name=DelivType]:checked').val();
//        LendingCarsDetailList.push({
//            IDDetailReqAmani: 0,
//            entekhab: 0,
//            radif: MaxRadif,
//            CarName: "",
//            pt_desc: "",
//            num: $("#num").val(),
//            num_ok: 0,
//            Days: $("#Days").val(),
//            typeDliv: DelivType,
//            nameDliv: "",
//            StatusDesc: "",
//            F_color: 0,
//            F_IDCar: $("#F_IDCar").val(),
//            AcceptanceType: 0,
//            status: 0,
//            F_Deliver: F_Deliver,
//            DelivType: DelivType,
//            F_UsageType: $("#F_UsageType").val(),
//            F_IdCar: $("#F_IDCar").val(),
//            ShasiNO: "",
//            IsDelete: false
//        });
//        ShowAlert("ردیف اضافه شد", 1);
//    }
//});
//$(document).on("change", "#TermOfSaleProductGroup", function () {
//    //public JsonResult GetTermOfSaleProductType(int GroupId)
//    var address = "/TermOfSales/GetTermOfSaleProductType?GroupId=" + $("#TermOfSaleProductGroup").val();
//    LoadComboBox(address, "TermOfSaleProductType", false)
//})
//$(document).on("change", "#TermOfSaleProductType", function () {
//    ///public JsonResult GetTermOfSaleSalesRow(int ProductType)
//    var address = "/TermOfSales/GetTermOfSaleSalesRow?ProductType=" + $("#TermOfSaleProductType").val();
//    LoadComboBox(address, "TermOfSaleSaleRecord", false)
//})
//$(document).on("change", "#TermOfSaleSaleRecord", function () {
//    LoadTermOfSaleGrid();
//})
//$(document).on("click", "#SearchTermOfSales", function (e) {
//    LoadTermOfSaleGrid();
//});
//$(document).on("click", "#ClearTermOfSales", function (e) {
//    if (ContractTemrOfSaledt != undefined) {
//        ContractTemrOfSaledt.clear();
//        ContractTemrOfSaledt.draw();
//        $("#TermOfSaleSaleRecord").val("0");
//        $("#TermOfSaleSaleRecord").selectpicker('refresh');
//        $("#TermOfSaleProductType").val("0");
//        $("#TermOfSaleProductType").selectpicker('refresh');
//        $("#TermOfSaleProductGroup").val("0");
//        $("#TermOfSaleProductGroup").selectpicker('refresh');
//    }
//});
$(document).on("click", "#btnLendingCarsNew", function (e) {
    $("#btnLendingCarsCancel").prop("disabled", false)
    $("#btnLendingCarsConfirm").prop("disabled", false)
    $("#btnLendingCarsReject").prop("disabled", true)
    $("#btnLendingCarsEdit").prop("disabled", true)
    $("#btnLendingCarsNew").prop("disabled", true)
    $("#btnLendingCarsOption").prop("disabled", true)
    $("#EbtalShow").css({ "display": "none" });
    ClearCombo("IDrequstAmani", true);
    $("#F_AgnID").val("0");
    $("#F_AgnID").trigger("refresh");
    $("#DateA").val("");
    $.get("/Home/GetDateNow", {}, function (data) {
        $("#DateA").val(data);
    })
    //$("#F_AgnID = query.F_AgnID;
    $("#FlgTaahod").prop("checked", false);
    //$("#TrackID = (int?)query.TrackID;
    $("#code").val("");
    $("#LendigCarsSelectDetail").prop("disabled", false)
    LendingCarsDetailList = [];
    LoadLendingCarsDetail(0, function () { });
});
$(document).on("click", "#btnLendingCarsEdit", function (e) {
    $("#btnLendingCarsCancel").prop("disabled", false)
    $("#btnLendingCarsConfirm").prop("disabled", false)
    $("#btnLendingCarsReject").prop("disabled", false)
    $("#btnLendingCarsEdit").prop("disabled", true)
    $("#btnLendingCarsNew").prop("disabled", true)
    $("#LendigCarsSelectDetail").prop("disabled", false)
    $("#btnLendingCarsOption").prop("disabled", false)
});
$(document).on("click", "#btnLendingCarsReject", function (e) {
    var Id = $("#IDrequstAmani").val();
    $("#LendingCarsDeleteDialog").css({ "display": "" });
    $("#LendingCarsDeleteDialog").dialog({
        resizable: false,
        height: 140,
        modal: true,
        buttons: {
            "انصراف": function () {
                $(this).dialog("close");
            },
            "ابطال": function () {
                $.post("/LendingCars/Delete", { id: Id }, function (result) {
                    if (result.Status == 0) {
                        ShowAlert(result.Message, 1);
                        $("#LendingCarsDeleteDialog").dialog("close");
                        $("#btnLendingCarsCancel").prop("disabled", false)
                        $("#btnLendingCarsConfirm").prop("disabled", false)
                        $("#btnLendingCarsReject").prop("disabled", true)
                        $("#btnLendingCarsEdit").prop("disabled", true)
                        $("#btnLendingCarsNew").prop("disabled", true)
                        $("#btnLendingCarsOption").prop("disabled", true)
                        ClearCombo("IDrequstAmani", true);
                        $("#F_AgnID").val("0");
                        $("#F_AgnID").trigger("refresh");
                        $("#DateA").val("");
                        $.get("/Home/GetDateNow", {}, function (data) {
                            $("#DateA").val(data);
                        })
                        //$("#F_AgnID = query.F_AgnID;
                        $("#FlgTaahod").prop("checked", false);
                        //$("#TrackID = (int?)query.TrackID;
                        $("#code").val("");
                        $("#LendigCarsSelectDetail").prop("disabled", false)
                        LendingCarsDetailList = [];
                        LoadLendingCarsDetail(0, function () { });
                    }
                    else {
                        ShowAlert(result.Message, 2);
                    }
                });
            }
        }
    });
});
$(document).on("click", "#btnLendingCarsConfirm", function (e) {
    $("#frmLendingCars").submit();
});
$(document).on("change", "#FlgTaahodCheck", function (e) {
    if ($("#FlgTaahodCheck").is(":checked")) {
        $("#FlgTaahod").val("true");
    }
    else {
        $("#FlgTaahod").val("false");
    }
});
function ValidateLendingCars() {
    var Flag = true;
    $(".error").removeClass("error");
    if ($("#F_AgnID").val() == 0) {
        $("#F_AgnID_chosen").addClass("error");
        Flag = false;
    }
    if ($("#DateA").val() == "") {
        $("#DateA").addClass("error");
        Flag = false;
    }
    if (LendingCarsDetailList.length == 0) {
        ShowAlert("یک ردیف را انتخاب کنید", 2);
        Flag = false;
    }
    if (Flag == false) {
        ShowAlert("موارد مشخص شده را وارد کنید", 2);
    }
    if ($("#FlgTaahodCheck").is(":checked") == false) {
        alert("لطفا تیک تعهد را بزنید");
        Flag = false;
    }
    return Flag;
}
$(document).on("submit", "#frmLendingCars", function (e) {
    e.preventDefault();
    if (!ValidateLendingCars()) {
        return;
    }
    $.post("/LendingCars/Create", $("#frmLendingCars").serializeObject(), function (result) {
        console.log(result);
        if (result.Status == 0) {
            var idMaster = result.Parameters[0].Item2;
            $("#code").val(result.Parameters[1].Item2)
            $.post("/LendingCars/CreateDetail", { model: JSON.stringify(LendingCarsDetailList), IdMaster: idMaster }, function (e) {
                ShowAlert(result.Message, 1);
                LendingCarsDetailList = [];
                $("#btnLendingCarsCancel").prop("disabled", false)
                $("#btnLendingCarsConfirm").prop("disabled", true)
                $("#btnLendingCarsReject").prop("disabled", false)
                $("#btnLendingCarsEdit").prop("disabled", false)
                $("#btnLendingCarsNew").prop("disabled", false)
                $("#LendigCarsSelectDetail").prop("disabled", true)
                $("#btnLendingCarsOption").prop("disabled", false)
            });
        }
        else {
            ShowAlert(result.Message, 2);
        }
    });
});
$(document).on("click", "#btnLendingCarsCancel", function (e) {
    $("#btnLendingCarsConfirm").prop("disabled", true)
    if ($("#IDrequstAmani").val() == "0" || $("#IDrequstAmani").val() == "") {
        $("#btnLendingCarsReject").prop("disabled", true)
        $("#btnLendingCarsEdit").prop("disabled", true)
        $("#btnLendingCarsNew").prop("disabled", false)
        $("#btnLendingCarsCancel").prop("disabled", true)
        $("#LendigCarsSelectDetail").prop("disabled", true)
    }
    else {
        $("#btnLendingCarsReject").prop("disabled", false)
        $("#btnLendingCarsEdit").prop("disabled", false)
        $("#btnLendingCarsNew").prop("disabled", false)
        $("#btnLendingCarsCancel").prop("disabled", true)
        $("#LendigCarsSelectDetail").prop("disabled", true)
    }
    $("#btnLendingCarsOption").prop("disabled", true)
});
$(document).on("click", "#LendigCarsSelectDetail", function (e) {
    //edit from db
    if ($("#F_AgnID").val() == "0") {
        ShowAlert("نمایندکی را انتخاب کنید", 2);
    } else {
        OpenWindow("/LendingCars/LendingCarsDetail", "انتخاب ردیف درخواست امانی", 800, 600, {});
    }
});
$(document).on("change", "#IDrequstAmani", function (e) {
    var Id = $(this).val();
    $.get("/LendingCars/GetLendingCarsMasterById", { LEndingCarsId: Id }, function (data) {
        $("#DateA").val(data.DateA);
        //$("#F_AgnID = query.F_AgnID;
        $("#F_AgnID").val(data.F_AgnID);
        LoadComboBox("/Contract/GetAgent/" + data.F_AgnID, "F_AgnID", true);
        $("#FlgTaahodCheck").prop("checked", data.FlgTaahod);
        $("#FlgTaahod").val(data.FlgTaahod);
        //$("#TrackID = (int?)query.TrackID;
        $("#code").val(data.code);
        $("#btnLendingCarsCancel").prop("disabled", false)
        $("#btnLendingCarsConfirm").prop("disabled", true)
        $("#btnLendingCarsReject").prop("disabled", false)
        $("#btnLendingCarsEdit").prop("disabled", false)
        $("#btnLendingCarsNew").prop("disabled", false)
        $("#btnLendingCarsOption").prop("disabled", false)
        LoadLendingCarsDetail($("#IDrequstAmani").val(), function () { });
        $("#EbtalShow").css({ "display": "none" });
        $.get("/LendingCars/GetLendingCarsDetail", { LEndingCarsId: Id }, function (e) { });
        $.get("/LendingCars/CheckEbtal", { IdRequestId: Id }, function (e) {
            if (e == "True") {
                $("#EbtalShow").css({ "display": "" });
                $("#btnLendingCarsCancel").prop("disabled", false)
                $("#btnLendingCarsConfirm").prop("disabled", true)
                $("#btnLendingCarsReject").prop("disabled", true)
                $("#btnLendingCarsEdit").prop("disabled", true)
                $("#btnLendingCarsNew").prop("disabled", false)
                $("#btnLendingCarsOption").prop("disabled", true)
                $("#LendigCarsSelectDetail").prop("disabled", true);
            }
        });
    });
});
$(document).on("click", ".EditLendingDetail", function (e) {
    if (!$("#btnLendingCarsEdit").prop("disabled")) {
        ShowAlert("دکمه ویرایش را اول بزنید", 2);
        return;
    }
    var IDRequestAmani = $(this).attr("data-LendingCarsDetailId");
    var RowNumber = $(this).attr("data-LendingCarsDetailRowNumber")
    if (IDRequestAmani == 0) {
        //newRecord
        OpenWindow("/LendingCars/LendingCarsDetail?RowId=" + RowNumber, "انتخاب ردیف درخواست امانی", 800, 600, {});
    }
    else {
        //edit
        OpenWindow("/LendingCars/LendingCarsDetail?IDRequestAmani=" + IDRequestAmani, "انتخاب ردیف درخواست امانی", 800, 600, {});
    }
});
var LendigCarsDetailGriddt;
var SelectedLendingCarsDetailRow;
function LoadLendingCarsDetail(IdRequestAmani, callbak) {
    if (IdRequestAmani != 0) {
        LendingCarsDetailList = [];
    }
    var address = "/LendingCars/GetLendingCarsDetailByRequestId?IdRequest=" + IdRequestAmani;
    $.get(address, {}, function (data) {
        console.log(data);
        var i = 0;
        for (i = 0; i < data.aaData.length; i++) {
            var row = data.aaData[i];
            LendingCarsDetailList.push({
                IDDetailReqAmani: row.IDDetailReqAmani,
                entekhab: row.entekhab,
                radif: row.radif,
                CarName: row.CarName,
                pt_desc: row.pt_desc,
                num: row.num,
                num_ok: row.num_ok,
                Days: row.Days,
                typeDliv: row.typeDliv,
                nameDliv: row.nameDliv,
                StatusDesc: row.StatusDesc,
                F_color: row.F_color,
                F_IDCar: row.F_IDCar,
                AcceptanceType: row.AcceptanceType,
                status: row.status,
                F_Deliver: row.F_Deliver,
                DelivType: row.DelivType,
                F_UsageType: row.F_UsageType,
                F_IdCar: row.F_IDCar,
                ShasiNO: row.ShasiNO
            });
        }
        index = 0;
        SelectedContractDetailRow = null;
        var ex = document.getElementById('LendigCarsDetailGrid');
        if (!$.fn.DataTable.fnIsDataTable(ex)) {
            LendigCarsDetailGriddt = undefined;
        }
        if (LendigCarsDetailGriddt == undefined) {
            LendigCarsDetailGriddt = $('#LendigCarsDetailGrid').DataTable({
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
                        "data": "radif",
                        "title": "ردیف درخواست",
                        "width": "150px"
                    },
            {
                "data": "CarName",
                "title": "خودرو",
                "width": "150px"
            },
             {
                 "data": "num",
                 "title": "تعداد",
                 "width": "150px"
             },
                            {
                                "data": "Days",
                                "title": "مدت",
                                "width": "150px"
                            },
            {
                "data": "typeDliv",
                "title": "نوع تحویل گیرنده",
                "width": "150px"
            },
              {
                  "data": "nameDliv",
                  "title": "تحویل گیرنده",
                  "width": "150px"
              },
              {
                  "data": "StatusDesc",
                  "title": "وضعیت",
                  "width": "150px"
              },
              {
                  "data": "pt_desc",
                  "title": " کاربری",
                  "width": "150px"
              },
                {
                    "data": "Command",
                    "title": "",
                    "width": "150px"
                },
                ],
                "columnDefs": [
                 {
                     "render": function (data, type, row) {
                         //row.Mail_Subject
                         str = "<span class='EditLendingDetail btn btn-warning' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' data-LendingCarsDetailRowNumber='" + row.radif + "' data-LendingCarsDetailId='" + row.IDDetailReqAmani + "'>ویرایش</span>   <span class='DeleteLendingDetail btn btn-danger' style='padding-left: 5px; padding-right: 5px; cursor: pointer;' data-LendingCarsDetailRowNumber='" + row.radif + "' data-LendingCarsDetaiId='" + row.IDDetailReqAmani + "'>حذف</span> "
                         return str;
                     },
                     "targets": 8,
                 }],
                "fnDrawCallback": function () {
                    $("#LendigCarsDetailGrid_info").css({ 'width': '99%' });
                    $("#LendigCarsDetailGrid_info").html("<div class='PageNumbersInfo'>" + $("#LendigCarsDetailGrid_info").html() + "</div>")
                    $("#LendigCarsDetailGrid_info").prepend("<input class='LendigCarsSelectDetail btn btn-large btn-info' id='LendigCarsSelectDetail' style='height:30px;padding: 5px 40px 0px;font-family: yekan;font-size:10px' type='button' value='اضافه ردیف'>");
                },
                "createdRow": function (row, data, index) {
                    //if (data.isRead == false) {
                    //    $('td', row).addClass('highlight');
                    //}
                    //else {
                    //    $('td', row).addClass('readed');
                    //}
                    //LendingCarsDetailList.push({
                    //    IDDetailReqAmani: row.IDDetailReqAmani,
                    //    entekhab: row.entekhab,
                    //    radif: row.radif,
                    //    CarName: row.CarName,
                    //    pt_desc: row.pt_desc,
                    //    num: row.num,
                    //    num_ok: row.num_ok,
                    //    Days: row.Days,
                    //    typeDliv: row.typeDliv,
                    //    nameDliv: row.nameDliv,
                    //    StatusDesc: row.StatusDesc,
                    //    F_color: row.F_color,
                    //    F_IDCar: row.F_IDCar,
                    //    AcceptanceType: row.AcceptanceType,
                    //    status: row.status,
                    //    F_Deliver: row.F_Deliver,
                    //    DelivType: row.DelivType,
                    //    F_UsageType: row.F_UsageType,
                    //    F_IdCar: row.F_IdCar,
                    //    ShasiNO: row.ShasiNO
                    // });
                }
            });
            var detailRows = [];
            $('#LendigCarsDetailGrid tbody').on('click', 'tr', function () {
                //Select Row
                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                }
                else {
                    LendigCarsDetailGriddt.$('tr.selected').removeClass('selected');
                    $(this).addClass('selected');
                    var row = LendigCarsDetailGriddt.row($(this));
                    SelectedLendingCarsDetailRow = row;
                }
            });
        }
        else {
            LendigCarsDetailGriddt.ajax.url(address).load(function () {
                HideLoading();
                callbak();
            });
        }
    });
}
$(document).on("click", "#ConfirmLendingCarsOption", function () {
    //public JsonResult GetTermOfSaleProductType(int GroupId)
    ShowAlert("آپشن درخواست ثبت شد", 2);
})
$(document).on("change", "#LendingCarsProductGroup", function () {
    //public JsonResult GetTermOfSaleProductType(int GroupId)
    var address = "/Contract/GetContractDetailProductType?GroupId=" + $("#LendingCarsProductGroup").val();
    LoadComboBox(address, "F_IDCar", false)
})
$(document).on("change", "#F_IDCar", function () {
    var address = "/Contract/GetContractDetailProductUsage?ProductType=" + $("#F_IDCar").val();
    LoadComboBox(address, "F_UsageType", false)
})
var LendingCarsDetailList = [];
$(document).on("click", "#btnLendingCarsDetailConfirm", function (e) {
    if (CheckLendingCarsDetail()) {
        var MaxRadif = 0;
        var i = 0;
        for (i = 0; i < LendingCarsDetailList.length; i++) {
            MaxRadif = LendingCarsDetailList[i].radif;
        }
        MaxRadif = MaxRadif + 1;
        var F_Deliver = $("#F_Deliver").val();
        var DelivType = $('input:radio[name=DelivType]:checked').val();
        LendingCarsDetailList.push({
            IDDetailReqAmani: 0,
            entekhab: 0,
            radif: MaxRadif,
            CarName: "",
            pt_desc: "",
            num: $("#num").val(),
            num_ok: 0,
            Days: $("#Days").val(),
            typeDliv: DelivType,
            nameDliv: "",
            StatusDesc: "",
            F_color: 0,
            F_IDCar: $("#F_IDCar").val(),
            AcceptanceType: 0,
            status: 0,
            F_Deliver: F_Deliver,
            DelivType: DelivType,
            F_UsageType: $("#F_UsageType").val(),
            F_IdCar: $("#F_IDCar").val(),
            ShasiNO: "",
            IsDelete: false
        });
        $.post("/LendingCars/GenerateDetailListView", { DetailStr: JSON.stringify(LendingCarsDetailList) }, function (data) {
            LendigCarsDetailGriddt.clear();
            var i = 0;
            for (i = 0; i < data.length; i++) {
                if (LendigCarsDetailGriddt == undefined) {
                    //init grid
                    LoadLendingCarsDetail(0, function () { });
                }
                LendigCarsDetailGriddt.row.add(data[i]).draw();;
            }
            CloseWindow();
        });
    }
    else {
        $.post("/LendingCars/GenerateDetailListView", { DetailStr: JSON.stringify(LendingCarsDetailList) }, function (data) {
            LendigCarsDetailGriddt.clear();
            var i = 0;
            for (i = 0; i < data.length; i++) {
                if (LendigCarsDetailGriddt == undefined) {
                    //init grid
                    LoadLendingCarsDetail(0, function () { });
                }
                LendigCarsDetailGriddt.row.add(data[i]).draw();;
            }
            CloseWindow();
        });
    }
    //$.post("/LendingCars/GenerateDetailListView", { DetailStr: JSON.stringify(LendingCarsDetailList) }, function (data) {
    //    LendigCarsDetailGriddt.clear();
    //    var i = 0;
    //    for (i = 0; i < data.length; i++) {
    //        if (LendigCarsDetailGriddt == undefined) {
    //            //init grid
    //            LoadLendingCarsDetail(0, function () { });
    //        }
    //        LendigCarsDetailGriddt.row.add(data[i]).draw();;
    //    }
    //    CloseWindow();
    //});
});
$(document).on("click", "input:radio[name=DelivType]", function () {
    var val = $('input:radio[name=DelivType]:checked').val();
    if (val == "4") {
        $("#F_DeliverArea").css({ "display": "none" });
        $("#F_DeliverAreaKargozari").css({ "display": "none" });
        $("#F_DeliverAreaBarbari").css({ "display": "none" });
        $("#F_DeliverTextArea").css({ "display": "" });
    }
    else if (val == "3") {
        //barbari
        $("#F_DeliverArea").css({ "display": "none" });
        $("#F_DeliverTextArea").css({ "display": "none" });
        $("#F_DeliverAreaKargozari").css({ "display": "none" });
        $("#F_DeliverAreaBarbari").css({ "display": "" });
    }
    else if (val == "2") {
        //kargozar 
        $("#F_DeliverArea").css({ "display": "none" });
        $("#F_DeliverTextArea").css({ "display": "none" });
        $("#F_DeliverAreaKargozari").css({ "display": "" });
        $("#F_DeliverAreaBarbari").css({ "display": "none" });
    }
    else {
        $("#F_DeliverArea").css({ "display": "" });
        $("#F_DeliverTextArea").css({ "display": "none" });
        $("#F_DeliverAreaKargozari").css({ "display": "none" });
        $("#F_DeliverAreaBarbari").css({ "display": "none" });
    }
});
$(document).on("click", "#btnlendingcarsRemove", function () {
    CloseWindow();
});
function CheckLendingCarsDetail() {
    var Flag = true;
    $(".error").removeClass("error");
    if ($("#LendingCarsProductGroup").val() == 0) {
        $("[data-id=LendingCarsProductGroup]").addClass("error");
        Flag = false;
    }
    if ($("#F_IDCar").val() == 0 || $("#F_IDCar").val() == null) {
        $("[data-id=F_IDCar]").addClass("error");
        Flag = false;
    }
    if ($("#F_UsageType").val() == 0 || $("#F_IDCar").val() == null) {
        $("[data-id=F_UsageType]").addClass("error");
        Flag = false;
    }
    if ($('input:radio[name=DelivType]:checked').val() == undefined) {
        $('input:radio[name=DelivType]').parent().addClass("error");
        Flag = false;
    }
    if ($('input:radio[name=DelivType]:checked').val() == 1) {
        if ($("#F_Deliver").val() == 0) {
            $('#F_Deliver_chosen').addClass("error");
            Flag = false;
        }
    } else if ($('input:radio[name=DelivType]:checked').val() != 4) {
        ShowAlert("محل تحویل را وارد کنید", 2);
        Flag = false;
    }
    if ($('#Days').val() == "") {
        $('#Days').addClass("error");
        Flag = false;
    }
    if ($('#num').val() == "") {
        $('#num').addClass("error");
        Flag = false;
    }
    if (Flag == false) {
        ShowAlert("موارد خواسته شده را وارد کنید", 2);
    }
    return Flag;
}
$(document).on("click", "#btnLendingCarsOption", function (e) {
    e.preventDefault();
    OpenWindow("/LendingCars/LendingCarsOption", "آپشن", 600, 400, {});
})
var SelectedAmani;
$(document).on("click", "#DeleteLendingDetailConfirm", function (e) {
    var i = 0;
    var index = 0;
    for (i = 0; i < LendingCarsDetailList.length; i++) {
        if (LendingCarsDetailList[i].radif == SelectedAmani) {
            LendingCarsDetailList[i].IsDelete = true;
            index = i;
        }
    }
    //  LendingCarsDetailList.splice(index, 1);
    HidePrompt();
    $.post("/LendingCars/GenerateDetailListView", { DetailStr: JSON.stringify(LendingCarsDetailList) }, function (data) {
        LendigCarsDetailGriddt.clear();
        var i = 0;
        for (i = 0; i < data.length; i++) {
            if (LendigCarsDetailGriddt == undefined) {
                //init grid
                LoadLendingCarsDetail(0, function () { });
            }
            LendigCarsDetailGriddt.row.add(data[i]).draw();;
        }
        CloseWindow();
    });
});
$(document).on("click", ".DeleteLendingDetail", function (e) {
    e.preventDefault();
    if (!$("#btnLendingCarsEdit").prop("disabled")) {
        ShowAlert("دکمه ویرایش را بزنید", 2)
        return;
    }
    SelectedAmani = $(this).attr("data-LendingCarsDetailRowNumber");
    var Content = "<div>مایل به حذف ردیف امانی هستید ؟</div><div><input type='button' class=' btn btn-large btn-block btn-primary' id='DeleteLendingDetailConfirm' style='width:100px !important;' value='تایید' /></div>";
    ShowPrompt(Content, "حذف ردیف قرارداد", 300, 120);
})
$(document).on("click", "#btnLendingCarsDetailEdit", function (e) {
    if (CheckLendingCarsDetail()) {
        var i = 0;
        var index = 0;
        for (i = 0; i < LendingCarsDetailList.length; i++) {
            if ($("#IDDetailReqAmani").val() != "0") {
                if (LendingCarsDetailList[i].IDDetailReqAmani == $("#IDDetailReqAmani").val()) {
                    index = i;
                }
            } else {
                if (LendingCarsDetailList[i].radif == $("#RowID").val()) {
                    index = i;
                }
            }
        }
        var F_Deliver = $("#F_Deliver").val();
        var DelivType = $('input:radio[name=DelivType]:checked').val();
        LendingCarsDetailList[index].num = $("#num").val();
        LendingCarsDetailList[index].Days = $("#Days").val();
        LendingCarsDetailList[index].typeDliv = DelivType;
        LendingCarsDetailList[index].F_IDCar = $("#F_IDCar").val();
        LendingCarsDetailList[index].F_Deliver = F_Deliver;
        LendingCarsDetailList[index].DelivType = DelivType;
        LendingCarsDetailList[index].F_UsageType = $("#F_UsageType").val();
        LendingCarsDetailList[index].F_IdCar = $("#F_IDCar").val();
        if ($("#btnLendingCarsDetailConfirm").css("display") == "none") {
            $("#btnLendingCarsDetailConfirm").trigger("click");
        }
        ShowAlert("ردیف ویرایش شد", 1);
    }
});
$(document).on("click", "#btnLendingCarsDetailAdd", function (e) {
    if (CheckLendingCarsDetail()) {
        var MaxRadif = 0;
        var i = 0;
        for (i = 0; i < LendingCarsDetailList.length; i++) {
            MaxRadif = LendingCarsDetailList[i].radif;
        }
        MaxRadif = MaxRadif + 1;
        var F_Deliver = $("#F_Deliver").val();
        var DelivType = $('input:radio[name=DelivType]:checked').val();
        LendingCarsDetailList.push({
            IDDetailReqAmani: 0,
            entekhab: 0,
            radif: MaxRadif,
            CarName: "",
            pt_desc: "",
            num: $("#num").val(),
            num_ok: 0,
            Days: $("#Days").val(),
            typeDliv: DelivType,
            nameDliv: "",
            StatusDesc: "",
            F_color: 0,
            F_IDCar: $("#F_IDCar").val(),
            AcceptanceType: 0,
            status: 0,
            F_Deliver: F_Deliver,
            DelivType: DelivType,
            F_UsageType: $("#F_UsageType").val(),
            F_IdCar: $("#F_IDCar").val(),
            ShasiNO: "",
            IsDelete: false
        });
        $.post("/LendingCars/GenerateDetailListView", { DetailStr: JSON.stringify(LendingCarsDetailList) }, function (data) {
            LendigCarsDetailGriddt.clear();
            var i = 0;
            for (i = 0; i < data.length; i++) {
                if (LendigCarsDetailGriddt == undefined) {
                    //init grid
                    LoadLendingCarsDetail(0, function () { });
                }
                LendigCarsDetailGriddt.row.add(data[i]).draw();;
            }
        });
        ClearCombo("LendingCarsProductGroup", false);
        ClearCombo("F_IDCar", false);
        ClearCombo("F_UsageType", false);
        ShowAlert("ردیف اضافه شد", 1);
    }
});
$(document).on("change", "#TermOfSaleProductGroup", function () {
    //public JsonResult GetTermOfSaleProductType(int GroupId)
    var address = "/TermOfSales/GetTermOfSaleProductType?GroupId=" + $("#TermOfSaleProductGroup").val();
    LoadComboBox(address, "TermOfSaleProductType", false)
})
$(document).on("change", "#TermOfSaleProductType", function () {
    ///public JsonResult GetTermOfSaleSalesRow(int ProductType)
    var address = "/TermOfSales/GetTermOfSaleSalesRowAll?ProductType=" + $("#TermOfSaleProductType").val();
    LoadComboBox(address, "TermOfSaleSaleRecord", false)
})
$(document).on("change", "#TermOfSaleSaleRecord", function () {
    LoadTermOfSaleGrid();
})
$(document).on("click", "#SearchTermOfSales", function (e) {
    LoadTermOfSaleGrid();
});
$(document).on("click", "#ClearTermOfSales", function (e) {
    if (ContractTemrOfSaledt != undefined) {
        ContractTemrOfSaledt.search('');
        ContractTemrOfSaledt.columns().search('');
        ContractTemrOfSaledt.clear();
        ContractTemrOfSaledt.draw();
        $("#TermOfSaleSaleRecord").val("0");
        $("#TermOfSaleSaleRecord").selectpicker('refresh');
        $("#TermOfSaleProductType").val("0");
        $("#TermOfSaleProductType").selectpicker('refresh');
        $("#TermOfSaleProductGroup").val("0");
        $("#TermOfSaleProductGroup").selectpicker('refresh');
        //$("#SaleQty").val("");
        $("#TermOfSaleDetail").html("");
    }
});
