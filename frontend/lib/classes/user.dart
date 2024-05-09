class MyUser {
  final String userId;
  final String firstName;
  final String lastName;
  final String email;
  final DateTime birthDate;
  final int preferedSeatType;
  final int preferedSeatLocation;

  MyUser({
    required this.userId,
    required this.firstName,
    required this.lastName,
    required this.email,
    required this.birthDate,
    required this.preferedSeatType,
    required this.preferedSeatLocation,
  });

  // Metoda fromJson do parsowania danych JSON na obiekt User
  factory MyUser.fromJson(Map<String, dynamic> json) {
    return MyUser(
      userId: json['userID'],
      firstName: json['firstName'],
      lastName: json['lastName'],
      email: json['email'],
      birthDate: DateTime.parse(json['birthDate']),
      preferedSeatType: json['preferedSeatType'],
      preferedSeatLocation: json['preferedSeatLocation'],
    );
  }
}