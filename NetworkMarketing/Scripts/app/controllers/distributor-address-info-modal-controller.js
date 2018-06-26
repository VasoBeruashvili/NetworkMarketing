app.controller('distributor-address-info-modal-controller', function ($scope, $http, $uibModalInstance, distributorsService, $uibModal) {
    $scope.modalState = $uibModalInstance.modalState;
    $scope.obj = $uibModalInstance.obj;
    $scope.objs = $uibModalInstance.objs;

    if ($scope.obj !== null)
        $scope.obj.typeId = $scope.obj.typeId.toString();

    distributorsService.getInfoTypes(EnumInfoTypes.Address).then(function (it) {
        $scope.infoTypes = it.data;
    });

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    function getTypeName() {
        return $scope.infoTypes.first(function (it) { return it.id === parseInt($scope.obj.typeId); }).name;
    }

    $scope.save = function () {
        if ($scope.obj.id === undefined) {
            $scope.objs.push({
                id: 0,
                typeId: $scope.obj.typeId,
                typeName: getTypeName(),
                address: $scope.obj.address
            });
        } else {
            var mainObj = $scope.objs.first(function (ai) { return ai.id === $scope.obj.id; });
            mainObj.typeId = $scope.obj.typeId;
            mainObj.typeName = getTypeName();
            mainObj.address = $scope.obj.address;
        }
        $scope.cancel();
    }
});