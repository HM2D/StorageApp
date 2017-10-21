<?php
include('dblib.php');
session_start();
$count = $_POST['count'];
$id = $_POST['ID'];
$con = db_connection();
$query = "UPDATE item
set count = '". $count."' where ID = ".$id.";";
$result = db_query($query,$con);





?>