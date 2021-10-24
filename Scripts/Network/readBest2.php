<?php
$servername = "localhost";
$username = "mangowcy_Dante";
$password = "cvBkx),1N%_u";
$dbname = "mangowcy_Dante";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT nick, time FROM Unity_Classroom";

$result = mysqli_query($conn, $sql);

echo "dupa";

?>