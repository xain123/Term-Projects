<?php session_start();?>
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
				<div class="button"> <li>  <a  class="ban" href="issue_book.php"> Issue Books </a> </div>
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
				<marquee width='950'  behavior="alternate" vspace='6' style="color:white"> <?php echo $_SESSION['username'] ?></marquee>
			
			</div>
			<h2 style="text-shadow: 0 0 4px black; color:#4CAF50;  text-align:center; text-decoration:blink; font:18pt Impact; ">
				Register User
				
			</h2>
			
			  <a href="register_student.php" class="i_button">Register Student</a>
			  <a href="create_login.php" class="i_button">Create Login</a>
			  <a href="register_teacher.php" class="i_button">Register Teacher</a>
			
			
		</div>
</div>
</body>
</html>