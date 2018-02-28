<?php
	//form detection
	session_start();
	require_once("include_function.php");
	require_once("validation_functions.php");
	require_once("connection.php");
	$errors = array();
	$message ="";
	if(isset($_POST['submit']))
	{
		
		
		$isbn = mysqli_real_escape_string($connection ,strtolower(trim($_POST['book_isbn'])));
		$bname = mysqli_real_escape_string($connection ,strtolower(trim($_POST['book_name'])));
		//validations
		
		$fields_required =array( "book_isbn");
		foreach($fields_required as $field){
			$value = trim($_POST[$field]);
			if(!has_presence($value))
			{		
				$errors[$field] = ucfirst($field) . " can't be Blank";
			}		
		}
		
		
		$fields_with_max_lengths = array( "book_isbn" => 11);
		validate_max_lengths($fields_with_max_lengths);
		
			$query2="select isbn 
					from isbn
					where isbn=$isbn";
			$r4=mysqli_query($connection,$query2);
			$r5=mysqli_fetch_assoc($r4);
			
			if(empty($r5["isbn"]))
			{
				$errors["isbn"]="isbn does not exist";
			}
			else{
				$query1="UPDATE isbn SET book_name='$bname' WHERE isbn=$isbn";
				$r112=mysqli_query($connection,$query1);

				
				if($r112)
				{
				echo"<script>alert('Book has been Updated.')</script>";
				}
			}
			
			
		
	}
	else
	{			
		$isbn ="";
		$bname="";
	}
	
?>



<html>
<head>
	<title> Librarian </title>
	<link rel="stylesheet" type="text/css" href="adminstyle.css">
	<link rel="stylesheet" type="text/css" href="add_book.css">
</head>

<body>
<div class="main">

		<div id="banner">
			<img src="banner.jpg" width="100%" height="192"/>
		</div>



		<div id="sidelinks" >
			<ul>

				<div class="button"> <li>  <a  class="ban" href="admin.php" >  Home </a> </div>
				
				<hr align="left" width=80% size=1 color="black"> 
				
				<div class="button"> <li>  <a  class="ban" href="add_book.php" >  Add Books </a> </div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="issue_book.php"> Issue Books </a> </div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="return_book.php"> Return Book </a> </div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="delete_book.php"> Delete Book </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="search_book.php"> Search Book </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="register_user.php"> Register User </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="fine_list.php"> Fine List </a> </div>
				<hr align="left" width=80% size=1 color="black">
				
				<div class="button"> <li>  <a class="ban" href="display_book.php"> Display Book </a></div>
				<hr align="left" width=80% size=1 color="black">				
				<div class="button"> <li>  <a class="ban" href="add_category.php"> Add Category </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="show_category.php"> Show Category </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="active" class="ban" href="update_book.php" >  Update Books </a> </div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="change_admin_pin.php"> Change Pin </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="login.php"> Log Out </a></div>
				<hr align="left" width=80% size=1 color="black">
				
			</ul>
		</div>

			
		
		<div id="content">
			
			
		
				<div class="log">			
			<marquee width='950'  behavior="alternate" vspace='6' style="color:white"> <?php echo $_SESSION['username'] ?></marquee>
			
			</div>
			<h2 style="text-shadow: 0 0 4px black; color:#4CAF50;  text-align:center; text-decoration:blink; font:18pt Impact; ">
				 update Book  
				
			</h2>
			
			<div class="addbook">
				<form action="update_book.php" method ="post">
				
				ISBN: <input   class="inputs"  type="number" name="book_isbn" min="1" value="<?php echo htmlspecialchars($isbn); ?>" /> <br />
				Book Name:	<input   class="inputs"  type="text" name="book_name" value="<?php echo htmlspecialchars($bname); ?>" /> <br />		
	
	
				<div class="space">
					<div class="button">
						<input type="submit" name="submit" value="update book" />
					</div>
				</div>
				</form>	
			</div>
				
			<div class="error" >
			<?php
				echo form_errors($errors);
				?>
			</div>
			
		</div>
</div>




</body>
</html>
<?php
	//5. Close database connection
	mysqli_close($connection);

?>