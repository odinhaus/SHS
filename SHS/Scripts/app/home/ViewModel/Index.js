define(function (require) {
    var   ko = require("knockout")
        , kom = require('komapping')
        , $ = require("jquery")
    ;

    function Industry(name, value) {
        var self = this;
        self.name = name;
        self.value = value;
    }

    function Index(indexModel) {
        var self = this;

        this.id = ko.observable();
        this.industry = ko.observable();
        this.userFeedback = ko.observable();
        this.feature = ko.observable();
        this.improve = ko.observable();
        this.rating = ko.observable();

        this.ratingText = ko.computed({
            read: function () {
                return this.rating;
            },
            write: function (value) {
                this.rating(parseInt(value));
            },
            owner: this
        });

        kom.fromJS(indexModel, {}, self);

        this.industries = ko.observableArray([
                new Industry("Healthcare", 1),
                new Industry("Information Technology", 2),
                new Industry("Finances", 3),
                new Industry("Academic", 4),
                new Industry("Other", 5)
        ]);

        this.submit = function () {
            var model = kom.toJS(self);
            $.post('/Home/Submit', model, function (results) {
                // success
                if (results.ResponseType == 0) {
                    window.location = results.RedirectUri;
                }
            }, 'json');
        }
    }

    return Index;
});