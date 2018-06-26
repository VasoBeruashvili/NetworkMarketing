app.controller('product-flows-controller', function ($scope, $http, productFlowsService) {
    $scope.loadProductFlows = function () {
        productFlowsService.getAllProductFlows().then(function (pf) {
            $scope.productFlows = pf.data;
            $scope.productFlows.map(function (pf) { pf.operationDate = moment(pf.operationDate).format(dateFormat) });
        });
    }
    $scope.loadProductFlows();

    $scope.openModal = function (index) {
        var obj = index === undefined ? null : angular.copy($scope.productFlows[index]);
        app.openModalGeneric(index, '/Scripts/app/templates/product-flow-modal-template.html', 'product-flow-modal-controller', 'lg', obj, $scope.loadProductFlows);
    }

    $scope.deleteProductFlow = function (id) {
        if (confirm('გინდათ წაშლა?')) {
            productFlowsService.delete(id).then(function (resp) {
                if (resp.data)
                    $scope.loadProductFlows();
            });
        }
    }
});