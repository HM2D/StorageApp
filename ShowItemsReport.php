<?php
include('dblib.php');
session_start();

$con = db_connection();
$query = "select * from report";
$result = db_query($query,$con);
while($row = $result->fetch_assoc()){

	echo $row['ID']. "|" . $row['itemCode']."|". $row['itemName'] ."|".$row['itemBuyPrice']."|".$row['itemSellPrice'] ."|".$row['oldCount']."|".$row['newCount'] ."|".$row['itemUnit'] ."|".$row['date'] ."|".$row['user'] ."|".$row['targetCode'].";";

}


if ($con->query($query) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $query . "<br>" . $con->error;
}
echo $query;



?>