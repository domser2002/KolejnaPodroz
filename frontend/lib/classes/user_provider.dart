import 'package:flutter/material.dart';
import 'package:frontend/classes/user.dart';

class UserProvider with ChangeNotifier {
  MyUser? _user;

  MyUser? get user => _user;

  void setUser(MyUser newUser) {
    _user = newUser;
    notifyListeners();
  }

  void clearUser() {
    _user = null;
    notifyListeners();
  }
}
