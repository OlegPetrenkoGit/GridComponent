angular
    .module("GridComponent")
    .constant("ClrJsTypes", [
                { clrType: "Int32", htmlType: "number", defaultValue: 0 },
                { clrType: "String", htmlType: "text", defaultValue: "" },
                { clrType: "DateTime", htmlType: "date", defaultValue: "2011-11-11" }
    ]);