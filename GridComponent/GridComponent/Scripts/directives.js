angular
    .module("GridComponent", [])
    .directive("entityPropertyHeader", function () {
        return {
            link: function (scope, element, attributes) {
                element.text(scope.property.name);
            }
        };
    })
    .directive("entityPropertyInput", function () {
        return {
            link: function (scope, element, attributes) {
                var property = scope.property;
                if (!property.readonly) {
                    var inputHtml = '<input type="' + property.type + '" name="' + property.name + '"/>';
                    $(element).append(inputHtml);
                } else {
                    var inputHtml = '<input type="hidden" name="' + property.name + '" value="0"' + '/>'; //todo set default value for type
                    $(element).append(inputHtml);
                }
            }
        };
    });