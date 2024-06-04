class MyAdmin {
  final int id;
  final bool accepted;
  final bool verified;

  MyAdmin({required this.id, required this.accepted, required this.verified});

  // Metoda fromJson do parsowania danych JSON na obiekt Admin
  factory MyAdmin.fromJson(Map<String, dynamic> json) {
    return MyAdmin(
        id: json['id'], accepted: json['accepted'], verified: json['verified']);
  }
}
