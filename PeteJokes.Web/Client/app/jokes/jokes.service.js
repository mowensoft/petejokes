(function() {
    'use strict';

    angular
        .module('PeteJokes')
        .service('jokesService', jokesService);

    jokesService.$inject = ['$http'];

    function jokesService($http) {
        var service = {
            getRecentJokes: getRecentJokes
        };

        return service;

        function getRecentJokes() {
            return $http.get('api/Jokes/Recent');
        }
    }
})();