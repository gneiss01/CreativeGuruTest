﻿app.controller('productController', ['$router', '$scope', '$location', '$rootScope', '$http', '$window', productController]);

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

    self.productFilter = {
        Product: '',
        Category: null
    };

    self.products = [];
    self.categories = [];
    self.getCategory = function (id) {
        var result = $.grep(self.categories, function (category) {
            return category.Id === id;
        });

        if (result.length > 0)
            return result[0];
    }

    self.productForm = {};
    self.newProductTitle = 'Create New Product';
    self.defaultNewProduct = {
        DisplayName: '',
        Category: { Id: "" },
        UnitPrice: 0,
        IsActive: true
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
        self.productForm.isNew = true;
        self.productForm.title = self.newProductTitle;
        self.setFormProduct(self.defaultNewProduct);

        self.showForm();
    }

    self.setFormProduct = function (product) {
        self.productForm.product =
        {
            DisplayName: product.DisplayName,
            CategoryId: product.Category.Id,
            UnitPrice: product.UnitPrice,
            IsActive: product.IsActive
        };
    }

    self.editProduct = function (product) {
        self.productForm.isNew = false
        self.productForm.title = 'Update Product';
        self.setFormProduct(product);

        self.showForm();
    }

    self.deleteProduct = function (product) {
    }

    self.showForm = function () {
        $("#modalForm").modal('show');
    }

    self.saveProduct = function () {
        var url = '/Product/Update';
        if (self.productForm.isNew === true)
            url = '/Product/Create';

        $http.post(url, self.productForm.product)
            .success(function (product) {
                if (self.productForm.isNew === true) {
                    product.Category = self.getCategory(product.CategoryId);
                    self.products.push(product);

                    self.setFormProduct(self.defaultNewProduct);
                }
                else {
                    self.initializeProducts();
                    self.closeForm();
                }
            })
            .error(function (error) {
            });
    }

    self.closeForm = function () {
        $("#modalForm").modal('hide');
    }

    self.init();
}