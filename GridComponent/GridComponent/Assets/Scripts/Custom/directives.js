angular
    .module("GridComponent")
    .directive("entityPropertyHeader", function () {
        return {
            link: function (scope, element, attributes) {
                element.text(scope.property.name);
            }
        };
    })
    .directive("entityPropertyInput", ["ClrJsTypes", function (ClrJsTypes) {
        return {
            link: function (scope, element, attributes) {
                var property = scope.property;
                var defaultValue = ClrJsTypes.find(function (type) {
                    return type.htmlType === property.type;
                }).defaultValue;

                var inputHtml = '<input type="';
                if (!property.readonly) {
                    inputHtml += property.type;
                } else {
                    inputHtml += "hidden";
                }

                inputHtml += '" name=obj.' + property.name + ' value="' + defaultValue + '"/>';
                element.append(inputHtml);
            }
        };
    }]);