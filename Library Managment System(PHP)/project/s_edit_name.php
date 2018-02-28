<?php
	session_start();
	$username = $_SESSION['username'];

	//form detection
	require_once("include_function.php");
	require_once("validation_functions.php");
	require_once("connection.php");
	$errors = array();
	
	if(isset($_POST['submit']))
	{
		
	
		$first_name = mysqli_real_escape_string($connection ,strtolower(trim($_POST['first_name'])));
		$Last_name = mysqli_real_escape_string($connection ,strtolower(trim($_POST['Last_name'])));
			
		//validations
		
		//1
		$fields_required =array( "first_name", "Last_name");
		foreach($fields_required as $field){
			$value = trim($_POST[$field]);
			if(!has_presence($value))
			{		
				$errors[$field] = ucfirst($field) . " can't be Blank";
			}		
		}
		
		
		$fields_with_max_lengths = array("first_name" => 30, "Last_name" => 30);
		validate_max_lengths($fields_with_max_lengths);
		
		
			
			
			$query ="update student
						set student_first_name ='$first_name', student_last_name ='$Last_name'						
						where student_id = '$username'";
			$result = mysqli_query($connection, $query);
			if($result)
			{
				echo"<script>alert('Name has been changed.')</script>";
			}
			else
			{
				$errors["exist"]="Name Cant be change.";
			}
		
	}
	else{
		$first_name="";
		$Last_name="";
		
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
				
				<div class="button"> <li>  <a class="active" class="ban" href="s_edit_name.php"> Edit Name </a></div>
				<hr align="left" width=80% size=1 color="black">
				
				<div class="button"> <li>  <a  class="ban" href="s_fine_student.php"> Fine </a></div>
				<hr align="left" width=80% size=1 color="black">
				
				<div class="button"> <li>  <a class="ban" href="change_password.php"> Change Pin </a></div>
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
				Change Name
				
			</h2>
			
			<div class="issue">
					<form action="s_edit_name.php" method ="post">
			
						
						New First Name:		<input   class="inputs"  type="text" name="first_name" value="<?php echo htmlspecialchars($first_name); ?>" /> <br />	
						New Last Name:		<input   class="inputs"  type="text" name="Last_name" value="<?php echo htmlspecialchars($Last_name); ?>" /> <br />	
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