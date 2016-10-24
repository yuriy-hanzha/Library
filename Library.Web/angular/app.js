var app = angular.module("app", ["ngRoute"]);

app.config(function ($routeProvider, $locationProvider) {

    $routeProvider.when("/library", {
        controller: "homeController",
        templateUrl: "/views/home.html"
    });

    $routeProvider.otherwise({ redirectTo: "/library" });
});

app.constant('settings', {
    serviceBase: 'http://localhost:50548/'
});