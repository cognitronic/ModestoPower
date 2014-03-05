(function ($) {

    /*	Table OF Contents
	==========================
	1-parallax
	2-Carousel/sliders
	3-Knob
	4-Contact
	5-Natural Language Form
	6-main Banners height/Width adjustments
	7-Navigation
	8-Google map
	9-Portfolio
	10-Vegas Slider
	11-Facts Number Animations
	12-Tabs
	13-Ajax
	
	*/
	
	/*=================================
	0-Genral
	=================================*/
	
	var isMobile = {
        Android: function () {
            return navigator.userAgent.match(/Android/i);
        },
        BlackBerry: function () {
            return navigator.userAgent.match(/BlackBerry/i);
        },
        iOS: function () {
            return navigator.userAgent.match(/iPhone|iPad|iPod/i);
        },
        Opera: function () {
            return navigator.userAgent.match(/Opera Mini/i);
        },
        Windows: function () {
            return navigator.userAgent.match(/IEMobile/i);
        },
        any: function () {
            return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
        }
    };
	
	
	 var testMobile = isMobile.any();

    /*=================================
	1-parallax
	=================================*/

    $('.parallax-one').parallax("50%", 0.4);
    $('.parallax-two').parallax("50%", 0.4);
    $('.parallax-customer').parallax("50%", 0.4);
    $('.hero-parallax').parallax("50%", 0.4);
    $('.testimonial-parallax').parallax("50%", 0.3);
    $('.facts-parallax').parallax("50%", 0.3);
    $('.singleFolio-parallax').parallax("50%", 0.3);



    /*=================================
	2-Carousel/sliders
	=================================*/
	
	
	
	

    $('.carousel').carousel();


    $('.clients-logo').carouFredSel({
        width: "100%",
        circular: false,
        infinite: false,
        auto: false,
        scroll: {
            items: 1,
            easing: "linear"
        },
        prev: {
            button: "a#client-prev",
            key: "left"
        },
        next: {
            button: "a#client-next",
            key: "right"
        }
    });


    $('.testi-slider').flexslider({
        animation: "slide",
        directionNav: false,
        controlNav: false,
        slideshow: false,
        direction: "horizontal" //Direction of slides
    });
	
	$('.text-fadder').flexslider({
        animation: "fade",
        directionNav: false,
        controlNav: false,
        slideshow: true,
		easing: "swing",
		animationSpeed: 3000,
		slideshowSpeed: 5000,
    });
	
	




    $('.video-flex').flexslider({
        animation: "slide",
        directionNav: false,
        controlNav: true,
        slideshow: true,
        direction: "horizontal" //Direction of slides
    });


    $('.clients li').click(function () {
        $('.clients li').removeClass('active');
        $(this).addClass('active');
        $('.testi-slider').flexslider($(this).index());
    });



    /*=================================
	3-Knob
	=================================*/

    $(".knob").knob();


    /*=================================
	4-Contact
	=================================*/

    function IsEmail(email) {
        var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    }


    



    /*=================================
	5-Natural Language Form
	=================================*/
    //if ($('#hire-us').length) {
    //    var hireusForm = new NLForm(document.getElementById('nl-form'));
    //}


    /*=======================================
	6-main Banners height/Width adjustments
	=========================================*/



    if ($('.video-BG').length) {
        var player = new MediaElementPlayer('.video-BG', {
            videoWidth: '100%',
            videoHeight: '100%',
            loop: true,
            alwaysShowControls: false,
            features: [],
			startVolume: 0,
        });
        player.play();
    }



    //var wTop = 0,
    //    wHeight = $(document).height(),
    //    navHeight = $('.navContent').height();
    //scrollAblepixels = wHeight - navHeight;
    //$(window).scroll(function () {
    //    wTop = $(window).scrollTop();
    //    if (wTop <= scrollAblepixels) {
    //        $('.navContent').css('top', wTop + 'px');
    //    }
    //});


    function EasyPeasyParallax() {
        scrollPos = $(this).scrollTop();
        $('.parallax-banner').css({
            'background-position': '50% ' + (-scrollPos / 4) + "px"
        });
        $('.bannertext').css({
            'margin-top': (scrollPos / 4) + "px",
            'opacity': 1 - (scrollPos / 250),
        });
    }
    $(document).ready(function () {
        $(window).scroll(function () {
            EasyPeasyParallax();
        });
    });



    var para_parent = $('.bannertext').parent();
    var para_parent_h = para_parent.height();
    var my_height = $('.bannertext').height();
    var setTop = para_parent_h / 2 - my_height / 2;
    $('.bannertext').css('top', setTop + 'px');

    function heroInit() {
        var hero = jQuery('.hero'),
            content = $('.hero-content'),
            content_height = '-' + content.height() / 2,
            ww = jQuery(window).width(),
            wh = jQuery(window).height(),
            heroHeight = wh;
        hero.css({
            height: heroHeight + "px",
        });

        var heroContent = jQuery('.hero .content'),
            contentHeight = heroContent.height(),
            parentHeight = hero.height(),
            topMargin = (parentHeight - contentHeight) / 2;

        heroContent.css({
            "margin-top": topMargin + "px"
        });
        if (content.length) {
            content.css('margin-top', content_height + 'px');

        }
    }
	
	

    jQuery(window).on("resize", function(){
		 if (testMobile === null){
		 	heroInit();
		}
	});
	
	jQuery(window).on("ready", function(){
		 if (testMobile === null){
		 	heroInit();
		}
	});



    reanimate();

    function reanimate() {
        $('.scroller').animate({
            bottom: 40
        }, 1000).animate({
            bottom: 55
        }, 1000, function () {
            setTimeout(reanimate, 100);
        });
    }

    /*=======================================
	7-Navigation
	=========================================*/


    $(".ny_nav ul a[href^='#'],.home-nav a[href^='#'],.navmenu-nav a[href^='#'],.scroller").click(function () {
        
		$('.navbar-nav li').removeClass('active');
        $(this).parent().addClass('active');
        $('html, body').animate({
            scrollTop: $($.attr(this, 'href')).offset().top - 0
        }, 1500,'easeInOutExpo');
        return false;
    });

    $('ul.nav li.dropdown').click(
        function () {
            $(this).children('.dropdown-menu').slideToggle(400);
        });


    $(window).on("resize", function () {
        if ($(window).width() > 1000 && !$("#sticktop").hasClass('nav-stop')) {
            $('#home').bind('inview', function (event, visible) {
                if (visible === false) {
                    if (!$("#sticktop").hasClass('slideInDown')) {
                        $("#sticktop").removeClass('animated slideInUpBig').addClass('animated slideInDown');
                    }
                } else {
                    $("#sticktop").removeClass('animated slideInDown').addClass('animated slideInUpBig');
                }
            });
        }
    }).resize();
	
	if(!$("#sticktop").hasClass('nav-stop')){
		$("#sticktop").sticky({
			topSpacing: 0
		});
	}

    $(".navbar-nav a[href^='#']").click(function () {
		if($(this).parents('.navbar-collapse').hasClass('in'))
		{
			$(this).parents('.navbar-collapse').removeClass('in').addClass('collapse');
		}
        $('.navbar-nav li').removeClass('active');
        $(this).parent().addClass('active');
        $('html, body').animate({
            scrollTop: $($.attr(this, 'href')).offset().top - 0
        }, 1500,'easeInOutExpo');
        return false;
    });


    /*=======================================
	8-Google map
	=========================================*/

    if ($('.g-map').length) {
        var main_office = 'contact-map',
            branch_office = 'contact-map2',
            mapAddress = $('#contact-map').data('address'),
            mapType = $('#contact-map').data('maptype'),
            zoomLvl = $('#contact-map').data('zoomlvl');

        //mapAddress2 = $('#contact-map2').data('address'),
        //mapType2 = $('#contact-map2').data('maptype'),
        //zoomLvl2 = $('#contact-map2').data('zoomlvl');
        contactemaps(main_office, mapAddress, mapType, zoomLvl);
        //contactemaps(branch_office, mapAddress2, mapType2, zoomLvl2);

    }

    function contactemaps(selector, address, type, zoom_lvl) {
        var map = new google.maps.Map(document.getElementById(selector), {
            mapTypeId: google.maps.MapTypeId.type,
            scrollwheel: false,
            draggable: false,
            zoom: zoom_lvl,
        });
        var map_pin = "/images/basic/pin.png";
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({
                'address': address
            },
            function (results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                    new google.maps.Marker({
                        position: results[0].geometry.location,
                        map: map,
                        icon: map_pin
                    });
                    map.setCenter(results[0].geometry.location);

                }
            });
    }

    //animate scroll down icon


    /*=======================================
	9-Portfolio
	=========================================*/

	

	$("a[data-rel^='prettyPhoto']").prettyPhoto();
    var $containerfolio = $('.projects');

    $containerfolio.waitForImages(function () {

        if ($containerfolio.length) {
            $containerfolio.isotope({
                layoutMode: 'fitRows',
                filter: '*',
                animationOptions: {
                    duration: 750,
                    easing: 'linear',
                    queue: false
                }
            });
        }
    });



    $('.portfolio-filter li').click(function () {
        $('.portfolio-filter li').removeClass("active");
        $(this).addClass("active");
        var selector = $(this).attr('data-filter');
        $containerfolio.isotope({
            filter: selector,
            animationOptions: {
                duration: 750,
                easing: 'linear',
                queue: false
            }
        });
        return false;
    });



    /*=======================================
	10-Vegas Slider
	=========================================*/


    if ($('.full_width_slider').length) {
        $.vegas('slideshow', {
            backgrounds: [{
                src: 'assets/img/slider/slide01.jpg',
                fade: 2000
            }, {
                src: 'assets/img/slider/slide02.jpg',
                fade: 2000
            }, {
                src: 'assets/img/slider/slide03.jpeg',
                fade: 2000
            }, ]
        });
    }



    /*=======================================
	11- Animations
	=========================================*/
	

    
	
    if (testMobile === null) {
        console.log(testMobile === null);
        $('.about-mockup').bind('inview', function (event, visible) {
            if (visible === true) {
				$(this).addClass('fadeInUp animated').css('opacity','1');
			}
		});
		
		$('.service').bind('inview', function (event, visible) {
			if (visible === true) {
				$(this).addClass('fadeInUp animated').css('opacity','1');
			}
		});
		
		$('.team-visual').bind('inview', function (event, visible) {
			if (visible === true) {
				$(this).addClass('fadeInUp animated').css('opacity','1');
			}
		});
		
		$('.member').bind('inview', function (event, visible) {
			if (visible === true) {
				$(this).addClass('fadeInUp animated').css('opacity','1');
			}
		});
		
		$('.projects').bind('inview', function (event, visible) {
			if (visible === true) {
				$(this).addClass('fadeInUp animated').css('opacity','1');
			}
		});
		
		$('.feature').bind('inview', function (event, visible) {
			if (visible === true) {
				$(this).addClass('fadeInUp animated').css('opacity','1');
			}
		});
		
		$('#getintouch .container').bind('inview', function (event, visible) {
			if (visible === true) {
				$(this).addClass('fadeInUp animated').css('opacity','1');
			}
		});
		
		$('.g-map').bind('inview', function (event, visible) {
			if (visible === true) {
				$(this).addClass('fadeInUp animated').css('opacity','1');
			}
		});
		
		$('.about-mockup-wide').bind('inview', function (event, visible) {
			if (visible === true) {
				$(this).addClass('fadeInUp animated').css('opacity','1');
			}
		});
	
	}else{
        $('.stat,.about-mockup,.service,.team-visual,.member,.projects,.about-mockup-wide,.g-map,#getintouch .container,.feature').addClass('no-animation');
        console.log('fuck');
	}
	
	$('.stat').bind('inview', function (event, visible) {
		  if (visible === true) {
			  $(this).parent('.record').addClass('fadeInRight animated');
			  $(this).html($(this).attr('data-total'));
  
		  }
	  });
	
	
	
    /*=======================================
	12-Tabs
	=========================================*/

    $('.nav-tabs a').click(function (e) {
        e.preventDefault();
        $(this).tab('show');
    });


    /*=======================================
	13-Ajax
	=========================================*/


    var active, next_project, prev_project,
        target, hash, url, page, projectIndex,
        xv_scrollTo,
        projectLength,
        ajaxLoading = false,
        xv_projectHeight,
        content = false,
        xv_projects = $('.projects'),
        easing = 'easeOutExpo',
        nav_height = $('#sticktop').height(),
        loader = $('.ajax-loader'),
        projectContainer = $('.ajax-content'),
        projectNav = $('.folio-nav ul'),
        exitProject = $('#folio-close');

    $('.folio-nav ul').fadeOut();

    $(window).bind('hashchange', function () {
        hash = $(window.location).attr('hash');
        var root = '#';
        var rootLength = root.length;
        if (hash.substr(0, rootLength) != root || !(hash.search( '#_' )===-1)) {
            return;
        } else {
            hash = $(window.location).attr('hash');
            url = hash.replace(/[#]/g, '');

            $('.ajax-project a').click(function () {
                $('.ajax-project').removeClass('active');
                $(this).parents('.ajax-project').addClass('active');
            });

            $('#portfolio').find('.projects.active-folio').removeClass('active-folio');
            $('#portfolio').find('.ajax-holder.ajax-action').removeClass('ajax-action');
            xv_projects.find('.ajax-project a[href="#' + url + '"]').parents('.ajax-project').addClass('active');
            xv_projects.find('.ajax-project.active').find('a[href="#' + url + '"]').addClass('active');
            xv_projects.find('.ajax-project a[href="#' + url + '"]').parents('.projects').addClass('active-folio');

            $('.ajax-holder').addClass('ajax-action');
            if (hash.substr(0, rootLength) == root) {
                jQuery('html,body').stop().animate({
                    scrollTop: (projectContainer.offset().top - 20) + 'px'
                }, 800, 'easeOutExpo', function () {
                    loadProject();
                });
            } else if (hash.substr(0, rootLength) == root) {

                jQuery('html,body').stop().animate({
                    scrollTop: (projectContainer.offset().top - nav_height + 100) + 'px'
                }, 800, 'easeOutExpo', function () {

                    if (content === false) {
                        loadProject();
                    } else {
                        projectContainer.animate({
                            opacity: 0,
                            height: xv_projectHeight
                        }, function () {
                            loadProject();
                        });
                    }
                    projectNav.fadeOut('100');
                });
            } else if (hash === '' || hash.substr(0, rootLength) != root || hash.substr(0, rootLength) != root) {
                xv_scrollTo = hash;
                $('html,body').stop().animate({
                    scrollTop: xv_scrollTo + 'px'
                }, 1000, function () {
                    XV_ajaxClose();
                });
            }
        }
    });

    function loadProject() {
        loader.fadeIn().removeClass('projectError').html('');
        if (!ajaxLoading) {
            ajaxLoading = true;
            projectContainer.load(url + ' section#ajax-page', function (xhr, statusText, request) {
                if (statusText == "success") {
                    ajaxLoading = false;
                    page = $('#ajax-page');
                    $('#ajax-page').waitForImages(function () {
                        loader.delay(300).fadeOut(function () {
                            showProject();
                            $('#ajax-Modal').modal('show');

                        });
                    });
                }
                if (statusText == "error") {
                    loader.addClass('projectError').append("<p>Loading Error!</p>").slideDown();
                }
            });
        }
    }

    function showProject() {
        xv_projectHeight = projectContainer.children('#ajax-page').outerHeight() + 'px';
        if (content === false) {
            xv_projectHeight = projectContainer.children('#ajax-page').outerHeight() + 'px';
            projectContainer.animate({
                opacity: 1,
                height: xv_projectHeight
            }, function () {
                xv_scrollTo = $('html,body').scrollTop();
                projectNav.fadeIn();
                content = true;
            });
        } else {
            xv_projectHeight = projectContainer.children('#ajax-page').outerHeight() + 'px';
            projectContainer.animate({
                opacity: 1,
                height: xv_projectHeight
            }, function () {
                xv_scrollTo = $('html,body').scrollTop();
                projectNav.fadeIn();
            });
        }
        projectIndex = xv_projects.find('.ajax-project.active').index();
        projectLength = $('.ajax-project a').length - 1;
        if (projectIndex == projectLength) {
            $('#folio-next').addClass('disabled');
            $('#folio-prev').removeClass('disabled');
        } else if (projectIndex === 0) {
            $('#folio-prev').addClass('disabled');
            $('#folio-next').removeClass('disabled');
        } else {
            $('#folio-next, #folio-prev').removeClass('disabled');
        }
    }

    function XV_ajaxClose(closeURL) {
		 var xv_loader = $('.ajax-action').children('.ajax-loader');
        projectNav.fadeOut();
        projectContainer.animate({
            opacity: 0,
            height: '0px'
        }, 800, 'easeOutExpo');
        projectContainer.empty();
        $('html,body').stop().animate({
            scrollTop: projectContainer.offset().top - nav_height - 100
        });
		 if (typeof closeURL != 'undefined' && closeURL != '') {
            window.location.hash = '#_';
        }
		
		xv_loader.fadeOut();
        $('#portfolio').find('.projects.active-folio').removeClass('active-folio');
        $('#portfolio').find('.ajax-holder.ajax-action').removeClass('ajax-action');

        
    }
    $('#folio-next').on('click', function () {
        active = xv_projects.find('.ajax-project.active');
        next_project = active.next('.ajax-project');
        target = $(next_project).find('.pop-project').attr('href');
        $(this).attr('href', target);
        if (next_project.length === 0) {
            return false;
        }
        active.removeClass('active');
        next_project.addClass('active');

    });
    $('#folio-prev').on('click', function () {
        active = xv_projects.find('.ajax-project.active');
        prev_project = active.prev('.ajax-project');
        target = $(prev_project).find('.pop-project').attr('href');
        $(this).attr('href', target);
        if (prev_project.length === 0) {
            return false;
        }
        active.removeClass('active');
        prev_project.addClass('active');

    });
    $('#folio-close').on('click', function () {
        var xv_loader = $('.ajax-action').children('.ajax-loader');
        XV_ajaxClose($(this).attr('href'));
        xv_loader.fadeOut();
        $('#ajax-Modal').modal('hide');
        return false;
    });




})(jQuery);