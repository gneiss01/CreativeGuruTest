app.controller('productController', ['$router', '$scope', '$location', '$rootScope', '$http', '$window', productController]);

app.filter('searchFor', function () {
    return function (products, searchText) {

        if (!searchText) {
            return products;
        }

        var result = [];

        searchText = searchText.toLowerCase();
        angular.forEach(products, function (product) {

            if (product.DisplayName.toLowerCase().indexOf(searchText) !== -1) {
                result.push(product);
            }

        });

        return result;
    };
});

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