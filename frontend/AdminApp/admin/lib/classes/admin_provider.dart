import 'package:flutter/material.dart';
import 'package:admin/classes/admin.dart';

class AdminProvider with ChangeNotifier {
  MyAdmin? _admin;

  MyAdmin? get admin => _admin;

  void setAdmin(MyAdmin newAdmin) {
    _admin = newAdmin;
    notifyListeners();
  }

  void clearAdmin() {
    _admin = null;
    notifyListeners();
  }
}
