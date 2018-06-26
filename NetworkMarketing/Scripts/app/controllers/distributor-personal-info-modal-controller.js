app.controller('distributor-personal-info-modal-controller', function ($scope, $http, $uibModalInstance, distributorsService, $uibModal) {
    $scope.modalState = $uibModalInstance.modalState;
    $scope.obj = $uibModalInstance.obj;
    $scope.objs = $uibModalInstance.objs;

    if ($scope.obj === null) {
        $scope.obj = {
            docIssueDate: new Date(),
            docDeadline: new Date()
        };
    } else {
        $scope.obj.docIssueDate = new Date(moment($scope.obj.docIssueDate).format(dateFormat));
        $scope.obj.docDeadline = new Date(moment($scope.obj.docDeadline).format(dateFormat));
        $scope.obj.docTypeId = $scope.obj.docTypeId.toString();
    }

    distributorsService.getInfoTypes(EnumInfoTypes.Personal).then(function (it) {
        $scope.infoTypes = it.data;
    });

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.popupDate = {
        openedIssueDate: false,
        openedDeadline: false
    }

    $scope.openIssueDate = function () {
        $scope.popupDate.openedIssueDate = true;
    };
    $scope.openDeadline = function () {
        $scope.popupDate.openedDeadline = true;
    };

    $scope.dateOptions = {
        showWeeks: false
    }

    function getTypeName() {
        return $scope.infoTypes.first(function (it) { return it.id === parseInt($scope.obj.docTypeId); }).name;
    }

    $scope.save = function () {
        if ($scope.obj.id === undefined) {
            $scope.objs.push({
                id: 0,
                docTypeId: $scope.obj.docTypeId,
                docTypeName: getTypeName(),
                docSeries: $scope.obj.docSeries,
                docNumber: $scope.obj.docNumber,
                docIssueDate: moment($scope.obj.docIssueDate).format(dateFormat),
                docDeadline: moment($scope.obj.docDeadline).format(dateFormat),
                personalNumber: $scope.obj.personalNumber,
                issuingAgency: $scope.obj.issuingAgency
            });
        } else {
            var mainObj = $scope.objs.first(function (pi) { return pi.id === $scope.obj.id; });
            mainObj.docTypeId = $scope.obj.docTypeId;
            mainObj.docTypeName = getTypeName();
            mainObj.comment = $scope.obj.comment;
            mainObj.docSeries = $scope.obj.docSeries;
            mainObj.docNumber = $scope.obj.docNumber;
            mainObj.docIssueDate = moment($scope.obj.docIssueDate).format(dateFormat);
            mainObj.docDeadline = moment($scope.obj.docDeadline).format(dateFormat);
            mainObj.personalNumber = $scope.obj.personalNumber;
            mainObj.issuingAgency = $scope.obj.issuingAgency;
        }
        $scope.cancel();
    }
});