(function (global) {
    var application,
        api = "http://chuckfacts.azurewebsites.net/"; /* "http://localhost:52787/"; */

    global.app = {};

    var randomJoke = function(explicit) {
        var dfrd = $.Deferred();

        $.get(api + "joke/" + (explicit ? "explicit" : "clean"), function(data) {
            dfrd.resolve(data.JokeText);
        });

        return dfrd;
    };

    global.app.cleanModel = (function () {

        var viewModel = kendo.observable({
            joke: ""
        });

        var refresh = function () {
            randomJoke(false).then(function (joke) {
                viewModel.set("joke", joke);
            });
        };

        return {
            viewModel: viewModel,
            refresh: refresh
        };

    }());

    global.app.dashboardModel = (function () {

        var init = function() {
            $("#categoriesPie").kendoChart({
                theme: "flat",
                dataSource: {
                    transport: {
                        read: api + "dashboard/categories"
                    }
                },
                legend: {
                    visible: false
                },
                chartArea: {
                    background: ""
                },
                seriesDefaults: {
                    labels: {
                        visible: true,
                        background: "transparent",
                        template: "#= category #: #= value #%"
                    }
                },
                series: [{
                    type: "pie",
                    field: "Jokes",
                    categoryField: "Description",
                    startAngle: 150,
                }]
            });
        };

        return {
            init: init
        };

    }());

    document.addEventListener("deviceready", function () {
        application = new kendo.mobile.Application(document.body, { transition: "slide", skin: "flat" });
    }, false);

})(window);