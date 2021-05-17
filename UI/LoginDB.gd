extends Control

var user_info = null
# Called when the node enters the scene tree for the first time.
func _ready():
	Firebase.Auth.connect("login_succeeded", self, "_on_FirebaseAuth_login_succeeded")
	Firebase.Auth.connect("login_failed", self, "_on_FirebaseAuth_login_failed")
	pass # Replace with function body.

func _login(email, token, password):
	var task = Firebase.Auth.login_with_email_and_password(email, password)
	
	var firestore_collection : FirestoreCollection = Firebase.Firestore.collection("tokenizer")
	firestore_collection.get(email)
	var document : FirestoreDocument = yield(firestore_collection, "get_document")
	var temptoken = document.doc_fields.get("Token")
	var timestamp = document.doc_fields.get("Timestamp")
	
	var path = ProjectSettings.globalize_path("res://")
	if path == "":
		# Exported, will return the folder where the executable is located.
		path = OS.get_executable_path().get_base_dir()
	else:
		# Editor, will return one level above the project folder
		path = path.get_base_dir().get_base_dir()
	
	if temptoken == null:
		OS.alert("Use the Super Buz World Tokenizer tool to generate a new token")
		Firebase.Auth.logout()
		print("Use the Super Buz World Tokenizer tool to generate a new token")
		var array = []
		var args = PoolStringArray(array)
		OS.execute(path + "\\SuperBuzWorldTokenizer\\SuperBuzWorldTokenizer.exe", args, true)
		pass
	elif token != str(temptoken):
		Firebase.Auth.logout()
		OS.alert("Logged out because token didnt match")
		print("Logged out because token didnt match")
		pass
	elif timestamp != null:
		var TimestampChecker = load("res://UI/TimestampChecker.cs")
		var TsC = TimestampChecker.new()
		if TsC.IsTimestampValid(timestamp):
			var firestore_collection2 : FirestoreCollection = Firebase.Firestore.collection("userdata")
			firestore_collection2.get(email)
			var document2 : FirestoreDocument = yield(firestore_collection2, "get_document")
			OS.alert("Login succeeded\n\n Hello " + document2.doc_fields.get("username") + "\n\n Welcome to this UI", "Welcome!")
			var login = load("res://UI/Login.cs")
			var loginnode = login.new()
			loginnode.SaveAccount(email)
			loginnode.ChangeScene()
			pass
		else:
			Firebase.Auth.logout()
			print("Token expired use the Super Buz World Tokenizer tool to generate a new token")
			OS.alert("Token expired \n\nUse the Super Buz World Tokenizer tool to generate a new token \n\nYou get 5 minutes to login before the token gets expired")
			var array = []
			var args = PoolStringArray(array)
			OS.execute(path + "\\SuperBuzWorldTokenizer\\SuperBuzWorldTokenizer.exe", args, true)
	pass

func _on_FirebaseAuth_login_succeeded(auth_info):
	user_info = auth_info
	var login = load("res://UI/Login.cs")
	var loginnode = login.new()
	loginnode._on_Login_succeeded(user_info)
	
	Firebase.Auth.save_auth(auth_info)
	
	pass

func _on_FirebaseAuth_login_failed(error_code, message):
	print("error code: " + str(error_code))
	print("message: " + str(message))
	pass

func _forgot_password(email):
	Firebase.Auth.send_password_reset_email(email)
	pass
