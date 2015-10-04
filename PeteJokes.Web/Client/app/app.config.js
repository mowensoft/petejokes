(function () {
    'use strict';

    angular
        .module('PeteJokes')
        .config(configureMaterial);

    configureMaterial.$inject = ['$mdThemingProvider', '$mdIconProvider'];

    function configureMaterial($mdThemingProvider, $mdIconProvider) {
        $mdThemingProvider.theme('default')
            .primaryPalette('indigo')
            .accentPalette('pink');

        $mdIconProvider.fontSet('fa', 'fontawesome');
    }
})();