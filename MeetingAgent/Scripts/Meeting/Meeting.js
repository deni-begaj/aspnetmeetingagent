
$("#submitCreateMeeting").click(function () {
    var grid = $("#UserViewList").data("kendoGrid");
    var data = grid.dataSource.data();
    var totalNumber = data.length;
    for (var i = 0; i < totalNumber; i++) {
        var currentDataItem = data[i];
        if (currentDataItem.IsChecked != false) {
            return true;
        }
    }
    $("#alertNotSelected").show();
    return false;
});

function dateformat(dt) {
    if (dt == null || dt == "") {
        return "e papërcaktuar"
    }
    else {
        var date = new Date(dt)
        var a = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
        return a
    }
}

function checkStatus(st) {
    debugger;
        var a ;
        if (st) {
            a = "Aktiv";
        } else
        {
            a = "Jo Aktiv";
        }

        return a
    
}

function checkStatusRel(st) {
    debugger;
    var a;
    if (st == 1) {
        a = "Ne Pritje te aprovimit (Pezull)";
    } else if (st == 2) {
        a = "I Aprovuar";
    }
    else {
        a="I Refuzuar"
    }

    return a

}

function timeformat(dt) {
  
    if (dt == null || dt == "") {
        return "e papërcaktuar"
    }
    else {
        var hour = dt.Hours;
        if (hour < 10) {
            hour = "0" + hour;
        }
        var min = dt.Minutes;
        
        return hour + ":" + min + ":00"
    }
}
    


$("#choosePersons").click(function () {
  
    var date = $("#MeetingDate").val();
    var sHour = $("#starting_hour").val();
    var eHour = $("#ending_hour").val();

    if ((date != "") && (sHour != "") && (eHour != "")) {
        var gridTransactions = $("#UserViewList").data("kendoGrid");
        gridTransactions.dataSource.read();
        $("#DivUser").show();
    }
    return false;
});

function debtorClientParameters() {
   
    var date = $("#MeetingDate").val();
    var sHour = $("#starting_hour").val();
    var eHour = $("#ending_hour").val();

    return {
        date: date,
        startHour: sHour,
        endHour: eHour
    };
}
$(document).ready(function () {
    $("DivUser").hide();
});

function CheckIfEmpty(e) {
    if (e.sender._data.length == 0) {
        //addValidationMessage("Nuk ka asnje person te lire ne kete orar!");
    }
}

function startChange() {
    var startTime = this.value(),
        endPicker = $("#ending_hour").data("kendoTimePicker");

    if (startTime) {
        startTime = new Date(startTime);

        endPicker.max(startTime);

        startTime.setMinutes(startTime.getMinutes() + this.options.interval);

        endPicker.min(startTime);
        endPicker.value(startTime);
    }
}



function indexAccess(dataItem) {
    var data = $("#UserViewList").data("kendoGrid").dataSource.data();
    return data.indexOf(dataItem);
}

function indexAccessForApproval(dataItem) {
    var data = $("#MeetingListForApproval").data("kendoGrid").dataSource.data();
    return data.indexOf(dataItem);
}


function markTransactionDetailAsChecked(e) {
    var grid = $("#UserViewList").data("kendoGrid");
    var data = grid.dataSource.data();
    var totalNumber = data.length;
    var dataItem = grid.dataItem($(e).closest("tr"));
    if (dataItem.IsChecked) // elementi i cekuar
    { // uncheck
        dataItem.IsChecked = false;
    }
    else { //check
        dataItem.IsChecked = true;
    }
    grid.refresh();
}


function markMeetingAsApproved(e) {
    var grid = $("#MeetingListForApproval").data("kendoGrid");
    var data = grid.dataSource.data();
    var totalNumber = data.length;
    var dataItem = grid.dataItem($(e).closest("tr"));
    if (dataItem.IsApproved) // elementi i cekuar
    { // uncheck
        dataItem.IsApproved = false;
    }
    else { //check
        dataItem.IsApproved = true;
        dataItem.IsRejected = false;
    }
    grid.refresh();
}


function markMeetingAsRejected(e) {
    var grid = $("#MeetingListForApproval").data("kendoGrid");
    var data = grid.dataSource.data();
    var totalNumber = data.length;
    var dataItem = grid.dataItem($(e).closest("tr"));
    if (dataItem.IsRejected) // elementi i cekuar
    { // uncheck
        dataItem.IsRejected = false;
    }
    else { //check
        dataItem.IsRejected = true;
        dataItem.IsApproved = false;
    }
    grid.refresh();
}
