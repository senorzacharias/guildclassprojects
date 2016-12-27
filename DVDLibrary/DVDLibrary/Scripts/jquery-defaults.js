jQuery.validator.setDefaults({
    highlight: function (element, errorClass, validClass) {
        $(element).parents(".form-group").removeClass("has-success").addClass("has-error");

    },
    unhighlight: function (element, errorClass, validClass) {

        $(element).parents(".form-group").removeClass("has-error").addClass("has-success");

    }
});