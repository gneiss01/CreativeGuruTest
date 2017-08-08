app.controller('productController', ['$router', '$scope', '$location', '$rootScope', '$http', '$window', productController]);

function productController($router, $scope, $location, $rootScope, $http, $window) {
    var self = $scope;

    self.products = [];

    self.init = function () {
        $http.get("/Product/List")
            .success(function (products) {
                self.products = products;
            })
            .error(function (error) {
            });
    }

    self.init();
}