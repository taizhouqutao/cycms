jQuery(document).ready(function () {
    $('a.zoom').fancyZoom({ scaleImg: true, closeOnClick: true, directory: $("#directory").val()+"Images" });
});