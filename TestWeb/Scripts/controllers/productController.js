app.controller('productController', ['$router', '$scope', '$location', '$rootScope', '$http', '$window', productController]);

app.filter('searchFor', function () {
    function nameContains(product, text) {
        return !text || product.DisplayName.toLowerCase().indexOf(text.toLowerCase()) !== -1;
    }

    function withSameCategory(product, category) {
        return !category || product.Category.Id === category.Id;
    }

    return function (products, filter) {
        if (!filter || (!filter.Product && !filter.Category))
            return products

        var result = [];
        angular.forEach(products, function (product) {
            if (nameContains(product, filter.Product) && withSameCategory(product, filter.Category))
                result.push(product);
        });

        return result;
    };
});

function productController($router, $scope, $location, $rootScope, $http, $window) {
    var self = $scope;

    self.productFilter =
    {
        Product: '',
        Category: null
    };

    self.products = [];
    self.categories = [];

    self.init = function () {
        self.initializeProducts();
        self.initializeCategories();
    }

    self.initializeProducts = function () {
        $http.get("/Product/List")
            .success(function (products) {
                self.products = products;
            })
            .error(function (error) {
            });
    }

    self.initializeCategories = function () {
        $http.get("/Product/Categories")
            .success(function (categories) {
                self.categories = categories;
            })
            .error(function (error) {
            });
    }

    self.init();
}