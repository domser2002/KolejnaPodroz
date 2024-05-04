import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:frontend/cubits/ranking_cubit/ranking_state.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';


class RankingCubit extends Cubit<RankingState> {
  final String host;

  RankingCubit({required this.host}) : super(RankingState());

  // Function to fetch ranking by user ID
  Future<void> getRankingByUser(String userId) async {
    emit(RankingState(loading: true));
    try {
      var url = Uri.parse('$host/Ranking/byUser/$userId');
      var response = await http.get(url);

      if (response.statusCode == 200) {
        var ranking = jsonDecode(response.body);
        emit(RankingState(ranking: ranking));
      } else {
        emit(RankingState(error: 'Failed to load ranking'));
      }
    } catch (e) {
      emit(RankingState(error: e.toString()));
    } finally {
      emit(RankingState(loading: false));
    }
  }

  // Function to update ranking by user ID
  Future<void> updateRankingByUser(String userId, Map<String, dynamic> data) async {
    emit(RankingState(loading: true));
    try {
      var url = Uri.parse('$host/Ranking/update/byUser/$userId');
      var response = await http.put(
        url,
        body: jsonEncode(data),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        emit(RankingState());
      } else {
        emit(RankingState(error: 'Failed to update ranking'));
      }
    } catch (e) {
      emit(RankingState(error: e.toString()));
    } finally {
      emit(RankingState(loading: false));
    }
  }
}
