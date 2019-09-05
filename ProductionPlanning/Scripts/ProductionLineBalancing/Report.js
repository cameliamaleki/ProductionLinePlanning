$(document).on("click","#btnPrintAccessibilityByDay",function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintAccessibilityByMonth", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityRoutMonthly?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintAccessibilityByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityRoutByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintaccessibilityWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintaccessibilityWorkstationMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityWorkStationMonthly?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#accessibilityWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintaccessibilityFacilityDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityFacilityDaily?FacilityID=" + $("#FacilityID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintaccessibilityFacilityMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityFacilityMonthly?FacilityID=" + $("#FacilityID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintaccessibilityFacilityByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityFacilityByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintaccessibilityWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityWorkerDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintaccessibilityWorkerMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityWorkerMonthly?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintaccessibilityWorkerByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAccessibilityWorkerByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintefficiencyByDay", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintefficiencyByMonth", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyRoutMonthly?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintefficiencyByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyRoutByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintefficiencyWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintefficiencyWorkstationMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyWorkStationMonthly?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#efficiencyWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintefficiencyWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyWorkerDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintefficiencyResponsibleDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyResponsibleDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintefficiencyWorkerMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyWorkerMonthly?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintefficiencyWorkerByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyWorkerByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintqualityByDay", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerQualityRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintqualityByMonth", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerQualityRoutMonthly?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintqualityByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerQualityRoutByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintqualityWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerQualityWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintqualityWorkstationMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerQualityWorkStationMonthly?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#qualityWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerQualityWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintqualityWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerQualityWorkerDaily?WorkerID="+ $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintqualityWorkerMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerQualityWorkerMonthly?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintqualityWorkerByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerQualityWorkerByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintproductioncountByDay", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerProductionCountRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintproductioncountByMonth", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerProductionCountRoutMonthly?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintproductioncountByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerProductionCountRoutByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintproductioncountWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerProductionCountWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintproductioncountWorkstationMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerProductionCountWorkStationMonthly?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#productioncountWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerProductionCountWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintproductioncountWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerProductionCountWorkerDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintproductioncountWorkerMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerProductionCountWorkerMonthly?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#productioncountWorkerByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerProductionCountWorkerByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintOEEcountByDay", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECountRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEEcountByMonth", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECountRoutMonthly?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEEcountByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECountRoutByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEEcountWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECountWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEEcountWorkstationMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECountWorkStationMonthly?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#OEEcountWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECountWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEEWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEEWorkerDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEEWorkerMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEEWorkerMonthly?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEEWorkerByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEEWorkerByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintPPMReport", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerPPMReport?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintSendToWareHouseReport", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerSendToWareHouseReport?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintSendToWareHouseReportByWorkstation", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerSendToWareHouseReportByWorkstation?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintPPMParetoReport", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerPPMParetoReport?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintFaultDescParetoByDay", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerFaultDescParetoRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintFaultDescParetoWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerFaultDescParetoWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintFaultDescParetoWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerFaultDescParetoWorkerDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintFaultListWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerFaultListWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintFaultDescParetoByDay", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerFaultDescParetoRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintFaultDescParetoWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerFaultDescParetoWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintFaultDescParetoWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerFaultDescParetoWorkerDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintStopListReport", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopListReport?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintUnitStopPercent", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerUnitStopPercent?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintCumulativeStopDurationByDay", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerCumulativeStopDurationRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintCumulativeStopDurationByMonth", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerCumulativeStopDurationRoutMonthly?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintCumulativeStopDurationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerCumulativeStopDurationRoutByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintCumulativeStopDurationWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerCumulativeStopDurationWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintCumulativeStopDurationWorkstationMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerCumulativeStopDurationWorkStationMonthly?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#CumulativeStopDurationWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerCumulativeStopDurationWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintCumulativeStopDurationWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerCumulativeStopDurationWorkerDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintCumulativeStopDurationWorkerMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerCumulativeStopDurationWorkerMonthly?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintCumulativeStopDurationWorkerByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerCumulativeStopDurationWorkerByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintSplitPartReport", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerSplitPartReport?RoutID=" + $("#RoutID").val()
        +"&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintSplitPartParetoReport", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerSplitPartParetoReport?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintReworkPartReport", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerReworkPartReport?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintReworkPartParetoReport", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerReworkPartParetoReport?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintZayeaatPartReport", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerZayeaatPartReport?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintWastageCostByDay", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerWastageCostRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintWastageCostWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerWastageCostWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintWastageCostWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerWastageCostWorkerDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintMTTR", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerMTTR?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintMTTRWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerMTTRWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintMTTRWorkstationMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerMTTRWorkStationMonthly?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintMTTRWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerMTTRWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintMTBFWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerMTBFWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintMTBFWorkstationMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerMTBFWorkStationMonthly?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintMTBFWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerMTBFWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintStopMatchinWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopMatchinWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});


$(document).on("click", "#btnPrintOEECompletecountByDay", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECompleteCountRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEECompletecountByMonth", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECompleteCountRoutMonthly?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEECompletecountByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECompleteCountRoutByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEECompletecountWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECompleteCountWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEECompletecountWorkstationMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECompleteCountWorkStationMonthly?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#OEECompletecountWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECompleteCountWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEECompleteWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECompleteWorkerDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEECompleteWorkerMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECompleteWorkerMonthly?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintOEECompleteWorkerByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerOEECompleteWorkerByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});



$(document).on("click", "#btnPrintStopReasoncountByDay", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopReasonCountRoutDaily?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintStopReasoncountByMonth", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopReasonCountRoutMonthly?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintStopReasoncountByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopReasonCountRoutByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintStopReasoncountWorkstationDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopReasonCountWorkStationDaily?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintStopReasoncountWorkstationMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopReasonCountWorkStationMonthly?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnZayeatPareto", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerZayeatPareto?WorkStationID=" + $("#WorkStationID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#StopReasoncountWorkstationByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopReasonCountWorkStationByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintStopReasonWorkerDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopReasonWorkerDaily?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintStopReasonWorkerMonthly", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopReasonWorkerMonthly?WorkerID=" + $("#WorkersID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnPrintStopReasonWorkerByYear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerStopReasonWorkerByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnPrintQuantityFacilityDaily", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerQuantityFacilityDaily?FacilityID=" + $("#FacilityID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnnonebalancingrout", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerNoneBalancingRout?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnnonebalancingroutbymonth", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerNoneBalancingRoutByMonth?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnnonebalancingroutbyyear", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerNoneBalancingRoutByYear?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
}); 
$(document).on("click", "#btndurationtimeandreworkbyworker", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerDurationTimeAndReworkByWorker?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnTolidReport", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerTolid?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
$(document).on("click", "#btnTolidReportPersonel", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerTolidPersonel?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnEfficiencyRoutByWorker", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerEfficiencyRoutByWorker?RoutID=" + $("#RoutID").val()
        + "&FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});

$(document).on("click", "#btnAllFactor", function (e) {
    window.open("/ProductionLineBalancingArea/ReportInfo/ViewerAllFactor?FDate=" + $("#FDate").val()
        + "&TDate=" + $("#TDate").val(), "a", "height=600,width=800,modal=yes,alwaysRaised=yes,menubar=no");
});
