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
		$sql = "INSERT INTO leaderboard (device_id,level_id,time,score) VALUES ('" . $device_id . "','" . $level_id . "','" . $time . "','" . $score . "') ON DUPLICATE KEY UPDATE time= IF(VALUES(time) < time,'" . $time . "',time)";
		if( $result = $conn->query($sql) != TRUE )
		{
			returnWithError( $conn->error );
		}
		else
		{

			if ($result->num_rows > 0)
			{
				$row2 = $result->fetch_assoc();
				$time = $row2["time"];
			}

			$new_score_id = $conn->insert_id;
			$conn->close();
			$message = '{"error":"", "time":"' . $time . '"}';
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
