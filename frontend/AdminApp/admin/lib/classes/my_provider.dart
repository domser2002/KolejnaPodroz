class MyProvider {
  String name;
  String info;
  String email;
  int id;

  MyProvider({
    required this.name,
    required this.info,
    required this.email,
    required this.id,
  });

  factory MyProvider.fromJson(dynamic json) {
    return MyProvider(
      name:
          json['name'] as String? ?? 'Unknown ID', // Provide a default if null
      info: json['additionalInfo'] as String? ?? "no info",
      email: json['email'] as String? ?? "no email",
      id: json[
          'id'], // This should always be provided, handle if potentially null
    );
  }

  @override
  String toString() {
    return 'Complaint{id: $id, name: $name, info: $info, email: $email}';
  }
}
