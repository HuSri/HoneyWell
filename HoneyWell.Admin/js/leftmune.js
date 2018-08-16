// JavaScript Document
$(document).ready(function() {
	
	//如何读取第一个主菜单
		$(".total").children().eq(0).addClass("activebd");
		$(".total").children().eq(0).children().eq(0).children().eq(2).addClass("arrows");
		$(".total").children().eq(0).children().eq(0).addClass("colortxt");
		$(".total").children().eq(0).children().eq(1).show();
   	
	//主菜单的hover事件
	$(".mainmenu").hover(function() {
		 /*alert($(this).children().eq(0).text());*/
		 var zj=$(this).parent().hasClass("activebd") ;
		 //判断是否点中，点中就不加hover事件
		 if(zj==true){
			  $(this).removeClass("bbackg ")
			  $(this).children().eq(0).removeClass("borderl");
		}else{ 
			 $(this).addClass("bbackg")
			 $(this).children().eq(0).addClass("borderl");
		}
		}, function() {
			 $(this).removeClass("bbackg")
			 $(this).children().eq(0).removeClass("borderl");
	});
	
	//子菜单的hover事件
	$(".second").hover(function() {
		 /*alert($(this).children().eq(0).text());*/		 
			$(this).children().eq(0).attr("src","images/line2.png");
			$(this).children("a").addClass("colortxt");
		}, function() {
			 $(this).children().eq(0).attr("src","images/line1.png");
			 $(this).children("a").removeClass("colortxt");
		});
		
	//子菜单的hover事件
	$(".three li").hover(function() {
		 /*alert($(this).children().eq(0).text());*/
			$(this).children().eq(0).attr("src","images/line2.png");
			$(this).children("a").addClass("colortxt");
		}, function() {
			 $(this).children().eq(0).attr("src","images/line1.png");
			 $(this).children("a").removeClass("colortxt");
		});
		
	//子菜单菜单点击事件
	$('.second').click(function(){
		//判断二级菜单是否有子菜单
		 var zj=$(this).next().hasClass("three") ;
		if(zj==false){
				$(this).parent().each(function () {//移除其余非点中状态
					$('.second i').removeClass("arrows1 ");
					$('.second').children("a").removeClass("colortxt1");
					$('.three li i').removeClass("arrows1 ");
					
					
				});
				$(this).children("a").addClass("colortxt1");
				$(this).children().eq(2).addClass("arrows1");
				$(".mainmenu b").removeClass("arrows");	
				$('.three li a').removeClass("colortxt1 ");
				$(this).next().show();
			}
			
	});
	
	//三级菜单点击事件
	$('.three li').click(function(){
			$(this).parent().each(function () {//移除其余非点中状态
				$('.three li i').removeClass("arrows1 ");
				$('.three li').removeClass("colortxt");
				$('.three li').children("a").removeClass("colortxt1");
			});
		$(this).children("a").addClass("colortxt1");
		$(this).children().eq(2).addClass("arrows1");
		$(".second i").removeClass("arrows1");
		$(".mainmenu b").removeClass("arrows");	
		$(".second a").removeClass("colortxt1");	
	});
	
	//主菜单菜单点击事件
	$('.mainmenu').click(function() {
			
				$(this).parent().each(function () {//移除其余非点中状态
				//子菜单单点击事件
				$('.submenu li i').removeClass("arrows1 ");
				//箭头
				$('.mainmenu b').removeClass("arrows");
				//边框
				$('.overall').removeClass("activebd");
				//子菜单隐藏
				$(".submenu").hide();
				$(".three").hide();
				//字体设置
				$('.mainmenu').removeClass("colortxt");
				});
			$(this).children().eq(2).addClass("arrows");		
			$(this).parent().addClass("activebd");
			$(this).next().show();
			$(this).addClass("colortxt");
			$(".three").show();
	});
	
	
});