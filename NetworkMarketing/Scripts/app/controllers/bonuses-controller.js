app.controller('bonuses-controller', function ($scope, $http, bonusesService) {
    $scope.fromDate = new Date();
    $scope.toDate = new Date();

    $scope.popupDate = {
        openedFrom: false,
        openedTo: false
    }

    $scope.openFromDate = function () {
        $scope.popupDate.openedFrom = true;
    };
    $scope.openToDate = function () {
        $scope.popupDate.openedTo = true;
    };

    $scope.dateOptions = {
        showWeeks: false
    }

    $scope.loadBonuses = function () {
        bonusesService.getAllBonuses(moment($scope.fromDate).format(dateFormat), moment($scope.toDate).format(dateFormat)).then(function (b) {
            $scope.bonuses = b.data;
            $scope.bonuses.map(function (b) { b.calculationDate = moment(b.calculationDate).format(dateFormat) });
        });
    }
    $scope.loadBonuses();

    $scope.calculate = function () {        
        bonusesService.calculateBonuses(moment($scope.fromDate).format(dateFormat), moment($scope.toDate).format(dateFormat)).then(function (c) {
            if (c.data)
                $scope.loadBonuses();
            else
                alert('ბონუსები უკვე გადათვლილია და არცერთი ახალი გაყიდვა არცერთ დისტრიბუტორზე არ დაფიქსირდა.');
        });
    }
});