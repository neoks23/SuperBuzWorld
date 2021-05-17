extends Control

var user_info = null

var pos : Dictionary = {
	"X": 0,
	"Y": 0,
	"Z": 0,
}
# Called when the node enters the scene tree for the first time.
func _ready():
	Firebase.Auth.connect("signup_succeeded", self, "_on_FirebaseAuth_signup_succeeded")
	pass # Replace with function body.

func _register(email, username, password):
	
	if(username.length() > 5):
		Firebase.Auth.signup_with_email_and_password(email, password)
	else:
		print("username length has to be bigger then 5")
		OS.alert("username length has to be bigger then 5", "username")
	pass
# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass

func _open_tokenizer():
	var path = ProjectSettings.globalize_path("res://")
	if path == "":
		# Exported, will return the folder where the executable is located.
		path = OS.get_executable_path().get_base_dir()
	else:
		# Editor, will return one level above the project folder
		path = path.get_base_dir().get_base_dir()
		
	var array = []
	var args = PoolStringArray(array)
	OS.execute(path + "\\SuperBuzWorldTokenizer\\SuperBuzWorldTokenizer.exe", args, true)
	pass
func _on_FirebaseAuth_signup_succeeded(auth_info):
	user_info = auth_info
	var register = load("res://UI/Register.cs")
	var registernode = register.new()
	registernode._on_SignUp_succeeded(user_info)
	
	var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("userdata")
	var add_task : FirestoreTask = firestore_collection.add(user_info.email, {'email': $Email.text, 'username': $Username.text, 'score': 0, 'position': pos, 'insidePosition': pos, 'world': "OverWorld"})
	yield(add_task, "task_finished")
	
	var firestore_collection3 : FirestoreCollection = Firebase.Firestore.collection("userdata1")
	var add_task3 : FirestoreTask = firestore_collection3.add(user_info.email, {'email': $Email.text, 'username': $Username.text, 'score': 0, 'position': pos, 'insidePosition': pos, 'world': "OverWorld"})
	yield(add_task3, "task_finished")
	
	var firestore_collection4 : FirestoreCollection = Firebase.Firestore.collection("userdata2")
	var add_task4 : FirestoreTask = firestore_collection4.add(user_info.email, {'email': $Email.text, 'username': $Username.text, 'score': 0, 'position': pos, 'insidePosition': pos, 'world': "OverWorld"})
	yield(add_task4, "task_finished")
	
	var firestore_collection2 : FirestoreCollection = Firebase.Firestore.collection("tokenizer")
	var add_task2 : FirestoreTask = firestore_collection2.add(user_info.email, {'Email': user_info.email, 'Token': null, 'Timestamp': null})
	yield(add_task2, "task_finished")
	
	var path = ProjectSettings.globalize_path("res://")
	if path == "":
		# Exported, will return the folder where the executable is located.
		path = OS.get_executable_path().get_base_dir()
	else:
		# Editor, will return one level above the project folder
		path = path.get_base_dir().get_base_dir()
		
	var array = []
	var args = PoolStringArray(array)
	print("signup succesful")
	OS.alert("signup succesful", "Registry")
	OS.execute(path + "\\SuperBuzWorldTokenizer\\SuperBuzWorldTokenizer.exe", args, true)
	
	
	pass
