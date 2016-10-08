<?php
/**
 * ckip-test-driver.php
 *
 * PHP version 5
 *
 * @category PHP
 * @package  /
 * @author   Fukuball Lin <fukuball@gmail.com>
 * @license  No Licence
 * @version  Release: <1.0>
 * @link     http://fukuball@github.com
 */

require_once "./src/CKIPClient.php";

// change to yours
define("CKIP_SERVER", "");
define("CKIP_PORT", 0);
define("CKIP_USERNAME", "");
define("CKIP_PASSWORD", "");

$ckip_client_obj = new CKIPClient(
   CKIP_SERVER,
   CKIP_PORT,
   CKIP_USERNAME,
   CKIP_PASSWORD
);


if(!isset($_POST["raw_text"])){
	echo "{\"error\":\"true\",\"errorMsg\":\"raw_text not set.\"}";
	return;
}

$raw_text = $_POST["raw_text"];

if(!isset($_POST["type"])){
	echo "{\"error\":\"true\",\"errorMsg\":\"type not set.\"}";
	return;
}

$type = $_POST["type"];

$api_key = "asdfasdf";
if($_POST["api_key"] != $api_key){
	echo "{\"error\":\"true\",\"errorMsg\":\"API Key using failed.\"}";
	return;
}else{

	if($type == "text"){
		$return_text = $ckip_client_obj->send($raw_text);
		print_r($return_text);
	}

	if($type == "sentence"){
		$return_sentence = $ckip_client_obj->getSentence();
		print_r($return_sentence);
	}

	if($type == "term"){
		$return_term = $ckip_client_obj->getTerm();
		print_r($return_term);
	}

}

?>
