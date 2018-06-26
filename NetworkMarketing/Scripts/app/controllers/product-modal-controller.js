app.controller('product-modal-controller', function ($scope, $http, $uibModalInstance, productsService) {
    $scope.modalState = $uibModalInstance.modalState;
    $scope.obj = $uibModalInstance.obj;
    $scope.refreshGrid = $uibModalInstance.refreshGrid;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.save = function () {
        productsService.save($scope.obj).then(function (resp) {
            if (resp.data) {
                $scope.refreshGrid();
                $scope.cancel();
            }
        });
    }
});