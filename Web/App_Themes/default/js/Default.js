jQuery(document).ready(function () {
    jQuery('#mycarousel').jcarousel({
        vertical: true,
        scroll: 1,
        initCallback: mycarousel_initCallback
    });
});
function show_pdinfo(productID,node) {
    if ($('#txtandrun').attr("nowid") != productID) {
        $('#mycarousel a').attr("class","");
        $(node).attr("class","select");
        $('#txtandrun').hide();
        $('#bigimg').hide();
        $('#txtandrun').attr("nowid", productID);
        $('#txtandrun').children("h1").html($('#pd_' + productID).children("h1").html());
        $('#txtandrun').children("p").html($('#pd_' + productID).children("p").html());
        $('#bigimg').html($('#im_' + productID).html());
        $('#txtandrun').slideDown("slow");
        $('#bigimg').fadeIn("slow");
    }
}
function mycarousel_initCallback(carousel) {
    carousel.buttonNext.bind('click', function () {
        if ($('#pd_' + $('#txtandrun').attr("nowid")).nextAll().length >= 4) {
            var productID = $('#pd_' + $('#txtandrun').attr("nowid")).next(".product_info").attr("goodid");
            $('#mycarousel a').attr("class", "");
            $('#a_' + productID).attr("class", "select");
            $('#txtandrun').hide();
            $('#bigimg').hide();
            $('#txtandrun').attr("nowid", productID);
            $('#txtandrun').children("h1").html($('#pd_' + productID).children("h1").html());
            $('#txtandrun').children("p").html($('#pd_' + productID).children("p").html());
            $('#bigimg').html($('#im_' + productID).html());
            $('#txtandrun').slideDown("slow");
            $('#bigimg').fadeIn("slow");
        }
    });
    carousel.buttonPrev.bind('click', function () {
        if ($('#pd_' + $('#txtandrun').attr("nowid")).prevAll().length >= 4) {
            var productID = $('#pd_' + $('#txtandrun').attr("nowid")).prev(".product_info").attr("goodid");
            $('#mycarousel a').attr("class", "");
            $('#a_' + productID).attr("class", "select");
            $('#txtandrun').hide();
            $('#bigimg').hide();
            $('#txtandrun').attr("nowid", productID);
            $('#txtandrun').children("h1").html($('#pd_' + productID).children("h1").html());
            $('#txtandrun').children("p").html($('#pd_' + productID).children("p").html());
            $('#bigimg').html($('#im_' + productID).html());
            $('#txtandrun').slideDown("slow");
            $('#bigimg').fadeIn("slow");
        }
    });
}
function factory_select(factoryID, node) {
    $("#moreinfo .compayinfo .compaylist li").removeClass("select");
    $(node).parent().addClass("select");
    $("#moreinfo .compayinfo .compaydetail .factoryunion").hide();
    $('#f_'+factoryID).fadeIn("slow");
}

/*最近更新按钮*/
jQuery(function () {
    if (!$('#slidePic')[0])
        return;
    var i = 0, p = $('#slidePic ul'), pList = $('#slidePic ul li'), len = pList.length;
    var elePrev = $('#prev'), eleNext = $('#next');
    var w = 46, num = 4;
    p.css('height', w * len);
    if (len <= num)
        eleNext.addClass('gray');
    function prev() {
        if (elePrev.hasClass('gray')) {
            return;
        }
        p.animate({
            marginTop: -(--i) * w
        }, 500);
        if (i < len - num) {
            eleNext.removeClass('gray');
        }
        if (i == 0) {
            elePrev.addClass('gray');
        }
    }
    function next() {
        if (eleNext.hasClass('gray')) {
            return;
        }
        p.animate({
            marginTop: -(++i) * w
        }, 500);
        if (i != 0) {
            elePrev.removeClass('gray');
        }
        if (i == len - num) {
            eleNext.addClass('gray');
        }
    }
    elePrev.bind('click', prev);
    eleNext.bind('click', next);
    pList.each(function (n, v) {
        $(this).click(function () {
            $('#slidePic ul li.cur').removeClass('cur');
            $(this).addClass('cur');
        }).mouseover(function () {
            $(this).addClass('hover');
        }).mouseout(function () {
            $(this).removeClass('hover');
        })
    });
});