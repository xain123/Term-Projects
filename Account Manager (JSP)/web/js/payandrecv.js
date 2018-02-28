
function creat_payable()
{
    var errors =["List of errors:\r\n"];
        
        
        var fname= document.getElementById("fname").value;
        var lname= document.getElementById("lname").value;
        var company = document.getElementById("comp").value;
        var contact = document.getElementById("pnum").value;
        var email= document.getElementById("email").value;  
        var cnic= document.getElementById("cnic").value;  
        var amount_payable= document.getElementById("pay").value;
        
        

        
        if (fname==null || fname=="")
        {  
             
             errors.push("First Name can't be blank\r\n"); 
            
        }
        if (company==null || company=="")
        {  
             
             errors.push("company name can't be blank\r\n"); 
            
        }
        if (contact==null || contact=="")
        {  
             
             errors.push("Contact can't be blank\r\n");  
             
        }
        if(cnic.length<13)
        {       
            errors.push("CNIC must be at least 13 characters long.\r\n");
               
              
        }   
        if(amount_payable==null || amount_payable=="")
        {   
            errors.push("Amount Payable can't be blank!\r\n");
              
            
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
            document.getElementById("comp").value=company;
            document.getElementById("pnum").value=contact;
            document.getElementById("email").value=email;  
            document.getElementById("cnic").value=cnic;  
            document.getElementById("pay").value=amount_payable;   
        return false;   
        } 
            else
        { 
            //alert("Account Created Successfully.")
            return true;   
        }
    
    
}


 
    

function creat_recevable()
{
        var errors =["List of errors:\r\n"];
        
        var fname= document.getElementById("fname").value;
        var lname= document.getElementById("lname").value;
        var address = document.getElementById("add").value;
        var contact = document.getElementById("pnum").value;
        var email= document.getElementById("email").value;  
        var cnic= document.getElementById("cnic").value;  
        var amount_recveable= document.getElementById("receivable").value;
        
        
        if (fname==null || fname=="")
        {  
             
             errors.push("First Name can't be blank\r\n"); 
            
        }
        if (address==null || address=="")
        {  
             
             errors.push("Address can't be blank\r\n"); 
            
        }
        if (contact==null || contact=="")
        {  
             
             errors.push("Contact can't be blank\r\n");  
             
        }
        if(cnic.length<13)
        {       
            errors.push("CNIC must be at least 13 characters long.\r\n");
                             
        }   
        if(amount_recveable==null || amount_recveable=="")
        {   
            errors.push("Amount Receivable can't be blank!\r\n");
                  
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
            document.getElementById("add").value=address;
            document.getElementById("pnum").value=contact;
            document.getElementById("email").value=email;  
            document.getElementById("cnic").value=cnic;  
            document.getElementById("receivable").value=amount_recveable;
           
            return false;
        } 
        else
        { 
            
            return true;   
        }

}