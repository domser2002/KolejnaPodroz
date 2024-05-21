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

  factory TrainOffer.fromJson(Map<String, dynamic> json) {
    return TrainOffer(
      offerID: json['id'] as int? ?? 0,
      stations: List<String>.from(json['stations'] ?? []),
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

List<TrainOffer> parseTrainOffers(List<dynamic> jsonList) {
  return jsonList.map((json) => TrainOffer.fromJson(json)).toList();
}
