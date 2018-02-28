<?php
	session_start();
	$username = $_SESSION['username'];
	//form detection
	require_once("include_function.php");
	require_once("validation_functions.php");
	require_once("connection.php");
	$errors = array();
	$message ="";
	if(isset($_POST['submit']))
	{
		
		$old_password = mysqli_real_escape_string($connection ,strtolower(trim($_POST['old_password'])));
		$new_password = mysqli_real_escape_string($connection ,strtolower(trim($_POST['new_password'])));
			
		//validations
		
		//1
		$fields_required =array( "old_password", "new_password");
		foreach($fields_required as $field){
			$value = trim($_POST[$field]);
			if(!has_presence($value))
			{		
				$errors[$field] = ucfirst($field) . " can't be Blank";
			}		
		}
		
		
		$fields_with_max_lengths = array("old_password" => 20, "new_password" => 20);
		validate_max_lengths($fields_with_max_lengths);
		
		if(Empty($errors))
		{
			
			
			$query ="select password
								from  student_pass
								where username = '$username';";
					$result = mysqli_query($connection, $query);
					$pass = mysqli_fetch_assoc($result);
					
					if($pass["password"] == $old_password)
					{
						$query2="update student_pass
								set password='$new_password'
								where username = '$username';";

						$result2 = mysqli_query($connection,$query2);
						
						if(mysqli_affected_rows($connection) == 1)
						{
							echo"<script>alert('Password has been Changed.')</script>";	
						}
						else 
						{
							$errors["incorrect"]="Old password is incorrect.";
							
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

				<div class="button"> <li>  <a  class="ban" href="student.php"> Search Book </a></div>
				<hr align="left" width=80% size=1 color="black">
					<div class="button"> <li>  <a  class="ban" href="s_edit_name.php"> Edit Name </a></div>
				<hr align="left" width=80% size=1 color="black">
				
				<div class="button"> <li>  <a  class="ban" href="s_fine_student.php"> Fine </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="active" class="ban" href="change_password.php"> Change Pin </a></div>
				<hr align="left" width=80% size=1 color="black">
				
				<div class="button"> <li>  <a class="ban" href="student_login.php"> Log Out </a></div>
				<hr align="left" width=80% size=1 color="black">
				
			</ul>
		</div>

			
		
		<div id="content">
			
			
		
				<div class="log">			
				<marquee width='950'  behavior="alternate" vspace='6' style="color:white"> <?php echo $_SESSION['username'] ?></marquee>
			
			</div>
			<h2 style="text-shadow: 0 0 4px black; color:#4CAF50;  text-align:center; text-decoration:blink; font:18pt Impact; ">
				Change Password
				
			</h2>
			
			<div class="issue">
					<form action="change_password.php" method ="post">
			
						Old Password:		<input   class="inputs"  type="text" name="old_password" value="" /> <br />
						New Password:		<input   class="inputs"  type="text" name="new_password" value="" /> <br />	
						<div class="space">
							<div class="button">
								<input type="submit" name="submit" value="Change" />
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