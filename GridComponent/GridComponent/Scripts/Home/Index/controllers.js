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
                name: propertyName,
                readonly: element.ReadOnly,
                type: null
            };

            //   if (!readonly) {
            property.type = dataTypes.find(function (type) {
                return type.clrType === entityType;
            }).htmlType;
            //   }

            properties.push(property);
        });

        return properties;
    };

    $scope.submitAddEntity = function (event, form) {

       // var formData = new FormData();
        //var strigifiedSpec = JSON.stringify($scope.formatSpecification);
        //formData.append("FormatSpecification", strigifiedSpec);

        ////var formElement = angular.element(event.target).serialize();

        //var inputs = angular.element(event.target).context.getElementsByTagName("input");;

        //var entityProperties = [];
        //var count = inputs.length;
        //for (var i = 0; i < count; i++) {
        //    var current = inputs[i];
        //    entityProperties.push({ name: current.name, value: current.value });
        //}

        //var strigifiedProps = JSON.stringify(entityProperties);
        //formData.append("EntityProperties", strigifiedProps);


        //formData.append("value", JSON.stringify("lol"));


        var formData = new FormData();
      //  var strigified = JSON.stringify("textForTest");

        formData.append("blank", JSON.stringify("blank"));

        formData.append("String", "textForTest");

        $http({
            method: "POST",
            url: "/Home/Create",
            data: formData,
            headers: { 'Content-Type': "application/x-www-form-urlencoded" }
          //  headers: { 'Content-Type': "application/json" }
        })
        .success(function (response) {
            console.log(response);
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