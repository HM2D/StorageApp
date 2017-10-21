<?php
include('dblib.php');
session_start();
$username = $_POST["username"];
$password =$_POST["password"];
$role =  $_POST['role'];
$con = db_connection();
$query = "insert into user(username,password,role) values('".$username."','".$password."','".$role."')";
//$result = db_query($query,$con);

if ($con->query($query) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $query . "<br>" . $con->error;
}
echo $query;


?>