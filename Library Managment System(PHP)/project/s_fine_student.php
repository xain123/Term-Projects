<?php
session_start();
require_once("connection.php");
$username=$_SESSION['username'];

	$query="select * from issue_return 
								where student_id='$username'
								and fine <>0 ;";

				$result = mysqli_query($connection,$query);
				$result112 = mysqli_query($connection,$query);
				$test112 = mysqli_fetch_assoc($result112);
				
				if(empty($test112["book_id"])){		
				 $errors["exist"]="No record found.";
				}

?>
<html>
<head>
	<title> Librarian </title>
	<link rel="stylesheet" type="text/css" href="adminstyle.css">
	<link rel="stylesheet" type="text/css" href="issue_book.css">
	<link rel="stylesheet" type="text/css" href="category_table.css">
	
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
				
				<div class="button"> <li>  <a class="active" class="ban" href="s_fine_student.php"> Fine </a></div>
				<hr align="left" width=80% size=1 color="black">
				
				<div class="button"> <li>  <a class="ban" href="change_password.php"> Change Pin </a></div>
				<hr align="left" width=80% size=1 color="black">
				
				<div class="button"> <li>  <a class="ban" href="student_login.php"> Log Out </a></div>
				<hr align="left" width=80% size=1 color="black">
				
			</ul>
		</div>

			<?php
				$username=$_SESSION['username'];
				
			?>
		
		<div id="content">
			
			
		
				<div class="log">			
				<marquee width='950'  behavior="alternate" vspace='6' style="color:white"> <?php echo $username?></marquee>
			
			</div>
			<h2 style="text-shadow: 0 0 4px black; color:#4CAF50;  text-align:center; text-decoration:blink; font:18pt Impact; ">
				Fine
				
			</h2>
			
			<table align="center">
					<tr>
												
						<th>Book Id</th>
						<th>Fine Amount</th>
					</tr>
					<?php
						global  $result;
						if($result){
							while($fine = mysqli_fetch_assoc ($result))
							{			
					?>					
					</tr>
					<tr>
						
						<td><?php echo ucfirst($fine["book_id"])?></td>
						<td><?php echo ucfirst($fine["fine"])?></td>
					
					</tr>
				<?php
							}
						}
				?>	
 
			</table>		
					
		</div>
</div>
</body>
</html>
<?php
	//5. Close database connection
	mysqli_close($connection);

?>