$(function () {
    var clearBorder = function () {
        $('.g-recaptcha > div').css('border', 'solid 1px transparent');
    }
    var data = [{ id: 1 }];
    var selections = JSON.parse(JSON.stringify(data));
    var reason = JSON.parse(JSON.stringify(data[0].id));
    $("#id_motivo").val(reason).value;

    function scrollTo(div) {
        $('html, body').animate({
            scrollTop: div.offset().top
        }, 1000);
    }
    $('.hamburger').on('click', function () {
        $(this).toggleClass("active");
        $(".navs").toggleClass('active');
    })
    $('#Button1').on('click', function () {

        var gAuth = grecaptcha.getResponse();
        var privacy = $('.checkbox > input').prop("checked");

        $('.g-recaptcha > div').css({
            'border': 'solid 0px transparent'
            , 'transition': 'all 0.3s ease'
        });
        if ((gAuth.length > 0) && privacy && !($(this).hasClass('loading'))) {
            $(this).addClass('loading');
            $(".loadingModal").addClass("active");
            console.log('true');
        }
        else {
            if (gAuth.length == 0) {
                $('.g-recaptcha > div').css('border', 'solid 1px orangered');
            }
            if (!privacy) {
                $('.checkbox > input').css('border', 'solid 1px orangered');
                $('.text > h5 > a').css('color', 'orangered');
                $('.checkbox > input').on('click', function () {
                    $('.text > h5 > a').css('color', '#e6c700');
                })
            }
        }

        $("#cacth").val(gAuth).value;
        $("#policy").val(privacy).value;

    });

    $('.accept > .text > h5 > a').on('click', function () {
        $('.popup').addClass('active');
        $('.popup > .float > .content').load('placeholder.html');
        scrollTo($('.popup'));
    });


    $('.no-return').on('click', function () {
        if ($('.hamburger').hasClass('active') || ($(window).width() >= 768)) {
            $('.popup').addClass('active');
            $('.popup > .float > .content').load('No_return.html');
            scrollTo($('.popup'));
        }
    });

    $('.problems').on('click', function () {
        if ($('.hamburger').hasClass('active') || ($(window).width() >= 768)) {
            $('.popup').addClass('active');
            $('.popup > .float > .content').load('Problemas.html');
            scrollTo($('.popup'));
        }
    });

    $('.guide').on('click', function () {
        if ($('.hamburger').hasClass('active') || ($(window).width() >= 768)) {
            $('.popup').addClass('active');
            $('.popup > .float > .content').load('index_email.html');
            scrollTo($('.popup'));
        }
    });
    $('.float > .close').on('click', function () {
        $('html,body').animate({
            scrollTop: 0
        },
            'slow');
        $('.popup').removeClass('active');
    });
    $('.accordion').on('click', function () {
        $(this).toggleClass('active');
    });
    $('#dialog > .close').on('click', function () {
        $('#dialog').removeClass();
    });
    var overflow;
    var content = $('#dialog > .content');
    if (content[0].offsetHeight < content[0].scrollHeight || content[0].offsetWidth < content[0].scrollWidth) {
        overflow = true;
    }
    $('#dialog > .content').on('click', function () {
        if (overflow) {
            $(this).toggleClass('read');
        }
    });


    var selectList = function (listToAppend) {
        $('.select > .float > select').select2({
            tags: "true"
            , data: listToAppend
            , maximumInputLength: 10
        });
        $('.select > .float > select').on('select2:open', function () {
            $('.select2-search__field').attr('placeholder', 'Buscar...');
        });
        $('.select > .float > select').on("select2:close", function () {
            $('.select2-search__field').attr('placeholder', null);
        });
    }

    selectList(selections);
    $('.select > .float > select').on('select2:select', function (evt) {
        reason = evt.currentTarget.value;
        $("#id_motivo").val(reason).value;
    });
});
