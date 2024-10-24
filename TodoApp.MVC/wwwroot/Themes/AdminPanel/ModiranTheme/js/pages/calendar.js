// Initialize persian datepicker
$(".has-persian-datepicker").pDatepicker({
    persianDigit: false,
    format: "YYYY/MM/DD",
    observer: true,
    autoClose: true
});

$(".has-persian-datepicker-long").pDatepicker({
    format: "dddd, DD MMMM YYYY",
    autoClose: true,
});

$(".has-persian-datepicker-unix").pDatepicker({
    persianDigit: false,
    format: "dddd, DD MMMM YYYY",
    autoClose: true,
    altField: '#alt-field'
});

$(".has-persian-datepicker-year-mode").pDatepicker({
    persianDigit: false,
    format: "YYYY/MM/DD",
    observer: true,
    autoClose: true,
    viewMode: "year",
    initialValue: false,
});

$(".has-time-picker").pDatepicker({
    onlyTimePicker: true,
    observer: true,
    format: "HH:mm:ss",
});



$(".datepicker-without-default-date").pDatepicker({
    persianDigit: false,
    format: "YYYY/MM/DD",
    observer: true,
    autoClose: true,
    initialValue: false,
});


// Initialize from-to type
var to, from;
to = $(".persian-datepicker-to").pDatepicker({
    persianDigit: false,
    format: "YYYY/MM/DD",
    observer: true,
    initialValue: false,
    autoClose: true,
    onSelect: function (unix) {
        to.touched = true;
        if (from && from.options && from.options.maxDate != unix) {
            var cachedValue = from.getState().selected.unixDate;
            from.options = {maxDate: unix};
            if (from.touched) {
                from.setDate(cachedValue);
            }
        }
    }
});
from = $(".persian-datepicker-from").pDatepicker({
    format: "YYYY/MM/DD",
    observer: true,
    initialValue: false,
    autoClose: true,
    onSelect: function (unix) {
        console.log("now");
        from.touched = true;
        if (to && to.options && to.options.minDate != unix) {
            var cachedValue = to.getState().selected.unixDate;
            to.options = {minDate: unix};
            if (to.touched) {
                to.setDate(cachedValue);
            }
        }
    }
});