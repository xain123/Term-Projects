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
	
		$a_Fname = mysqli_real_escape_string($connection ,strtolower(trim($_POST['author_Fname'])));
		$a_Lname = mysqli_real_escape_string($connection ,strtolower(trim($_POST['author_Lname'])));
		
		
	
		
		//validations
		
		//1
		$fields_required =array("author_Fname","author_Lname");
		foreach($fields_required as $field){
			$value = trim($_POST[$field]);
			if(!has_presence($value))
			{		
				$errors[$field] = ucfirst($field) . " can't be Blank";
			}		
		}
		
		
		$fields_with_max_lengths = array("author_Fname" => 10, "author_Lname" => 10);
		validate_max_lengths($fields_with_max_lengths);
		
		$query0="select author_id from author where author_first_name='$a_Fname' and author_last_name='$a_Lname'";
			$r1=mysqli_query($connection,$query0);
			$r2=mysqli_fetch_assoc($r1);
			
			if(empty($r2["author_id"]))
			{
				$errors["aid"]="Author Does Not Exist.";		
			}
			else
			{
		
					$query = "select a.isbn,b.book_id, a.book_name,concat(e.author_first_name, ' ', e.author_last_name) as author,a.book_edition, d.status_type
									from isbn a, book b, status d, author e
									where b.isbn = a.isbn
									and b.status_id = d.status_id
									and a.author_id = e.author_id
									and e.author_first_name = '$a_Fname'
									and e.author_last_name= '$a_Lname'";
									 
					
					$result = mysqli_query($connection, $query);
					
					$result112 = mysqli_query($connection, $query);
					$res112=mysqli_fetch_assoc($result112);
					
					if(empty($res112["book_id"]))
					{
						$errors["bid"]="No Record Found";
						
					}
			}
		
	}
	else
	{
		$a_Fname = "";
		$a_Lname = "";
	}
	
?>
<html>
<head>
	<title> Librarian </title>
	<link rel="stylesheet" type="text/css" href="adminstyle.css">
	<link rel="stylesheet" type="text/css" href="issue_book.css">
	<link rel="stylesheet" type="text/css" href="table.css">
</head>

<body>
<div class="main">

		<div id="banner">
			<img src="banner.jpg" width="100%" height="192"/>
		</div>



		<div id="sidelinks" >
			<ul>

					<div class="button"> <li>  <a class="active" class="ban" href="student.php"> Search Book </a></div>
				<hr align="left" width=80% size=1 color="black">
				
					<div class="button"> <li>  <a  class="ban" href="s_edit_name.php"> Edit Name </a></div>
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
				Search Book
				
			</h2>
			
			<div class="issue">
					<form action="s_search_author_name.php" method ="post">
			
						Author First Name:		<input   class="inputs"  type="text" name="author_Fname" value="" /> <br />
						Author Last Name:		<input   class="inputs"  type="text" name="author_Lname" value="" /> <br />
						
						<div class="space">
							<div class="button">
								<input type="submit" name="submit" value="Search" />
							</div>
						</div>
					</form>
				</div>
			<table>
					<tr>
						<th>ISBN</th>
						<th>Book Id</th>
						<th>Book name</th>
					    <th>Author name</th>
						<th>Edition</th>
						<th>Status</th>
					</tr>
					<?php
						global $result;
						if($result){
							while($display = mysqli_fetch_assoc($result))
							{
					?>
					<tr>
						<td><?php echo ucfirst($display['isbn']); ?> </td>
						<td><?php echo ucfirst($display['book_id']); ?></td>
						<td><?php echo ucfirst($display['book_name']); ?></td>
						<td><?php echo ucfirst($display['author']); ?></td>
						<td><?php echo ucfirst($display['book_edition']); ?></td>
						<td><?php echo ucfirst($display['status_type']); ?></td>
					</tr>
					<?php
							}
						}
						?>
			</table>	
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