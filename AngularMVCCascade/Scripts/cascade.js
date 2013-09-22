var app = angular.module('myModule', []);
app.controller('myController', function ($scope, $http) {

   GetCountries();  
    function GetCountries() {
        $http({
            method: 'Get',
            url: '/Home/GetCountries'
        }).success(function (data, status, headers, config) {
            $scope.countries = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    }

    $scope.GetStates = function () {
        var countryId = $scope.country;
        if (countryId) {
            $http({
                method: 'POST',
                url: '/Home/GetStates/',
                data: JSON.stringify({ countryId: countryId })
            }).success(function (data, status, headers, config) {
                $scope.states = data;
            }).error(function (data, status, headers, config) {
                $scope.message = 'Unexpected Error';
            });
        }
        else {
            $scope.states = null;
        }
    }
    //When you have entire dataset
    GetAll();
    function GetAll() {
        $http({
            method: 'Get',
            url: '/Home/GetAll'
        }).success(function (data, status, headers, config) {
            $scope.allItems = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    }

});