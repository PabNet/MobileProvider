$(document).ready(()=>{

    let IdUser;

    $('.Data').on("click", function()
    {
        IdUser = $(this).attr('id');
        $("#AdditionalTask").css("display", "inline-block");
        $("#Table").css("display", "none");
    })

    $("#No").click( (event) =>
    {
        hideModal();
    });

    $("#Yes").click( (event) =>
    {
        $.get('/Functionality/DeleteUser', {UserId: IdUser});
        hideModal();
    });

    function hideModal()
    {
        $("#AdditionalTask").css("display", "none");
        $("#Table").css("display", "table");
    }
    
});