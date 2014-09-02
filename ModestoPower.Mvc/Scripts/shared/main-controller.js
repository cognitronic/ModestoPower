app.controller('MainController', function ($scope, PageService) {
    $scope.bgimage_0 = {
        background: 'url(/images/bg/img_0851.jpg)'
    };
    $scope.loadHomePage = function () {
        PageService.getPage('Home').then(function (data) {
            console.log(data);
            
            if (data.bannerimages.length > 0) {
                for (var i = 0, l = data.bannerimages.length; i < l; i++) {
                    $scope['bgimage_' + i] = data.bannerimages[i];
                }
            }
        });
    }
    console.log(bowser);
});