define(function (require) {
    var ko = require('knockout')
        , kom = require('komapping')
        , Index = require('./ViewModel/Index')
    ;

    (function () {
        var vm = new Index({
            id: 0,
            rating: 5,
            feature: '',
            improve: '',
            industry: 1,
            userFeedback: ''
        });
        window.vm = vm;
        ko.applyBindings(vm);
    })();
});