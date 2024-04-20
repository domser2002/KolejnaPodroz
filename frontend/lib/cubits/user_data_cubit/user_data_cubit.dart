import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/cubits/user_data_cubit/user_state.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';



class UserProfileCubit extends Cubit<UserProfileState> {
  UserProfileCubit() : super(UserProfileState());

  Future<void> getUserProfile() async {
    emit(UserProfileState(loading: true));
    try {
      var url = Uri.parse('https://localhost:7006/user/{id}}');
      var response = await http.get(url, headers: {
        //'Authorization': 'Bearer twoj_token_dostepu'
      });

      if (response.statusCode == 200) {
        var jsonResponse = jsonDecode(response.body);
        emit(UserProfileState(data: jsonResponse));
      } else {
        emit(UserProfileState(error: 'Nie udało się pobrać danych użytkownika'));
      }
    } catch (e) {
      emit(UserProfileState(error: e.toString()));
    }
  }
}
