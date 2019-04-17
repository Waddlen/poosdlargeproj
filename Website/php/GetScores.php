<?php
	$_POST = json_decode(file_get_contents('php://input'), true);
	$searchResults = "";
	$searchCount = 0;
	$search = $_POST['Search'];
    $error = "";

    //update these as appropriate?
    $localhost = "poosdlarge.ckbkojoxq1y0.us-east-1.rds.amazonaws.com";
    $my_user = "poosdadmin";
    $my_password = "DontForgetThis321";
	$my_db = "poosdlarge";

    $conn = new mysqli($localhost, $my_user, $my_password, $my_db);
	if ($conn->connect_error)
	{
		returnWithError( $conn->connect_error );
	}
	else
	{
		//$sql = "SELECT ContactName from Contact where ContactName like '%" . $search . "%'";
		$search = '%' . $search . '%';
		$sql = "SELECT * FROM leaderboard WHERE level_id=$search";
		$result = $conn->query($sql);
		if ($result->num_rows > 0)
		{
			while($row = $result->fetch_assoc())
			{
				if( $searchCount > 0 )
				{
					$searchResults .= ",";
				}
	
				//level_id device_id nickname time
				$searchCount++;
                $Device_ID = $row["device_id"];
                $sql2 = "SELECT * FROM usernames WHERE device_id=$Device_ID";
                $result2 = $conn->query($sql2);

                if ($result2->num_rows > 0) 
                {
                    $row2 = $result2->fetch_assoc();
                    $Nickname = $row2["nickname"];
                    $Time = $row["time"];
                    $searchResults .= '{"Nickname":"' . $Nickname . '","Time":"' . $Time . '","error":""}';
                    //$searchResults .= '"' . $row["Name"] . '"';
                }
                else
                {
                    returnWithError( "No Records Found (device_id)" );
                }
			}
			returnWithInfo( $searchResults );
		}
		else
		{
			returnWithError( "No Records Found (level_id)" );
			//$error = "No Records Found";
		}
		$conn->close();
	}
	
	function sendResultInfoAsJson( $obj )
	{
		header('Content-type: application/json');
		echo $obj;
	}
	function returnWithError( $err )
	{
		$retValue = '{"level_id":"' . $search . '","device_id":"' . $Device_ID . '","error":"' . $err . '"}';
		sendResultInfoAsJson( $retValue );
	}
	function returnWithInfo( $searchResults )
	{
		$retValue = '{"results":[' . $searchResults . '],"error":""}';
		sendResultInfoAsJson( $retValue );
	}
?>