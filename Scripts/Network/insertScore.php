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

$sql = "INSERT INTO Unity_Classroom (nick, time)
VALUES ('".$_POST['nick']."', '".$_POST['time']."')";

mysqli_query($conn, $sql);

?>