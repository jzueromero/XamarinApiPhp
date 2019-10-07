<?php
include("connection.php");
	$db = new dbObj();
	$connection =  $db->getConnstring();
 
    $request_method=$_SERVER["REQUEST_METHOD"];

    switch($request_method)
	{
		case 'GET':
		// Retrive Pedidos
		if(!empty($_GET["id"]))
		{
			$id=intval($_GET["id"]);
			get_pedidosById($id);
		}
		else
		{
			get_pedidos();
		}
        break;
        case 'POST':
        // Insert Product
        insert_pedido();
		break;
		case 'PUT':
        // Insert Product
        Update_registro();
		break;
		case 'DELETE':
        // Insert Product
        Delete_registro($_GET["id"]);
        break;
		default:
		// Invalid Request Method
		header("HTTP/1.0 405 Method Not Allowed");
		break;
	}
  	
function get_pedidos()
	{
		global $connection;
		$query="SELECT * FROM usuarios";
		$response=array();
		$result=mysqli_query($connection, $query);
		while($row=mysqli_fetch_array($result))
		{
		$response[]=$row;
		}
		header('Content-Type: application/json');
		echo json_encode($response);
    }
 function get_pedidosById($id=0)
{
	global $connection;
	$query="SELECT * FROM usuarios";
	if($id != 0)
	{
		$query.=" WHERE id=".$id." LIMIT 1";
	}
	$response=array();
	$result=mysqli_query($connection, $query);
	while($row=mysqli_fetch_array($result))
	{
		$response[]=$row;
	}
	header('Content-Type: application/json');
	echo json_encode($response);
}

function insert_pedido()
	{
		global $connection;

		$data = json_decode(file_get_contents('php://input'), true);
		$id=$data["Id"];
		$usuarios=$data["Usuario"];
		$pass=$data["Password"];
		echo $query="INSERT INTO usuarios VALUES( null,'$usuarios'   
			,$pass)" ;
		 
		if(mysqli_query($connection, $query))
		{
			$response=array(
				'status' => 1,
				'status_message' =>'Pedido Agregado Satisfactoriamente.'
			);
		}
		else
		{
			$response=array(
				'status' => 0,
				'status_message' =>'Pedido No se puedo agregar.'
			);
		}
		header('Content-Type: application/json');
		echo json_encode($response);
	}



	function Update_registro()
	{
		global $connection;

		$data = json_decode(file_get_contents('php://input'), true);
		$id=$data["Id"];
		$usuarios=$data["Usuario"];
		$pass=$data["Password"];
		echo $query="UPDATE usuarios SET Usuario='$usuarios', Password = $pass WHERE Id = $id " ;
		 
		if(mysqli_query($connection, $query))
		{
			$response=array(
				'status' => 1,
				'status_message' =>'Pedido Agregado Satisfactoriamente.'
			);
		}
		else
		{
			$response=array(
				'status' => 0,
				'status_message' =>'Pedido No se puedo agregar.'
			);
		}
		header('Content-Type: application/json');
		echo json_encode($response);
	}


	function Delete_registro($id=0)
	{
		global $connection;
		$query="DELETE FROM USUARIOS ";
		if($id != 0)
		{
			$query.=" WHERE Id=".$id." LIMIT 1";
		}
		$response=array();
		$result=mysqli_query($connection, $query);
		while($row=mysqli_fetch_array($result))
		{
			$response[]=$row;
		}
		header('Content-Type: application/json');
		echo json_encode($response);
	}
	

?>