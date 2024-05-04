import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/cubits/achievements_cubit/achievements_state.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class AchievementsCubit extends Cubit<AchievementsState> {
  AchievementsCubit() : super(AchievementsState());

  Future<void> getUserAchievements() async {
    emit(AchievementsState(loading: true));
    try {
      var url = Uri.parse('https://localhost:7006/user/achievements');
      var response = await http.get(url, headers: {
        'Authorization': 'Bearer twoj_token_dostepu'
      });

      if (response.statusCode == 200) {
        var jsonResponse = jsonDecode(response.body);
        emit(AchievementsState(achievements: jsonResponse['achievements']));
      } else {
        emit(AchievementsState(error: 'Failed to load achievements'));
      }
    } catch (e) {
      emit(AchievementsState(error: e.toString()));
    }
  }
}
