
function updateCarProducts() {
	var cartProducts;
	var existingCookieData = $.cookie('CartProducts');

	if (existingCookieData != undefined && existingCookieData != "" && existingCookieData != null) {

		cartProducts = existingCookieData.split('-');

	}

	else {
		cartProducts = [];
	}

	$("#cartProductsCount").html(cartProducts.length);
}



/*----------------------------
Cart Plus Minus Button
------------------------------ */
var CartPlusMinus = $(".cart-plus-minus");
//CartPlusMinus.prepend('<div class="dec qtybutton">-</div>');
//CartPlusMinus.append('<div class="inc qtybutton" data-id="">+</div>');
$(".qtybutton").on("click", function () {
	var $button = $(this);
	var oldValue = $button.parent().find("input").val();
	if ($button.text() === "+") {

		var existingCookieData = $.cookie('CartProducts');

		products = existingCookieData.split('-');

		$.cookie('CartProducts', products.join('-'), { path: '/' });

		var newVal = parseFloat(oldValue);

	} else {
		// Don't allow decrementing below zero
		if (oldValue > 1) {
			var newVal = parseFloat(oldValue);

			var products = $(this).attr('data-id') - 1;

			$.removeCookie('CartProducts', products);

		} else {
			newVal = 1;
		}
	}
	$button.parent().find("input").val(newVal);
});



$(".removeItem").click(function () {
	$(this).parent().parent().remove();
	$.removeCookie('CartProducts');
});

/*var products;*/


/*----------------------------
	Cart Plus Minus Button
------------------------------ */
//var CartPlusMinus = $(".cart-plus-minus");
////CartPlusMinus.prepend('<div class="dec qtybutton">-</div>');
////CartPlusMinus.append('<div class="inc qtybutton" data-id="">+</div>');
//$(".qtybutton").on("click", function () {
//	var $button = $(this);
//	var oldValue = $button.parent().find("input").val();
//	if ($button.text() === "+") {
//		var newVal = parseFloat(oldValue) + 1;

//		var existingCookieData = $.cookie('CartProducts');

//		if (existingCookieData != undefined && existingCookieData != "" && existingCookieData != null) {

//			products = existingCookieData.split('-');

//		}

//		else {
//			products = [];
//		}

//		var productID = $(this).attr('data-id');

//		products.push(productID);

//		$.cookie('CartProducts', products.join('-'), { path: '/' });

//		updateCarProducts();

//		Swal.fire(
//			"Producto Agregado",
//			"El producto se agregado al carro correctamente",
//			"success"
//		)

//	} else {
//		// Don't allow decrementing below zero
//		if (oldValue > 1) {
//			var newVal = parseFloat(oldValue) - 1;
//		} else {
//			newVal = 1;
//		}
//	}
//	$button.parent().find("input").val(newVal);
//});

/*-------------------------------
	Create an account toggle
---------------------------------*/
$(".checkout-toggle2").on("click", function () {
	$(".open-toggle2").slideToggle(1000);
});

$(".checkout-toggle").on("click", function () {
	$(".open-toggle").slideToggle(1000);
});


/*========================================
SELECCIONAR DEPARTAMENTO DE ENVÍO   
=========================================*/
$.ajax({
	url: "/Scripts/departamentos.json",
	type: "GET",
	cache: false,
	contentType: false,
	processData: false,
	dataType: "json",
	success: function (respuesta) {

		respuesta.forEach(selectDepartment);

		function selectDepartment(item, index) {

			var departments = item.name;
			var codDepartment = item.id;

			$("#selectDepartment").append('<option value="' + codDepartment + '">' + departments + '</option>');

		}

	}
});

/*========================================
SELECCIONAR PROVINCIA DE ENVÍO   
=========================================*/
$("#selectDepartment").change(function () {

	$("#selectProvince option").remove();

	$("#selectProvince").html('<select id="selectProvince" name="Province">' +
		'<option value="">Seleccionar una Provincia</option>' +
		'</select>');

	$("#selectDistrict option").remove();

	$("#selectDistrict").html('<select id="selectDistrict" name="District">' +
		'<option value="">Seleccionar un Distrito</option>' +
		'</select>');

	var codDepartment = $(this).val();

	$.ajax({
		url: "/Scripts/provincias.json",
		type: "GET",
		cache: false,
		contentType: false,
		processData: false,
		dataType: "json",
		success: function (respuesta) {

			respuesta.forEach(selectProvince);

			function selectProvince(item, index) {

				var province = item.name;
				var codProvince = item.id;
				var idDepartment = item.department_id;

				if (codDepartment == idDepartment) {

					$("#selectProvince").append('<option value="' + codProvince + '">' + province + '</option>');

				}

			}

		}
	});

})



/*========================================
SELECCIONAR DISTRITO DE ENVÍO   
=========================================*/
$("#selectProvince").change(function () {

	$("#selectDistrict option").remove();

	$("#selectDistrict").html('<select id="selectDistrict" name="District">' +
		'<option value="">Seleccionar un Distrito</option>' +
		'</select>');

	var codProvince = $(this).val();

	$.ajax({
		url: "/Scripts/distritos.json",
		type: "GET",
		cache: false,
		contentType: false,
		processData: false,
		dataType: "json",
		success: function (respuesta) {

			respuesta.forEach(selectDistrict);

			function selectDistrict(item, index) {

				var district = item.name;
				var codDistrict = item.id;
				var idProvince = item.province_id;

				if (codProvince == idProvince) {

					$("#selectDistrict").append('<option value="' + codDistrict + '">' + district + '</option>');

				}

			}

		}
	});
})

//function hideLoader() {
//	$(".loader").hide();
//	$("#loading-overlay").hide('slow');
//};

//function showLoader() {
//	$(".loader").show();
//	$("#loading-overlay").show();
//};



; (function ($) {

	'use strict'

	var removePreloader = function () {
		$(window).on("load", function () {
			$(".loader").fadeOut();
			//$("#loading-overlay").delay(500).fadeOut('slow', function () {
			//	$(this).remove();
			//});
			$("#loading-overlay").delay(500).fadeOut('slow'); 
		});
	};	


	//var updateCarProducts = function () {
	//	var cartProducts;
	//	var existingCookieData = $.cookie('CartProducts');

	//	if (existingCookieData != undefined && existingCookieData != "" && existingCookieData != null) {

	//		cartProducts = existingCookieData.split('-');

	//	}

	//	else {
	//		cartProducts = [];
	//	}

	//	$("#cartProductsCount").html(cartProducts.length);
 //   }
	

	$(function () {
		removePreloader();
		updateCarProducts();
	});

})(jQuery);


jQuery(document).ready(function ($) {
	//open/close mega-navigation
	$('.cd-dropdown-trigger').on('click', function(event){
		event.preventDefault();
		toggleNav();
	});

	//close meganavigation
	$('.cd-dropdown .cd-close').on('click', function(event){
		event.preventDefault();
		toggleNav();
	});

	//on mobile - open submenu
	$('.has-children').children('a').on('click', function(event){
		//prevent default clicking on direct children of .has-children 
		event.preventDefault();
		var selected = $(this);
		selected.next('ul').removeClass('is-hidden').end().parent('.has-children').parent('ul').addClass('move-out');
	});

	//on desktop - differentiate between a user trying to hover over a dropdown item vs trying to navigate into a submenu's contents
	var submenuDirection = ( !$('.cd-dropdown-wrapper').hasClass('open-to-left') ) ? 'right' : 'left';
	$('.cd-dropdown-content').menuAim({
        activate: function(row) {
        	$(row).children().addClass('is-active').removeClass('fade-out');
        	if( $('.cd-dropdown-content .fade-in').length == 0 ) $(row).children('ul').addClass('fade-in');
        },
        deactivate: function(row) {
        	$(row).children().removeClass('is-active');
        	if( $('li.has-children:hover').length == 0 || $('li.has-children:hover').is($(row)) ) {
        		$('.cd-dropdown-content').find('.fade-in').removeClass('fade-in');
        		$(row).children('ul').addClass('fade-out')
        	}
        },
        exitMenu: function() {
        	$('.cd-dropdown-content').find('.is-active').removeClass('is-active');
        	return true;
        },
        submenuDirection: submenuDirection,
    });

	//submenu items - go back link
	$('.go-back').on('click', function(){
		var selected = $(this),
			visibleNav = $(this).parent('ul').parent('.has-children').parent('ul');
		selected.parent('ul').addClass('is-hidden').parent('.has-children').parent('ul').removeClass('move-out');
	}); 

	function toggleNav(){
		var navIsVisible = ( !$('.cd-dropdown').hasClass('dropdown-is-active') ) ? true : false;
		$('.cd-dropdown').toggleClass('dropdown-is-active', navIsVisible);
		$('.cd-dropdown-trigger').toggleClass('dropdown-is-active', navIsVisible);
		if( !navIsVisible ) {
			$('.cd-dropdown').one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend',function(){
				$('.has-children ul').addClass('is-hidden');
				$('.move-out').removeClass('move-out');
				$('.is-active').removeClass('is-active');
			});	
		}
	}	

});


//function updateCarProducts() {
//	var cartProducts;
//	var existingCookieData = $.cookie('CartProducts');

//	if (existingCookieData != undefined && existingCookieData != "" && existingCookieData != null) {

//		cartProducts = existingCookieData.split('-');

//	}

//	else {
//		cartProducts = [];
//	}

//	$("#cartProductsCount").html(cartProducts.length);
//}
