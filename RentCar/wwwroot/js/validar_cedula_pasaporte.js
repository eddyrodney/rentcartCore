$("#field-cctipoidentificacion").change(function(){
    if($("#field-cctipoidentificacion option:selected").val() == "PASAPORTE")
    {
        $("#field-cedula").val("");
        $("#field-cedula").addClass("avoid-clicks");
        $("#field-cedula").attr("disabled", "disabled");
        $("#field-ccalterna").removeClass("avoid-clicks");
        $("#field-ccalterna").removeAttr("disabled", "disabled");
        
    }
    else
    {
        $("#field-ccalterna").val("");
        $("#field-ccalterna").addClass("avoid-clicks");
        $("#field-ccalterna").attr("disabled", "disabled");
        $("#field-cedula").removeClass("avoid-clicks").removeAttr("disabled", "disabled");
        $("#field-cedula").removeAttr("disabled", "disabled");
    }
    }
);