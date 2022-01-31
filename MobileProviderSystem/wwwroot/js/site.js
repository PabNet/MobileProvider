function postQuery(url, data)
{
    $.post(url,data, () => {
        location.reload();
    });
}