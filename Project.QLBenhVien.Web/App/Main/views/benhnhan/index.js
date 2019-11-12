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
            //        templateUrl: '/App/Main/views/benhnhan/createOrEditModalBenhNhan.cshtml',
            //        controller: 'Main.views.benhnhan.createOrEditModalBenhNhan as vm',
            //        backdrop: 'static'
            //    });
            //    modalInstance.result.then(function () {
            //        getDSBenhNhans();
            //    });
            //    modalInstance.result.then(function () {
            //        getDSBenhNhans();
            //    });
            //}

            vm.openBenhNhanCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/benhnhan/createOrEditModalBenhNhan.cshtml',
                    controller: 'app.main.views.benhnhan.createOrEditModalBenhNhan as vm',
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
                    templateUrl: '/App/Main/views/benhnhan/createOrEditModalBenhNhan.cshtml', // path đến file cshtml
                    controller: 'app.main.views.benhNhan.createOrEditModalBenhNhan as vm', //path đến file js
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            console.log(benhNhan.id);
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
                abp.message.confirm(
                    "Xóa bệnh nhân '" + benhNhan.ho +" "+ benhNhan.ten + "'?",
                    function (result) {
                        if (result) {
                            benhNhanService.delete({ id: benhNhan.id })
                                .then(function () {
                                    abp.notify.info("Đã xóa thông tin bệnh nhân : " + benhNhan.ho +" " + benhNhan.ten);
                                    getDSBenhNhans();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getDSBenhNhans();
            };

            getDSBenhNhans();
        }
    ]);
})();
