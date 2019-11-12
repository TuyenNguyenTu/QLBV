(function () {
    angular.module('app').controller('app.main.views.benhNhan.createOrEditModalBenhNhan', [
        '$scope', '$uibModalInstance', 'abp.services.app.benhNhan','id',
        function ($scope, $uibModalInstance, benhNhanService, id) {
            var vm = this;

            //vm.benhNhan = {
            //    ho: '',
            //    ten: '',
            //    cmnd: '',
            //    gioiTinh: '',
            //    diaChi: '',
            //    soDienThoai: '',
            //    ngaySinh: ''
            //};
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
                if (vm.Create.id == null) {
                    benhNhanService.create(vm.Create).then(function () {
                        abp.notify.info(App.localize("Lưu Thành Công"));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
                } else {
                    benhNhanService.update(vm.Create).then(function () {
                        abp.notify.info(App.localize("Sửa thành công"));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    })
                }
            };

        }
    ]);
})();