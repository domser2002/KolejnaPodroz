class MyAdmin {
  final int id;
  final String? firstName;
  final String? lastName;
  final String? email;
  final DateTime birthDate;

  MyAdmin({
    required this.id,
    required this.firstName,
    required this.lastName,
    required this.email,
    required this.birthDate,
  });

  // Metoda fromJson do parsowania danych JSON na obiekt Admin
  factory MyAdmin.fromJson(Map<String, dynamic> json) {
    return MyAdmin(
      id: json['id'],
      firstName: json['firstName'],
      lastName: json['lastName'],
      email: json['email'],
      birthDate: json['birthDate'] != null
          ? DateTime.parse(json['birthDate'])
          : DateTime
              .now(), //backend zwraca null, więc jeśli jest null to zwracamy aktualną datę
    );
  }
}
