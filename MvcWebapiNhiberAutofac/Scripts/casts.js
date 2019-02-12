$(document).ready(function () {
    $('.detailsLink').click(Shows.getShow);
    $('.addLink').click(Shows.addShow);
    $('.editLink').click(Shows.editShow);
    $('.deleteLink').click(Shows.deleteShow);
});

Shows = {
    getShow: function () {
        var id = $(this).attr('id');

        $.ajax(
            {
                type: 'GET',
                asynh: true,
                url: "/api/casts/" + id,
                success: function (output) {
                    Shows.reflectShowDetails(output);
                },
                error: function () {
                    alert("Error");
                }
            });
    },

    deleteShow: function () {
        var id = $(this).attr('id');

        $.ajax(
            {
                type: 'DELETE',
                asynh: true,
                url: "/api/casts/" + id,
                success: function (output) {
                    alert("Show is deleted");
                },
                error: function () {
                    alert("Error");
                }
            });
    },

    editShow: function () {
        var id = $(this).attr('id');
        var name = $('#editName').val();
        
        $.ajax(
            {
                type: 'PUT',
                asynh: true,
                url: "/api/casts/" + id,
                data: JSON.stringify(name),
                contentType: "application/json;charset=utf-8",
                success: function (output) {
                    alert("Show is edited");
                },
                error: function () {
                    alert("Error");
                }
            });
    },

    addShow: function () {
        var name = $('#editName').val();

        $.ajax(
            {
                type: 'POST',
                asynh: true,
                url: "/api/casts/",
                data: JSON.stringify(name),
                contentType: "application/json;charset=utf-8",
                success: function (output) {
                    alert("Show is added");
                },
                error: function () {
                    alert("Error");
                }
            });
    },

    reflectShowDetails: function (show) {
        var result = "Show id: " + show.id + ", " + "name: " + show.name + "<br/>";
        var i;
        for (i = 0; i < show.cast.length; i++) {
            result += "Cast id: " + show.cast[i].id + ", " + "name: " + show.cast[i].name + ", " + "birthday: " + show.cast[i].birthday + "<br/>";
        }
        document.getElementById("detailsArea").innerHTML = result;
    }
}