class MyUser {
  final int id;
  final String? firstName;
  final String? lastName;
  final String? email;
  final DateTime birthDate;
  final int preferedSeatType;
  final int preferedSeatLocation;
  int loyaltyPoints;
  
  MyUser({
    required this.id,
    required this.firstName,
    required this.lastName,
    required this.email,
    required this.birthDate,
    required this.preferedSeatType,
    required this.preferedSeatLocation,
    required this.loyaltyPoints
  });

  // Metoda fromJson do parsowania danych JSON na obiekt User
  factory MyUser.fromJson(Map<String, dynamic> json) {
    return MyUser(
      id: json['id'],
      firstName: json['firstName'],
      lastName: json['lastName'],
      email: json['email'],
      birthDate: json['birthDate'] != null ?
       DateTime.parse(json['birthDate']) : DateTime.now(), //backend zwraca null, więc jeśli jest null to zwracamy aktualną datę
      preferedSeatType: json['preferedSeatType'],
      preferedSeatLocation: json['preferedSeatLocation'],
      loyaltyPoints: json['loyaltyPoints']
    );
  }
}