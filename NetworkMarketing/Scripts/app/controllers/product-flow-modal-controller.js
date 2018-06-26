app.controller('product-flow-modal-controller', function ($scope, $http, $uibModalInstance, productFlowsService, distributorsService, productsService) {
    $scope.modalState = $uibModalInstance.modalState;
    $scope.obj = $uibModalInstance.obj;
    $scope.refreshGrid = $uibModalInstance.refreshGrid;

    if ($scope.obj === null) {
        $scope.obj = {
            operationDate: new Date()
        };
    } else {
        $scope.obj.operationDate = new Date(moment($scope.obj.operationDate).format(dateFormat));
        $scope.selectedDistributor = {
            id: $scope.obj.distributorId,
            firstName: $scope.obj.distributorFirstName,
            lastName: $scope.obj.distributorLastName
        };
        $scope.selectedProduct = {
            id: $scope.obj.distributorId,
            code: $scope.obj.productCode,
            name: $scope.obj.productName
        }
    }

    $scope.popupOperationDate = {
        opened: false
    }

    $scope.openOperationDate = function () {
        $scope.popupOperationDate.opened = true;
    };

    $scope.dateOptions = {
        showWeeks: false
    }

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.save = function () {
        productFlowsService.save($scope.obj).then(function (resp) {
            if (resp.data) {
                $scope.refreshGrid();
                $scope.cancel();
            }
        });
    }

    $scope.searchDistributors = function (value) {
        return distributorsService.searchDistributors(value).then(function (d) {
            if (d.data[0] !== null) {
                $scope.obj.distributorId = d.data[0].id;
            }
            return d.data;
        });
    }

    $scope.searchProducts = function (value) {
        return productsService.searchProducts(value).then(function (p) {      
            if (p.data[0] !== null) {
                $scope.obj.productId = p.data[0].id;
                $scope.obj.productUnitPrice = p.data[0].unitPrice;
                $scope.calculateAmount();
            }
            return p.data;
        });        
    }

    $scope.calculateAmount = function () {
        $scope.obj.amount = $scope.obj.productUnitPrice * $scope.obj.quantity;
    }
});