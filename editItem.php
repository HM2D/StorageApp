<?php
include('dblib.php');
session_start();
$itemCode = $_POST["itemCode"];
$itemName = $_POST["itemName"];
$itemBuyPrice = $_POST["itemBuyPrice"];
$itemSellPrice =$_POST["itemSellPrice"];
$itemCount =$_POST["itemCount"];
$itemUnit =$_POST["itemUnit"];
$itemUser =$_POST["itemUser"];
$itemDate =$_POST["itemDate"];
$id = $_POST['ID'];

$con = db_connection();
$query = "UPDATE item
    SET code = '".$itemCode."',
        name = '".$itemName."',
        buyPrice = '".$itemBuyPrice."',
        sellPrice = '".$itemSellPrice."',
        count = '".$itemCount."',
        unit = '".$itemUnit."',
        User = '".$itemUser."',
        Date = '".$itemDate."' 
    WHERE id = ".$id.";";
//$result = db_query($query,$con);

if ($con->query($query) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $query . "<br>" . $con->error;
}
echo $query;


?>