<?php session_start(); ?>

<html>
<head>
	<title> Student </title>
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
			
			  <a href="s_search_book_name.php" class="i_button">Book Name</a>
			  <a href="s_search_author_name.php" class="i_button">Author Name</a>
			  <a href="s_search_book_author_name.php" class="i_button">Book and Author Name</a>
			  <a href="s_search_book_id.php" class="i_button">Book Id</a>
			
			
		</div>
</div>
</body>
</html>