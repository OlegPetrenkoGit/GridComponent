angular
    .module("GridComponent")
    .controller("GridController", GridController);

GridController.$inject = ["$http", "$window", "$scope"];

function GridController($http, $window, $scope) {
    $scope.formatSpecification = null;

    $scope.AddEntity = function () {
        $(".button-add").hide();

        var addEntityRow = $scope.createAddEntityFormRow();
        $(".grid > tbody:last-child").append(addEntityRow);
    }

    $scope.AddEntityCancel = function () {
        $(".button-add").show();
        $(".grid > tbody:last-child").delete();
    }

    $scope.createAddEntityFormRow = function () {
        var row = "";
        $scope.formatSpecification.Properties.forEach(function (element) {
            if (element.Name === "Id") {
                element.ReadOnly = true;
            }

            var entityType = element.Type.substr(element.Type.indexOf(".") + 1);
            var propertyName = element.Name;
            var readonly = element.ReadOnly;

            if (readonly) {
                row += "<td>-</td>";
            } else {
                var inputElement = "<input type=";
                switch (entityType) {
                    case "Int32":
                        {
                            inputElement += "'number'";
                            break;
                        }
                    case "String":
                        {
                            inputElement += "'text'";
                            break;
                        }
                    case "DateTime":
                        {
                            inputElement += "'date'";
                            break;
                        }
                }

                inputElement += "Name='" + propertyName + "'>";
                row += "<td>" + inputElement + "</td>";
            }
        });

        var buttonAdd = "<td><button type='submit'>Save</button></td>";
        var buttonCancel = "<td><button ng-click='AddEntityCancel()'>Cancel</button></td>"; //add watcher

        row += buttonAdd + buttonCancel;
        row = "<tr>" + row + "</tr>";
        return row;
    }

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
        $http.get("/Home/GetFormatSpecification?type=client").success(function (response) {
            $scope.formatSpecification = response;
            $(".button-add").prop("disabled", false);
        }).error(function (error) {
            console.log(error);
        });
    };

    this.getViewModelFormatSpecification();
}