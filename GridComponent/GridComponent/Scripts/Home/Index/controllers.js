angular
    .module("GridComponent")
    .controller("GridController", GridController);

GridController.$inject = ["$http", "$window", "$scope"];

function GridController($http, $window, $scope) {
    const dataTypes = [
        { clrType: "Int32", htmlType: "number" },
        { clrType: "String", htmlType: "text" },
        { clrType: "DateTime", htmlType: "date" }
    ];

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
            if (element.Name === "Id") { //todo set Id readonly in backend
                element.ReadOnly = true;
            }

            var entityType = element.Type.substr(element.Type.indexOf(".") + 1);
            var propertyName = element.Name;
            var readonly = element.ReadOnly;

            var property = {
                header: propertyName,
                readonly: element.ReadOnly,
                type: null
            };

            if (!readonly) {
                property.type = dataTypes.find(function (type) {
                    return type.clrType === entityType;
                }).htmlType;
            }

            properties.push(property);
        });

        return properties;
    };

    $scope.submitForm = function () {
        var form = document.getElementById("form");

        var dataObject = new Object;
        $scope.formatSpecification.Properties.forEach(function (element) {
            if (!element.ReadOnly) {
                var propertyName = element.Name;
                var value = form.elements[propertyName].value;
                dataObject[propertyName] = value;
            }
        });

        $http({
            method: "POST",
            url: "/Home/Create",
            data: dataObject,
            headers: { 'Content-Type': "application/x-www-form-urlencoded" }
        })
        .success(function (data) {
            console.log(data);
        });
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