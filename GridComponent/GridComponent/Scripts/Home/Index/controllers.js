angular
    .module("GridComponent")
    .controller("GridController", GridController);

GridController.$inject = ["$http", "$window", "$scope"];

function GridController($http, $window, $scope) {
    $scope.showAddEntityRow = false;
    $scope.buttonAddDisabled = true;
    $scope.formatSpecification = null;

    $scope.showAddEntity = function () {
        $scope.showAddEntityRow = true;
    };

    $scope.AddEntity = function () { //todo remove
        $(".button-add").hide();

        var addEntityRow = $scope.createAddEntityFormRow();
        $(".grid > tbody:last-child").append(addEntityRow);
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
            }

            if (!readonly) {
                var types = [
                    { clrType: "Int32", htmlType: "number" },
                    { clrType: "String", htmlType: "text" },
                    { clrType: "DateTime", htmlType: "date" }
                ];

                property.type = types.find(function (type) {
                    return type.clrType === entityType;
                }).htmlType;
                //  inputElement += "Name='" + propertyName + "'>"; todo add names for form
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

    this.getViewModelFormatSpecification = function () {
        var entityType = "GridComponent.Models.Client";

        $http.get("/Home/GetFormatSpecification?type=" + entityType).success(function (response) {
            $scope.buttonAddDisabled = false;
            $scope.formatSpecification = $scope.createFormatSpecification(response);
        }).error(function (error) {
            console.log(error);
        });
    };

    this.getViewModelFormatSpecification();
}