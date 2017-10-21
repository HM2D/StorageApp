<?php
include('dblib.php');
session_start();
$itemCode = $_POST["itemCode"];
$itemName = $_POST["itemName"];
$itemBuyPrice = $_POST["itemBuyPrice"];
$itemSellPrice = $_POST["itemSellPrice"];
$itemCount = $_POST["itemCount"];
$itemUnit = $_POST["itemUnit"];
$itemUser = $_POST["itemUser"];
$itemDate = $_POST["itemDate"];

$con = db_connection();
$query = "insert into item(code,name,buyPrice,sellPrice,count,unit,User,Date) values('".$itemCode."','".$itemName."','".$itemBuyPrice."','".$itemSellPrice."','".$itemCount."','".$itemUnit."','".$itemUser."','".$itemDate."');";
//$result = db_query($query,$con);

if ($con->query($query) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $query . "<br>" . $con->error;
}
echo $query;


?>