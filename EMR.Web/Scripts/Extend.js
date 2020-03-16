$.extend({
    ParseDate: function (obj) {
        var timeSpan = obj.replace('Date', '').replace('(', '').replace(')', '').replace(/\//g, '');
        return new Date(parseInt(timeSpan)).Format("yyyy-MM-dd");
    }
});