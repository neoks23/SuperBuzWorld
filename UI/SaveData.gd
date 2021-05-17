extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"



# Called when the node enters the scene tree for the first time.
func _save_data(pos, ipos, savefile, world):
	
	var staticInteractor = load("res://UI/StaticInteractor.cs")
	var staticInteractorNode = staticInteractor.new()
	var email = staticInteractorNode.GetEmail()
	
	var pos2 : Dictionary = {
		"X": pos.x,
		"Y": pos.y,
		"Z": 0,
	}
	var ipos2 : Dictionary = {
		"X": ipos.x,
		"Y": ipos.y,
		"Z": 0,
	}
	
	if world == "OverWorld":
		if savefile.x > 0:
			var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata")
			firestore_collection.get(email)
			var query : FirestoreDocument = yield(firestore_collection, "get_document")
			var up_task : FirestoreTask = firestore_collection.update(email, {'email': email, 'username': query.doc_fields.get("username"), 'score': 100, 'position': pos2, 'insidePosition': ipos2, 'world': world})
			var document : FirestoreDocument = yield(up_task, "task_finished")
		elif savefile.y > 0:
			var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata1")
			firestore_collection.get(email)
			var query : FirestoreDocument = yield(firestore_collection, "get_document")
			var up_task : FirestoreTask = firestore_collection.update(email, {'email': email, 'username': query.doc_fields.get("username"), 'score': 100, 'position': pos2, 'insidePosition': ipos2, 'world': world})
			var document : FirestoreDocument = yield(up_task, "task_finished")
		elif savefile.z > 0:
			var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata2")
			firestore_collection.get(email)
			var query : FirestoreDocument = yield(firestore_collection, "get_document")
			var up_task : FirestoreTask = firestore_collection.update(email, {'email': email, 'username': query.doc_fields.get("username"), 'score': 100, 'position': pos2, 'insidePosition': ipos2, 'world': world})
			var document : FirestoreDocument = yield(up_task, "task_finished")
	elif world == "InsideWorld":
		if savefile.x > 0:
			var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata")
			firestore_collection.get(email)
			var query : FirestoreDocument = yield(firestore_collection, "get_document")
			var up_task : FirestoreTask = firestore_collection.update(email, {'email': email, 'username': query.doc_fields.get("username"), 'score': 100, 'position': ipos2, 'insidePosition': pos2, 'world': world})
			var document : FirestoreDocument = yield(up_task, "task_finished")
		elif savefile.y > 0:
			var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata1")
			firestore_collection.get(email)
			var query : FirestoreDocument = yield(firestore_collection, "get_document")
			var up_task : FirestoreTask = firestore_collection.update(email, {'email': email, 'username': query.doc_fields.get("username"), 'score': 100, 'position': ipos2, 'insidePosition': pos2, 'world': world})
			var document : FirestoreDocument = yield(up_task, "task_finished")
		elif savefile.z > 0:
			var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata2")
			firestore_collection.get(email)
			var query : FirestoreDocument = yield(firestore_collection, "get_document")
			var up_task : FirestoreTask = firestore_collection.update(email, {'email': email, 'username': query.doc_fields.get("username"), 'score': 100, 'position': ipos2, 'insidePosition': pos2, 'world': world})
			var document : FirestoreDocument = yield(up_task, "task_finished")
		pass
	OS.alert("Data saved succesfully!", "Data saved")
	pass


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
