
function show(a)
{
    if(a==1)
    {
    	document.getElementById("pass_form").style.display="none";
    	document.getElementById("contact_form").style.display="none";
    	document.getElementById("user_form").style.display="none";
    	document.getElementById("name_form").style.display="block";
    }
    
    else if(a==2)
    {
    	document.getElementById("pass_form").style.display="none";
    	document.getElementById("contact_form").style.display="none";
    	document.getElementById("name_form").style.display="none";
    	document.getElementById("user_form").style.display="block";
    }
    else if (a==3) 
    {
    	document.getElementById("pass_form").style.display="none";
    	document.getElementById("name_form").style.display="none";
    	document.getElementById("user_form").style.display="none";
    	document.getElementById("contact_form").style.display="block";
    }
    else if (a=4 ) 
    {
    	document.getElementById("name_form").style.display="none";
    	document.getElementById("user_form").style.display="none";
    	document.getElementById("contact_form").style.display="none";
    	document.getElementById("pass_form").style.display="block";
    }
}

 
    

