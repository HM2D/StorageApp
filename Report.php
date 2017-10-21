<?php
include('dblib.php');
session_start();
$itemCode = $_POST["itemCode"];
$itemNewCount = $_POST['newCount'];
$targetCode = $_POST['targetCode'];
$itemName = $_POST["itemName"];
$itemBuyPrice = $_POST["itemBuyPrice"];
$itemSellPrice = $_POST["itemSellPrice"];
$itemCount = $_POST["oldCount"];
$itemUnit = $_POST["itemUnit"];
$itemUser = $_POST["itemUser"];
$itemDate = $_POST["itemDate"];

$con = db_connection();
$query = "insert into report(itemCode,itemName,itembuyPrice,itemsellPrice,oldCount,itemUnit,user,date,newCount,targetCode) values('".$itemCode."','".$itemName."','".$itemBuyPrice."','".$itemSellPrice."','".$itemCount."','".$itemUnit."','".$itemUser."','".$itemDate."','".$itemNewCount."','".$targetCode."');";
//$result = db_query($query,$con);

if ($con->query($query) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $query . "<br>" . $con->error;
}
echo $query;


?>