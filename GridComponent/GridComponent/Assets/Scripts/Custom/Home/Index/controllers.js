angular
    .module("GridComponent")
    .controller("GridController", ["$http", "$scope", "ClrJsTypes",
        function ($http, $scope, ClrJsTypes) {

            $scope.showAddEntityRow = false;
            $scope.showAddEntityButtonRow = true;
            $scope.buttonAddDisabled = true;
            $scope.formatSpecification = null;

            $scope.showAddEntity = function () {
                $scope.showAddEntityRow = !$scope.showAddEntityRow;
                $scope.showAddEntityButtonRow = !$scope.showAddEntityButtonRow;
            };

            $scope.createFormatSpecification = function (formatSpecification) {
                var properties = [];

                formatSpecification.Properties.forEach(function (element) {
                    var entityType = element.Type.substr(element.Type.indexOf(".") + 1);
                    var propertyName = element.Name;

                    var property = {
                        name: propertyName,
                        readonly: element.ReadOnly,
                        type: null
                    };

                    var dataTypes = ClrJsTypes;

                    property.type = dataTypes.find(function (type) {
                        return type.clrType === entityType;
                    }).htmlType;

                    properties.push(property);
                });

                return properties;
            };

            $scope.getViewModelFormatSpecification = function () {
                var entityType = "GridComponent.Models.Client";

                $http.get("/Home/GetFormatSpecification?type=" + entityType).success(function (response) {
                    $scope.buttonAddDisabled = false;
                    $scope.formatSpecification = $scope.createFormatSpecification(response);
                }).error(function (error) {
                    console.log(error);
                });
            };
        }
    ]);