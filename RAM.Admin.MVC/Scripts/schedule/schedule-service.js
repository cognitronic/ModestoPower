
'use strict';
angular.module('service.schedule', [])
.factory('ScheduleService', function ($http, $rootScope, $q, $location, APP_SETTINGS) {
    console.log('inside service');

    return {
        getClasses: function () {
            console.log('getClasses called');
            var deferred = $q.defer();
            $rootScope.loading = true;
            $http.get(APP_SETTINGS.apiUrl + 'Schedule/ScheduleList')
            .success(function (data) {
                $rootScope.loading = false;
                deferred.resolve(data);
            })
            .error(function () {
                $rootScope.loading = false;
                deferred.reject();
            });
            return deferred.promise;
        },
        deleteClass: function (classId) {
            var deferred = $q.defer();
            $rootScope.loading = true;
            $http.post(APP_SETTINGS.apiUrl + '/Schedule/DeleteClass', classId)
                .success(function (data) {
                    $rootScope.loading = false;
                    deferred.resolve(data);
                })
                .error(function () {
                    $rootScope.loading = false;
                    deferred.reject();
                });
            return deferred.promise;
        },
        saveSchedule: function (schedule) {
            var deferred = $q.defer();
            $rootScope.loading = true;
            $http.post(APP_SETTINGS.apiUrl + '/Schedule/SaveClass', schedule)
                .success(function (data) {
                    $rootScope.loading = false;
                    console.log('success ' + data);
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