function getArea(ee1,obj,obj1){
    $.ajax({
        type : "POST",
        url: "../inside/getCity.aspx",
        async : true,
        data : {"ee1" : ee1,"ee2":obj1},
        beforeSend : function(xmlHttpRequest){
        },
        success : function(data,textStatus){
                    
           if(ee1!="")
           {
               var temp=data.split('|');
               $("#"+obj).empty();
               $("#" + obj).append("<option selected=\"true\" value=\"\">==请选择==</option>");
               temp[0]=temp[0].replace("selected='true'","");
               $("#"+obj).append(temp[0]);
                
               
               if($("#hfCID").val()!="")
               {
                 $("#"+obj).val($("#hfCID").val());
               }
               if(obj=="ddlCity")
               {
                 $("#hfCID").val($("#"+obj).val());
               }
 
           }
           else
           {
              $("#"+obj).empty();
              $("#" + obj).append("<option selected=\"true\" value=\"\">==请选择==</option>");       
           }
             
        },
        complete : function(xmlHttpRequest, textStatus){
           
        },
        error : function(){
          
        }
    });
}

 