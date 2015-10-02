
var app = angular.module('app', ['ui.router', 'LocalStorageModule']);

app.config(function ($stateProvider, $urlRouterProvider) {
    //
    // For any unmatched url, redirect to /state1
    $urlRouterProvider.otherwise("/");
    //
    // Now set up the states
    $stateProvider
      .state('login', {
          url: "/login",
          templateUrl: "/app/templates/login.html",
          controller: "loginCtrl as login"
      })
      .state('home', {
          url: "/home",
          templateUrl: "/app/templates/home.html",
          controller: "homeCtrl as home"
      })
      .state('register', {
          url: "/register",
          templateUrl: "/app/templates/register.html",
          controller: "registerCtrl as register"
      })
      .state('default', {
          url: "/",
          templateUrl: "",
      });
});

var serviceBase = 'http://localhost:54761/';

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorSvc');
});

app.run(['authSvc', function (authService) {
    authService.fillAuthData();
}]);

