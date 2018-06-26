var app = angular.module('main-app', ['ui.bootstrap']);

app.controller('main-controller', function ($scope, $http, $uibModal) {

    app.openModalGeneric = function (index, templateUrl, controller, size, obj, refreshGrid, objs) {
        var modalInstance = $uibModal.open({
            animation: true,
            size: size,
            templateUrl: templateUrl,            
            controller: controller,
            backdrop: 'static'
        });
        modalInstance.modalState = getModalState(index);
        modalInstance.obj = obj;
        modalInstance.refreshGrid = function () {
            refreshGrid();
        }
        modalInstance.objs = objs;
    }

});