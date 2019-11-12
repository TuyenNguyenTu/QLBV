(function () {
    angular.module('app').controller('app.main.views.benhnhan.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.benhNhan',
        function ($scope, $timeout, $uibModal, benhNhanService) {
            var vm = this;

            vm.click = function () {
                alert("Hello");
            };

            vm.DSbenhNhans = []; // khai báo

            function getDSBenhNhans() {
                benhNhanService.listAll({}).then(function (result) {
                    vm.DSbenhNhans = result.data;
                    console.log(result);
                });
            };


            //vm.openModalCreateOrEditBenhNhan = function () {
            //    var modalInstance = $uibModal.open({
            //        templateUrl: '~/App/Main/views/benhnhan/createOrEditBenhNhan.cshtml',
            //        controller: 'Main.views.benhnhan.createOrEditBenhNhan as vm',
            //        backdrop: 'static'
            //    });
            //    modalInstance.result.then(function () {
            //        getDSBenhNhans();
            //    })
            //}

            vm.openBenhNhanCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/Main/views/benhnhan/createModal.cshtml',
                    controller: 'app.main.views.benhnhan.createModal as vm',
                    backdrop: 'static'
                });
                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });
                modalInstance.result.then(function () {
                    getDSBenhNhans();
                });
            };



            vm.openBenhNhanEditModal = function (benhNhan) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/benhNhan/EditModal.cshtml', // path đến file cshtml
                    controller: 'app.main.views.benhNhan.EditModal as vm', //path đến file js
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return benhNhan.id;
                        }
                    }
                });
                modalInstance.rendered.then(function () {
                    $timeout(function () {
                        $.AdminBSB.input.activate();
                    }, 0);
                });

                modalInstance.result.then(function () {
                    getDSBenhNhans();
                });
            };


            vm.delete = function (benhNhan) {
                alert("DELETE BENH NHAN")
                //abp.message.confirm(
                //    "Delete user '" + benhNhan.userName + "'?",
                //    function (result) {
                //        if (result) {
                //            benhNhanService.delete({ id: benhNhan.id })
                //                .then(function () {
                //                    abp.notify.info("Deleted user: " + benhNhan.userName);
                //                    getDSBenhNhans();
                //                });
                //        }
                //    });
            }

            vm.refresh = function () {
                getDSBenhNhans();
            };

            getDSBenhNhans();
        }
    ]);
})();
