angular
    .module("GridComponent", [])
    .directive("entityPropertyHeader", function () {
        return {
            link: function (scope, element, attributes) {
                element.attr("name", scope.property.header);
                element.text(scope.property.header);
            }
        };
    })
    .directive("entityPropertyInput", function () {
        return {
            template: '<input type="type()" name="name()"></input>',
            link: function (scope, element, attributes) {
                element.attr("type", scope.property.type);

                scope.type = function () {
                    return scope.property.type;
                }

                //todo finish implementation

                console.log(propertySpecification);
            }
        };
    });