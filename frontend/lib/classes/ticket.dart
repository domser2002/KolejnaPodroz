class Ticket {
  int id;
  int ownerID;
  int connectionID;
  bool purchased;

  Ticket({
    required this.id,
    required this.ownerID,
    required this.connectionID,
    required this.purchased,
  });

  factory Ticket.fromJson(Map<String, dynamic> json) {
    return Ticket(
      id: json['id'] as int? ?? 0, // Provide a default if null
      ownerID: json['ownerID'] as int? ?? 0, // Provide a default if null
      connectionID: json['connectionID'] as int? ?? 0, // Provide a default if null
      purchased: json['purchased'] as bool? ?? false, // Default to false if null
    );
  }

  @override
  String toString() {
    return 'Ticket{id: $id, ownerID: $ownerID, connectionID: $connectionID, purchased: $purchased}';
  }
}
