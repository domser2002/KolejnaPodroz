import 'package:firebase_auth/firebase_auth.dart';
import 'package:frontend/classes/auth_service.dart';
import 'package:frontend/classes/http_service.dart';
import 'package:frontend/utils/http_requests.dart';

class FirebaseAuthService implements AuthService {
  final FirebaseAuth _auth = FirebaseAuth.instance;
  final HttpService _httpService;

  FirebaseAuthService(this._httpService);

  @override
  User? get currentUser => _auth.currentUser;
  
  @override
  Stream<User?> get authStateChanges => _auth.authStateChanges();

  @override
  Future<void> logInWithEmailAndPassword(String email, String password) async {
    UserCredential userCredential = await _auth.signInWithEmailAndPassword(email: email, password: password);
    await _httpService.authoriseUser(userCredential.user!.uid);  
  }

  @override
  Future<void> registerWithEmailAndPassword(String email, String password) async {
    UserCredential userCredential = await _auth.createUserWithEmailAndPassword(email: email, password: password);
    await _httpService.authoriseUser(userCredential.user!.uid);
  }

  @override
  Future<void> signOut() async {
    await _auth.signOut();
  }
}

