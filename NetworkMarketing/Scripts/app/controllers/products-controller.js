app.controller('products-controller', function ($scope, $http, productsService) {
    $scope.loadProducts = function () {
        productsService.getAllProducts().then(function (p) {
            $scope.products = p.data;
        });
    }
    $scope.loadProducts();

    $scope.openModal = function (index) {
        var obj = index === undefined ? null : angular.copy($scope.products[index]);
        app.openModalGeneric(index, '/Scripts/app/templates/product-modal-template.html', 'product-modal-controller', 'lg', obj, $scope.loadProducts);
    }

    $scope.deleteProduct = function (id) {
        if (confirm('გინდათ წაშლა?')) {
            productsService.delete(id).then(function (resp) {
                if (resp.data)
                    $scope.loadProducts();
            });
        }
    }
});