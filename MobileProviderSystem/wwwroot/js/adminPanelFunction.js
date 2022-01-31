$(document).ready(()=>{

    let IdUser;
    let Modal = $("#AdditionalTask");

    $('.Data').on("click", function()
    {
        IdUser = $(this).attr('id');
        Modal.css("display", "block").addClass("Input");
        $("#Table").css("display", "none");
    })

    $("#No").click( (event) =>
    {
        hideModal();
    });

    $("#Yes").click( (event) =>
    {
        postQuery('/Functionality/DeleteUser', {UserId: IdUser});
        hideModal();
    });

    function hideModal()
    {
        Modal.removeClass("Input").css("display", "none");
        $("#Table").css("display", "table");
    }

    $("#RoleSelect").change(() => 
    {
        let selectedOption = $("#RoleSelect option:selected");
        postQuery("/Functionality/UpdateRoleForUser", {UpdateRoleDates: [ selectedOption.val(),selectedOption.text()]});
    });
    

});