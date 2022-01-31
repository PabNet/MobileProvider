﻿$(document).ready(()=>
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
    
    
});