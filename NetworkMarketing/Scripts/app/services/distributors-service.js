app.service('distributorsService', function ($http) {
    this.getAllDistributors = function () {
        return $http.get('/Distributors/GetAll').then(function (resp) {
            return resp;
        });
    }

    this.searchDistributors = function (value) {
        return $http.get('/Distributors/Search?value=' + value).then(function (resp) {
            return resp;
        });
    }

    this.getPersonalInfos = function (id) {
        return $http.get('/Distributors/GetPersonalInfos/' + id).then(function (resp) {
            return resp;
        });
    }

    this.getContactInfos = function (id) {
        return $http.get('/Distributors/GetContactInfos/' + id).then(function (resp) {
            return resp;
        });
    }

    this.getAddressInfos = function (id) {
        return $http.get('/Distributors/GetAddressInfos/' + id).then(function (resp) {
            return resp;
        });
    }

    this.getInfoTypes = function (id) {
        return $http.get('/Distributors/GetInfoTypes/' + id).then(function (resp) {
            return resp;
        });
    }

    this.saveDistributor = function (distributor) {
        return $http.post('/Distributors/Save', { distributor: distributor }).then(function (resp) {
            return resp;
        });
    }

    this.delete = function (id) {
        return $http.get('/Distributors/Delete/' + id).then(function (resp) {
            return resp;                
        });
    }
});