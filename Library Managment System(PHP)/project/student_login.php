<?php
	session_start();
	//form detection
	require_once("connection.php");
	require_once("include_function.php");
	require_once("validation_functions.php");
	$errors = array();
	$message ="";
	if(isset($_POST['submit']))
	{
		$username = mysqli_real_escape_string($connection ,trim($_POST['username']));
		$password = mysqli_real_escape_string($connection ,trim($_POST['password']));
		
		//validations
		
		//1
		$fields_required =array("username", "password");
		foreach($fields_required as $field){
			$value = trim($_POST[$field]);
			if(!has_presence($value))
			{		
				$errors[$field] = ucfirst($field) . " can't be Blank";
			}		
		}
		
		
		$fields_with_max_lengths = array("username" => 10, "password" => 20);
		validate_max_lengths($fields_with_max_lengths);
		if(empty($errors)){
			
			//try to login part	
			// if($username == "admin" && $password == "abc123")
			// {
				// //sucessful login
				// redirect("admin.php");
			// }
			// else if($username == "student" && $password == "abc123")
			// {
				// redirect("student.php");
			// }
			// else
			// {
				// $message = "Username/Password Do not Match.";
			// }
			
			$query0 ="select username 
							from  student_pass
							where username = '$username';";
			$result0 = mysqli_query($connection, $query0);
			$user = mysqli_fetch_assoc($result0);
			if(empty($user["username"]))
			{
				$message = "Username does not exist.";
			}
			else
			{
						$query ="select password, username 
									from  student_pass
									where username = '$username';";
					$result = mysqli_query($connection, $query);
					$pass = mysqli_fetch_assoc($result);
					
					if($pass["password"] == $password && $pass["username"] == $username )
					{
						$_SESSION['username'] = $username;
						redirect("student.php");
						
					}
					else
					{
						$message = "Username/Password Do not Match.";
					}
			
			}
				
		}		
		
		
	}
	else
	{
				$username = "";

				
	}
?>


<html>
<head>
<title> LMS Login </title>
<link rel="stylesheet" type="text/css" href="loginstyle.css">
</head>
<body>

	<div class="main">
	<?php echo "Please Login!! "; ?>
	
	<form action="student_login.php" method ="post">
	
		Username:		<input  class="inputs"  type="text" name="username" value="<?php echo htmlspecialchars($username); ?>" /> <br />
		Password:		<input  class="inputs" type="password" name ="password" value="" /> <br />
	
	
	<div class="space">
	<div class="button">
	<input type="submit" name="submit" value="Login" />
	</div>
	</div>
	</form>
	
	
	<?php echo $message ?>
	
	<?php
			echo form_errors($errors);
	?>
	
	</div>	
	
	
</body>
</html>
<?php
	//5. Close database connection
	mysqli_close($connection);

?>