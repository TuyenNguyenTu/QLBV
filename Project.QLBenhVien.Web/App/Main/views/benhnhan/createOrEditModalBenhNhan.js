(function () {
    angular.module('app').controller('app.main.views.benhNhan.createOrEditModalBenhNhan', [
        '$scope', '$uibModalInstance', 'abp.services.app.benhNhan', 'id',
        function ($scope, $uibModalInstance, benhNhanService, id) {
            var vm = this;

            vm.benhNhan = {
                //ho: '',
                //ten: '',
                //cmnd: '',
                //gioiTinh: '',
                //diaChi: '',
                //soDienThoai: '',
                //ngaySinh: ''
            };
            var init = function () {
                vm.saving = false;
            }
            init();
            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
            alert(id);

            vm.save = function () {
                vm.saving = true;
                vm.Create.id = id;
                if (vm.Create.id == null) {
                    benhNhanService.create(vm.benhNhan).then(function () {
                        abp.notify.info(App.localize("Lưu Thành Công"));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
                } else {
                    benhNhanService.update(vm.benhNhan).then(function () {
                        abp.notify.info(App.localize("Sửa thành công"));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    })
                }
            };
            vm.edit = function () {
                vm.saving = true;
                vm.Create.id = id;

                benhNhanService.update(vm.benhNhan).then(function () {
                    abp.notify.info(App.localize("Sửa thành công"));
                    $uibModalInstance.close();
                }).finally(function () {
                    vm.saving = false;
                })

            };

        }
    ]);
})();