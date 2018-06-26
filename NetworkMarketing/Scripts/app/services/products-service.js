app.service('productsService', function ($http) {
    this.getAllProducts = function () {
        return $http.get('/Products/GetAll').then(function (resp) {
            return resp;
        });
    }

    this.searchProducts = function (value) {
        return $http.get('/Products/Search?value=' + value).then(function (resp) {
            return resp;
        });
    }

    this.delete = function (id) {
        return $http.get('/Products/Delete/' + id).then(function (resp) {
            return resp;
        });
    }

    this.save = function (obj) {
        return $http.post('/Products/Save', { product: obj }).then(function (resp) {
            return resp;
        });
    }
});