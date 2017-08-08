var app = angular.module('app', [
	'ngNewRouter'
]);

app.config(componentLoaderConfig);

function componentLoaderConfig($locationProvider) {
    //$locationProvider.html5Mode(true);
}
