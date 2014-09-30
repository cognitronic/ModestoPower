var app = angular.module('mp', ['ngRoute', 'service.page'])
    .config(function ($routeProvider, $httpProvider) {

        //This transformRequest is a global override for $http.post that transforms the body to the same param format used by  jQuery's $.post call
        $httpProvider.defaults.transformRequest = function (data) {
            if (data === undefined) {
                return data;
            }
            return $.param(data);
        }

        //sets the content type header globally for $http calls
        $httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded; charset=UTF-8';



        $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];

    })
    .constant('APP_SETTINGS', {
        apiUrl: 'http://www.teammodestopower.com/'
    });