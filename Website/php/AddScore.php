<?php
	$_POST = json_decode(file_get_contents('php://input'), true);
	$device_id = $_POST['device_id'];
	$level_id = $_POST['level_id'];
	$time = $_POST['time'];
	$score = $_POST['score'];
	//$Contactid = $_POST['Contactid']; //This field is auto-incremented by DB
	$conn = new mysqli("poosdlarge.ckbkojoxq1y0.us-east-1.rds.amazonaws.com", "poosdadmin", "DontForgetThis321", "poosdlarge");
	if ($conn->connect_error)
	{
		returnWithError( $conn->connect_error );
	}
	else
	{
		$sql = "INSERT INTO leaderboard (score_id,device_id,level_id,score,time) VALUES ('0','" . $device_id . "','" . $level_id . "','" . $time . "','" . $score . "')";
		if( $result = $conn->query($sql) != TRUE )
		{
			returnWithError( $conn->error );
		}
		else
		{
			$new_score_id = $conn->insert_id;
			$conn->close();
			$message = '{"error":"", "Contactid":"' . $new_score_id . '"}';
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
