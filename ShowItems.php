<?php
include('dblib.php');
session_start();

$con = db_connection();
$query = "select * from item";
$result = db_query($query,$con);
while($row = $result->fetch_assoc()){

	echo $row['id']. "|" . $row['code']."|". $row['name'] ."|".$row['buyPrice']."|".$row['sellPrice'] ."|".$row['count'] ."|".$row['unit'] ."|".$row['Date'] ."|".$row['User'] .";";

}




?>