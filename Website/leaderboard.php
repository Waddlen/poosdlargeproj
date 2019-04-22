<!DOCTYPE html>
<html lang="en">
<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>Modern Business - Start Bootstrap Template</title>

  <!-- Bootstrap core CSS -->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

  <!-- Custom styles for this template -->
  <link href="css/modern-business.css" rel="stylesheet">

</head>

<body>

  <!-- Navigation -->
  <nav class="navbar fixed-top navbar-expand-lg navbar-dark bg-dark fixed-top">
    <div class="container">
      <a class="navbar-brand" href="index.html">Bit Blocked TITLE</a>
      <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav">
          <li class="nav-item">
            <a class="nav-link" href="about.html">About</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="leaderboard.html">Leaderboard</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="chat.html">Chat</a>
          </li>
        </ul>
      </div>
    </div>
  </nav>



  <!-- Page Content -->
  <div class="container">

    <!-- Page Heading/Breadcrumbs -->
    <h1 class="mt-4 mb-3">Global Leaderboard</h1>

    <table class="striped">
    <tr class="header">
        <td>device_id</td>
        <td>level_id</td>
        <td>time</td>
    </tr>
    <?php
      $conn = new mysqli("poosdlarge.ckbkojoxq1y0.us-east-1.rds.amazonaws.com", "poosdadmin", "DontForgetThis321", "poosdlarge");

      if ($conn->connect_error)
    	{
    		returnWithError( $conn->connect_error );
    	}
    	else
    	{
        $sql = "SELECT * FROM `leaderboard`";

        $result = $conn->query($sql);

        if ($result->num_rows > 0)
		    {
          while($row = $result->fetch_assoc())
			    {
            echo "<td>".$row[device_id]."</td>";
            echo "<td>".$row[level_id]."</td>";
            echo "<td>".$row[time]."</td>";
            echo "</tr>";
          }
        }
      }
    ?>
</table>


  </div>
  <!-- /.container -->

  <!-- Footer -->
  <footer class="py-5 bg-dark">
    <div class="container">
      <p class="m-0 text-center text-white">Copyright &copy; Your Website 2019</p>
    </div>
    <!-- /.container -->
  </footer>

  <!-- Bootstrap core JavaScript -->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

</body>

</html>
