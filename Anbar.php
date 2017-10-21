<?php
include('dblib.php');
session_start();

$con = db_connection();
$query = "select * from user";
$result = db_query($query,$con);
while($row = $result->fetch_assoc()){

	echo $row['id']. "|" . $row['username']."|". $row['password'] ."|".$row['role'].";";

}




?>