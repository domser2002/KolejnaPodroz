import 'package:bloc/bloc.dart';
import 'package:frontend/cubits/user_data_cubit/user_state.dart';

import 'package:http/http.dart' as http;
import 'dart:convert';


class UserCubit extends Cubit<UserState> {
  final String host;
  
  UserCubit({required this.host}) : super(UserInitial());

  Future<void> createUser(Map<String, dynamic> userData) async {
    emit(UserLoading());
    try {
      var url = Uri.parse('$host/User/create');
      var response = await http.post(
        url,
        body: jsonEncode(userData),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        emit(UserCreated(jsonDecode(response.body)));
      } else {
        emit(UserError('Failed to create user'));
      }
    } catch (e) {
      emit(UserError(e.toString()));
    }
  }

  Future<void> verifyUser(int userID) async {
    emit(UserLoading());
    try {
      var url = Uri.parse('$host/User/verify/$userID');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        emit(UserVerified());
      } else {
        emit(UserError('Failed to verify user'));
      }
    } catch (e) {
      emit(UserError(e.toString()));
    }
  }

  Future<void> authoriseUser(int userID) async {
    emit(UserLoading());
    try {
      var url = Uri.parse('$host/User/authorise/$userID');
      var response = await http.post(url);

      if (response.statusCode == 200) {
        emit(UserAuthorised());
      } else {
        emit(UserError('Failed to authorise user'));
      }
    } catch (e) {
      emit(UserError(e.toString()));
    }
  }

  Future<void> deleteUser(int userID) async {
    emit(UserLoading());
    try {
      var url = Uri.parse('$host/User/delete/$userID');
      var response = await http.delete(url);

      if (response.statusCode == 200) {
        emit(UserDeleted());
      } else {
        emit(UserError('Failed to delete user'));
      }
    } catch (e) {
      emit(UserError(e.toString()));
    }
  }
}
