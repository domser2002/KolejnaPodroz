class Complaint {
  int complainantID;
  String title;
  String ticketId;
  String response;
  String content;
  bool isResponded;

  Complaint({
    required this.ticketId,
    this.content = "",
    this.isResponded = false,
    this.title = "",
    this.response = "",
    required this.complainantID
  });

  factory Complaint.fromJson(dynamic json) {
    return Complaint(
      ticketId: json['ticketId'] as String? ?? 'Unknown Ticket ID', // Provide a default if null
      content: json['content'] as String? ?? '', // Provide default empty string if null
      isResponded: json['isResponded'] as bool? ?? false, // Default to false if null
      title: json['title'] as String? ?? '', // Default empty if null
      response: json['response'] as String? ?? '', // Default empty if null
      complainantID: json['complainantID'] as int, // This should always be provided, handle if potentially null
    );
  }

  @override
  String toString() {
    return 'Complaint{userId: $complainantID, title: $title, ticketId: $ticketId, response: $response, content: $content, isResponded: $isResponded}';
  }
}
