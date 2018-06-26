app.service('productFlowsService', function ($http) {
    this.getAllProducts = function () {
        return $http.get('/Products/GetAll').then(function (resp) {
            return resp;
        });
    }

    this.getAllProductFlows = function () {
        return $http.get('/ProductFlows/GetAll').then(function (resp) {
            return resp;
        });
    }

    this.delete = function (id) {
        return $http.get('/ProductFlows/Delete/' + id).then(function (resp) {
            return resp;
        });
    }

    this.save = function (obj) {
        return $http.post('/ProductFlows/Save', { productFlow: obj }).then(function (resp) {
            return resp;
        });
    }
});