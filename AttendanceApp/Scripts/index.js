 $("#login-button").click(function(event){
		 event.preventDefault();
	 
	 $('form').fadeOut(500);
	 $('.wrapper').addClass('form-success');
 });

 $(document).ready(function () {
     $('#qrAndroid').qrcode({
         width: 200,
         height: 200,
         text: "DROID_URL_HERE"
     });

 });

