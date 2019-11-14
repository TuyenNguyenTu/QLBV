(function () {
    angular.module('app').controller('app.main.views.benhnhan.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.benhNhan',
        function ($scope, $timeout, $uibModal, benhNhanService) {
            var vm = this;

            vm.click = function () {
                alert("Hello");
            };

            vm.DSbenhNhans = []; // khai báo

            vm.showSubmit = true;
            vm.showEdit = false;
            vm.benhNhan = {
                ho:'',
                ten:'',
                cmnd:'',
                gioiTinh:'',
                diaChi:'',
                soDienThoai:''
            };
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
                $('#exampleModal').modal('show');
                vm.showSubmit = true;
                vm.showEdit = false;
                vm.benhNhan.ho = '';
                vm.benhNhan.ten = '';
                vm.benhNhan.cmnd = '';
                vm.benhNhan.gioiTinh = '';
                vm.benhNhan.diaChi = '';
                vm.benhNhan.soDienThoai = '';
            };



            //vm.openBenhNhanEditModal = function (benhNhan) {
            //    var modalInstance = $uibModal.open({
            //        templateUrl: '/App/Main/views/benhnhan/createOrEditModalBenhNhan.cshtml', // path đến file cshtml
            //        controller: 'app.main.views.benhNhan.createOrEditModalBenhNhan as vm', //path đến file js
            //        backdrop: 'static',
            //        resolve: {
            //            id: function () {
            //                //console.log(benhNhan.id);
            //                return benhNhan.id;
            //            }
            //        }
            //    });
            //    modalInstance.rendered.then(function () {
            //        $timeout(function () {
            //            $.AdminBSB.input.activate();
            //        }, 0);
            //    });

            //    modalInstance.result.then(function () {
            //        getDSBenhNhans();
            //    });
            //};
            vm.openBenhNhanEditModal = function (benhNhan) {
                $('#exampleModal').modal('show');
                vm.showSubmit = false;
                vm.showEdit = true;
                vm.benhNhan.ho = benhNhan.ho;
                vm.benhNhan.ten = benhNhan.ten;
                vm.benhNhan.cmnd = benhNhan.cmnd;
                vm.benhNhan.gioiTinh = benhNhan.gioiTinh;
                vm.benhNhan.diaChi = benhNhan.diaChi;
                vm.benhNhan.soDienThoai = benhNhan.soDienThoai;
                vm.entity = benhNhan;
            }
            // save data
            vm.save = function () {
                abp.ui.setBusy();
                benhNhanService.create(vm.benhNhan)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        abp.ui.clearBusy();
                        getDSBenhNhans();
                    });
            }
            //update data
            vm.edit = function (data) {
                var x = {};
                x = vm.entity;
                x.ho = data.benhNhan.ho;
                x.ten = data.benhNhan.ten;
                x.cmnd = data.benhNhan.cmnd;
                x.gioiTinh = data.benhNhan.gioiTinh;
                x.diaChi = data.benhNhan.diaChi;
                x.soDienThoai = data.benhNhan.soDienThoai;
                debugger
                abp.ui.setBusy();
                benhNhanService.update(x)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        abp.ui.clearBusy();
                        getDSBenhNhans();
                    });
            }

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
