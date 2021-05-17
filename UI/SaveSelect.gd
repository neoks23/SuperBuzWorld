extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
# Called when the node enters the scene tree for the first time.

var x
var y
var z
var x2
var y2
var z2
var x3
var y3
var z3

var x4
var y4
var z4
var x5
var y5
var z5
var x6
var y6
var z6

func _ready():
	get_node("SaveFile1").grab_focus()
	
	var staticInteractor = load("res://UI/StaticInteractor.cs")
	var staticInteractorNode = staticInteractor.new()
	var email = staticInteractorNode.GetEmail()
	
	var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata")
	firestore_collection.get(email)
	var document : FirestoreDocument = yield(firestore_collection, "get_document")
	var score = document.doc_fields.get("score")
	var username = document.doc_fields.get("username")
	var pos = document.doc_fields.get("position")
	var ipos = document.doc_fields.get("insidePosition")
	var world = document.doc_fields.get("world")
	x = pos.get("X")
	y = pos.get("Y")
	z = pos.get("Z")
	x4 = ipos.get("X")
	y4 = ipos.get("Y")
	z4 = ipos.get("Z")
	
	var firestore_collection2 : FirestoreCollection = Firebase.Firestore.collection("userdata1")
	firestore_collection2.get(email)
	var document2 : FirestoreDocument = yield(firestore_collection2, "get_document")
	var score2 = document2.doc_fields.get("score")
	var username2 = document2.doc_fields.get("username")
	var pos2 = document2.doc_fields.get("position")
	var ipos2 = document2.doc_fields.get("insidePosition")
	var world2 = document2.doc_fields.get("world")
	x2 = pos2.get("X")
	y2 = pos2.get("Y")
	z2 = pos2.get("Z")
	x5 = ipos2.get("X")
	y5 = ipos2.get("Y")
	z5 = ipos2.get("Z")
	
	var firestore_collection3 : FirestoreCollection = Firebase.Firestore.collection("userdata2")
	firestore_collection3.get(email)
	var document3 : FirestoreDocument = yield(firestore_collection3, "get_document")
	var score3 = document3.doc_fields.get("score")
	var username3 = document3.doc_fields.get("username")
	var pos3 = document3.doc_fields.get("position")
	var ipos3 = document3.doc_fields.get("insidePosition")
	var world3 = document3.doc_fields.get("world")
	x3 = pos3.get("X")
	y3 = pos3.get("Y")
	z3 = pos3.get("Z")
	x6 = ipos3.get("X")
	y6 = ipos3.get("Y")
	z6 = ipos3.get("Z")
	
	if world == "OverWorld":
		$SaveFile1/lblStats.text = "username: " + username + "\nxyz:" + str(x) + "," + str(y) + "," + str(z) + "\n" + "score: " + str(score) + "\nworld: " + world
	elif world == "InsideWorld":
		$SaveFile1/lblStats.text = "username: " + username + "\nxyz:" + str(x4) + "," + str(y4) + "," + str(z4) + "\n" + "score: " + str(score) + "\nworld: " + world
	if world2 == "OverWorld":
		$SaveFile2/lblStats.text = "username: " + username2 + "\nxyz:" + str(x2) + "," + str(y2) + "," + str(z2) + "\n" + "score: " + str(score2) + "\nworld: " + world2
	elif world2 == "InsideWorld":
		$SaveFile2/lblStats.text = "username: " + username2 + "\nxyz:" + str(x5) + "," + str(y5) + "," + str(z5) + "\n" + "score: " + str(score2) + "\nworld: " + world2
	if world3 == "OverWorld":
		$SaveFile3/lblStats.text = "username: " + username3 + "\nxyz:" + str(x3) + "," + str(y3) + "," + str(z3) + "\n" + "score: " + str(score3) + "\nworld: " + world3
	elif world3 == "InsideWorld":
		$SaveFile3/lblStats.text = "username: " + username3 + "\nxyz:" + str(x6) + "," + str(y6) + "," + str(z6) + "\n" + "score: " + str(score3) + "\nworld: " + world3
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func _on_SaveFile1_button_up():
	var staticInteractor = load("res://UI/StaticInteractor.cs")
	var staticInteractorNode = staticInteractor.new()
	staticInteractorNode.SetPos(x,y,z)
	staticInteractorNode.SetInsidePos(x4,y4,z4)
	staticInteractorNode.SetSaveFile(0)
	var email = staticInteractorNode.GetEmail()
	var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata")
	firestore_collection.get(email)
	var document : FirestoreDocument = yield(firestore_collection, "get_document")
	var world = document.doc_fields.get("world")
	
	if world == "OverWorld":
		get_tree().change_scene("res://Worlds/World.tscn")
	elif world == "InsideWorld":
		get_tree().change_scene("res://Worlds/InsideBobWorld.tscn")
	pass # Replace with function body.


func _on_SaveFile2_button_up():
	var staticInteractor = load("res://UI/StaticInteractor.cs")
	var staticInteractorNode = staticInteractor.new()
	staticInteractorNode.SetPos(x2,y2,z2)
	staticInteractorNode.SetInsidePos(x5,y5,z5)
	staticInteractorNode.SetSaveFile(1)
	var email = staticInteractorNode.GetEmail()
	var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata1")
	firestore_collection.get(email)
	var document : FirestoreDocument = yield(firestore_collection, "get_document")
	var world = document.doc_fields.get("world")
	
	if world == "OverWorld":
		get_tree().change_scene("res://Worlds/World.tscn")
	elif world == "InsideWorld":
		get_tree().change_scene("res://Worlds/InsideBobWorld.tscn")
	pass # Replace with function body.


func _on_SaveFile3_button_up():
	var staticInteractor = load("res://UI/StaticInteractor.cs")
	var staticInteractorNode = staticInteractor.new()
	staticInteractorNode.SetPos(x3,y3,z3)
	staticInteractorNode.SetInsidePos(x6,y6,z6)
	staticInteractorNode.SetSaveFile(2)
	var email = staticInteractorNode.GetEmail()
	var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata2")
	firestore_collection.get(email)
	var document : FirestoreDocument = yield(firestore_collection, "get_document")
	var world = document.doc_fields.get("world")
	
	if world == "OverWorld":
		get_tree().change_scene("res://Worlds/World.tscn")
	elif world == "InsideWorld":
		get_tree().change_scene("res://Worlds/InsideBobWorld.tscn")
	pass # Replace with function body.

func _on_BackButton_button_up():
	get_tree().change_scene("res://UI/Titlescreen.tscn")
	pass # Replace with function body.


func _on_SaveFile1_focus_entered():
	$SaveFile1/Label.text = "<Save 1>"
	pass # Replace with function body.


func _on_SaveFile1_focus_exited():
	$SaveFile1/Label.text = "Save 1"
	pass # Replace with function body.


func _on_SaveFile1_mouse_entered():
	$SaveFile1/Label.text = "<Save 1>"
	pass # Replace with function body.


func _on_SaveFile1_mouse_exited():
	$SaveFile1/Label.text = "Save 1"
	pass # Replace with function body.


func _on_SaveFile2_focus_entered():
	$SaveFile2/Label.text = "<Save 2>"
	pass # Replace with function body.


func _on_SaveFile2_focus_exited():
	$SaveFile2/Label.text = "Save 2"
	pass # Replace with function body.


func _on_SaveFile2_mouse_entered():
	$SaveFile2/Label.text = "<Save 2>"
	pass # Replace with function body.


func _on_SaveFile2_mouse_exited():
	$SaveFile2/Label.text = "Save 2"
	pass # Replace with function body.


func _on_SaveFile3_focus_entered():
	$SaveFile3/Label.text = "<Save 3>"
	pass # Replace with function body.


func _on_SaveFile3_focus_exited():
	$SaveFile3/Label.text = "Save 3"
	pass # Replace with function body.


func _on_SaveFile3_mouse_entered():
	$SaveFile3/Label.text = "<Save 3>"
	pass # Replace with function body.


func _on_SaveFile3_mouse_exited():
	$SaveFile3/Label.text = "Save 3"
	pass # Replace with function body.
