(function() {
    'use strict';

    angular
        .module('PeteJokes')
        .config(configureRoutes);

    configureRoutes.$inject = ['$stateProvider'];

    function configureRoutes($stateProvider) {
        $stateProvider.state('recent', {
            url: '/',
            templateUrl: 'Client/app/jokes/recent.html',
            controller: 'jokesController as vm',
        });
    }
})();