﻿(function () {
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

            // model
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
                vm.benhNhan.ngaySinh
            };



           
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
                vm.benhNhan.ngaySinh = benhNhan.ngaySinh;
                vm.entity = benhNhan;
            }
            // save data
            vm.save = function () {
                abp.ui.setBusy();
                benhNhanService.create(vm.benhNhan)
                    .then(function () {
                        abp.notify.info(App.localize('Saved Successfully'));
                        $('#exampleModal').modal('hide');
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
                x.ngaySinh = data.benhNhan.ngaySinh;
                debugger
                abp.ui.setBusy();
                benhNhanService.update(x)
                    .then(function () {
                        abp.notify.info(App.localize('Saved Successfully'));
                        $('#exampleModal').modal('hide');
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
