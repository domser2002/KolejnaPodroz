class Complaint {
  int userId;
  String title;
  String ticketId;
  String response;
  String content;
  bool isResponded;

  Complaint(
      {required this.ticketId, this.content = "", this.isResponded = false,
       this.title = "", this.response = "", this.userId = 1});
}
