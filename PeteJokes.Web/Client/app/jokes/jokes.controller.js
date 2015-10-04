(function() {
    'use strict';

    angular
        .module('PeteJokes')
        .controller('jokesController', jokesController);

    jokesController.$inject = ['jokesService'];

    function jokesController(jokesService) {
        var vm = this;
        vm.jokes = [];

        activate();

        function activate() {
            jokesService.getRecentJokes().then(function(response) {
                vm.jokes = response.data;
            });
        }
    }
})();