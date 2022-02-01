$(document).ready(()=>
{
   
    $("#AddButton").click(()=>
    {
        postQuery("/Functionality/AddRole", {RoleDates: [$("#RoleName").val(), $("#Description").val()]});
    });

    $("#DeleteButton").click(()=>
    {
        postQuery("/Functionality/DeleteRole", {RoleId: $("#RoleListForRemove").val()});
    });
    
    $('.UpdateInputs').blur(function(event) 
    {
        postQuery("/Functionality/UpdateRole/", {UpdateDates: [event.target.id, event.target.value]})
    });

    $("#SaveButton").click(()=>
    {
        let checkboxes = [];
        $('input:checkbox:checked').each(function(){
            checkboxes.push(this.value);
        });
        postQuery("/Functionality/UpdateRequirement", {PageName: $("#PageName").val(), Roles: checkboxes});
    });
    
    
});