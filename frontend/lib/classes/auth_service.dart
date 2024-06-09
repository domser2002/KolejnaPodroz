import 'package:firebase_auth/firebase_auth.dart';

abstract class AuthService {
  User? get currentUser;
  Stream<User?> get authStateChanges;
  
  Future<void> logInWithEmailAndPassword(String email, String password);
  Future<void> registerWithEmailAndPassword(String email, String password);
  Future<void> signOut();
}