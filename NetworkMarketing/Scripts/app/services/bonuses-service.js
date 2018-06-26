app.service('bonusesService', function ($http) {
    this.getAllBonuses = function (fromDate, toDate) {
        return $http.post('/Bonuses/GetAll', { fromDate: fromDate, toDate: toDate }).then(function (resp) {
            return resp;
        });
    }

    this.calculateBonuses = function (fromDate, toDate) {
        return $http.post('/Bonuses/Calculate', { fromDate: fromDate, toDate: toDate }).then(function (resp) {
            return resp;
        });
    }
});