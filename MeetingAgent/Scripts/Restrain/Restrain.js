

$(function () {
    $('#all_day').change(function () {
        var isChecked = $(this).is(':checked');
         $('#Hours').toggle(!isChecked);
        
    
    });
});

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

function checkDay(st) {
   
    var a;
    if (st) {
        a = "PO";
    } else {
        a = "JO";
    }

    return a

}