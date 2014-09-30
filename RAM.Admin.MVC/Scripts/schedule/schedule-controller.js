app.controller('ScheduleController', function ($scope, ScheduleService, Paginator) {
    $scope.pagination = Paginator.getNew(10);
    $scope.criteria_name = "";
    $scope.criteria_day = "";
    $scope.criteria_times = "";
    $scope.editing = {};
    $scope.hstep = 1;
    $scope.mstep = 15;
    $scope.editing.starttime = new Date("09/30/2014 07:00");
    $scope.editing.endtime = new Date("09/30/2014 07:00");
    $scope.options = {
        hstep: [1, 2, 3],
        mstep: [1, 5, 10, 15, 25, 30]
    };

    $scope.ismeridian = true;
    $scope.toggleMode = function () {
        $scope.ismeridian = !$scope.ismeridian;
    };

    $scope.update = function () {
        var d = new Date();
        d.setHours(14);
        d.setMinutes(0);
        $scope.mytime = d;
    };

    $scope.changed = function () {
        console.log('Time changed to: ' + $scope.mytime);
    };

    $scope.clear = function () {
        $scope.mytime = null;
    };

    $scope.editItem = function (item) {
        $scope.editing = item;
        $scope.editing.starttime = item.starttime;
        $scope.editing.endtime = item.endtime;
    }
    $scope.loadClasses = function () {
        ScheduleService.getClasses().then(function (data) {
            console.log(data);
            $scope.classes = data.Classes;
            $scope.pagination.numPages = Math.ceil($scope.classes.length / $scope.pagination.perPage);

        });
    }
    $scope.loadClasses();
    function dateToWcf(input) {
        var d = new Date(input);
        if (isNaN(d)) return null;
        return '\/Date(' + d.getTime() + '-0000)\/';
    }
    $scope.deleteClass = function (classId) {
        var deleteClass = confirm('Are you sure you want to delete class, this cannot be undone?');
        if (deleteClass) {
            ScheduleService.deleteClass(classId).then(function (data) {
                $scope.loadClasses();
            });
        }
    }
    
    $scope.saveClass = function () {
        $scope.editing.starttime = $scope.editing.starttime.toISOString();
        $scope.editing.endtime = $scope.editing.endtime.toISOString();
        console.log($scope.editing.starttime);
        ScheduleService.saveSchedule($scope.editing).then(function (data) {
            $scope.loadClasses();
            $scope.editing = null;
        });
    }
});