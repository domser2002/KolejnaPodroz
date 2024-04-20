import 'package:bloc/bloc.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

part 'search_state.dart';

class SearchCubit extends Cubit<SearchState> {
  SearchCubit() : super(SearchInitial());

  Future<void> searchTrains(String departure, String destination, String date) async {
    if (departure.isEmpty || destination.isEmpty || date.isEmpty) {
      emit(SearchError("Wszystkie pola muszą być wypełnione."));
      return;
    }

    emit(SearchLoading());

    try {
      var response = await http.post(
        Uri.parse('localhost:7006/search'),
        headers: <String, String>{
          'Content-Type': 'application/json',
        },
        body: jsonEncode(<String, String>{
          'departure': departure,
          'destination': destination,
          'date': date,
        }),
      );

      if (response.statusCode == 200) {
        emit(SearchSuccess(json.decode(response.body)));
      } else {
        emit(SearchError("Błąd serwera: ${response.statusCode}"));
      }
    } catch (e) {
      emit(SearchError("Błąd połączenia: $e"));
    }
  }
}
