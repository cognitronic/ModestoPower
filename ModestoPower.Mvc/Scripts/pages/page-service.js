
'use strict';
angular.module('service.page', [])
.factory('PageService', function ($http, $rootScope, $q, $location, APP_SETTINGS) {
    
    
    return {
        getPage: function (title) {
            console.log(APP_SETTINGS.apiUrl);
            var deferred = $q.defer();
            $rootScope.loading = true;
            $http.get(APP_SETTINGS.apiUrl + 'Home/GetPage', title)
            .success(function (data) {
                $rootScope.loading = false;
                deferred.resolve(data);
            })
            .error(function () {
                $rootScope.loading = false;
                deferred.reject();
            });
            return deferred.promise;
        }
    }
});