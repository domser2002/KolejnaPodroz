class Stop {
  final int id;
  final DateTime arrivalTime;
  final DateTime departureTime;
  final int stationID;
  final int connectionID;

  Stop({
    required this.id,
    required this.arrivalTime,
    required this.departureTime,
    required this.stationID,
    required this.connectionID,
  });

  factory Stop.fromJson(Map<String, dynamic> json) {
    return Stop(
      id: json['id'],
      arrivalTime: DateTime.parse(json['arrivalTime']),
      departureTime: DateTime.parse(json['departureTime']),
      stationID: json['stationID'],
      connectionID: json['connectionID'],
    );
  }
}

class TrainOffer {
  final int id;
  final List<Stop> stops;
  final int providerID;

  TrainOffer({
    required this.id,
    required this.stops,
    required this.providerID,
  });

  factory TrainOffer.fromJson(Map<String, dynamic> json, List<String> stationNames) {
    return TrainOffer(
      id: json['id'],
      stops: (json['stops'] as List<dynamic>)
          .map((stop) => Stop.fromJson(stop))
          .toList(),
      providerID: json['providerID'],
    );
  }
}
