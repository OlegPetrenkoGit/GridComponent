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
            link: function (scope, element, attributes) {
                var property = scope.property;
                if (!property.readonly) {
                    var inputHtml = '<input type="' + property.type + '" name="' + property.Name + '"/>';
                    $(element).append(inputHtml);
                }
            }
        };
    });