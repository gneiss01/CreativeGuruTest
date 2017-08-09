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

    self.productForm = {};
    self.newProductTitle = 'Create New Product';
    self.defaultNewProduct = {
        displayName: '',
        category: {},
        unitPrice: 0,
        isActive: true
    };

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

    self.showCreateForm = function () {
        self.productForm.mode = 'New';
        self.productForm.title = self.newProductTitle;
        self.productForm.product =
        {
            displayName: self.defaultNewProduct.displayName,
            category: self.defaultNewProduct.category,
            unitPrice: self.defaultNewProduct.unitPrice,
            isActive: self.defaultNewProduct.isActive
        };

        $("#productForm").modal('show');
    }

    self.closeForm = function () {
        $("#productForm").modal('hide');
    }

    self.editProduct = function (product) {
    }

    self.deleteProduct = function (product) {
    }

    self.init();
}