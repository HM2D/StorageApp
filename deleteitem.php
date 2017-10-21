<?php
include('dblib.php');
session_start();

$con = db_connection();
$id = $_POST["ID"];
$query = "delete from item where id=".$id;
$result = db_query($query,$con);



?>