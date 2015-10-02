angular.module('app')
    // Path: /
    .controller('menuCtrl', ['$scope', '$state', '$stateParams', 'authSvc', function ($scope, $state, $stateParams, authSvc) {
        $scope.authentication = authSvc.authentication;
        $scope.logout = authSvc.logout;

        $scope.isMe = function () {
            if (authentication.username !== "ANIVRA") {
                return false;
            }
            return true;
        }

    }])