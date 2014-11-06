// JavaScript Document
$(document).ready(function () {
            var firstMenu = $(".fst");
            var secondMenu = $('.scd');
			var secondMenuli = $('.scd li a');			
			firstMenu.each(function () {			
                $(this).click(function () {									    
                    var aSel = $(this).attr('selected');                   
                    if (aSel != 'selected') {
						secondMenu.slideUp(); 
						$(this).siblings(".scd").slideToggle();
                        firstMenu.removeAttr('selected').removeClass('z-crt');
                        $(this).addClass("z-crt").attr("selected", "selected");
                    }else{
						$(this).siblings(".scd").slideUp(function(){
							firstMenu.removeAttr('selected').removeClass('z-crt');
							});
					}									
                });
            });			
			secondMenuli.each(function () {			
                $(this).click(function () {									    
                    var aSel = $(this).attr('selected');                   
                    if (aSel != 'selected') {
                        secondMenuli.removeAttr('selected').removeClass('z-crt');
                        $(this).addClass("z-crt").attr("selected", "selected");
                    }else{
						$(this).siblings(".scd").slideUp(function(){
							secondMenuli.removeAttr('selected').removeClass('z-crt');
							});
					}									
                });
            });			
});

