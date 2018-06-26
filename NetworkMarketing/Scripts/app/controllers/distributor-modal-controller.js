app.controller('distributor-modal-controller', function ($scope, $http, $uibModalInstance, distributorsService, $uibModal) {
    $scope.modalState = $uibModalInstance.modalState;
    $scope.obj = $uibModalInstance.obj;
    $scope.refreshGrid = $uibModalInstance.refreshGrid;
    $scope.EnumInfoTypes = EnumInfoTypes;

    if ($scope.obj === null) {
        $scope.obj = {
            id: 0,
            personalInfos: [],
            contactInfos: [],
            addressInfos: [],
            birthDate: new Date()
        }
    } else {
        $scope.obj.genderId = $scope.obj.genderId.toString();
        $scope.obj.birthDate = new Date(moment($scope.obj.birthDate).format(dateFormat));
        if ($scope.obj.parentId !== null) {
            $scope.selectedDistributor = {
                id: $scope.obj.parentId,
                firstName: $scope.obj.parentFirstName,
                lastName: $scope.obj.parentLastName
            }
        }        
    }

    $scope.getPersonalInfos = function () {        
        if ($scope.obj.personalInfos === null) {
            distributorsService.getPersonalInfos($scope.obj.id).then(function (pi) {
                $scope.obj.personalInfos = pi.data;
                $scope.obj.personalInfos.map(function (pi) { pi.docIssueDate = moment(pi.docIssueDate).format(dateFormat); pi.docDeadline = moment(pi.docDeadline).format(dateFormat); });
            });
        }
    }

    $scope.getContactInfos = function () {
        if ($scope.obj.contactInfos === null) {
            distributorsService.getContactInfos($scope.obj.id).then(function (ci) {
                $scope.obj.contactInfos = ci.data;
            });
        }
    }

    $scope.getAddressInfos = function () {
        if ($scope.obj.addressInfos === null) {
            distributorsService.getAddressInfos($scope.obj.id).then(function (ai) {
                $scope.obj.addressInfos = ai.data;
            });
        }
    }

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };



    $scope.addPersonalInfo = function (index) {
        var obj = index === undefined ? null : angular.copy($scope.obj.personalInfos[index]);
        app.openModalGeneric(index, '/Scripts/app/templates/distributor-personal-info-modal-template.html', 'distributor-personal-info-modal-controller', 'lg', obj, null, $scope.obj.personalInfos);
    }

    $scope.addContactInfo = function (index) {
        var obj = index === undefined ? null : angular.copy($scope.obj.contactInfos[index]);
        app.openModalGeneric(index, '/Scripts/app/templates/distributor-contact-info-modal-template.html', 'distributor-contact-info-modal-controller', 'lg', obj, null, $scope.obj.contactInfos);
    }

    $scope.addAddressInfo = function (index) {
        var obj = index === undefined ? null : angular.copy($scope.obj.addressInfos[index]);
        app.openModalGeneric(index, '/Scripts/app/templates/distributor-address-info-modal-template.html', 'distributor-address-info-modal-controller', 'lg', obj, null, $scope.obj.addressInfos);
    }

    $scope.searchDistributors = function (value) {
        return distributorsService.searchDistributors(value).then(function (d) {
            if (d.data[0] !== null) {
                $scope.obj.parentId = d.data[0].id;
            }
            return d.data;
        });
    }



    $scope.popupBirthDate = {
        opened: false
    }

    $scope.openBirthDate = function () {
        $scope.popupBirthDate.opened = true;
    };

    $scope.dateOptions = {
        showWeeks: false
    }



    $scope.validateInfos = function () {
        return $scope.obj.personalInfos !== null && $scope.obj.personalInfos.length > 0
            && $scope.obj.contactInfos !== null && $scope.obj.contactInfos.length > 0
            && $scope.obj.addressInfos !== null && $scope.obj.addressInfos.length > 0;
    }


    $scope.save = function () {
        if ($scope.validateInfos()) {
            distributorsService.saveDistributor($scope.obj).then(function (r) {
                if (r.data.saveResult) {
                    $scope.refreshGrid();
                    $scope.cancel();
                } else {
                    if (r.data.errorText !== '')
                        alert(r.data.errorText);
                }
            });
        } else {
            alert('დაამატეთ დისტრიბუტორის პირადი, საკონტაქტო და საცხოვრებელი თითო ინფორმაცია მაინც.');
        }     
    };

    $scope.filterDeletedObjects = function (obj) {
        return !obj.deleted;
    }

    $scope.deleteInfo = function (index, type) {
        if (confirm('გინდათ წაშლა?')) {
            switch (type) {
                case EnumInfoTypes.Personal:
                    $scope.obj.personalInfos[index].deleted = true;
                    break;
                case EnumInfoTypes.Contact:
                    $scope.obj.contactInfos[index].deleted = true;
                    break;
                case EnumInfoTypes.Address:
                    $scope.obj.addressInfos[index].deleted = true;
                    break;
            }
        }
    }
});