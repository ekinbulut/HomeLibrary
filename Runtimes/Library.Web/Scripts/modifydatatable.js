$(function () {
    $("#example").DataTable({
        "pagingType": "full",
        responsive: true,
        "order": [[1, "asc"], [2, "asc"], [3, "asc"]]

    });
});