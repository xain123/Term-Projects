<?php
	//form detection
	require_once("include_function.php");
	require_once("validation_functions.php");
	require_once("connection.php");
	$errors = array();
	$message ="";
	if(isset($_POST['submit']))
	{
		
		$username = mysqli_real_escape_string($connection ,strtolower(trim($_POST['username'])));
		$password = mysqli_real_escape_string($connection ,strtolower(trim($_POST['password'])));
			
		//validations
		
		//1
		$fields_required =array( "username", "password");
		foreach($fields_required as $field){
			$value = trim($_POST[$field]);
			if(!has_presence($value))
			{		
				$errors[$field] = ucfirst($field) . " can't be Blank";
			}		
		}
		
		
		$fields_with_max_lengths = array("username" => 10, "password" => 20);
		validate_max_lengths($fields_with_max_lengths);
		
		if(Empty($errors))
		{
			
			
			$queryerror2="select student_id 
						from student 
						where student_id='$username'";
			$res3=mysqli_query($connection,$queryerror2);
			$res4 = mysqli_fetch_assoc($res3);
		
			if(empty($res4["student_id"]))
			{
				$errors["student"]="Register the Student first.";
			}
			else
			{
					$query="insert into student_pass(username ,password) 
										values ('$username', '$password')";

			$result = mysqli_query($connection,$query);
				if(!$result)
				{
					$errors["exist"]="Username Already exist.";
				}
				else
				{
					echo"<script>alert('Login has been created.')</script>";
				}
				
			}		
		}
	}
	else{
		$username = "";
		$password = "";
	}
		
?>
<html>
<head>
	<title> Librarian </title>
	<link rel="stylesheet" type="text/css" href="adminstyle.css">
	<link rel="stylesheet" type="text/css" href="issue_book.css">
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
				<div class="button"> <li>  <a  class="ban" href="return_book.php"> Return Book </a> </div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="delete_book.php"> Delete Book </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="search_book.php"> Search Book </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="active" class="ban" href="register_user.php"> Register User </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="fine_list.php"> Fine List </a> </div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="display_book.php"> Display Book </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="add_category.php"> Add Category </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="show_category.php"> Show Category </a></div>
				<hr align="left" width=80% size=1 color="black">
					<div class="button"> <li>  <a  class="ban" href="update_book.php" >  Update Books </a> </div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="change_admin_pin.php"> Change Pin </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="login.php"> Log Out </a></div>
				<hr align="left" width=80% size=1 color="black">
				
			</ul>
		</div>

			
		
		<div id="content">
			
			
		
				<div class="log">			
			
			
			</div>
			<h2 style="text-shadow: 0 0 4px black; color:#4CAF50;  text-align:center; text-decoration:blink; font:18pt Impact; ">
				Create Login
				
			</h2>
			
			<div class="issue">
					<form action="create_login.php" method ="post">
			
						User Name:		<input   class="inputs"  type="text" name="username" value="<?php echo htmlspecialchars($username); ?>" /> <br />
						Password:		<input   class="inputs"  type="password" name="password" value="" /> <br />	
						<div class="space">
							<div class="button">
								<input type="submit" name="submit" value="Create" />
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