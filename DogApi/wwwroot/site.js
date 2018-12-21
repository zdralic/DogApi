const uri = "api/dog";
let todos = null;
function getCount(data) {
    const el = $("#counter");
    let name = "Dog";
    if (data) {
        if (data > 1) {
            name = "Dogs";
        }
        el.text(data + " " + name);
    } else {
        el.text("No " + name);
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#dogs");

            $(tBody).empty();

            getCount(data.length);

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.breed))
                    .append($("<td></td>").append($('<a target="_blank" href="' + item.path + '">Link<a/>')))
                    .append(
                        $("<td></td>").append(
                            $("<button>Delete</button>").on("click", function () {
                                deleteItem(item.id);
                            })
                        )
                    );
                tr.appendTo(tBody);
            });
            dogs = data;
        }
    });
}

function addItem() {
    const item = {
        breed: $("#add-breed").val(),
        path: $("#add-path").val()
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            getData();
            $("#add-breed").val("");
            $("#add-path").val("");
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + "/" + id,
        type: "DELETE",
        success: function (result) {
            getData();
        }
    });
}

function getRandomItem() {
    $.ajax({
        type: "Get",
        accepts: "application/json",
        url: uri + "/" + $("#random-breed").val(),
        contentType: "application/json",
        data: JSON.stringify($("#random-breed").val()),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (item) {
            $("#random-img").html($('<img src="' + item.path + '"/>'));
        }
    });
}

