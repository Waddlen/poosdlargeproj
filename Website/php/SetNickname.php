<?php
	$_POST = json_decode(file_get_contents('php://input'), true);
	$device_id = $_POST['device_id'];
	$nickname = $_POST['nickname'];

	$conn = new mysqli("poosdlarge.ckbkojoxq1y0.us-east-1.rds.amazonaws.com", "poosdadmin", "DontForgetThis321", "poosdlarge");
	if ($conn->connect_error)
	{
		returnWithError( $conn->connect_error );
	}
	else
	{
		$sql = "INSERT INTO usernames (device_id, nickname) VALUES ('" . $device_id . "','" . $nickname . "') ON DUPLICATE KEY UPDATE nickname='" . $device_id . "'";
		if( $result = $conn->query($sql) != TRUE )
		{
			returnWithError( $conn->error );
		}
		else
		{
			$new_nickname = $conn->insert_id;
			$conn->close();
			$message = '{"error":"", "dunno":"' . $new_nickname . '"}';
			sendResultInfoAsJson($message);
		}
	}
	function sendResultInfoAsJson( $obj )
	{
		header('Content-type: application/json');
		echo $obj;
	}
	function returnWithError( $err )
	{
		$retValue = '{"error":"' . $err . '"}';
		sendResultInfoAsJson( $retValue );
	}
?>
