
	
//var attempt = 3;
//document.getElementById("login").onclick = function()
function signin_validate()
      {
        
        var username = document.getElementById("username").value;
        var password = document.getElementById("password").value;

        if (username==null || username=="")
        {  
 		 alert("Name can't be blank");  
  		return false;  
	}

	else if(password.length<6)
	{  
 		 alert("Password must be at least 6 characters long.");  
  		return false;  
  	} 
        else
        {
            return true;
        }
       
        
    }
     
	
	
		
		
	
	//document.getElementById("signup").onclick = function()
	function signup_validate() 
	{  
		var errors =["List of errors:\r\n"];
		
		
		var fname= document.getElementById("fname").value;
		var lname= document.getElementById("lname").value;
		var username = document.getElementById("user").value;
                var contact = document.getElementById("phone").value;
		var email= document.getElementById("email").value;  
		var password= document.getElementById("pwd").value;  
  		var cpassword= document.getElementById("cpwd").value;
  		var terms= document.getElementById("check").checked;
  		

		
		if (fname==null || fname=="")
		{  
 			 
 			 errors.push("First Name can't be blank\r\n"); 
  			
		}
                if (terms == false)
		{  
 			 
 			 errors.push("Please Accept The terms.\r\n"); 
  			
		}
		if (username==null || username=="")
		{  
 			 
 			 errors.push("Username can't be blank\r\n"); 
  			
		}
		if (contact==null || contact=="")
		{  
 			 
 			 errors.push("Contact can't be blank\r\n");  
  			 
		}
		if(password.length<6)
		{  		
			errors.push("Password must be at least 6 characters long.\r\n");
 			   
  			  
  		}   
		if(password != cpassword)
		{	
			errors.push("Please enter same password!\r\n");
			  
  			
		}	
		var atposition=email.indexOf("@");  
		var dotposition=email.lastIndexOf(".");  
		if (atposition<1 || dotposition<atposition+2 || dotposition+2>=email.length)
		{
			errors.push("Please enter a valid e-mail address\r\n");  
 			  
  		}
  			
  		if(errors.length > 1)
  		{
  			//('#MyModel').modal('show');
  			alert(errors);
  			document.getElementById("fname").value =fname ;
			document.getElementById("lname").value=lname;
			document.getElementById("user").value=username;
                        document.getElementById("phone").value=contact;
			document.getElementById("email").value=email;  
			document.getElementById("pwd").value=password;  
  			document.getElementById("cpwd").value=cpassword;   
 		return false;   
  		} 
                else
                {
                    return true;
                }
	}

    
  
		