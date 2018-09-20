// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#photoAlbumTable').DataTable({
        "ajax":
        {
            "url": "/PhotoAlbum/Get",
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { AlbumId: "AlbumId" },
            { PhotoId: "PhotoId" },
            { PhotoTitle: "Photo Title" },
            { AlbumName: "Album Name" },
            { ThumbnailUrl: "Thumbnail Image", render: getImg }
        ]
    });

    function getImg(data, type, full, meta) {
        return '<a target="_blank" href="'+full[5]+'"> <img src="'+data+'"></a>';
    }

});