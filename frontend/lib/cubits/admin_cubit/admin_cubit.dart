import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/cubits/admin_cubit/admin_state.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';


class AdminCubit extends Cubit<AdminState> {
  final String host;

  AdminCubit({required this.host}) : super(AdminState());

  Future<void> createAdmin(Map<String, dynamic> adminData) async {
    emit(AdminState(loading: true));
    try {
      var url = Uri.parse('$host/Admin/create');
      var response = await http.post(
        url,
        body: jsonEncode(adminData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        var data = jsonDecode(response.body);
        emit(AdminState(adminData: data));
      } else {
        emit(AdminState(error: 'Failed to create admin'));
      }
    } catch (e) {
      emit(AdminState(error: e.toString()));
    } finally {
      emit(AdminState(loading: false));
    }
  }

  Future<void> verifyAdmin(String adminId) async {
    emit(AdminState(loading: true));
    try {
      var url = Uri.parse('$host/Admin/verify/$adminId');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        emit(AdminState());
      } else {
        emit(AdminState(error: 'Failed to verify admin'));
      }
    } catch (e) {
      emit(AdminState(error: e.toString()));
    } finally {
      emit(AdminState(loading: false));
    }
  }

  Future<void> authoriseAdmin(String adminId) async {
    emit(AdminState(loading: true));
    try {
      var url = Uri.parse('$host/Admin/authorise/$adminId');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        emit(AdminState());
      } else {
        emit(AdminState(error: 'Failed to authorise admin'));
      }
    } catch (e) {
      emit(AdminState(error: e.toString()));
    } finally {
      emit(AdminState(loading: false));
    }
  }

  Future<void> deleteAdmin(String adminId) async {
    emit(AdminState(loading: true));
    try {
      var url = Uri.parse('$host/Admin/delete/$adminId');
      var response = await http.delete(url);

      if (response.statusCode == 200) {
        emit(AdminState());
      } else {
        emit(AdminState(error: 'Failed to delete admin'));
      }
    } catch (e) {
      emit(AdminState(error: e.toString()));
    } finally {
      emit(AdminState(loading: false));
    }
  }
}
