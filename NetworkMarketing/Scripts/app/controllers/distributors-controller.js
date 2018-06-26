app.controller('distributors-controller', function ($scope, $http, distributorsService) {
    $scope.loadDistributors = function () {
        distributorsService.getAllDistributors().then(function (d) {
            $scope.distributors = d.data;
            $scope.distributors.map(function (d) { d.birthDate = moment(d.birthDate).format(dateFormat) });
        });
    }
    $scope.loadDistributors();

    $scope.openModal = function (index) {
        var obj = index === undefined ? null : angular.copy($scope.distributors[index]);
        app.openModalGeneric(index, '/Scripts/app/templates/distributor-modal-template.html', 'distributor-modal-controller', 'lg', obj, $scope.loadDistributors);
    }

    $scope.deleteDistributor = function (id) {
        if (confirm('გინდათ წაშლა?')) {
            distributorsService.delete(id).then(function (resp) {
                if (resp.data)
                    $scope.loadDistributors();
            });
        }
    }
});