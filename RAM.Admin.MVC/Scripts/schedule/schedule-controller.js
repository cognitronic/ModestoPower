app.controller('ScheduleController', function ($scope, ScheduleService, Paginator) {
    $scope.pagination = Paginator.getNew(10);
    $scope.criteria_name = "";
    $scope.criteria_day = "";
    $scope.criteria_times = "";
    $scope.editing = null;

    $scope.editItem = function (item) {
        console.log(item);
        $scope.editing = item;
    }
    $scope.loadClasses = function () {
        ScheduleService.getClasses().then(function (data) {
            console.log(data);
            $scope.classes = data.Classes;
            $scope.pagination.numPages = Math.ceil($scope.classes.length / $scope.pagination.perPage);

        });
    }
    $scope.loadClasses();

    $scope.deleteClass = function (classId) {
        var deleteClass = confirm('Are you sure you want to delete class, this cannot be undone?');
        if (deleteClass) {
            ScheduleService.deleteClass(classId).then(function (data) {
                $scope.loadClasses();
            });
        }
    }
    
    $scope.saveClass = function () {
        console.log($scope.editing);
        ScheduleService.saveSchedule($scope.editing).then(function (data) {
            $scope.loadClasses();
            $scope.editing = null;
        });
    }
});