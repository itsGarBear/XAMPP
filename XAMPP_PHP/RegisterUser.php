<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitybackendtutorial";

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT username FROM users WHERE username = '" . $loginUser . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    //Tell user that that name is already taken
    echo "Username already taken";
} else {
    echo "Creating user...";
    //insert user and pass into DB
    $sql2 = "INSERT INTO users (username, password, level, coins) VALUES ('" . $loginUser . "', '" . $loginPass . "', '1', '0')";
    if($conn->query($sql2) === TRUE)
    {
        echo "New record created successfully"; 
    } else{
        echo "Error: " . $sql2 . "<br>" . $conn->error;
    }
}
$conn->close();
?>