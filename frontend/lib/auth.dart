import 'package:firebase_auth/firebase_auth.dart';
import 'package:frontend/utils/http_requests.dart';
class Auth{

  final FirebaseAuth _auth = FirebaseAuth.instance;
  
  final HttpRequests request = HttpRequests();

  User? get currentUser => _auth.currentUser;
  
  Stream<User?> get authStateChanges => _auth.authStateChanges();

  Future<void> logInWithEmailAndPassword(String email, String password) async {
    UserCredential userCredential = await _auth.signInWithEmailAndPassword(email: email, password: password);
    await request.authoriseUser(userCredential.user!.uid);  
  }

  Future<void> registerWithEmailAndPassword(String email, String password) async {
        UserCredential userCredential = await _auth.createUserWithEmailAndPassword(email: email, password: password);
    // Assuming you have an authoriseUser method that takes a UID and handles backend authorization
    await request.authoriseUser(userCredential.user!.uid);
  }

  Future<void> signOut() async {
    await _auth.signOut();
  }
}