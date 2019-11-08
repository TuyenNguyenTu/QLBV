
//(function () {
//    "use strict"
//    var app = angular.module("app");
//    app.component("benhNhanList", {
//        templateUrl: "~/App/Main/views/benhnhan/index.cshtml",
//        controllerAs: "vm",
//        controller: ['app.services.app.benhNhan',Controller]
//    });
//    function Controller(benhNhanService) {
//        debugger
//        var vm = this;
//        vm.benhNhans = [];
//        function GetBenhNhan() {
//            benhNhanService.listAll()
//                .then(function (result) {
//                    vm.benhNhans = result.data;
//                });
//        }
//        GetBenhNhan();
//    }
//        console.log("Hello")
//})();
(function () {
    angular.module('app').controller('app.main.views.benhnhan.index', [
        '$scope',
        '$timeout',
        '$uibModal',
        'abp.services.app.benhNhan',
        function ($scope, $timeout, $uibModal, benhNhanService) {
            var vm = this;
            vm.click = function () {
                alert("Hello");
            }
            vm.benhNhans = [];

            function getBenhNhans() {
                benhNhanService.ListAll().then(function (result) {
                    vm.benhNhans = result.data.items;
                });
            }

            vm.openBenhNhanEditModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/benhNhan/createModal.cshtml',
                    controller: 'app.views.benhNhan.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getUsers();
                });
            };

            vm.openUserEditModal = function (user) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/users/editModal.cshtml',
                    controller: 'app.views.users.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return user.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $timeout(function () {
                        $.AdminBSB.input.activate();
                    }, 0);
                });

                modalInstance.result.then(function () {
                    getUsers();
                });
            };

            vm.delete = function (user) {
                abp.message.confirm(
                    "Delete user '" + user.userName + "'?",
                    function (result) {
                        if (result) {
                            userService.delete({ id: user.id })
                                .then(function () {
                                    abp.notify.info("Deleted user: " + user.userName);
                                    getUsers();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getBenhNhans();
            };

            getBenhNhans();
        }
    ]);
})();
//(function () {
//    var app = angular.module('app').controller('app.main.views.benhnhan.index', []);
//    app.controller('BenhNhans', function ($scope, $http) {
//        $http.get('ListAll').then(function (d) {
//            $scope.regdata = d.data;
//        }, function (erro) {
//            alert("ERROR")
//            });
//    })
//})();