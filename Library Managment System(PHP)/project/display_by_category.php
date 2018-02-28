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
		
		$category_name = mysqli_real_escape_string($connection ,strtolower(trim($_POST['category_name'])));
		
	
		
		//validations
		
		//1
		$fields_required =array( "category_name");
		foreach($fields_required as $field){
			$value = trim($_POST[$field]);
			if(!has_presence($value))
			{		
				$errors[$field] = ucfirst($field) . " can't be Blank";
			}		
		}
		
		
		$fields_with_max_lengths = array("category_name" => 50);
		validate_max_lengths($fields_with_max_lengths);
		
		
		
			$query = "select a.isbn, a.book_name, c.book_id, a.book_edition, d.status_type, 
						concat(e.author_first_name, ' ', e.author_last_name) as author, b.category_type
						from isbn a, category b, book c, status d, author e
						where a.category_id = b.category_id
						and c.isbn = a.isbn
						and c.status_id = d.status_id
						and a.author_id = e.author_id
						and b.category_type = '$category_name'";
		
		$result = mysqli_query($connection, $query);
		
		$result11 = mysqli_query($connection, $query);
		$test11 =mysqli_fetch_assoc($result11);
		
		if(empty($test11["category_type"]))
		{
			$errors["exist"]="No results found.";
		}
		
		
	}
	else
	{
		$category_name ="";
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
				<div class="button"> <li>  <a class="ban" href="register_user.php"> Register User </a></div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="ban" href="fine_list.php"> Fine List </a> </div>
				<hr align="left" width=80% size=1 color="black">
				<div class="button"> <li>  <a class="active" class="ban" href="display_book.php"> Display Book </a></div>
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
				Display Book
				
			</h2>
			
			<div class="issue">
					<form action="display_by_category.php" method ="post">
			
						Category Name:		<select   class="inputs"  type="text" name="category_name"  /> <br />
						<?php 
									
								$sql = "select category_type from category";
								$sql1=mysqli_query($connection,$sql);
								while ($disp = mysqli_fetch_assoc($sql1))
								{ 
									
									echo'<option value="'.$disp["category_type"].'">'.$disp["category_type"].'</option>';

								}
							

								
								?>
								
								</select>
	
						<div class="space">
							<div class="button">
								<input type="submit" name="submit" value="Display" />
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