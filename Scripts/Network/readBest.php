<?php
$servername = "localhost";
$username = "mangowcy_Dante";
$password = "cvBkx),1N%_u";
$dbname = "mangowcy_Dante";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT nick, time FROM Unity_Classroom ORDER BY time ASC LIMIT 5";

$result = mysqli_query($conn, $sql);

if($result->num_rows > 0){
$rows = array();
while($row = $result->fetch_assoc()){
$rows[]=$row;
}
echo json_encode($rows);
}else {
echo"0";
}

$conn->close();

?>