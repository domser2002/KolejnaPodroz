import 'dart:convert';
import 'package:http/http.dart' as http;

class TrainOffer {
  int offerID;
  List<String> stations;
  List<DateTime> arrival;
  List<DateTime> departure;
  List<dynamic> providers;

  TrainOffer(
      {required this.offerID,
      required this.stations,
      required this.arrival,
      required this.departure,
      required this.providers});

  factory TrainOffer.fromJson(Map<String, dynamic> json, List<String> stationNames) {
    return TrainOffer(
      offerID: json['id'] as int? ?? 0,
      stations: stationNames,
      arrival: (json['arrivalTimes'] as List<dynamic>? ?? [])
          .map((item) => DateTime.parse(item as String))
          .toList(),
      departure: (json['departureTimes'] as List<dynamic>? ?? [])
          .map((item) => DateTime.parse(item as String))
          .toList(),
      providers: json['providers'] as List<dynamic>? ?? [],
    );
  }

  @override
  String toString() {
    return 'TrainOffer:{id: $offerID, stations: $stations, arrival times: $arrival, departure times: $departure, providers: $providers }';
  }
}

List<TrainOffer> parseTrainOffers(List<dynamic> jsonList, List<List<String>> stations) {
  return jsonList.asMap().entries.map((entry) {
    int idx = entry.key;
    var json = entry.value;
    return TrainOffer.fromJson(json, stations[idx]);
  }).toList();
}


